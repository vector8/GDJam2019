using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PipeWatcher : MonoBehaviour
{

    public UnityEvent OnSolve;
    public TimeContainer[] watchList;
    public bool[] statusList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool finished = true;
        for(int i = 0; i < watchList.Length;i++)
        {
            if (!(statusList[i]&&(watchList[i].currentTime>=watchList[i].GetMaxTime()))&&!((!statusList[i])&& (watchList[i].currentTime <= 0)))
            {
                finished = false;
            }
        }
        if (finished)
        {
            OnSolve.Invoke();
        }
    }
}
