using UnityEngine;

public class PositionIndicatorService : PlayerIndicator
{
    private const string PositionText = "pos {0:0.0}:{1:0.0}";

    public PositionIndicatorService(UiIndicatorFacade uiIndicatorFacade, IPlayerToPlayfieldMessaging playerMessaging) : base(uiIndicatorFacade, playerMessaging)
    {
    }

    protected override void Subscribe()
    {
        _playerMessaging.ShowHappen += OnShowHappen;
        _playerMessaging.HideHappen += OnHideHappen;
        _playerMessaging.UpdatePosition += OnUpdatePosition;
    }

    protected override void Unsubscribe()
    {
        _playerMessaging.ShowHappen -= OnShowHappen;
        _playerMessaging.HideHappen -= OnHideHappen;
        _playerMessaging.UpdatePosition -= OnUpdatePosition;
    }

    private void OnShowHappen(Vector3 position, float rotation)
    {
        _messaging.Show(GenerateText(position));
    }

    private void OnHideHappen()
    {
        _messaging.Hide();
    }

    private void OnUpdatePosition(Vector3 position)
    {
        _messaging.UpdateText(GenerateText(position));
    }

    private string GenerateText(Vector3 position)
    {
        _builder.Clear();

        return _builder.AppendFormat(PositionText, position.x, position.y).ToString();
    }
}
