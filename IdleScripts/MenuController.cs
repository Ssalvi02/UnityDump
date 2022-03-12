using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private SetaController sc;
    private Vector3 vel = Vector3.zero;
    private float velocity = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.queriesHitTriggers = true;
    }

    // Update is called once per frame
    void Update()
    {
        OpenMenu();
    }

    void OpenMenu()
    {
        if(sc.open_menu == false)
        {
            Vector3 origin = new Vector3(4.93f, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, origin, ref vel , velocity);
        }
        else
        {
            Vector3 target = new Vector3(-0.09f, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, velocity);
        }
    }

}
