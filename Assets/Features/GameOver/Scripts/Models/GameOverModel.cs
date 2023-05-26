public class GameOverModel
{
    private const string ScoreText = "Score: {0}";

    private readonly GameOverScoreView _view;

    public GameOverModel(GameOverScoreView view)
    {
        _view = view;
    }

    public void SetScore(int score)
    {
        _view.SetText(string.Format(ScoreText, score));
    }
}
