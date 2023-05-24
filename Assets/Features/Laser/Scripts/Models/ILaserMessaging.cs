using System;

public interface ILaserMessaging
{
    event Action ShowRequest;
    event Action HideRequest;
}
