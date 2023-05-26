using UnityEngine;

public class LaserCountIndicator : PlayerIndicator
{
    private const string LaserText = "las_c {0}";

    private readonly ILaserServiceExternalMessaging _laserService;

    public LaserCountIndicator(
        ILaserServiceExternalMessaging laserService,
        UiIndicatorFacade uiIndicatorFacade,
        IPlayerToPlayfieldMessaging playerMessaging)
        : base(uiIndicatorFacade, playerMessaging)
    {
        _laserService = laserService;
    }

    protected override void Subscribe()
    {
        _playerMessaging.ShowHappen += OnShowHappen;
        _playerMessaging.HideHappen += OnHideHappen;
        _laserService.ShotCountChange += OnShotCountChange;
    }

    protected override void Unsubscribe()
    {
        _playerMessaging.ShowHappen -= OnShowHappen;
        _playerMessaging.HideHappen -= OnHideHappen;
        _laserService.ShotCountChange -= OnShotCountChange;
    }

    private void OnShowHappen(Vector3 position, float rotation, float speed)
    {
        var count = _laserService.RequestShotCount();

        _messaging.Show(GenerateText(count));
    }

    private void OnHideHappen()
    {
        _messaging.Hide();
    }

    private void OnShotCountChange(int count)
    {
        _messaging.Show(GenerateText(count));
    }

    private string GenerateText(int count)
    {
        _builder.Clear();

        return _builder.AppendFormat(LaserText, count).ToString();
    }
}
