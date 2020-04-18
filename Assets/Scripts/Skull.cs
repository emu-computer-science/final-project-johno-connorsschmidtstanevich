using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public float timeLeft = 3;
    public float buffer = .5f;
    private float time;
    public GameObject blast;
    public GameObject blastSpawn;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        time = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            animator.SetBool("SkullAttack", false);
            Instantiate(blast, blastSpawn.transform.position, Quaternion.identity);
            timeLeft = time;
        }
        else if (timeLeft > 0 && timeLeft < buffer)
        {
            animator.SetBool("SkullAttack", true);
        }
    }
}
