using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClckerController : MonoBehaviour
{
    public Transform trans;
    public float clicker_mult = 1f;
    public float n_lines;
    public int ram_use = 0;
    public int total_ram = 1024;
    public string mem_size = "b";
    public string l = "Lines";

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void OnMouseEnter()
    {
        trans.localScale = new Vector3(0.95f, 0.95f, 0.95f);
    }

    private void OnMouseExit()
    {
        trans.localScale = new Vector3(1f, 1f, 1f);
        trans.rotation = Quaternion.Euler(0f, 0f, 0f);
    }


    private void OnMouseDown()
    {
        if (n_lines > 100)
        {
            l = "L";
        }
        n_lines += clicker_mult;
        trans.rotation = Quaternion.Euler(0f, 0f, Random.Range(-1.5f, 1.5f));
        float d = Random.Range(0.9f, 0.95f);
        trans.localScale = new Vector3(d, d, 0f);
    }
}
