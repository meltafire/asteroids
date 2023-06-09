using UnityEngine;

public class StartScreenViewFactory
{
    private const string StartScreenAdress = "StartScreen/StartScreen";

    public OneButtonWindowView Create(RectTransform parrentTransform)
    {
        var gameObject = Resources.Load<GameObject>(StartScreenAdress);

        return GameObject.Instantiate(gameObject, parrentTransform).GetComponent<OneButtonWindowView>();
    }
}
