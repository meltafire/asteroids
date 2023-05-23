using System;

public interface IAsteroidToPlayfieldMessaging
{
    event Action<IAsteroidToPlayfieldMessaging> BulletCollisionReported;

    void Show();
    void ReturnToPool();
}
