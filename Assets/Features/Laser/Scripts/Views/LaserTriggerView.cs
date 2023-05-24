using UnityEngine;

public class LaserTriggerView : MonoBehaviour
{
    [SerializeField]
    private LaserView _view;

    private void OnTriggerEnter2D(Collider2D col)
    {
        _view.ColliderTrigger(col);
    }
}
