﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bill_Door : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float killPlane;
    
    private IEnumerable<PlayerInput> _players => PlayerInput.all;
    private Spawner _spawner;

    private int PlayerNumber(Player player)
    {
        return player.GetComponent<PlayerInput>().playerIndex;
    }

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void FixedUpdate()
    {
        foreach (var player in _players)
        {
            if (player.inputIsActive && player.transform.position.y < killPlane) StartCoroutine(Respawn(player));
        }
    }

    IEnumerator Respawn(PlayerInput player)
    {
        player.DeactivateInput();
        foreach (var sprite in player.GetComponent<Player>().Sprites)
        {
            sprite.enabled = false;
        }
        Debug.Log($"Player {player.playerIndex + 1} has died!");
        yield return new WaitForSecondsRealtime(0);
        player.ActivateInput();
        player.gameObject.transform.position = _spawner.SpawnPoints[player.playerIndex];
        foreach (var sprite in player.GetComponent<Player>().Sprites)
        {
            sprite.enabled = true;
        }
    }
}
