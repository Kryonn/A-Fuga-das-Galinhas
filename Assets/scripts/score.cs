using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int score_total;
    public Text score_txt1;
    public Text score_txt2;
    public static score instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        score_txt1.text = score_total.ToString();
        score_txt2.text = score_total.ToString();
    }
}
