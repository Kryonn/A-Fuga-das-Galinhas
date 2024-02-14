using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private GameObject current;
    [SerializeField] private BoxCollider2D playerCollider;
    public List<GameObject> scene;
    pause a;
    public bool add;
    public bool res;

    public bool isjumping;
    public bool plat3;
    public bool start;
    public bool allow;
    public int cor;
    public bool ok;
    public fila f;
    public float y;
    public float y2;
    public bool hit;
    public List<int> pontuacoes;
    public GameObject go_screen;
    public bool go_pause;
    public GameObject pause_screen;
    public bool go;
    public bool freeze;
    public bool pre_dialogo;
    bool correr;
    clock clk;
    public AudioClip hit_sound;
    public AudioClip collect_sound;
    public AudioClip clock_sound;
    public AudioClip go_sound;
    public audio_controller audiocontroller;
    public bool stop_music;
    public bool sound_effect;
    public bool despause;
    


    private Rigidbody2D rig;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        start = true;
        go_pause = false;
        f.cria();
        go = false;
        pre_dialogo = true;
        correr = true;
        add = false;
        stop_music = false;
        sound_effect = true;
        despause = false;
    }

    // Update is called once per frame
    void Update()
    {
        clk = FindObjectOfType<clock>();
        StartCoroutine(correrf());
        Move();
        Jump();
        a = FindObjectOfType<pause>();

        y = rig.position.y;
        y2 = rig.position.y;
        if(rig.position.y >= 2)
        {
            y = 2.933118f;
        }
        else
        {
            if(rig.position.y < 2 && rig.position.y > -1)
            {
                y = -0.1473702f;
            }
            else
            {
                y = -3.042978f;
            }
        }
        


        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(current != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
        
        if(allow == true)
        {
            audiocontroller.SFX(collect_sound);
            f.Insere(cor, out ok);
            allow = false;
        }

        if(clk.go == true)
        {
            audiocontroller.SFX(go_sound);
            sound_effect = false;
            dead();
        }

        if(hit == true)
        {
            
            f.Retira(out cor, out ok);
            if(ok == false)
            {
                audiocontroller.SFX(go_sound);
                dead();
                ok = true;
                hit = false;
            }
            else
            {
                audiocontroller.SFX(hit_sound);
                StartCoroutine(hit_anim());
                hit = false;
            }
        }

        escape();
        pause();

        
    }

    void Move()
    {
        if(start == true)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
            
    }


    void Jump()
    {
        if((Input.GetButtonDown("Jump") && isjumping == false && plat3 == false && rig.velocity.y == 0))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            isjumping = false;
            current = collision.gameObject;
        }
        else
        {
            if(collision.gameObject.layer == 10)
            {
                isjumping = false;
                plat3 = true;
                current = collision.gameObject;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            isjumping = true;
            current = null;
        }
        else
        {
            if(collision.gameObject.layer == 10)
            {
                isjumping = true;
                plat3 = false;
                current = null;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 15)
        {
            allow = true;
            cor = 1;
        }
        else
        {
            if(collider.gameObject.layer == 16)
            {
                allow = true;
                cor = 2;
            }
            else
            {
                if(collider.gameObject.layer == 17)
                {
                    allow = true;
                    cor = 3;
                }      
                else
                {
                    if(collider.gameObject.layer == 18)
                {
                    allow = true;
                    cor = 4;
                }
                }
            }
        }
        if(collider.gameObject.layer == 4)
        {
            hit = true;
        }
        if(collider.gameObject.layer == 19)
        {
            audiocontroller.SFX(clock_sound);
            add = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 15 || collider.gameObject.layer == 16 || collider.gameObject.layer == 17 || collider.gameObject.layer == 18)
        {
            allow = false;
            cor = 0;
        }
        if(collider.gameObject.layer == 4)
        {
            hit = false;
        }
    }


    

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = current.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private IEnumerator hit_anim()
    {
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("hit", false);
    }

    public void dead()
    {
        go_pause = true;
        go = true;
        go_screen.SetActive(true); 
        stop_music = true;
    }

    public void restart()
    {
        SceneManager.LoadScene("Jogo");
        stop_music = false;
    }

    public void pause()
    {
        if(go == false)
        {
            if(a.on == true)
            {
                pause_screen.SetActive(true);
            }
            else
            {
                pause_screen.SetActive(false);
            }
        }
    }


    public void main_menu1()
    {
        SceneManager.LoadScene("start");
        go = false;
        go_pause = false;
        despause = true;
    }

    public void main_menu2()
    {
        SceneManager.LoadScene("start");
        a.pausar();
        go = false;
        go_pause = false;
        despause = true;
    }

    public void resume()
    {
        res = true;
    }

    private IEnumerator correrf()
    {
        if(correr == true)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Vector3 movement = new Vector3 (1f, 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            yield return new WaitForSeconds(1.4f);
            correr = false;
        }
        
    }

    public void escape()
    {
        if(a.esc == true)
        {
            scene[0].SetActive(false);
            scene[1].SetActive(false);
            scene[2].SetActive(false);
            a.esc = false;
        }
    }

    public void option_menu()
    {
        pause_screen.SetActive(false);
        scene[0].SetActive(true);
    }

    public void chicken_score()
    {
        scene[0].SetActive(false);
        scene[1].SetActive(true);
    }

    public void back_score_option_menu()
    {
        scene[1].SetActive(false);
        scene[0].SetActive(true);
    }

    public void sound_menu()
    {
        scene[2].SetActive(true);
        scene[0].SetActive(false);
    }

    public void back_sound_option_menu()
    {
        scene[2].SetActive(false);
        scene[0].SetActive(true);
    }

    public void back_pause_menu()
    {
        pause_screen.SetActive(true);
        scene[0].SetActive(false);
    }


    
    

}
