using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AutoController : MonoBehaviour
{
    public GameObject desc;
    public ClckerController cc;
    public GameController gc;
    public Button btn;
    public TextMeshPro desc_t;
    public TextMeshProUGUI[] quant_t;
    public string auto_name;
    private string auto_desc;
    public int auto_price;
    public float production_per_sec;
    public int ram_cost;
    public int quantity = 0;
    public int tier;
    public bool can_afford;
    private string price_col;
    private string price_ram_col;
    private float timer;
    [SerializeField] private int n;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("/Comp").GetComponent<ClckerController>();
        gc = GameObject.Find("/Game").GetComponent<GameController>();
        quant_t = GetComponentsInChildren<TextMeshProUGUI>();
        btn = GetComponent<Button>();
        desc = GameObject.Find("UpgradeMenu/Canvas/UpDesc");
        desc_t = desc.GetComponent<TextMeshPro>();
        desc.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            cc.n_lines += production_per_sec * quantity;
            timer = 0;
        }
    }

    private void OnMouseOver()
    {
        setText();
        if(Input.GetMouseButtonDown(1) && quantity > 0){
            quantity--;
            cc.n_lines += auto_price * 0.1f;
            quant_t[1].text = quantity.ToString();
            cc.ram_use -= ram_cost;
            gc.totalProdSub();
        }
    }

    private void setText()
    {
        desc.SetActive(true);
        if (affordCheck() == true)
        {
            price_col = "#77AA66";
        }
        else
        {
            price_col = "#bb5555";
        }
        if (ramCheck() == true)
        {
            price_ram_col = "#77AA66";
        }
        else
        {
            price_ram_col = "#bb5555";
        }
        auto_desc = "Produces "+production_per_sec+" lines of code each second.";
        desc_t.text = "<size=6>" + auto_name + "</size>\n\n" + auto_desc + "\nRam cost: <color="+price_ram_col+">" + ram_cost +"b\n\n<color=" + price_col + ">" + auto_price + "L</color>";
    }

    private bool ramCheck()
    {
        float ram_final = cc.total_ram - ram_cost - cc.ram_use;
        if (ram_final < 0f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool affordCheck()
    {
        if (cc.n_lines >= auto_price)
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
        cc.n_lines -= auto_price;
    }

    private void ramManage()
    {
        cc.ram_use += ram_cost;
    }

    private void OnMouseUp()
    {
        if (affordCheck() && ramCheck())
        {
            affordManage();
            ramManage();
            quantity++;
            quant_t[1].text = quantity.ToString();
            gc.totalProdAdd();
        }
    }

    private void OnMouseExit()
    {
        desc.SetActive(false);
    }
}
