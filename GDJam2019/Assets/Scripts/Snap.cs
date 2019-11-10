using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public string nameToSnap;
    public GameObject snapped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nameToSnap)
        {
            other.gameObject.SetActive(false);
            snapped.SetActive(true);
        }
    }
}
