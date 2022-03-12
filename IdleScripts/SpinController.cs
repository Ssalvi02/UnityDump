using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinController : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject reset;
    [SerializeField] private ResetController rc;
    [SerializeField] private Text pts_txt;
    private float timer_pts;
    public GameObject point_col;
    public float rotation_speed = -0.05f;
    public float rot_div;
    public int point_mult = 1;
    public bool auto = false;
    public bool pts_per_sec = false;
    public bool can_spin = true;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.LoadGame();
        point_col.SetActive(false);
        reset.SetActive(false);
        rot_div = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Spin(); //Roda
        if (auto == true) //Roda auto
        {
            AutoSpin();
        }
        if(pts_per_sec == true && timer_pts < 0f)//Pontos por segundo
        {
            timer_pts = 1f;
            PointsPerSec();
        }
        timer_pts -= Time.deltaTime;
        if(rotation_speed < -5f)//Muda o colisor pra n buga e fude tudo
        {
            BoxCollider2D size = point_col.GetComponent<BoxCollider2D>();
            size.size = new Vector2(5.8f, 1.1f);
            size.offset = new Vector2(-0.25f, -0.3f);
        }
        pts_txt.text = points.ToString() + "\nspeens";//Texto dos pontos

        if (rc.unlocked)
        {
            reset.SetActive(true);
        }
    }

    void Spin()
    {
        if ((Input.GetMouseButton(0) && can_spin) || Input.GetKey(KeyCode.Space))
        {
            head.transform.Rotate(new Vector3(0, 0, rotation_speed));
        }
    }

    void AutoSpin()
    {
        head.transform.Rotate(new Vector3(0f, 0f, rotation_speed/rot_div));
    }

    void PointsPerSec()
    {
        points += point_mult*100;
    }
    //RESETS ------->>>>>> 1o reset: Escolher entre idle ou ativo; 2o reset mema porra; 3o reset: MAIS UPGRADE; 4o reset: Reseta tudo mas desbloquei uma cabess nova

    private void OnApplicationQuit()
    {
        SaveLoad.SaveGame();
    }

}


