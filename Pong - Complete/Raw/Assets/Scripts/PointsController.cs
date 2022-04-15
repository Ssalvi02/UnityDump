using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsController : MonoBehaviour
{
    public TextMeshProUGUI textJ;
    public TextMeshProUGUI textS;
    public TextMeshProUGUI pntsL;
    public TextMeshProUGUI pntsR;
    public GameObject ball;
    public BallController bc;

    public int pts_l = 0;
    public int pts_r = 0;

    void Start()
    {
        textJ = GameObject.Find("TextJ").GetComponent<TextMeshProUGUI>();
        textS = GameObject.Find("TextSpa").GetComponent<TextMeshProUGUI>();
        pntsL = GameObject.Find("PointsL").GetComponent<TextMeshProUGUI>();
        pntsR = GameObject.Find("PointsR").GetComponent<TextMeshProUGUI>();
        ball = GameObject.Find("Ball");
        bc = ball.GetComponent<BallController>();
    }

    void Update()
    {
        pntsL.text = pts_l.ToString();
        pntsR.text = pts_r.ToString();

        if (ball.transform.position.x >= 10)
        {
            pts_l++;
            bc.ResetBall();
        }

        if (ball.transform.position.x <= -10)
        {
            pts_r++;
            bc.ResetBall();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(textS);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Destroy(textJ);
        }
    }
}
