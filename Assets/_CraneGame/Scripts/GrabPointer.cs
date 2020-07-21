using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GrabPointer : MonoBehaviour
{
    public Transform home;

    private LineRenderer lr;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!home)
            home = transform.parent;
        
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();

        if (rb != null)
            rb.isKinematic = true;
        
        lr.useWorldSpace = true;
        lr.SetPosition(0,home.position);
        lr.SetPosition(1,transform.position);
        
        Recenter();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0,home.position);
        lr.SetPosition(1,transform.position);
    }

    public void Recenter()
    {
        transform.parent = home;
        transform.localPosition = Vector3.zero;
    }
}
