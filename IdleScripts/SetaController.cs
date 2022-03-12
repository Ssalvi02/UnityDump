using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaController : MonoBehaviour
{
    public bool open_menu = false;
    [SerializeField] SpriteRenderer seta;
    [SerializeField] Sprite[] sprarr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        seta.sprite = sprarr[1];
        
    }

    private void OnMouseExit()
    {
        seta.sprite = sprarr[0];
    }

    private void OnMouseDown()
    {
        if (open_menu == false)
        {
            seta.flipX = true;
            open_menu = true;
        }
        else
        {
            seta.flipX = false;
            open_menu = false;
        }
    }


}
