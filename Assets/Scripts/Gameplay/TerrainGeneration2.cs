using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay
{
    public class TerrainGeneration2 : MonoBehaviour
    {
        [Header("Set in Inspector")]
        public Tile platform;
        public Tile background;
        public Tile finishLine;
        public Tilemap Foreground;
        public Tilemap Background;
        public Tilemap FinishLine;
        public GameObject enemy;

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

        public bool enemyY1 = false;
        public bool enemyY2 = false;
        public bool enemyY3 = false;
        public bool enemyY4 = false;

        public int enemyCooldownY1 = 800;
        public int enemyCooldownY2 = 800;
        public int enemyCooldownY3 = 800;
        public int enemyCooldownY4 = 800;

        public GameObject Enemy;


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
                    holeCooldownY1 = 20;
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
            for (int x = 1000; x < 7500; x++)
            {
                if (!enemyY1)
                {
                    if (Random.value > .9999f)
                    {
                        Enemy = Instantiate<GameObject>(enemy);
                        Enemy.transform.position = new Vector3Int(x, 70, 0);
                        enemyY1 = true;
                    }
                
                }

                if (!enemyY2)
                {
                    if (Random.value > .9997f)
                    {
                        Enemy = Instantiate<GameObject>(enemy);
                        Enemy.transform.position = new Vector3Int(x, 200, 0);
                        enemyY2 = true;
                    }

                }

                if (!enemyY3)
                {
                    if (Random.value > .9994f)
                    {
                        Enemy = Instantiate<GameObject>(enemy);
                        Enemy.transform.position = new Vector3Int(x, 330, 0);
                        enemyY3 = true;
                    }

                }

                if (!enemyY4)
                {
                    if (Random.value > .9991f)
                    {
                        Enemy = Instantiate<GameObject>(enemy);
                        Enemy.transform.position = new Vector3Int(x, 450, 0);
                        enemyY4 = true;
                    }

                }

                if (enemyY1)
                {
                    enemyCooldownY1--;
                    if (enemyCooldownY1 <= 0)
                    {
                        enemyY1 = false;
                        enemyCooldownY1 = 500;
                    }


                }

                if (enemyY2)
                {
                    enemyCooldownY2--;
                    if (enemyCooldownY2 <= 0)
                    {
                        enemyY2 = false;
                        enemyCooldownY2 = 500;
                    }


                }

                if (enemyY3)
                {
                    enemyCooldownY3--;
                    if (enemyCooldownY3 <= 0)
                    {
                        enemyY3 = false;
                        enemyCooldownY3 = 500;
                    }


                }

                if (enemyY4)
                {
                    enemyCooldownY4--;
                    if (enemyCooldownY4 <= 0)
                    {
                        enemyY4 = false;
                        enemyCooldownY4 = 500;
                    }


                }
            }

            for (int i = 0; i < 32; i++)
            {
                FinishLine.SetTile(new Vector3Int(500, i, 0), finishLine);
            }
        }

    }
}
