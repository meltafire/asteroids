using UnityEngine;

public class UfoModel
{
    private readonly UfoView _ufoView;

    public UfoModel(UfoView ufoView)
    {
        _ufoView = ufoView;
    }

    public void Show(Vector3 position)
    {
        _ufoView.Move(position);
        _ufoView.SetActive(true);
    }

    public void Hide()
    {
        _ufoView.SetActive(false);
    }

    public void Move(Vector3 playerPosition)
    {
        var position = Vector3.MoveTowards(_ufoView.Position, playerPosition, Time.deltaTime);

        _ufoView.Move(position);
    }
}
