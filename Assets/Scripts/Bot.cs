using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    //players must not have this player
    public GameObject[] players;

    // Update is called once per frame
    void Update()
    {
        //Only switch if no player on the same lane in front
        bool inFront = false;
        int closestPlayer;
        
        //Check if player is in front
        for(int i = 0; i < players.Length; i++)
        {
            float x = players[i].transform.position.x;
            float y = players[i].transform.position.y;

            if (x > this.transform.position.x && y == this.transform.position.y)
            {
                inFront = true;
                break;
            }
        }

        //Change lanes
        if(inFront == false)
        {
            //Find closest player by height
            
        }
    }
}
