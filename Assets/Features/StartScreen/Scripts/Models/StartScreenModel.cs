public class StartScreenModel
{
    private readonly IStartScreenView _view;

    public StartScreenModel(IStartScreenView view)
    {
        _view = view;
    }

    public void Destroy()
    {
        _view.Destroy();
    }
}
