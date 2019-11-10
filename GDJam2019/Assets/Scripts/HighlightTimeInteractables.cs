using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTimeInteractables : MonoBehaviour
{
    public Color lowTimeColor, highTimeColor;

    public Transform physicsFollowTarget;

    public ParticleSystem giveParticles, takeParticles;


    private Dictionary<Outline, bool> outlinesDict = new Dictionary<Outline, bool>();
    private List<Outline> outlines = new List<Outline>();
    public bool pickedUp = false;
    bool doPick = false;
    private Pickup pickup;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Outline o in outlines)
        {
            outlinesDict[o] = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            doPick = true;
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform.tag == "TimeInteractable")
            {
                Outline o = hit.transform.GetComponent<Outline>();
                if (!outlines.Contains(o))
                    outlines.Add(o);
                outlinesDict[o] = true;

                TimeContainer tc = hit.transform.gameObject.GetComponent<TimeContainer>();

                if (Input.GetMouseButton(0))
                {
                    GetComponent<TimePower>().DrainObject(tc);

                    SkinnedMeshRenderer r = hit.transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    if(r != null)
                        r.SetBlendShapeWeight(0, (1f - tc.currentTime / tc.GetMaxTime()) * 100f);

                    takeParticles.gameObject.SetActive(tc.currentTime > 0f);
                    giveParticles.gameObject.SetActive(false);

                    //float weight = r.GetBlendShapeWeight(0);
                    //weight = Mathf.Min(weight + blendShapeChangeSpeed * Time.deltaTime, 100f);
                    //r.SetBlendShapeWeight(0, weight);
                }
                else if (Input.GetMouseButton(1))
                {
                    GetComponent<TimePower>().RestoreObject(tc);

                    SkinnedMeshRenderer r = hit.transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    if(r != null)
                        r.SetBlendShapeWeight(0, (1f - tc.currentTime / tc.GetMaxTime()) * 100f);
                    //float weight = r.GetBlendShapeWeight(0);
                    //weight = Mathf.Max(weight - blendShapeChangeSpeed * Time.deltaTime, 0f);
                    //r.SetBlendShapeWeight(0, weight);

                    giveParticles.gameObject.SetActive(tc.currentTime < tc.GetMaxTime());
                    takeParticles.gameObject.SetActive(false);
                }
                else
                {
                    giveParticles.gameObject.SetActive(false);
                    takeParticles.gameObject.SetActive(false);
                }

                o.OutlineColor = Color.Lerp(lowTimeColor, highTimeColor, tc.currentTime / tc.GetMaxTime());
            }

            else
            {
                giveParticles.gameObject.SetActive(false);
                takeParticles.gameObject.SetActive(false);
            }
        }


            if (hit.transform.tag == "Pickupable")
            {
                if (doPick&&pickedUp==false)
                {
                    pickup = hit.transform.gameObject.GetComponent<Pickup>();
                    pickup.TogglePickup(physicsFollowTarget);
                    pickedUp =  true;
                    doPick = false;
                }
            }

        
        if (doPick && pickedUp == true)
        {
            pickup.TogglePickup(physicsFollowTarget);
            pickedUp = false;
            doPick = false;
        }
        foreach (Outline o in outlines)
        {
            o.enabled = outlinesDict[o];
        }
        doPick = false;
    }
}
