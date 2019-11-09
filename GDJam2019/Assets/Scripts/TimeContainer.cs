using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeContainer : MonoBehaviour
{
    [SerializeField]
    float maxTime = 30.0f;
    [SerializeField]
    bool isRestored = false;

    float _currentTime = 0;
    // Start is called before the first frame update
    private void Start()
    {
           _currentTime = isRestored ? maxTime : 0.0f ;
    }
    public void Drain(ref float  amount)
    {
        isRestored = false;
        if (_currentTime - amount > 0)
        {
            _currentTime -= amount;

        }
        else if (_currentTime - amount <= 0)
        {
            amount =  _currentTime;
            _currentTime = 0;
        }
    }
    public void Restore( ref float amount)
    {
        if (_currentTime+amount<maxTime)
        {
            _currentTime += amount;

        }else if (_currentTime+amount>=maxTime)
        {
            amount = (maxTime - _currentTime);
            _currentTime = maxTime;
            isRestored = true;
        }
    }
}
