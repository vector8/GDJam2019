using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[ExecuteInEditMode]

public class Objective : MonoBehaviour
{
   
    [SerializeField]
    string objectiveName = "";
    [SerializeField]
    bool activated = false;

    [SerializeField]
    UnityEvent OnStartCallbacks;
 
    [SerializeField]
    UnityEvent OnEndCallbacks;

    bool isLast = false;
    int numOfBranchs = 1;
    [SerializeField]
    List<Objective> nextObjectives = new List<Objective>();
   
  //  private string nameOfNextObjective;
  



    private void Start()
    {
       
    }

    private void Update()
    {
      
    }

    public void Next(int i)
    {
        if (activated)
        {
            OnEndCallbacks.Invoke();
            if (!isLast)
            {
                if (nextObjectives != null)
                {
                    nextObjectives[i].Activate();
                }
            }
        }
    }
    public void Next()
    {
        if (activated)
        {
            OnEndCallbacks.Invoke();
            if (!isLast)
            {
                if (nextObjectives != null)
                {
                    nextObjectives[0].Activate();
                }
            }
        }
    }
    public void Activate()
    {
        activated = true;
        OnStartCallbacks.Invoke();
    }
    public Objective GetNext(int i)
    {
        return nextObjectives[i];
    }
    public string GetName()
    {
        return objectiveName;
    }
    public bool GetIsLast()
    {
        return isLast;
    }
    public void SetLast(bool last)
    {
       
        isLast = last;
    }
    public void IncreaseBranches()
    {
        numOfBranchs++;
        nextObjectives.Add(null);
    }
    public void DecreaseBranches()
    {
        if (numOfBranchs > 0)
        {
            numOfBranchs--;
            nextObjectives.RemoveAt(nextObjectives.Count - 1);
        }
    }

    public void SetNext(Objective objective,int i)
    {
        nextObjectives[i] =objective;
    }
    public int GetCount()
    {
        return nextObjectives.Count;
    }
}
