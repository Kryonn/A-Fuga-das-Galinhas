using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_ac : MonoBehaviour
{
    public AudioSource fundo;
    public AudioSource music;
    public AudioClip [] musicas_de_fundo;
    public bool stop_music;
    start a;
    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<start>();
        AudioClip musica_de_fundo1 = musicas_de_fundo[0];
        fundo.clip = musica_de_fundo1;
        fundo.loop = true;
        fundo.Play();
    }

    void Update()
    {
        if(a.stop_sound == true)
        {
            fundo.Stop();
        }
    }

    public void SFX(AudioClip clip)
    {
        music.clip = clip;
        music.Play();
    }

    // Update is called once per frame
}
