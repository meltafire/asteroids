using TMPro;
using UnityEngine;

public class GameOverScoreView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textMesh;

    public void SetText(string text)
    {
        _textMesh.text = text;
    }
}
