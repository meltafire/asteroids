using System;
using UnityEngine;

public class SpeedIndicatorService : PlayerIndicator
{
    private const string SpeedText = "spd {0:0.0}";

    public SpeedIndicatorService(UiIndicatorFacade uiIndicatorFacade, IPlayerToPlayfieldMessaging playerMessaging) : base(uiIndicatorFacade, playerMessaging)
    {
    }

    protected override void Subscribe()
    {
        _playerMessaging.ShowHappen += OnShowHappen;
        _playerMessaging.HideHappen += OnHideHappen;
        _playerMessaging.UpdateSpeed += OnUpdateSpeed;
    }

    protected override void Unsubscribe()
    {
        _playerMessaging.ShowHappen -= OnShowHappen;
        _playerMessaging.HideHappen -= OnHideHappen;
        _playerMessaging.UpdateSpeed -= OnUpdateSpeed;
    }

    private void OnShowHappen(Vector3 position, float rotation, float speed)
    {
        _messaging.Show(GenerateText(speed));
    }

    private void OnHideHappen()
    {
        _messaging.Hide();
    }

    private void OnUpdateSpeed(float speed)
    {
        _messaging.UpdateText(GenerateText(speed));
    }

    private string GenerateText(float speed)
    {
        _builder.Clear();

        return _builder.AppendFormat(SpeedText, speed).ToString();
    }
}
