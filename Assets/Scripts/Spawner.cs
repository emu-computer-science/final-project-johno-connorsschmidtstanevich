using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public Color[] PlayerColors = {new Color(192, 0, 0), new Color(0, 0, 192), new Color(0, 192, 0), Color.yellow};
    public Vector2[] SpawnPoints = {new Vector2(0, 0), new Vector2(16, 16), new Vector2(0, 32), new Vector2(0, 48)};

    private void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log($"Player {player.playerIndex + 1} has joined!");
        player.transform.position = SpawnPoints[player.playerIndex];
        player.gameObject.GetComponentsInChildren<SpriteRenderer>()[2].color = PlayerColors[player.playerIndex];
    }
}
