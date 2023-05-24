public class LaserViewModel
{
    private readonly LaserView _view;

    public LaserViewModel(LaserView view)
    {
        _view = view;
    }

    public void Show()
    {
        _view.Show();
    }

    public void Hide()
    {
        _view.Hide();
    }
}
