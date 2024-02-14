using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class animation_text : MonoBehaviour
{
    public float delay = 0.05f;
    public TextMeshProUGUI textObject;
    public string full_text;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TypeText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TypeText()
    {
        textObject.text = full_text;
        textObject.maxVisibleCharacters = 0;
        for(int i = 0; i <= textObject.text.Length; i++) {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delay);
        }
    }


    public void start_typing()
    {
        StartCoroutine(TypeText());
    }
}
