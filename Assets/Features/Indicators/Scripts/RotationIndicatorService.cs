using UnityEngine;

public class RotationIndicatorService : PlayerIndicator
{
    private const string RotationText = "rot {0:0.0}";

    public RotationIndicatorService(UiIndicatorFacade uiIndicatorFacade, IPlayerToPlayfieldMessaging playerMessaging) : base(uiIndicatorFacade, playerMessaging)
    {
    }

    protected override void Subscribe()
    {
        _playerMessaging.ShowHappen += OnShowHappen;
        _playerMessaging.HideHappen += OnHideHappen;
        _playerMessaging.UpdateRotation += OnUpdateRotation;
    }

    protected override void Unsubscribe()
    {
        _playerMessaging.ShowHappen -= OnShowHappen;
        _playerMessaging.HideHappen -= OnHideHappen;
        _playerMessaging.UpdateRotation -= OnUpdateRotation;
    }

    private void OnShowHappen(Vector3 position, float rotation, float speed)
    {
        _messaging.Show(GenerateText(rotation));
    }

    private void OnHideHappen()
    {
        _messaging.Hide();
    }

    private void OnUpdateRotation(float rotation)
    {
        _messaging.UpdateText(GenerateText(rotation));
    }

    private string GenerateText(float rotation)
    {
        _builder.Clear();

        return _builder.AppendFormat(RotationText, rotation).ToString();
    }
}
