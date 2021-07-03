using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class play_pause : MonoBehaviour
{
    private bool ifPlay = false;
    private int index = 0;
    public AudioSource[] music;
    public Sprite play;
    public Sprite pause;

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
        ifPlay = !ifPlay;
        if (ifPlay)
        {
            music[index].Play();
            GetComponent<Image>().sprite = pause;
        }
        else
        {
            music[index].Stop();
            GetComponent<Image>().sprite = play;
        }    
    }

    public void change_volume(float f)
    {
        music[index].volume = f;
    }

    public void stop()
    {
        music[index].Stop();
    }

    public void next_news(int i)
    {
        index = i;
        music[index].Play();
    }
}
