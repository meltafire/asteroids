using UnityEngine;

public class LaserTimeIndicator : PlayerIndicator
{
    private const string LaserText = "las_t {0: 0.00}";

    private readonly ILaserServiceExternalMessaging _laserService;

    public LaserTimeIndicator(
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
        _laserService.TimeChange += OnTimeChange;
    }

    protected override void Unsubscribe()
    {
        _playerMessaging.ShowHappen -= OnShowHappen;
        _playerMessaging.HideHappen -= OnHideHappen;
        _laserService.TimeChange -= OnTimeChange;
    }

    private void OnShowHappen(Vector3 position, float rotation, float speed)
    {
        var count = _laserService.RequestTime();

        _messaging.Show(GenerateText(count));
    }

    private void OnHideHappen()
    {
        _messaging.Hide();
    }

    private void OnTimeChange(float time)
    {
        _messaging.Show(GenerateText(time));
    }

    private string GenerateText(float time)
    {
        _builder.Clear();

        return _builder.AppendFormat(LaserText, time).ToString();
    }
}
