using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class transform : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject[] AudioSourcePosition;
    public GameObject[] ScreenPosition;
    public GameObject AudioSource;
    public GameObject[] RawImage;
    public GameObject[] cubes;
    public GameObject[] cube;
    public Text[] texts;
    private double[] dAudio;
    private double[] dScreen;
    private float audioVolume;
    private float listenerVolume; 
    public Color colorStart = new Color(0f/255f,255f/255f,255f/255f,255f/255f);
    public Color colorEnd = Color.blue; 

    // Start is called before the first frame update
    void Start()
    {
        dAudio = new double[3];
        dScreen = new double[3];
    }

    // Update is called once per frame
    void Update()
    {
        int index1 = neareastAudioSource();
        //int index2 = neareastScreen();
        //Debug.Log("AudioSource: "+index1);
        //Debug.Log("Screen: "+index2);
        AudioSource.transform.position = AudioSourcePosition[index1].transform.position;
        
        if (dAudio[index1] > 10)
            AudioSource.GetComponent<AudioSource>().volume = 1f;
        else
            AudioSource.GetComponent<AudioSource>().volume = 0.5f/(float)(1 - dAudio[index1]/20);
        audioVolume = AudioSource.GetComponent<AudioSource>().volume;
        listenerVolume = audioVolume * (float)(1 - dAudio[index1]/20);
        
        for (int i = 0; i < 3; i++)
            cubes[i].SetActive(index1 == i);
        
        if (index1 == 0)
        {
            cube[0].GetComponent<MeshRenderer>().material.color = Color.Lerp(colorStart, colorEnd, (AudioSource.GetComponent<AudioSource>().volume - 0.5f)/0.5f);
            cube[1].GetComponent<MeshRenderer>().material.color = Color.Lerp(colorStart, colorEnd, (AudioSource.GetComponent<AudioSource>().volume - 0.5f)/0.5f);
        }
        else
            cube[index1 + 1].GetComponent<MeshRenderer>().material.color = Color.Lerp(colorStart, colorEnd, (AudioSource.GetComponent<AudioSource>().volume - 0.5f)/0.5f);
        
        texts[0].text = "Audio Source ID: " + index1.ToString();
        texts[1].text = "Audio Source Volume: " + audioVolume.ToString("0.##%");
        texts[2].text = "Listener Volume: " + listenerVolume.ToString("0.##%");
        texts[3].text = "Screen ID: ";

        for (int i = 0; i < 3; i++)
        {
            Vector3 camToScreen = ScreenPosition[i].transform.position - MainCam.transform.position;
            if (Vector3.Angle(MainCam.transform.forward, camToScreen) <= 60f)
            {
                RawImage[i].SetActive(true);
                texts[3].text = texts[3].text + i.ToString() + " ";
            }
        }
    }

    public int neareastAudioSource()
    {
        for (int i = 0; i < 3; i++)
            dAudio[i] = distance3D(MainCam.transform.position, AudioSourcePosition[i].transform.position);
        if (dAudio[0] < dAudio[1])
        {
            if (dAudio[0] < dAudio[2])
                return 0;
            else
                return 2;
        }
        else
        {
            if (dAudio[1] < dAudio[2])
                return 1;
            else
                return 2;
        }
    }

    public int neareastScreen()
    {
        for (int i = 0; i < 3; i++)
            dScreen[i] = distance3D(MainCam.transform.position, ScreenPosition[i].transform.position);
        if (dScreen[0] < dScreen[1])
        {
            if (dScreen[0] < dScreen[2])
                return 0;
            else
                return 2;
        }
        else
        {
            if (dScreen[1] < dScreen[2])
                return 1;
            else
                return 2;
        }
    }

    public double distance3D(Vector3 a, Vector3 b)
    {
        return System.Math.Sqrt((double)((a.x-b.x)*(a.x-b.x)+(a.y-b.y)*(a.y-b.y)+(a.z-b.z)*(a.z-b.z)));
    }
}
