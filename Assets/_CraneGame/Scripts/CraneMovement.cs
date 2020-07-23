using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CraneMovement : MonoBehaviour
{
    // private readonly float DEFAULT_FORCE = 1000;
    
    public HingeJoint slewPivot;
    public HingeJoint boomPivot;
    public ConfigurableJoint boomTelescope;
    public ConfigurableJoint chain;

    public Transform hookAnchor;
    private bool _powered;

    public bool powered
    {
        get { return _powered; }
        set
        {
            if (!value)
                StopInput();
            _powered = value;
        }
    }


    public float maxSlewVelocity;
    public float maxPitchVelocity;
    public float maxTelescopeVelocity;
    public float maxChainVelocity;
    public float minChainLength;

    private LineRenderer lr;
    
    private float slewVelocity;
    private JointMotor slewMotor;
    
    private float pitchVelocity;
    private bool usingPitchSpring = true;
    private JointMotor pitchMotor;
    private JointSpring pitchSpring;

    private float telescopeVelocity;
    private float telescopeTarget;

    private float chainLength;
    private float chainVelocity;
    private SoftJointLimit chainLimit;

    private void Awake()
    {
        // TODO Setup functions
        Debug.Log("Crane Awake");
        slewMotor = slewPivot.motor;
        
        pitchMotor = boomPivot.motor;
        pitchSpring = boomPivot.spring;
        
        telescopeTarget = (boomTelescope.connectedAnchor - boomTelescope.transform.localPosition).z;
        
        // Set limit to minimum
        chainLimit = chain.linearLimit;
        chainLimit.limit = minChainLength;
        chain.linearLimit = chainLimit;
        chainLength = chainLimit.limit;

        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
    }

    private void Update()
    {
            // Steering for Boom Telescope
            telescopeTarget += telescopeVelocity * Time.deltaTime;
            // Enforce Limits
            telescopeTarget = telescopeTarget > boomTelescope.linearLimit.limit
                ? boomTelescope.linearLimit.limit
                : telescopeTarget;
            telescopeTarget = telescopeTarget < -boomTelescope.linearLimit.limit
                ? -boomTelescope.linearLimit.limit
                : telescopeTarget;

            // Steering for Chain Extension
            chainLength += chainVelocity * Time.deltaTime;
            chainLength = chainLength < minChainLength ? minChainLength : chainLength;

            lr.SetPosition(0, hookAnchor.position);
            lr.SetPosition(1, chain.transform.position);
    }

    private void FixedUpdate()
    {
            // Slew Motor
            slewPivot.motor = slewMotor;
        
            // Pitch Motor - needs spring to stay upright
            boomPivot.spring = pitchSpring;
            boomPivot.motor = pitchMotor;
            boomPivot.useMotor = !usingPitchSpring;
            boomPivot.useSpring = usingPitchSpring;
        
            // Telescope Motor - Configurable Joints are WEIRD
            boomTelescope.targetPosition = new Vector3(0,0,telescopeTarget);
        
            // Extend Chain
            chainLimit.limit = chainLength;
            chain.linearLimit = chainLimit;
    }

    // Updates Driving Forces in Crane Joints with Active Input Changes
    public void OnInputChanged(int lever_id, float newValue)
    {
        if (powered)
        {
            switch (lever_id)
            {
                // Lever 1: Crane Slew
                case 0:
                    //Debug.Log("Rotating Crane Body");
                    slewMotor.targetVelocity = newValue * maxSlewVelocity;
                    break;
            
                // Lever 2: Boom Telescope
                case 1:
                    //Debug.Log("Telescoping Boom");
                    telescopeVelocity = newValue * maxTelescopeVelocity;
                    break;
            
                // Lever 3: Boom Pitch
                case 2:
                    //Debug.Log("Rotating Boom");
                    pitchMotor.targetVelocity = newValue * maxPitchVelocity;
                    usingPitchSpring = Mathf.Approximately(newValue, 0f);
                    if (usingPitchSpring)
                        pitchSpring.targetPosition = boomPivot.angle;
                    break;
            
                // Lever 4: Chain
                case 3:
                    //Debug.Log("Working Chain");
                    chainVelocity = newValue * maxChainVelocity;
                    break;
            }
        }
        else
            StopInput();
    }

    private void StopInput()
    {
        slewMotor.targetVelocity = 0;
        telescopeVelocity = 0f;
        pitchMotor.targetVelocity = 0f;
        usingPitchSpring = true;
        pitchSpring.targetPosition = boomPivot.angle;
        chainVelocity = 0f;
    }
}
