using UnityEngine;

public class AppLauncher : MonoBehaviour
{
    void Start()
    {
        var controller = new AppController();

        controller.Execute();
    }
}
