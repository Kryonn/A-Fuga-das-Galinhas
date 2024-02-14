using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arvore : MonoBehaviour
{
    public List<GameObject> Botao;
    public GameObject galinha_player;
    public GameObject galinha_npc;
    public int pos;
    public bool allow = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        jogada();
    }

    public node a;

    public class node
    {
        public int score;
        public int [] board = new int[9];
        public node [] filho = new node[9];
    }

    public int VerificaVitoria(int [] Board)
    {
        if ((Board[0] == Board[1]) && (Board[1] == Board[2]) && (Board[2] != 0))
        {
            return Board[0];
        }

        if ((Board[3] == Board[4]) && (Board[4] == Board[5]) && (Board[5] != 0))
        {
            return Board[3];
        }

        if ((Board[6] == Board[7]) && (Board[7] == Board[8]) && (Board[8] != 0))
        {
            return Board[6];
        }

        if ((Board[0] == Board[3]) && (Board[3] == Board[6]) && (Board[6] != 0))
        {
            return Board[0];
        }

        if ((Board[1] == Board[4]) && (Board[4] == Board[7]) && (Board[7] != 0))
        {
            return Board[1];
        }

        if ((Board[2] == Board[5]) && (Board[5] == Board[8]) && (Board[8] != 0))
        {
            return Board[2];
        }

        if ((Board[0] == Board[4]) && (Board[4] == Board[8]) && (Board[8] != 0))
        {
            return Board[0];
        }

        if ((Board[2] == Board[4]) && (Board[4] == Board[6]) && (Board[6] != 0))
        {
            return Board[2];
        }

        return 0;
    }

    public void constroi(ref node a, int [] vet, int valor)
    {
        int cont=0;
        int i,j;
        node b = new node();
        int [] vetor = new int[9];
        for(i=0;i<9;i++)
        {
            b.board[i] = vet[i];
            b.filho[i] = null;
        }
        b.score = VerificaVitoria(vet);
        a = b;
        if(VerificaVitoria(vet) == 0)
        {
            for(i=0;i<9;i++)
            {
                if(vet[i] == 0)
                {
                    
                    for(j=0;j<9;j++)
                    {
                        vetor[j] = vet[j];
                    }
                    vetor[i] = valor;
                    constroi(ref b.filho[cont], vetor, -valor);
                    cont++;
                }
            }
        }
    }


    public int numero_de_derrotas(node a)
    {
        int derrotas=0;
        int i;
        if(a == null)
        {
            return 0;
        }
        else
        {
            if(a.score == -1)
            {
                derrotas = derrotas + 1;
            }
            for(i=0;i<9;i++)
            {
                derrotas = derrotas + numero_de_derrotas(a.filho[i]);
            }
            return derrotas;
        }
    }

    int escolhe(node a)
    {
        int i;
        int menor = 1000;
        int posicao = 0;
        
        if(((a.board[0] == a.board[1]) && a.board[1] == 1) && a.board[2] == 0)
        {
            return 2;
        }
        if(((a.board[2] == a.board[1]) && a.board[1] == 1) && a.board[0] == 0)
        {
            return 0;
        }
        if(((a.board[0] == a.board[2]) && a.board[2] == 1) && a.board[1] == 0)
        {
            return 1;
        }
        
        if(((a.board[3] == a.board[4]) && a.board[4] == 1) && a.board[5] == 0)
        {
            return 5;
        }
        if(((a.board[5] == a.board[4]) && a.board[4] == 1) && a.board[3] == 0)
        {
            return 3;
        }
        if(((a.board[3] == a.board[5]) && a.board[5] == 1) && a.board[4] == 0)
        {
            return 4;
        }
        
        if(((a.board[6] == a.board[7]) && a.board[7] == 1) && a.board[8] == 0)
        {
            return 8;
        }
        if(((a.board[8] == a.board[7]) && a.board[7] == 1) && a.board[6] == 0)
        {
            return 6;
        }
        if(((a.board[6] == a.board[8]) && a.board[8] == 1) && a.board[7] == 0)
        {
            return 7;
        }
        
        if(((a.board[0] == a.board[3]) && a.board[3] == 1) && a.board[6] == 0)
        {
            return 6;
        }
        if(((a.board[0] == a.board[6]) && a.board[6] == 1) && a.board[3] == 0)
        {
            return 3;
        }
        if(((a.board[3] == a.board[6]) && a.board[6] == 1) && a.board[0] == 0)
        {
            return 0;
        }
        
        
        if(((a.board[1] == a.board[4]) && a.board[4] == 1) && a.board[7] == 0)
        {
            return 7;
        }
        if(((a.board[1] == a.board[7]) && a.board[7] == 1) && a.board[4] == 0)
        {
            return 4;
        }
        if(((a.board[4] == a.board[7]) && a.board[7] == 1) && a.board[1] == 0)
        {
            return 1;
        }
        
        
        if(((a.board[2] == a.board[5]) && a.board[5] == 1) && a.board[8] == 0)
        {
            return 8;
        }
        if(((a.board[2] == a.board[8]) && a.board[8] == 1) && a.board[5] == 0)
        {
            return 5;
        }
        if(((a.board[5] == a.board[8]) && a.board[8] == 1) && a.board[2] == 0)
        {
            return 2;
        }
        
        
        if(((a.board[0] == a.board[4]) && a.board[4] == 1) && a.board[8] == 0)
        {
            return 8;
        }
        if(((a.board[0] == a.board[8]) && a.board[8] == 1) && a.board[4] == 0)
        {
            return 4;
        }
        if(((a.board[4] == a.board[8]) && a.board[8] == 1) && a.board[0] == 0)
        {
            return 0;
        }
        
        
        if(((a.board[2] == a.board[4]) && a.board[4] == 1) && a.board[6] == 0)
        {
            return 6;
        }
        if(((a.board[2] == a.board[6]) && a.board[6] == 1) && a.board[4] == 0)
        {
            return 4;
        }
        if(((a.board[4] == a.board[6]) && a.board[6] == 1) && a.board[2] == 0)
        {
            return 2;
        }
        
        ///////////////////////////////////////////////////////////////////////////
        
        if(((a.board[0] == a.board[1]) && a.board[1] != 0) && a.board[2] == 0)
        {
            return 2;
        }
        if(((a.board[2] == a.board[1]) && a.board[1] != 0) && a.board[0] == 0)
        {
            return 0;
        }
        if(((a.board[0] == a.board[2]) && a.board[2] != 0) && a.board[1] == 0)
        {
            return 1;
        }
        
        if(((a.board[3] == a.board[4]) && a.board[4] != 0) && a.board[5] == 0)
        {
            return 5;
        }
        if(((a.board[5] == a.board[4]) && a.board[4] != 0) && a.board[3] == 0)
        {
            return 3;
        }
        if(((a.board[3] == a.board[5]) && a.board[5] != 0) && a.board[4] == 0)
        {
            return 4;
        }
        
        if(((a.board[6] == a.board[7]) && a.board[7] != 0) && a.board[8] == 0)
        {
            return 8;
        }
        if(((a.board[8] == a.board[7]) && a.board[7] != 0) && a.board[6] == 0)
        {
            return 6;
        }
        if(((a.board[6] == a.board[8]) && a.board[8] != 0) && a.board[7] == 0)
        {
            return 7;
        }
        
        if(((a.board[0] == a.board[3]) && a.board[3] != 0) && a.board[6] == 0)
        {
            return 6;
        }
        if(((a.board[0] == a.board[6]) && a.board[6] != 0) && a.board[3] == 0)
        {
            return 3;
        }
        if(((a.board[3] == a.board[6]) && a.board[6] != 0) && a.board[0] == 0)
        {
            return 0;
        }
        
        
        if(((a.board[1] == a.board[4]) && a.board[4] != 0) && a.board[7] == 0)
        {
            return 7;
        }
        if(((a.board[1] == a.board[7]) && a.board[7] != 0) && a.board[4] == 0)
        {
            return 4;
        }
        if(((a.board[4] == a.board[7]) && a.board[7] != 0) && a.board[1] == 0)
        {
            return 1;
        }
        
        
        if(((a.board[2] == a.board[5]) && a.board[5] != 0) && a.board[8] == 0)
        {
            return 8;
        }
        if(((a.board[2] == a.board[8]) && a.board[8] != 0) && a.board[5] == 0)
        {
            return 5;
        }
        if(((a.board[5] == a.board[8]) && a.board[8] != 0) && a.board[2] == 0)
        {
            return 2;
        }
        
        
        if(((a.board[0] == a.board[4]) && a.board[4] != 0) && a.board[8] == 0)
        {
            return 8;
        }
        if(((a.board[0] == a.board[8]) && a.board[8] != 0) && a.board[4] == 0)
        {
            return 4;
        }
        if(((a.board[4] == a.board[8]) && a.board[8] != 0) && a.board[0] == 0)
        {
            return 0;
        }
        
        
        if(((a.board[2] == a.board[4]) && a.board[4] != 0) && a.board[6] == 0)
        {
            return 6;
        }
        if(((a.board[2] == a.board[6]) && a.board[6] != 0) && a.board[4] == 0)
        {
            return 4;
        }
        if(((a.board[4] == a.board[6]) && a.board[6] != 0) && a.board[2] == 0)
        {
            return 2;
        }
        
        ///////////////////////////////////////////////////////////////////////////
        for(i=0;i<9;i++)
        {
            if(numero_de_derrotas(a.filho[i]) < menor)
            {
                posicao = i;
                menor = numero_de_derrotas(a.filho[i]);
            }
        }
        return posicao;
    }

    public int jogada()
    {
        int acabou = 0;
        node a = new node();
        int [] board = new int [9];
        bool vez = true;
        for(int i=0;i<9;i++)
        {
            board[i] = 0;
        }
        while(acabou == 0)
        {
            if(vez == true)
            {
                for(int i=0;i<9;i++)
                {
                    if(board[i] == 0)
                    {
                        Botao[i].gameObject.SetActive (true);
                    }
                }
                while(allow == false)
                {

                }
                board[pos] = -1;
                acabou = VerificaVitoria(board);
                vez = false;
                allow = false;
            }
            else
            {
                a = null;
                constroi(ref a, board, 1);
                pos = escolhe(a);
                board[pos] = 1;
                if(pos == 0)
                {
                    Vector3 position = new Vector3(-7.15f, 3.08f);
                    Instantiate(galinha_npc, position, Quaternion.identity);
                }
                else
                {
                    if(pos == 1)
                    {
                        Vector3 position = new Vector3(-3.13f, 3.08f);
                        Instantiate(galinha_npc, position, Quaternion.identity);
                    }
                    else
                    {
                        if(pos == 2)
                        {
                            Vector3 position = new Vector3(0.52f, 3.08f);
                            Instantiate(galinha_npc, position, Quaternion.identity);
                        }
                        else
                        {
                            if(pos == 3)
                            {
                                Vector3 position = new Vector3(-7.15f, 0.14f);
                                Instantiate(galinha_npc, position, Quaternion.identity);
                            }
                            else
                            {
                                if(pos == 4)
                                {
                                    Vector3 position = new Vector3(-3.13f, 0.14f);
                                    Instantiate(galinha_npc, position, Quaternion.identity);
                                }
                                else
                                {
                                    if(pos == 5)
                                    {
                                        Vector3 position = new Vector3(0.52f, 0.14f);
                                        Instantiate(galinha_npc, position, Quaternion.identity);
                                    }
                                    else
                                    {
                                        if(pos == 6)
                                        {
                                            Vector3 position = new Vector3(-7.15f, -2.82f);
                                            Instantiate(galinha_npc, position, Quaternion.identity);
                                        }
                                        else
                                        {
                                            if(pos == 7)
                                            {
                                                Vector3 position = new Vector3(-3.13f, -2.82f);
                                                Instantiate(galinha_npc, position, Quaternion.identity);
                                            }
                                            else
                                            {
                                                Vector3 position = new Vector3(0.52f, -2.82f);
                                                Instantiate(galinha_npc, position, Quaternion.identity);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                acabou = VerificaVitoria(board);
                vez = true;
            }
        }
        return acabou;
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(7f);
    }

    public void b1()
    {
        Vector3 position = new Vector3(-7.15f, 3.08f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[0].gameObject.SetActive (false);
        pos = 0;
        allow = true;
    }

    public void b2()
    {
        Vector3 position = new Vector3(-3.13f, 3.08f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[1].gameObject.SetActive (false);
        pos = 1;
        allow = true;
    }

    public void b3()
    {
        Vector3 position = new Vector3(0.52f, 3.08f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[2].gameObject.SetActive (false);
        pos = 2;
        allow = true;
    }

    public void b4()
    {
        Vector3 position = new Vector3(-7.15f, 0.14f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[3].gameObject.SetActive (false);
        pos = 3;
        allow = true;
    }

    public void b5()
    {
        Vector3 position = new Vector3(-3.13f, 0.14f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[4].gameObject.SetActive (false);
        pos = 4;
        allow = true;
    }

    public void b6()
    {
        Vector3 position = new Vector3(0.52f, 0.14f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[5].gameObject.SetActive (false);
        pos = 5;
        allow = true;
    }

    public void b7()
    {
        Vector3 position = new Vector3(-7.15f, -2.82f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[6].gameObject.SetActive (false);
        pos = 6;
        allow = true;
    }

    public void b8()
    {
        Vector3 position = new Vector3(-3.13f, -2.82f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[7].gameObject.SetActive (false);
        pos = 7;
        allow = true;
    }

    public void b9()
    {
        Vector3 position = new Vector3(0.52f, -2.82f);
        Instantiate(galinha_player, position, Quaternion.identity);
        Botao[8].gameObject.SetActive (false);
        pos = 8;
        allow = true;
    }    

}
    