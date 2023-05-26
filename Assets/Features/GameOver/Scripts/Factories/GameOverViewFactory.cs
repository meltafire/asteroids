using UnityEngine;

public class GameOverViewFactory
{
    private const string StartScreenAdress = "GameOver/GameOverScreen";

    public void Create(RectTransform parrentTransform, out OneButtonWindowView windowView, out GameOverScoreView scoreView)
    {
        var gameObject = Resources.Load<GameObject>(StartScreenAdress);

        var instantiatedObject = GameObject.Instantiate(gameObject, parrentTransform);

        windowView = instantiatedObject.GetComponent<OneButtonWindowView>();
        scoreView = instantiatedObject.GetComponent<GameOverScoreView>();
    }
}
