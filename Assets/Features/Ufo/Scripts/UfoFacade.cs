public class UfoFacade
{
    private readonly UfoFactory _factory;
    private readonly IPlayerToPlayfieldMessaging _playerMessaging;

    public UfoFacade(IPlayerToPlayfieldMessaging playerMessaging)
    {
        _playerMessaging = playerMessaging;

        _factory = new UfoFactory();
    }

    public IUfoToPlayfieldMessaging Spawn()
    {
        var messaging = new UfoMessaging();

        var view = _factory.Create();
        var model = new UfoModel(view);
        var presenter = new UfoViewPresenter(_playerMessaging, model, messaging);

        view.Initialize(presenter);

        return messaging;
    }
}
