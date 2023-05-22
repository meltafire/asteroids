using System;

public interface IAsteroidMessaging
{
    event Action ShowRequest;
    event Action HideRequest;
    event Action DestroyRequest;
}
