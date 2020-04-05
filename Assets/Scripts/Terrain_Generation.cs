using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_Generation : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject[] terrainChunks;
    public GameObject finishLine;
    public int numberOfChunks = 10;


    [Header("Set Dynamically")]
    public GameObject terrainChunk;
    public int lastChunkIndex = 0;
    public int lastChunkPosition = 0;
    public int newChunkIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfChunks; i++)
        {
            if (i == 0)
            {
                terrainChunk = Instantiate<GameObject>(terrainChunks[0]);
                terrainChunk.transform.position = new Vector2(0,0);
                lastChunkIndex = 0;

            }
            else
            {
                switch(lastChunkIndex)
                {
                    case 0:
                        newChunkIndex = Random.Range(1, terrainChunks.Length);
                        terrainChunk = Instantiate<GameObject>(terrainChunks[newChunkIndex]);
                        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800,0);
                        lastChunkPosition += 800;
                        lastChunkIndex = newChunkIndex;
                        break;

                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        newChunkIndex = Random.Range(1, terrainChunks.Length);
                        terrainChunk = Instantiate<GameObject>(terrainChunks[newChunkIndex]);
                        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800, 0);
                        lastChunkPosition += 800;
                        lastChunkIndex = newChunkIndex;
                        break;

                    case 17:
                        newChunkIndex = Random.Range(1, terrainChunks.Length);
                        while (newChunkIndex == 1)
                        {
                            newChunkIndex = Random.Range(1, terrainChunks.Length);
                        }
                        terrainChunk = Instantiate<GameObject>(terrainChunks[newChunkIndex]);
                        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800, 0);
                        lastChunkPosition += 800;
                        lastChunkIndex = newChunkIndex;
                        break;

                    case 18:
                        newChunkIndex = Random.Range(1, terrainChunks.Length);
                        while (newChunkIndex == 2)
                        {
                            newChunkIndex = Random.Range(1, terrainChunks.Length);
                        }
                        terrainChunk = Instantiate<GameObject>(terrainChunks[newChunkIndex]);
                        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800, 0);
                        lastChunkPosition += 800;
                        lastChunkIndex = newChunkIndex;
                        break;

                    case 19:
                        newChunkIndex = Random.Range(1, terrainChunks.Length);
                        while (newChunkIndex == 3)
                        {
                            newChunkIndex = Random.Range(1, terrainChunks.Length);
                        }
                        terrainChunk = Instantiate<GameObject>(terrainChunks[newChunkIndex]);
                        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800, 0);
                        lastChunkPosition += 800;
                        lastChunkIndex = newChunkIndex;
                        break;

                    case 20:
                        newChunkIndex = Random.Range(1, terrainChunks.Length);
                        while (newChunkIndex == 4)
                        {
                            newChunkIndex = Random.Range(1, terrainChunks.Length);
                        }
                        terrainChunk = Instantiate<GameObject>(terrainChunks[newChunkIndex]);
                        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800, 0);
                        lastChunkPosition += 800;
                        lastChunkIndex = newChunkIndex;
                        break;

                }
            }
            
        }

        terrainChunk = Instantiate<GameObject>(finishLine);
        terrainChunk.transform.position = new Vector2(lastChunkPosition + 800, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
