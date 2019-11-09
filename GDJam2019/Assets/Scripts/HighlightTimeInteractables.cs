using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTimeInteractables : MonoBehaviour
{
    public float blendShapeChangeSpeed = 10.0f;
    
    private List<Outline> outlines = new List<Outline>();
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Outline o in outlines)
        {
            o.enabled = false;
        }

        outlines.Clear();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f));

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if(hit.transform.tag == "TimeInteractable")
            {
                Outline o = hit.transform.GetComponent<Outline>();
                o.enabled = true;

                outlines.Add(o);

                if(Input.GetMouseButton(0))
                {
                    SkinnedMeshRenderer r = hit.transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    float weight = r.GetBlendShapeWeight(0);
                    weight = Mathf.Min(weight + blendShapeChangeSpeed * Time.deltaTime, 100f);
                    r.SetBlendShapeWeight(0, weight);

                    GetComponent<TimePower>().DrainObject(hit.transform.gameObject.GetComponent<TimeContainer>());
                }
                else if (Input.GetMouseButton(1))
                {
                    SkinnedMeshRenderer r = hit.transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    float weight = r.GetBlendShapeWeight(0);
                    weight = Mathf.Max(weight - blendShapeChangeSpeed * Time.deltaTime, 0f);
                    r.SetBlendShapeWeight(0, weight);

                    GetComponent<TimePower>().RestoreObject(hit.transform.gameObject.GetComponent<TimeContainer>());
                }
            }
        }
    }
}
