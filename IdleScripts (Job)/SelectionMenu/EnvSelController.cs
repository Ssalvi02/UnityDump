using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class EnvSelController : MonoBehaviour
{
    public Volume effects;
    private Vignette vig;
    private float v = 0f;
    private float t = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Vignette vi;
        if(effects.profile.TryGet<Vignette>(out vi))
        {
            vig = vi;
        }

    }


    void Update()
    {
        vig.intensity.value = Mathf.Clamp(vig.intensity.value, 0.313f, 0.343f);
        if (t <= 3f) 
        {
            vig.intensity.value = Mathf.SmoothDamp(vig.intensity.value, 0.343f, ref v, 3f);
        }
        else
        {
            vig.intensity.value = Mathf.SmoothDamp(vig.intensity.value, 0.313f, ref v, 3f);
        }

        t += Time.deltaTime;
        if(vig.intensity.value <= 0.315f)
        {
            t = 0f;
        }
    }
}
