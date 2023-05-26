using System;

public class LaserServiceModel
{
    public const int LazerLimit = 3;

    private const float RefilTimeLimit = 3f;

    private int _currentLazerCount;
    private float _timeToRefill;
    private bool _isRefillOngoing;

    public event Action<int> ShotCountChanged;
    public event Action<float> TimeChanged;

    public int CurrentLazerCount => _currentLazerCount;
    public bool IsRefillOngoing => _isRefillOngoing;
    public float TimeToRefill => _timeToRefill;

    public void Reset()
    {
        _currentLazerCount = LazerLimit;
        _isRefillOngoing = false;
        _timeToRefill = 0;

        ReportShotCountChanged();
        ReportTimeChanged();
    }

    public void Use()
    {
        _currentLazerCount--;

        ReportShotCountChanged();
    }

    public void DeclareRefill()
    {
        if(!_isRefillOngoing)
        {
            _isRefillOngoing = true;

            _timeToRefill = RefilTimeLimit;

            ReportTimeChanged();
        }
    }

    public void AwateHappened(float seconds)
    {
        if(_isRefillOngoing)
        {
            _timeToRefill -= seconds;

            if (_timeToRefill <= 0)
            {
                Refill();

                if (_currentLazerCount < LazerLimit)
                {
                    _timeToRefill = RefilTimeLimit;
                }
                else
                {
                    _timeToRefill = 0;
                    _isRefillOngoing = false;
                }
            }

            ReportTimeChanged();
        }
    }

    private void Refill()
    {
        _currentLazerCount++;

        ReportShotCountChanged();
    }

    private void ReportShotCountChanged()
    {
        ShotCountChanged?.Invoke(_currentLazerCount);
    }

    private void ReportTimeChanged()
    {
        TimeChanged?.Invoke(_timeToRefill);
    }
}
