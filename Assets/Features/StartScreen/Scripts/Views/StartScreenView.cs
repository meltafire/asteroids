using System;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenView : MonoBehaviour, IStartScreenView
{
    [SerializeField]
    private Button _button;

    private StartScreenPresenter _presenter;

    public void Initialize(StartScreenPresenter presenter)
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
