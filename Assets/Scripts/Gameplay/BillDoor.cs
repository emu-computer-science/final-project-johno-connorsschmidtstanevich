using System.Collections;
using System.Collections.Generic;
using Entities.Wolf;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class BillDoor : MonoBehaviour
    {
        [Header("Set in Inspector")]
        public float killPlane;
    
        private static IEnumerable<PlayerInput> Players => PlayerInput.all;
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
            foreach (var player in Players)
            {
                if (player.inputIsActive && player.transform.position.y < killPlane) StartCoroutine(Respawn(player));
            }
        }

        private IEnumerator Respawn(PlayerInput player)
        {
            player.DeactivateInput();
            Rigidbody2D playerRigidBody2D = player.GetComponent<Rigidbody2D>();
            playerRigidBody2D.simulated = false;
            SpriteRenderer playerSprite = player.GetComponent<Player>().GetComponent<SpriteRenderer>();
            playerSprite.enabled = false;
            Debug.Log($"Player {player.playerIndex + 1} has died!");
            yield return new WaitForSecondsRealtime(3);
            player.ActivateInput();
            player.gameObject.transform.position = _spawner.spawnPoints[player.playerIndex];  // Moves the player back to their spawn point
            player.GetComponent<SpriteRenderer>().enabled = true;
            playerRigidBody2D.velocity = Vector2.zero;
            playerRigidBody2D.simulated = true;
        }
    }
}
