using UnityEngine;

public class GameOverViewFactory
{
    private const string StartScreenAdress = "GameOver/GameOverScreen";

    public OneButtonWindowView Create(RectTransform parrentTransform)
    {
        var gameObject = Resources.Load<GameObject>(StartScreenAdress);

        return GameObject.Instantiate(gameObject, parrentTransform).GetComponent<OneButtonWindowView>();
    }
}
