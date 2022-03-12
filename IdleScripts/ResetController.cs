using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetController : MonoBehaviour
{
    public Sprite[] spr;
    public bool unlocked;
    public SpriteRenderer sprite;
    public int n_res = 0;

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
        sprite.sprite = spr[1];
    }

    private void OnMouseExit()
    {
        sprite.sprite = spr[0];
    }

    private void OnMouseDown()
    {
        switch (n_res)
        {
            case 1:
                //Multi row esq + rst
                break;
            case 2:
                //Div row dir + rst
                break;
            case 3:
                //Novo up row + rst
                break;
            case 4:
                //Nova cabess + rst
                break;
        }
    }

}
