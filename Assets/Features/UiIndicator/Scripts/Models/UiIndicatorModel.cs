public class UiIndicatorModel
{
    private readonly UiIndicatorView _view;

    public UiIndicatorModel(UiIndicatorView view)
    {
        _view = view;
    }

    public void Show()
    {
        _view.SetActive(true);
    }

    public void Hide()
    {
        _view.SetActive(false);
    }

    public void SetText(string text)
    {
        _view.SetText(text);
    }
}
