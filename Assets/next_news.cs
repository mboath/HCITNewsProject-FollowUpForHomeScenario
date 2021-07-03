using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class next_news : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyButtonEvent()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
