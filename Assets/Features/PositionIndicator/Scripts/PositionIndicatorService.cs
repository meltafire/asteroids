using System;
using System.Text;
using UnityEngine;

public class PositionIndicatorService : IDisposable
{
    private const string PositionText = "pos {0:0.0}:{1:0.0}";

    private readonly UiIndicatorFacade _uiIndicatorFacade;
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;
    private readonly StringBuilder _builder;

    private IUiIndicatorExternalMessaging _messaging;

    public PositionIndicatorService(UiIndicatorFacade uiIndicatorFacade, IPlayerToPlayfieldMessaging playerMessaging)
    {
        _uiIndicatorFacade = uiIndicatorFacade;
        _playerMessaging = playerMessaging;

        _builder = new StringBuilder();
    }

    public void CreateIndicator()
    {
        if (_messaging == null)
        {
            _messaging = _uiIndicatorFacade.CreateView();
        }

        _playerMessaging.ShowHappen += OnShowHappen;
        _playerMessaging.HideHappen += OnHideHappen;
        _playerMessaging.UpdatePosition += OnUpdatePosition;
    }

    public void Dispose()
    {
        _playerMessaging.ShowHappen -= OnShowHappen;
        _playerMessaging.HideHappen -= OnHideHappen;
        _playerMessaging.UpdatePosition -= OnUpdatePosition;
    }

    private void OnShowHappen(Vector3 position)
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
