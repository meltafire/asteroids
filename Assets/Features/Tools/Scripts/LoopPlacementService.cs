using UnityEngine;

public class LoopPlacementService : ILoopPlacementService
{
    private readonly Vector2 _screenBounds;

    public LoopPlacementService(Camera camera)
    {
        _screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    public Vector3 AdjustPosition(Vector3 position)
    {
        if (position.x < -_screenBounds.x)
        {
            var uncompletedDeltaX = position.x + _screenBounds.x;
            var adjustedX = _screenBounds.x + uncompletedDeltaX;

            position = new Vector3(adjustedX, position.y, position.z);
        }
        else if (position.x > _screenBounds.x)
        {
            var uncompletedDeltaX = position.x - _screenBounds.x;
            var adjustedX = -_screenBounds.x + uncompletedDeltaX;

            position = new Vector3(adjustedX, position.y, position.z);
        }
        else if (position.y < -_screenBounds.y)
        {
            var uncompletedDeltaY = position.y + _screenBounds.y;
            var adjustedY = _screenBounds.y + uncompletedDeltaY;

            position = new Vector3(position.x, adjustedY, position.z);
        }
        else if (position.y > _screenBounds.y)
        {
            var uncompletedDeltaY = position.y - _screenBounds.y;
            var adjustedY = -_screenBounds.y + uncompletedDeltaY;

            position = new Vector3(position.x, adjustedY, position.z);
        }

        return position;
    }
}
