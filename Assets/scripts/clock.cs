using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    public Text tempo_txt;
    public float tempo = 20;
    public bool go;
    player a;
    // Start is called before the first frame update
    void Start()
    {
        go = false;
        a = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tempo > 0)
        {
            tempo = tempo - Time.deltaTime;
            tempo_txt.text = tempo.ToString("F0");
            if(a.add == true)
            {
                tempo = tempo + 10;
                a.add = false;
            }
        }
        else
        {
            if(a.sound_effect == true)
            {
                go = true;
            }
            else
            {
                go = false;
            }
            
        }
    }
}
