using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_script : MonoBehaviour
{
    [SerializeField] Slider volumeslider;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_volume()
    {   
        AudioListener.volume = volumeslider.value;
        save();
    }

    private void load()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeslider.value);
    }
}
