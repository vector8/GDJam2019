using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour
{
    [SerializeField]
    float fadeInTime = 0.2f;

    [SerializeField]
    float _currentTimer = 0.0f;
    Image background;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0.0f);
        _currentTimer = fadeInTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;
           
            background.color = new Color(background.color.r, background.color.g, background.color.b, (1.0f - (_currentTimer / fadeInTime)));
           // vignette.color = new Color(background.color.r, background.color.g, background.color.b, (1.0f - (_currentTimer / fadeInTime)));

        }
    }
}
