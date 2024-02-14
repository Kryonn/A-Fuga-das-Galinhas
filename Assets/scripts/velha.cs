/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class velha : MonoBehaviour
{
    public GameObject galinha_player;
    public GameObject galinha_bot;
    public List<GameObject> Botao;
    public int posicao;
    public List<int> posicoes;
    arvore arv;
    public bool allow;
    



    // Start is called before the first frame update
    void Start()
    {
        arv = FindObjectOfType<arvore>();
        Botao[0].gameObject.SetActive (false);
        Botao[1].gameObject.SetActive (false);
        Botao[2].gameObject.SetActive (false);
        Botao[3].gameObject.SetActive (false);
        Botao[4].gameObject.SetActive (false);
        Botao[5].gameObject.SetActive (false);
        Botao[6].gameObject.SetActive (false);
        Botao[7].gameObject.SetActive (false);
        Botao[8].gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        allow = arv.vez;
        if(allow = true)
        {
            Botao[0].gameObject.SetActive (true);
            Botao[1].gameObject.SetActive (true);
            Botao[2].gameObject.SetActive (true);
            Botao[3].gameObject.SetActive (true);
            Botao[4].gameObject.SetActive (true);
            Botao[5].gameObject.SetActive (true);
            Botao[6].gameObject.SetActive (true);
            Botao[7].gameObject.SetActive (true);
            Botao[8].gameObject.SetActive (true);
        }
    }

    public void b1()
    {
        Vector3 position = new Vector3(-7.15f, 3.08f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[0].gameObject.SetActive (false);
        posicoes[0] = 1;
        posicao = 0;
        bot_turn = true;
    }

    public void b2()
    {
        Vector3 position = new Vector3(-3.13f, 3.08f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[1].gameObject.SetActive (false);
        posicoes[1] = 1;
    }

    public void b3()
    {
        Vector3 position = new Vector3(0.52f, 3.08f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[2].gameObject.SetActive (false);
        posicoes[2] = 1;
    }

    public void b4()
    {
        Vector3 position = new Vector3(-7.15f, 0.14f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[3].gameObject.SetActive (false);
        posicoes[3] = 1;
    }

    public void b5()
    {
        Vector3 position = new Vector3(-3.13f, 0.14f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[4].gameObject.SetActive (false);
        posicoes[4] = 1;
    }

    public void b6()
    {
        Vector3 position = new Vector3(0.52f, 0.14f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[5].gameObject.SetActive (false);
        posicoes[5] = 1;
    }

    public void b7()
    {
        Vector3 position = new Vector3(-7.15f, -2.82f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[6].gameObject.SetActive (false);
        posicoes[6] = 1;
    }

    public void b8()
    {
        Vector3 position = new Vector3(-3.13f, -2.82f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[7].gameObject.SetActive (false);
        posicoes[7] = 1;
    }

    public void b9()
    {
        Vector3 position = new Vector3(0.52f, -2.82f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[8].gameObject.SetActive (false);
        posicoes[8] = 1;
    }
}
*/