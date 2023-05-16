using System;

public class PlayerMessaging : IPlayerMessaging, IPlayerToPlayfieldMessaging
{
    public event Action SpawnRequest;

    public void SpawnPlayer()
    {
        SpawnRequest?.Invoke();
    }
}
