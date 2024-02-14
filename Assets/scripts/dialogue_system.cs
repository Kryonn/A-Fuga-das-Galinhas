using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum estado
{
    desabilitado, espera, escrevendo
}

public class dialogue_system : MonoBehaviour
{
    public dialogue_data Dialogue_data;
    estado state;
    
    int current = 0;
    //bool acabou = false;
    animation_text typeText;

    void awake()
    {
        typeText = FindObjectOfType<animation_text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = estado.desabilitado;
        Next();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(state == estado.desabilitado) return;

        switch(state)
        {
            case estado.espera:
                Espera();
                break;
            case estado.escrevendo:
                Escrevendo();
                break;
        }
    }

    //public IEnumerator start_dialogue()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Next();
    //}

    public void Next()
    {
        typeText.full_text = Dialogue_data.talkScript[current++].text;
        //if(current == Dialogue_data.talkScript.Count) //acabou = true;
        typeText.start_typing();    
        state = estado.escrevendo;
    }

    public void Espera()
    {

    }

    public void Escrevendo()
    {
        
    }

    
}
