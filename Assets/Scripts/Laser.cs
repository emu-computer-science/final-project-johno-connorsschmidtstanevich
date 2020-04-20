using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed = 100;
    public float timeLeft = 5;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.left * speed;
        StartCoroutine(LaserTimer(timeLeft));
    }

    IEnumerator LaserTimer(float s)
    {
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
    }

    // void Update()
    // {
    //     transform.position += -transform.right * Time.deltaTime * speed;
    //
    //     timeLeft -= Time.deltaTime;
    //     if(timeLeft <= 0)
    //         Destroy(gameObject);
    // }
    
    


}
