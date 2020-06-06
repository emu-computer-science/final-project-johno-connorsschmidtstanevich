using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [FormerlySerializedAs("PlayerColors")] [Header("Set in Inspector")]
    public Color[] playerColors = {new Color(192, 0, 0), new Color(0, 0, 192), new Color(0, 192, 0), Color.yellow};
    [FormerlySerializedAs("SpawnPoints")] public Vector2[] spawnPoints = {new Vector2(0, 0), new Vector2(16, 16), new Vector2(0, 32), new Vector2(0, 48)};

    private void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log($"Player {player.playerIndex + 1} has joined!");
        player.transform.position = spawnPoints[player.playerIndex];
        player.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color = playerColors[player.playerIndex];
        foreach (SpriteRenderer spriteRenderer in player.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.sortingOrder = -player.playerIndex;
        }
    }
}
