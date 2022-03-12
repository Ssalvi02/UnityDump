using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    public SpinController sc;
    public TextMeshPro texto;
    public bool bought = false;
    public Sprite[] spr;
    public SpriteRenderer sprite;
    public int upid;
    public bool[] save_b = new bool[12];
    private bool can_buy;
    private int up_price;
    private Color c;
    public int blacked = 0;


    void Start()
    {
        texto = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        if (bought == false)
        {
            blacked = 1;
            sprite.sprite = spr[blacked];
        }
        sc.can_spin = false;
    }

    private void OnMouseExit()
    {
        if (bought == false)
        {
            blacked = 0;
            sprite.sprite = spr[blacked];
        }
        sc.can_spin = true;
    }


    private void OnMouseDown()
    {
        switch (upid)
        {
            case 1:                                                 //Dobro de velocidade
                up_price = 1;
                if (sc.points >= up_price && bought == false)
                {
                    sc.rotation_speed *= 2;
                    save_b[0] = true;
                    Change();
                }
                break;
            case 2:                                                 //Automatiza com softcap de 8
                up_price = 2;
                if (sc.points >= up_price && bought == false)
                {
                    if (sc.rot_div > 4f)
                    {
                        sc.rot_div = 8f;
                    }
                    sc.auto = true;
                    save_b[1] = true;
                    Change();
                }
                break;
            case 3:                                                 //15x de velocidade
                up_price = 5;
                if (sc.points >= up_price && bought == false)
                {
                    sc.rotation_speed *= 15;
                    save_b[2] = true;
                    Change();
                }
                break;
            case 4:                                                 //Automatiza com softcap de 4
                up_price = 10;
                if (sc.points >= up_price && bought == false)
                {
                    if (sc.rot_div > 2f)
                    {
                        sc.rot_div = 4f;
                    }
                    sc.auto = true;
                    save_b[3] = true;
                    Change();
                }
                break;
            case 5:                                                 //Multiplica pontos por 4
                up_price = 25;
                if (sc.points >= up_price && bought == false)
                {
                    sc.point_mult = 4;
                    save_b[4] = true;
                    Change();
                }
                break;
            case 6:                                                 //Automatiza com softcap de 2
                up_price = 40;
                if (sc.points >= up_price && bought == false)
                {
                    sc.rot_div = 2f;
                    sc.auto = true;
                    save_b[5] = true;
                    Change();
                }
                break;
            case 7:                                                 //Multiplica a velocidade por 5
                up_price = 60;
                if (sc.points >= up_price && bought == false)
                {
                    sc.rotation_speed *= 5;
                    save_b[6] = true;
                    Change();
                }
                break;
            case 8:                                                 //Ganha 100x dos pontos por seg
                up_price = 1000;
                if (sc.points >= up_price && bought == false)
                {
                    sc.pts_per_sec = true;
                    save_b[7] = true;
                    Change();
                }
                break;
        }
    }

    void Change()
    {
        blacked = 1;
        sprite.sprite = spr[blacked];
        bought = true;
        ColorUtility.TryParseHtmlString("#4c5359", out c);
        texto.color = c;
        sc.points -= up_price;
    }
}
