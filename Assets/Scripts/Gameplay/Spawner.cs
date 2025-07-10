using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Spawner : MonoBehaviour
    {
        [Header("Set in Inspector")]
        [FormerlySerializedAs("PlayerColors")]
        public Color[] playerColors = {new Color(192, 0, 0), new Color(0, 0, 192), new Color(0, 192, 0), Color.yellow};
        [FormerlySerializedAs("SpawnPoints")] public Vector2[] spawnPoints = {new Vector2(0, 0), new Vector2(0, 16), new Vector2(0, 32), new Vector2(0, 48)};

        private void Start()
        {
            int maxPlayerCount = GetComponent<PlayerInputManager>().maxPlayerCount;
            if (playerColors.Length != maxPlayerCount || spawnPoints.Length != maxPlayerCount)
                Debug.LogWarning($"ALERT: Player colors and spawn points do not match the max player count!");
        }

        private void OnPlayerJoined(PlayerInput player)
        {
            Debug.Log($"Player {player.playerIndex + 1} has joined!");
            player.transform.position = spawnPoints[player.playerIndex];
            player.gameObject.GetComponent<SpriteRenderer>().color = playerColors[player.playerIndex];
            player.GetComponent<SpriteRenderer>().sortingOrder = -player.playerIndex;
            // player.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color = playerColors[player.playerIndex];
            // foreach (SpriteRenderer spriteRenderer in player.GetComponentsInChildren<SpriteRenderer>())
            // {
            //     spriteRenderer.sortingOrder = -player.playerIndex;
            // }
        }
    }
}
