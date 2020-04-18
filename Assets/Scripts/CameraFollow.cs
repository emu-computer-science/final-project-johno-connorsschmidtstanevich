using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public float lead;

    // Start is called before the first frame update
    void Start()
    {
        lead = p1.transform.position.x;
        this.transform.position = new Vector3(lead, this.transform.position.y,-10);
    }

    // Update is called once per frame
    void Update()
    {
        if (p1.transform.position.x > lead)
            lead = p1.transform.position.x;
        else if (p2.transform.position.x > lead)
            lead = p2.transform.position.x;
        else if (p3.transform.position.x > lead)
            lead = p3.transform.position.x;
        else if (p4.transform.position.x > lead)
            lead = p4.transform.position.x;
        this.transform.position = new Vector3(lead, this.transform.position.y,-10);
    }
}
