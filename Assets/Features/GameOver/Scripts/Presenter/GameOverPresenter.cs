public class GameOverPresenter
{
    private readonly ScoresFacade _scoresFacade;
    private readonly GameOverModel _model;

    public GameOverPresenter(ScoresFacade scoresFacade, GameOverModel model)
    {
        _scoresFacade = scoresFacade;
        _model = model;
    }

    public void SetScore()
    {
        _model.SetScore(_scoresFacade.Score);
    }
}
