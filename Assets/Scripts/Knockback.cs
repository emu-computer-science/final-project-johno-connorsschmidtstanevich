using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public int distance = 5;
    public string tagName = "racer";
    public int buttonValue = 0;
    public int force = 500;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(buttonValue) || Input.GetKeyUp(KeyCode.Space))
        {
            GameObject[] racers = GameObject.FindGameObjectsWithTag(tagName);
            for (int n = 0; n < racers.Length; n++)
            {
                float racerDistance = Vector2.Distance(racers[n].transform.position, transform.position);
                if (racerDistance < distance)
                {
                    print("within distance" + racerDistance);
                    Rigidbody2D rb = racers[n].GetComponent<Rigidbody2D>();
                    Vector2 backDirection = new Vector2(-1, -1);
                    rb.AddForce((backDirection * force));
                }
            }
        }
    }
}
