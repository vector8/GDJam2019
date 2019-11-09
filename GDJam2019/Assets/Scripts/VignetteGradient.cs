using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VignetteGradient : MonoBehaviour
{
    [SerializeField]
    float fadeInTime = 0.2f;
    [SerializeField]
    Image vignette;

    bool _doGradient = false;
    float target = 0.5f;
    [SerializeField]
    float _currentTimer = 0.0f;

    // Start is called before the first frame update
    private void OnDisable()
    {
        Image background = GetComponent<Image>();
        background.color = new Color(background.color.r, background.color.g, background.color.b,0.0f);
        vignette.color = new Color(background.color.r, background.color.g, background.color.b,0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;
            Image background = GetComponent<Image>();
            background.color = new Color(background.color.r, background.color.g, background.color.b, (1.0f - (_currentTimer / fadeInTime)) * (  target));
            vignette.color = new Color(background.color.r, background.color.g, background.color.b, ( 1.0f - (_currentTimer / fadeInTime)) );
            
        }    
    }
    public void Gradient()
    {
        _currentTimer = fadeInTime;
    }
}
