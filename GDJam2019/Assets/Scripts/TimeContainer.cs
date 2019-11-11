using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeContainer : MonoBehaviour
{
    [SerializeField]
    float maxTime = 30.0f;
    [SerializeField]
    bool isRestored = false;
    [SerializeField]
    UnityEvent OnRestore;

    public float currentTime { get; set; }
    // Start is called before the first frame update
    private void Start()
    {

           currentTime = isRestored ? maxTime : 0.0f ;
        SkinnedMeshRenderer r = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        if (r != null)
            r.SetBlendShapeWeight(0, (1f - currentTime / GetMaxTime()) * 100f);
    }
    public void Drain( ref float  amount)
    {
        isRestored = false;
        if (currentTime - amount > 0)
        {
            currentTime -= amount;

        }
        else if (currentTime - amount <= 0)
        {
            amount =  currentTime;
            currentTime = 0;
        }
    }
    public void Restore( ref float amount)
    {
        if (currentTime+amount<maxTime)
        {
            currentTime += amount;

        }else if (currentTime+amount>=maxTime)
        {
            amount = (maxTime - currentTime);
            currentTime = maxTime;
            isRestored = true;
            OnRestore.Invoke();
        }
    }

    public float GetMaxTime()
    {
        return maxTime;
    }
}
