using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class JobController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    public Color color_i, color_f;
    public TextMeshPro txt;
    public int x;
    private float v = 0f;
    public float t = 0f;
    public bool mouse_over = false;
    public bool mouse_down = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        color_i = sr.color;
        color_f = color_i - new Color(0.3f, 0.3f, 0.3f, 0f);
    }
    
    
    void Update()
    {
        t = Mathf.Clamp(t, 0f, 1f);
        if (mouse_over == false)
        {
            t -= Mathf.SmoothDamp(0f, 1.0f, ref v, 0.3f);
        }
        if (mouse_down == false)
        {
            sr.color = Color.Lerp(color_i, color_f, t);
        }
    }

    private void OnMouseOver()
    {
        mouse_over = true;
        t += Mathf.SmoothDamp(0f, 1f, ref v, 0.3f);
        switch (x)
        {
            case 0:
                txt.color = new Color(0.2470588f, 0.3647059f, 0.3529412f, 1f);
                txt.text = "More <color=#7e2738>active</color> playstyle";
                break;
            case 1:
                txt.color = new Color(0.5647059f, 0.3058824f, 0.1921569f, 1f);
                txt.text = "More <color=#7e2738>balanced</color> playstyle";
                break;
            case 2:
                txt.color = new Color(0.4627451f, 0.3607843f, 0.4196079f, 1f);
                txt.text = "More <color=#7e2738>active</color>, but still <color=#7e2738>balanced</color> playstyle";
                break;
            case 3:
                txt.color = new Color(0.2313726f, 0.2862745f, 0.4431373f, 1f);
                txt.text = "More <color=#7e2738>idle</color> playstyle";
                break;
        }
    }

    private void OnMouseEnter()
    {
        anim.SetTrigger("m_over");
    }

    private void OnMouseExit()
    {
        mouse_over = false;
        txt.text = "";
    }

    private void OnMouseDown()
    {
        mouse_down = true;
        sr.color = color_f - new Color(0.1f, 0.1f, 0.1f, 0f);
    }

    private void OnMouseUp()
    {
        mouse_down = false;

        switch (x)
        {
            case 0:
                SceneManager.LoadScene("Prog_gm");
                break;
            case 1:
                SceneManager.LoadScene("Cook_gm");
                break;
            case 2:
                SceneManager.LoadScene("Hitman_gm");
                break;
            case 3:
                SceneManager.LoadScene("Sale_gm");
                break;
        }
    }
}
