using System;

public class GameSessionAndPlayerMessaging : IGameSessionFromPlayerMessaging
{
    public event Action OnPlayerDeath;
}
