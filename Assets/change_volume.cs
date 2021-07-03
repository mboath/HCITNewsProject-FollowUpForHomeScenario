using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class change_volume : MonoBehaviour
{
    public GameObject sliderObj;
    public Slider mySlider;
    public GameObject play_pause;
    public GameObject panel1;

    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = 1f;
        sliderObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void appear_slider()
    {
        panel1.SetActive(false);
        sliderObj.SetActive(true);
    }

    public void con_sound()
    {
        play_pause.GetComponent<play_pause>().change_volume(mySlider.value);
    }
}
