public class OneButtonWindowModel
{
    private readonly OneButtonWindowView _view;

    public OneButtonWindowModel(OneButtonWindowView view)
    {
        _view = view;
    }

    public void Destroy()
    {
        _view.Destroy();
    }
}
