using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshPro number_t;
    public TextMeshPro number_a_t;
    public TextMeshPro ram_t;
    public ClckerController cc;
    public AutoController[] ac;
    public GameObject up_ls;
    public GameObject auto_ls;
    public Button but_up;
    public Button but_auto;
    public TextMeshPro head;
    public int avaible_tier = 0;
    public bool scr_unlock = false;
    public string ram_use_t;
    public string total_ram_t;
    void Start()
    {
        head = GameObject.Find("Header").GetComponent<TextMeshPro>();
        number_a_t = GameObject.Find("Lines/LinePS").GetComponent<TextMeshPro>();
        up_ls = GameObject.Find("ScrollArea");
        ac = GameObject.Find("UpgradeMenu/Canvas/ScrollArea2/Mask/UpList").GetComponentsInChildren<AutoController>();

        if(avaible_tier == 0)
        {
            for(int i =0; i < ac.Length; i++)
            {
                ac[i].gameObject.SetActive(false);
            }
        }

        auto_ls = GameObject.Find("ScrollArea2");
        but_up = GameObject.Find("butt").GetComponent<Button>();
        but_auto = GameObject.Find("butt1").GetComponent<Button>();
        but_up.interactable = false;
        auto_ls.SetActive(false);
        but_up.onClick.AddListener(buttonManageUp);
        but_auto.onClick.AddListener(buttonManageAuto);
    }

    void Update()
    {
        //Ram text
        ram_use_t = cc.ram_use.ToString();
        total_ram_t = cc.total_ram.ToString();
        ram_t.text = "<color=#bb5555>" + ram_use_t + "</color>/<color=#77aa66>" + total_ram_t + "</color>" + cc.mem_size;
        //Total lines text
        number_t.text = cc.n_lines.ToString() + " " + cc.l;
    }

    public void totalProdAdd()
    {
        float total = 0;
        for (int i = 0; i < ac.Length; i++)
        {
            total += ac[i].production_per_sec * ac[i].quantity;
        }
        number_a_t.text = total + " L/s";
    }
    public void totalProdSub()
    {
        float total = 0;
        for (int i = 0; i < ac.Length; i++)
        {
            total -= ac[i].production_per_sec * ac[i].quantity;
        }
        number_a_t.text = total*-1 + " L/s";
    }

    void buttonManageUp()
    {
        changeHead(0.9333333f, 0.6f, 0.6666667f, "Upgrades");
        but_auto.interactable = true;
        but_up.interactable = false;
        up_ls.SetActive(true);
        auto_ls.SetActive(false);
    }

    void buttonManageAuto()
    {
        changeHead(0.4666667f, 0.6666667f, 0.4f, "Automation");
        head.fontSize = 4;
        but_auto.interactable = false;
        but_up.interactable = true;
        up_ls.SetActive(false);
        auto_ls.SetActive(true);
    }

    void changeHead(float r, float g, float b, string text)
    {
        Color c = new Color(r, g, b);
        head.text = text;
        head.color = c; 
    }

    public void activateTier()
    {
        avaible_tier++;
        for (int i = 0; i < ac.Length; i++)
        {
            if (ac[i].tier == avaible_tier)
            {
                ac[i].gameObject.SetActive(true);
            }
        }
    }

    public void prod20()
    {
        for (int i = 0; i < ac.Length; i++)
        {
            ac[i].production_per_sec *= 1.2f;
        }
    }



}
