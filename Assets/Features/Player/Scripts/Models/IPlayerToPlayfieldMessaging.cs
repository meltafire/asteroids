using System;

public interface IPlayerToPlayfieldMessaging
{
    event Action CollisionHappened;

    IPlayerShotSpawnDataProvider GetShotSpawnData();
    void Show();
    void Hide();
}
