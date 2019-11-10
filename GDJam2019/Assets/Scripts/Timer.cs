using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TimePower power;

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = power.GetCurrentTimeFormatted();
        if (power.UsingRestore())
        {
            text.color = Color.red;
        }
        else if(power.UsingDrain())
        {
            
            text.color = Color.blue;
           
        }
        else 
        {
            text.color = Color.white;
        } 
        power._doingDrainPower = false;
        power._doingRestorePower = false;
    }
}
