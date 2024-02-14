using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class historia_ac : MonoBehaviour
{
    public AudioSource fundo;
    public AudioSource music;
    public AudioClip [] musicas_de_fundo;
    public bool stop_music;
    start2 start2;
    // Start is called before the first frame update
    void Start()
    {
        start2 = FindObjectOfType<start2>();
        AudioClip musica_de_fundo1 = musicas_de_fundo[0];
        fundo.clip = musica_de_fundo1;
        fundo.loop = true;
        fundo.Play();
    }

    void Update()
    {
        if(start2.stop_music == true)
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
