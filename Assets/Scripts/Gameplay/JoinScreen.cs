using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class JoinScreen : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void OnPlayerJoined(PlayerInput player)
        {
            _canvas.enabled = false;
        }
    }
}
