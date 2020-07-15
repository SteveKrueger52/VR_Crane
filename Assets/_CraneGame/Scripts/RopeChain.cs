using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeChain : MonoBehaviour
{
    public Rigidbody anchor;
    public SpringJoint[] links;
    public float minLinkLength;

    private float length;
    private float linkLength;
    private LineRenderer lr;

    private void Awake()
    {
        // Connect Links in sequence
        Rigidbody rb = anchor;
        foreach (SpringJoint link in links)
        {
            if (link.minDistance < minLinkLength || link.maxDistance < minLinkLength)
                link.maxDistance = link.minDistance = minLinkLength;
            length += link.minDistance;
            link.connectedBody = rb;
            rb = link.GetComponent<Rigidbody>();
        }

        UpdateLength(0);
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
    }

    private void Update()
    {
        Vector3[] drawPoints = new Vector3[links.Length + 1];
        drawPoints[0] = anchor.transform.position;
        for (int i = 0; i < links.Length; i++)
            drawPoints[i + 1] = links[i].transform.position;
        lr.SetPositions(drawPoints);
    }

    void FixedUpdate()
    {
        foreach (SpringJoint link in links)
        {
            link.minDistance = linkLength;
            link.maxDistance = linkLength;
        } 
    }

    public void UpdateLength(float delta)
    {
        length += delta;
        length = length < minLinkLength * links.Length ? minLinkLength * links.Length : length;
        linkLength = length / links.Length;
    }
}
