using System;
using System.Text;

public abstract class PlayerIndicator : IDisposable
{
    private readonly UiIndicatorFacade _uiIndicatorFacade;

    protected readonly IPlayerToPlayfieldMessaging _playerMessaging;
    protected readonly StringBuilder _builder;

    protected IUiIndicatorExternalMessaging _messaging;

    public PlayerIndicator(UiIndicatorFacade uiIndicatorFacade, IPlayerToPlayfieldMessaging playerMessaging)
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

        Subscribe();
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    protected abstract void Subscribe();
    protected abstract void Unsubscribe();
}
