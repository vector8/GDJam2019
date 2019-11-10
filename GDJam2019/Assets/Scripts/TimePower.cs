using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;
public class TimePower : MonoBehaviour
{
     [SerializeField]
    float startTime = 120.0f;
    [SerializeField]
    float drainRestoreSpeed = 10f;
    [SerializeField]
    float emergencyThreshold = 120f;
    [SerializeField]
    GameObject vignette;
    [SerializeField]
    UnityEvent gradient;
    [SerializeField]
    PlayerDeath playerDeath;
    [SerializeField]
    FirstPersonController controller;
   
    private float _currentTime;
    public bool _doingRestorePower = false;
    public bool _doingDrainPower = false;
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
    
        if(_currentTime < emergencyThreshold)
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
        if (_currentTime <= 0)
        {
            _currentTime = 0;
            playerDeath.KillPlayer();
            controller.enabled = false;
        }
      //  _doingDrainPower = false;
       // _doingRestorePower = false;

    }
    public  string  GetCurrentTimeFormatted()
    {
        return  FormatTime(_currentTime);
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
    public static string FormatTime(double seconds)
    {
        System.TimeSpan timespan = System.TimeSpan.FromSeconds(seconds);
        string mm = (timespan.Minutes).ToString("00");
        string ss = (timespan.Seconds).ToString("00");
        string ms = (timespan.Milliseconds/10.0f).ToString("00");
        return mm + ":" + ss + "." + ms;
    }

}
