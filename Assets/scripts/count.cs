using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public int count_total;
    public Text count_txt1;
    public Text count_txt2;
    public static count instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        count_txt1.text = count_total.ToString();
        count_txt2.text = count_total.ToString();

    }
}
