using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool pickedUp = false;
    Rigidbody rigidbody;
    Transform target;
    [SerializeField]
    float forceMultiplier = 900.0f;
    [SerializeField]
    float range = 0.5f;

    bool collidingWithPlayer = false;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void TogglePickup(Transform t)
    {
        target = t;
        pickedUp = !pickedUp;
       // rigidbody.useGravity = !pickedUp;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            
           
            rigidbody.velocity = ((target.position - transform.position).normalized*forceMultiplier*Time.deltaTime)*(target.position - transform.position).magnitude;
        }
       
    }
   

}
