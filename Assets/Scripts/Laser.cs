using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed = 100;
    public float timeLeft = 20;

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;

        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
            Destroy(this);
    }


}
