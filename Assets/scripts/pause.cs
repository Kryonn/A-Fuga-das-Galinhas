using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool on;
    public bool on1;
    public bool go_pause;
    public bool esc;

    player a;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        on = false;
        on1 = false;
        a = FindObjectOfType<player>();
        esc = false;
    }

    // Update is called once per frame
    void Update()
    {
        go_pause = a.go_pause;
        if(Input.GetKeyDown(KeyCode.Escape) || a.res == true || a.despause == true)
        {
            pausar();
            a.res = false;
            a.despause = false;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                esc = true;
            }
        }
        
        if(a.go == true)
        {
            go_pausar1();
        }
        else
        {
            if(!on)
            {
                go_pausar2();
            }
            
        }

    }

    public void pausar()
    {
        if(on == false)
        {
            Time.timeScale = 0f;
            on = true;
        }
        else
        {
            Time.timeScale = 1f;
            on = false;
        }
    }

    public void go_pausar1()
    {
        Time.timeScale = 0f;     
    }

    public void go_pausar2()
    {
        Time.timeScale = 1f;     
    }
}
