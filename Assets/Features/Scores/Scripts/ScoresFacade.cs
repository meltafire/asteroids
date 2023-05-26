public class ScoresFacade
{
    private readonly ScoresModel _model;

    public int Score => _model.Score;

    public ScoresFacade()
    {
        _model = new ScoresModel();
    }

    public void Reset()
    {
        _model.Reset();
    }

    public void RegisterAsteroid()
    {
        _model.RegisterAsteroid();
    }

    public void RegisterAsteroidSmall()
    {
        _model.RegisterAsteroidSmall();
    }

    public void RegisterUfo()
    {
        _model.RegisterUfo();
    }
}
