using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ObjectiveManager : MonoBehaviour
{
  
    [SerializeField]
    Objective starter;
    [SerializeField]
    string starterTaskName;
    string[] names;
    public bool startOnPlay = true;
    public static ObjectiveManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        Objective[] list;
        list = FindObjectsOfType<Objective>();
        for (int i = 0; i<list.Length;i++)
        {
            list[i].Deactivate();
        }

        if (Instance != null)
           {
               Destroy(gameObject);
               return;
           }

           Instance = this;
#if UNITY_STANDALONE
        if (startOnPlay) {
            if (starter != null)
            {
                starter.Activate();
            }
        }
#endif

    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (starter != null)
        {
            starterTaskName = starter.GetName();
        }
#endif
    }
   public bool HasStarter()
    {
        if (starter != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetStarter(Objective o)
    {
        starter = o;
    }
    public Objective GetObjectiveFromList(string objective)
    {
        return starter;
    }
    public string[] GetList(){
        return names;
        }
}
