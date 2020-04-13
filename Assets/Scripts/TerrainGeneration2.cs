using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TerrainGeneration2 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Tile platform;
    public Tile background;
    public Tile finishLine;
    public Tilemap Foreground;
    public Tilemap Background;
    public Tilemap FinishLine;

    [Header("Set Dynamically")]
    public bool holeY1 = false;
    public bool holeY2 = false;
    public bool holeY3 = false;
    public bool holeY4 = false;
    
    public int holeTrackerY1 = 0;
    public int holeTrackerY2 = 0;
    public int holeTrackerY3 = 0;
    public int holeTrackerY4 = 0;

    public int holeCooldownY1 = 10;
    public int holeCooldownY2 = 10;
    public int holeCooldownY3 = 10;
    public int holeCooldownY4 = 10;


    // Start is called before the first frame update
    void Start()
    {

        for(int x = 0; x < 49; x++)
        {
            Vector3Int p = new Vector3Int(x, 0, 0);
            Tile tile = platform;
            Foreground.SetTile(p, tile);

            p = new Vector3Int(x, 8, 0);
            Foreground.SetTile(p, tile);

            p = new Vector3Int(x, 16, 0);
            Foreground.SetTile(p, tile);

            p = new Vector3Int(x, 24, 0);
            Foreground.SetTile(p, tile);
        }

        for (int x = 49; x < 500; x++)
        {



            if (!holeY1)
            {
                Vector3Int p = new Vector3Int(x, 0, 0);
                Tile tile = platform;
                Foreground.SetTile(p, tile);
                holeCooldownY1--;

                if (holeCooldownY1 <= 0)
                {
                    holeY1 = (Random.value > .95f);
                }
                

            }
            if (!holeY2)
            {
                Vector3Int p = new Vector3Int(x, 8, 0);
                Tile tile = platform;
                Foreground.SetTile(p, tile);
                holeCooldownY2--;

                if (holeCooldownY2 <= 0)
                {
                    holeY2 = (Random.value > .95f);
                }


            }
            if (!holeY3)
            {
                Vector3Int p = new Vector3Int(x, 16, 0);
                Tile tile = platform;
                Foreground.SetTile(p, tile);
                holeCooldownY3--;

                if (holeCooldownY3 <= 0)
                {
                    holeY3 = (Random.value > .95f);
                }


            }
            if (!holeY4)
            {
                Vector3Int p = new Vector3Int(x, 24, 0);
                Tile tile = platform;
                Foreground.SetTile(p, tile);
                holeCooldownY4--;

                if (holeCooldownY4 <= 0)
                {
                    holeY4 = (Random.value > .95f);
                }


            }

            if (holeY1)
            {
                holeTrackerY1++;
                holeCooldownY1 = 10;
                if (holeTrackerY1 >= 10)
                {
                    holeY1 = false;
                    holeTrackerY1 = 0;
                }
                
            }

            if (holeY2)
            {
                holeTrackerY2++;
                holeCooldownY2 = 10;
                if (holeTrackerY2 >= 10)
                {
                    holeY2 = false;
                    holeTrackerY2 = 0;
                }

            }

            if (holeY3)
            {
                holeTrackerY3++;
                holeCooldownY3 = 10;
                if (holeTrackerY3 >= 10)
                {
                    holeY3 = false;
                    holeTrackerY3 = 0;
                }

            }

            if (holeY4)
            {
                holeTrackerY4++;
                holeCooldownY4 = 10;
                if (holeTrackerY4 >= 10)
                {
                    holeY4 = false;
                    holeTrackerY4 = 0;
                }

            }


        }

        for (int x = 0; x < 500; x++)
        {
            for (int y = 0; y < Random.Range(11, 15); y++ )
            {
                Vector3Int p = new Vector3Int(x, y, 0);
                Tile tile = background;
                Background.SetTile(p, tile);
            }
        }

        for (int i = 0; i < 32; i++)
        {
            FinishLine.SetTile(new Vector3Int(500, i, 0), finishLine);
        }
    }

}
