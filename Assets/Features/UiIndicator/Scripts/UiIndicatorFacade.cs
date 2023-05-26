using UnityEngine;

public class UiIndicatorFacade
{
    private readonly UiIndicatorFactory _factory;
    private readonly RectTransform _parentTransform;

    public UiIndicatorFacade(RectTransform parentTransform)
    {
        _factory = new UiIndicatorFactory();
        _parentTransform = parentTransform;
    }

    public IUiIndicatorExternalMessaging CreateView()
    {
        var messaging = new UiIndicatorMessaging();
        var view = _factory.Create(_parentTransform);
        var model = new UiIndicatorModel(view);
        var presenter = new UiIndicatorPresenter(model, messaging);

        view.Initialize(presenter);

        return messaging;
    }
}
