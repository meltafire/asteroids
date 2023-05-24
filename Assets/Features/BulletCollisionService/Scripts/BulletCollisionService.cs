using UnityEngine;

public class BulletCollisionService : IBulletCollisionService
{
    private const string AsteroidTag = "Asteroid";

    public bool HandleCollision(Collider2D col)
    {
        if(col.gameObject.tag == AsteroidTag)
        {
            var view = col.GetComponent<TriggerView>();

            view.HandleBulletCollision();

            return true;
        }

        return false;
    }
}
