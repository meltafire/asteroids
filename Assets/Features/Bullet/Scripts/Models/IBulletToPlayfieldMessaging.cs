using System;

public interface IBulletToPlayfieldMessaging
{
    event Action<IBulletToPlayfieldMessaging> OnCollision;

    void ReturnToPool();
}
