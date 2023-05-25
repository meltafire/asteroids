using UnityEngine;
using UnityEngine.UI;

public class OneButtonWindowView : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    private OneButtonWindowPresenter _presenter;

    public void Initialize(OneButtonWindowPresenter presenter)
    {
        _presenter = presenter;

        _button.onClick.AddListener(OnButtonClicked);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _presenter.OnButtonClicked();
    }
}
