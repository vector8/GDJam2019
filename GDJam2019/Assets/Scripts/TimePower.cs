using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePower : MonoBehaviour
{
    
    [SerializeField]
    float drainRestoreSpeed = 10f;

    private float _currentTime;


    public  string  GetCurrentTimeFormatted()
    {
        return  formatTime(_currentTime);
    }

    public void DrainObject(TimeContainer timeContainer)
    {
        float _drainAmount = Time.deltaTime* drainRestoreSpeed;
        timeContainer.Drain(ref _drainAmount);
        _currentTime += _drainAmount;
    }
    public void RestoreObject(TimeContainer timeContainer)
    {
        float _restoreAmount = Time.deltaTime * drainRestoreSpeed;
        timeContainer.Restore(ref _restoreAmount);
        _currentTime -= _restoreAmount;
    }
    public static string formatTime(double seconds)
    {
        System.TimeSpan timespan = System.TimeSpan.FromSeconds(seconds);
        string mm = (timespan.Minutes).ToString("00");
        string ss = (timespan.Seconds).ToString("00");
        string ms = (timespan.Milliseconds).ToString("000");
        return mm + ":" + ss + "." + ms;
    }

}
