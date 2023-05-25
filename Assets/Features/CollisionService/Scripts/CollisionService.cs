using UnityEngine;

public class CollisionService : ICollisionService
{
    private const string AsteroidTag = "Asteroid";

    public bool HandleCollision(Collider2D col)
    {
        if(col.gameObject.tag == AsteroidTag)
        {
            var view = col.GetComponent<CollisionTriggerView>();

            view.HandleBulletCollision();

            return true;
        }

        return false;
    }
}
