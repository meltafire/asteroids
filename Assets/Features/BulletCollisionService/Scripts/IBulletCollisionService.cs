using UnityEngine;

public interface IBulletCollisionService
{
    bool HandleCollision(Collider2D col);
}
