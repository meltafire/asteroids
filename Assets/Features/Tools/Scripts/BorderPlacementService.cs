using UnityEngine;

public class BorderPlacementService : ILoopPlacementService, IOutOfScreenPlacementService, IOutOfScreenCheck
{
    private readonly Vector2 _screenBounds;

    public BorderPlacementService(Camera camera)
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

    public Vector3 GetRandomPositionAtScreenBorder()
    {
        var isPoisitonAllignedWithWidth = Random.Range(0, 2) == 0;

        if (isPoisitonAllignedWithWidth)
        {
            return new Vector3(
                _screenBounds.x,
                Random.Range(-_screenBounds.y, _screenBounds.y),
                0f
                );
        }
        else
        {
            return new Vector3(
                Random.Range(-_screenBounds.x, _screenBounds.x),
                -_screenBounds.y,
                0f
                );
        }
    }

    public bool IsOutOfScreen(Vector3 position)
    {
        if (position.x < -_screenBounds.x)
        {
            return true;
        }
        else if (position.x > _screenBounds.x)
        {
            return true;
        }
        else if (position.y < -_screenBounds.y)
        {
            return true;
        }
        else if (position.y > _screenBounds.y)
        {
            return true;
        }

        return false;
    }
}
