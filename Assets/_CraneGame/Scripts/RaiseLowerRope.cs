using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseLowerRope : MonoBehaviour
{
    public GameObject RopeLever;
    public GameObject Rope;
    public GameObject AttachPoint;

    private Vector3 startPosTop;
    private Vector3 startPosEnd;

    private float ropeMinLengthY = 13.4f;
    private float ropeMaxLengthY = 2.05f;

    private Vector3 cablePosChange;
  


    void Start()
    {
        var LineRenderer = Rope.GetComponent<LineRenderer>();

        startPosTop = new Vector3(0f, 13.4f, -11.9f); //connection point of rope, should never change
        startPosEnd = new Vector3(0f, 2.05f, -11.9f); //bottom of rope, should change

        LineRenderer.SetPosition(0, startPosTop);
        LineRenderer.SetPosition(1, startPosEnd);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeverMove(float pushed)
    {
        if (pushed == ropeMinLengthY)
            return;
        if (pushed == ropeMaxLengthY)
            return;

        var LineRenderer = Rope.GetComponent<LineRenderer>();

        cablePosChange = new Vector3(LineRenderer.GetPosition(1).x, LineRenderer.GetPosition(1).y + pushed, LineRenderer.GetPosition(1).z);


        LineRenderer.SetPosition(1, cablePosChange);

        AttachPoint.transform.position = LineRenderer.GetPosition(1);

        
        //when value is positive, add slowly to length of rope until it reaches max length of 2.05f
        //when value is negative, reduce slowly until reaches minimum length or player stops pressing lever

    }

   
}
