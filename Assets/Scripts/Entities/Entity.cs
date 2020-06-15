using System;
using UnityEngine;

namespace Entities
{
    public interface IEntity
    {
        void OnHit(Vector2 launchAngle);
    }
}