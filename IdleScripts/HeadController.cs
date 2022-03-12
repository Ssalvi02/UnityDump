using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    [SerializeField] private SpinController sc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PointCollider")
        {
            sc.points += 1*sc.point_mult;
        }
        if (collision.name == "PtColActivator")
        {
            sc.point_col.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
