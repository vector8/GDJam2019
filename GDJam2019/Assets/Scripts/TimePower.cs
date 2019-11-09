using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimePower : MonoBehaviour
{
     [SerializeField]
    float startTime = 120.0f;
    [SerializeField]
    float drainRestoreSpeed = 10f;
    [SerializeField, Range(0f, 1f)]
    float emergencyPercentage = 0.2f;
    [SerializeField]
    GameObject vignette;
    [SerializeField]
    UnityEvent gradient;
   
    private float _currentTime;
    private bool _doingRestorePower = false;
    private bool _doingDrainPower = false;
    private bool _isEmergency = false;

    private void Start()
    {
        _currentTime = startTime;
    }
    private void Update()
    {
        if (!(_doingRestorePower||_doingDrainPower))
        {
            _currentTime -= Time.deltaTime;
        }
        _doingDrainPower = false;
        _doingRestorePower = false;
        if(_currentTime / startTime < emergencyPercentage ? true : false)
        {
            if (!_isEmergency)
            {
                vignette.SetActive(true);
                gradient.Invoke();
            }
           
            _isEmergency = true;

        }
        else
        {

            vignette.SetActive(false);
            _isEmergency = false;
        }
        
    }
    public  string  GetCurrentTimeFormatted()
    {
        return  formatTime(_currentTime);
    }

    public void DrainObject(TimeContainer timeContainer)
    {
        float _drainAmount = Time.deltaTime* drainRestoreSpeed;
        timeContainer.Drain(ref _drainAmount);
        if (_drainAmount > 0)
        {
            _doingDrainPower = true;
            _currentTime += _drainAmount;
        }
    }
    public void RestoreObject(TimeContainer timeContainer)
    {
        float _restoreAmount = Time.deltaTime * drainRestoreSpeed;
        timeContainer.Restore(ref _restoreAmount);
        if (_restoreAmount > 0)
        {
            _doingRestorePower = true;
            _currentTime -= _restoreAmount;
        }
    }
    public bool UsingRestore()
    {
        return _doingRestorePower;
    }
    public bool UsingDrain()
    {
        return _doingDrainPower;
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
