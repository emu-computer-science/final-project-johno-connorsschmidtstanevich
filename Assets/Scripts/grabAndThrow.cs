using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabAndThrow : MonoBehaviour
{

    [SerializeField] private float _power = 7.5f;
    private Rigidbody2D _pickedUpItem;
    private bool _facingRight = true;
    private bool _readyToThrow = false;


    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Pickup") == 1)
        {
            // pick up item
        }

        if (Input.GetAxisRaw("Throw") == 1 && _pickedUpItem)
        {
            ThrowItem(_pickedUpItem);
            _readyToThrow = true;
        }

        if (Input.GetAxisRaw("Throw") == 0 && _pickedUpItem)
        {
            _readyToThrow = false;
        }
    }

    private void ThrowItem(Rigidbody2D item)
    {
        if (!_readyToThrow)
        {
            item.AddRelativeForce(new Vector2(_power * (_facingRight ? -1 : 1), _power), ForceMode2D.Impulse);
        }
    }
}
