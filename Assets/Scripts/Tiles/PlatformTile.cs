using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR

#endif

namespace Tiles
{
    public class PlatformTile : Tile
    {
        public Sprite[] m_Sprites;

        public Sprite m_Preview;

        public override void RefreshTile(Vector3Int location, ITilemap tilemap)
        {
            // for (int yd = -1; yd <= 1; yd++)
            for (int xd = -1; xd <= 1; xd++)
            {
                Vector3Int position = new Vector3Int(location.x + xd, location.y, location.z);
                if (HasPlatform(tilemap, position))
                    tilemap.RefreshTile(position);
            }
        }

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            int mask = HasPlatform(tilemap, location + new Vector3Int(-1, 0, 0)) ? 1 : 0;
            mask += HasPlatform(tilemap, location + new Vector3Int(1, 0, 0)) ? 2 : 0;
            int index = GetIndex((byte) mask);
            if (index >= 0 && index < m_Sprites.Length)
            {
                tileData.sprite = m_Sprites[index];
                tileData.color = Color.white;
                var m = tileData.transform;
                m.SetTRS(Vector3.zero, Quaternion.Euler(0.0f, 0.0f, 0.0f), Vector3.one);
                tileData.transform = m;
                tileData.flags = TileFlags.LockTransform;
                tileData.colliderType = ColliderType.Sprite;
            }
            else
            {
                Debug.LogWarning("Not enough sprites in PlatformTile instance");
            }
        }

        private bool HasPlatform(ITilemap tilemap, Vector3Int position)
        {
            return tilemap.GetTile(position) == this;
        }

        private int GetIndex(byte mask)
        {
            switch (mask)
            {
                case 0:
                    return 0;
                case 1:
                    return 3;
                case 2:
                    return 1;
                case 3:
                    return 2;
            }
            return -1;
        }
    
#if UNITY_EDITOR
        [MenuItem("Assets/Create/PlatformTile")]
        public static void CreatePlatformTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Platform Tile", "New Platform Tile", "Asset",
                "Save Platform Tile", "Assets");
            if (path == "") return;
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<PlatformTile>(), path);
        }
#endif
    }
}
