using System;

public interface IUiIndicatorMessaging
{
    event Action<string> Show;
    event Action Hide;
    event Action<string> UpdateText;
}
