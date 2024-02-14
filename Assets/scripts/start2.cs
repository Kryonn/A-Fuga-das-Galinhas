using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class start2 : MonoBehaviour
{
    public bool start_walk;
    public float tempo = 1;
    private Animator anim;
    public float Speed;
    public bool start_dialog = false;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;
    public GameObject screen6;
    public GameObject screen7;
    public GameObject screen8;
    public GameObject screen9;
    public GameObject screen10;
    public List<GameObject> button;
    animation_text text;
    public string txt;
    public TextMeshProUGUI texto;
    bool start_walk2 = false;
    public historia_ac historia_ac;
    public AudioClip d1;
    public AudioClip d2;
    public AudioClip d3;
    public AudioClip d4;
    public AudioClip d5;
    public AudioClip d6;
    public AudioClip d7;
    public AudioClip d8;
    public AudioClip d9;
    public bool stop_music;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        text = FindObjectOfType<animation_text>();
        start_walk = true;
        stop_music = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(walk());
        StartCoroutine(walk1());
        //dialogue1();
    }

    private IEnumerator walk()
    {
        if(start_walk == true)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Vector3 movement = new Vector3 (1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            yield return new WaitForSeconds(0.9f);
            start_walk = false;
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
            historia_ac.SFX(d1);
            yield return new WaitForSeconds(0.5f);
            dialogue1();
        }
    }

    public void dialogue1()
    {
        
        screen1.SetActive(true);
        screen2.SetActive(true);
        button[0].gameObject.SetActive(true);
    }

    public void dialogue2()
    {
        historia_ac.SFX(d2);
        button[0].gameObject.SetActive(false);
        screen2.SetActive(false);
        screen3.SetActive(true);
        button[1].gameObject.SetActive(true);
    }

    public void dialogue3()
    {
        historia_ac.SFX(d3);
        button[1].gameObject.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(true);
        button[2].gameObject.SetActive(true);
    }

    public void dialogue4()
    {
        historia_ac.SFX(d4);
        button[2].gameObject.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(true);
        button[3].gameObject.SetActive(true);
    }

    public void dialogue5()
    {
        historia_ac.SFX(d5);
        button[3].gameObject.SetActive(false);
        screen5.SetActive(false);
        screen6.SetActive(true);
        button[4].gameObject.SetActive(true);
    }

    public void dialogue6()
    {
        historia_ac.SFX(d6);
        button[4].gameObject.SetActive(false);
        screen6.SetActive(false);
        screen7.SetActive(true);
        button[5].gameObject.SetActive(true);
    }

    public void dialogue7()
    {
        historia_ac.SFX(d7);
        button[5].gameObject.SetActive(false);
        screen7.SetActive(false);
        screen8.SetActive(true);
        button[6].gameObject.SetActive(true);
    }

    public void dialogue8()
    {
        historia_ac.SFX(d8);
        button[6].gameObject.SetActive(false);
        screen8.SetActive(false);
        screen9.SetActive(true);
        button[7].gameObject.SetActive(true);
    }

    public void dialogue9()
    {
        historia_ac.SFX(d9);
        button[7].gameObject.SetActive(false);
        screen9.SetActive(false);
        screen10.SetActive(true);
        button[8].gameObject.SetActive(true);
    }

    public void dialogue10()
    {
        // volta a andar
        stop_music = true;
        button[8].gameObject.SetActive(false);
        screen10.SetActive(false);
        anim.SetBool("idle", false);
        anim.SetBool("walk", true);
        start_walk2 = true;
    }

    private IEnumerator walk1()
    {
        if(start_walk2 == true)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Vector3 movement = new Vector3 (1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("jogo");
            start_walk2 = false;
        }
        
    }


    /*private IEnumerator dialogo()
    {
        if(start_dialog == true)
        {
            
        }
    }*/
}
