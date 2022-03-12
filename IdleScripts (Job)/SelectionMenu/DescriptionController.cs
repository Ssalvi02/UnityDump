using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionController : MonoBehaviour
{
    public TextMeshPro txt;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshPro>();
        x = -1;
    }
}
