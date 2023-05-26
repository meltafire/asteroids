public class ScoresModel
{
    private const int Asteroid = 1;
    private const int AsteroidSmall = 2;
    private const int Ufo = 3;

    private int _score;

    public int Score => _score;

    public void Reset()
    {
        _score = 0;
    }

    public void RegisterAsteroid()
    {
        _score += Asteroid;
    }

    public void RegisterAsteroidSmall()
    {
        _score += AsteroidSmall;
    }

    public void RegisterUfo()
    {
        _score += Ufo;
    }
}
