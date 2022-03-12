using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    public GameObject desc;
    public ClckerController cc;
    public GameController gc;
    public BoxCollider2D col;
    public Button btn;
    public TextMeshPro desc_t;
    public string up_name;
    public string up_desc;
    public int up_price;
    public bool can_afford;
    private string price_col;
    [SerializeField] private int n;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("/Comp").GetComponent<ClckerController>();
        gc = GameObject.Find("/Game").GetComponent<GameController>();
        col = GetComponent<BoxCollider2D>();
        btn = GetComponent<Button>();
        desc = GameObject.Find("UpgradeMenu/Canvas/UpDesc");
        desc_t = desc.GetComponent<TextMeshPro>(); 
        desc.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        setText();
    }

    private void setText()
    {
        desc.SetActive(true);
        if(affordCheck() == true)
        {
            price_col = "#77AA66";
        }
        else
        {
            price_col = "#bb5555";
        }
        desc_t.text = "<size=6>" + up_name + "</size>\n\n" + up_desc + "\n\n<color=" + price_col + ">" + up_price + "L</color>";
    }

    private bool affordCheck()
    {
        if(cc.n_lines >= up_price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void affordManage()
    {
        if (affordCheck())
        {
            cc.n_lines -= up_price;
        }
    }

    private void OnMouseUp()
    {
        if (affordCheck())
        {
            affordManage();
            btn.interactable = false;
            switch (n)
            {
                case 0: //Mult 2
                    cc.clicker_mult += 1;
                    col.enabled = false;
                    break;
                case 1: //Unlock t1
                    gc.activateTier();
                    gc.scr_unlock = true;
                    col.enabled = false;
                    break;
                case 2: //More RAM
                    cc.total_ram += 1024;
                    break;
                case 3:
                    gc.prod20();
                    break;
            }
        }
    }

    private void OnMouseExit()
    {
        desc.SetActive(false);
    }
}
