using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSlideController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Camera cam;
    public Color color_i, color_f;
    public float x = 0f;
    private float v = 0f;
    private Vector3 v2 = Vector3.zero;
    public float t = 0f;
    public bool mouse_over = false;
    public bool mouse_down = false;
    public bool up_menu = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        color_i = sr.color;
        color_f = color_i - new Color(0.3f, 0.3f, 0.3f, 0f);
    }

    // Update is called once per frame
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


        if (up_menu == true && cam.transform.position.x < 5.1)
        {
            Vector3 target_position = new Vector3(5.1f, 0, -10);
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, target_position, ref v2, 0.2f);
        }

        if (up_menu == false && cam.transform.position.x > 0)
        {
            Vector3 target_position = new Vector3(0f, 0, -10);
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, target_position, ref v2, 0.2f);
        }
        

    }

    private void OnMouseOver()
    {
        mouse_over = true;
        t += Mathf.SmoothDamp(0f, 1f, ref v, 0.3f);
    }

    private void OnMouseExit()
    {
        mouse_over = false;
    }

    private void OnMouseDown()
    {
        mouse_down = true;
        sr.color = color_f - new Color(0.1f, 0.1f, 0.1f, 0f);
    }

    private void OnMouseUp()
    {
        mouse_down = false;
        if (up_menu == false)
        {
            sr.flipX = false;
            up_menu = true;
        }
        else
        {
            sr.flipX = true;
            up_menu = false;
        }
    }
}
