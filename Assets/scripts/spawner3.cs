using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner3 : MonoBehaviour
{
    [SerializeField] GameObject[] obstpre;
    [SerializeField] float t1, t2;
    public int temp_min;
    public int temp_max;
    [SerializeField] int t3, t4, plat;
    player a;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObsSpawn());
        a = FindObjectOfType<player>();
    }




    IEnumerator ObsSpawn()
    {
        float y;
        while(true)
        {
            //if(a.pre_dialogo != true)
            //{
                plat = Random.Range(t3, t4);
                if(plat == 1)
                {
                    y = -2.89f;
                }
                else
                {
                    if(plat == 2)
                    {
                        y = 0.11f;
                    }
                    else
                    {
                        y = 3.17f;
                    }
                }
                var wanted = Random.Range(t1, t2);
                var position = new Vector3(wanted, y);
                GameObject gameObject = Instantiate(obstpre[Random.Range(0, obstpre.Length)], position, Quaternion.identity); 
                yield return new WaitForSeconds(Random.Range(temp_min, temp_max));
                Destroy(gameObject, 6f);
            //}
        }
    }
}

