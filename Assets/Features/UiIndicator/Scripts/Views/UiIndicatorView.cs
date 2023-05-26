using TMPro;
using UnityEngine;

public class UiIndicatorView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textMesh;

    private UiIndicatorPresenter _presenter;

    public void Initialize(UiIndicatorPresenter presenter)
    {
        _presenter = presenter;

        _presenter.OnViewCreated();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetText(string text)
    {
        _textMesh.text = text;
    }
}
