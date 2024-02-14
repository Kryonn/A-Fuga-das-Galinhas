using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject start1_screen;
    public GameObject start2_screen;
    public GameObject start3_screen;
    public GameObject start4_screen;
    public GameObject start5_screen;
    public GameObject start6_screen;
    public List<GameObject> botao;
    public float Speed;
    public bool start_walk;
    public float tempo = 1;
    private Animator anim;
    public start_ac start_ac;
    public AudioClip start_sound;
    public bool stop_sound;
    // Start is called before the first frame update
    void Start()
    {
        start1_screen.SetActive(true);
        anim = GetComponent<Animator>();
        start_walk = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        StartCoroutine(walk());
    }

    public void main_menu()
    {
        start1_screen.SetActive(false);
        start2_screen.SetActive(true);
    }

    public void star()
    {
        //SceneManager.LoadScene("Jogo");
        start_ac.SFX(start_sound);
        for(int i=0;i<4;i++)
        {
            botao[i].SetActive(false);
        }
        start2_screen.SetActive(false);
        start6_screen.SetActive(true);
        stop_sound = true;
        start_walk = true;
    }

    public void options()
    {
        start2_screen.SetActive(false);
        start3_screen.SetActive(true);
    }

    public void control()
    {
        start4_screen.SetActive(true);
        start3_screen.SetActive(false);
    }

    public void back_to_main()
    {
        start3_screen.SetActive(false);
        start2_screen.SetActive(true);
        start5_screen.SetActive(false);
    }

    public void back_to_option()
    {
        start4_screen.SetActive(false);
        start3_screen.SetActive(true);
    }

    public void credits()
    {
        start5_screen.SetActive(true);
        start2_screen.SetActive(false);
    }

    /*void Move()
    {
        if(start_walk == true)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Vector3 movement = new Vector3 (1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
        }
        
    }*/

    private IEnumerator walk()
    {
        if(start_walk == true)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Vector3 movement = new Vector3 (1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            yield return new WaitForSeconds(1.8f);
            SceneManager.LoadScene("historia");
            
        }
    }


}
