using UnityEngine;

public class GameOverViewFactory : AssetLoader
{
    private const string GameOverScreen = "GameOverScreen";

    public async Awaitable<(OneButtonWindowView, GameOverScoreView)> Create(RectTransform parrentTransform)
    {
        var go = await Load(GameOverScreen, parrentTransform);

        var windowView = go.GetComponent<OneButtonWindowView>();
        var scoreView = go.GetComponent<GameOverScoreView>();

        return (windowView, scoreView);
    }
}
