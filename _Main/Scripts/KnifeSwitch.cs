using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwitch : MonoBehaviour
{
    public GameObject knife1, knife2, knife3, knife4;
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            knife1.SetActive(true);
            knife2.SetActive(false);
            knife3.SetActive(false);
            knife4.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {

            knife1.SetActive(false);
            knife2.SetActive(true);
            knife3.SetActive(false);
            knife4.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {

            knife1.SetActive(false);
            knife2.SetActive(false);
            knife3.SetActive(true);
            knife4.SetActive(false);
        }
        if (Input.GetKeyDown("4"))
        {

            knife1.SetActive(false);
            knife2.SetActive(false);
            knife3.SetActive(false);
            knife4.SetActive(true);
        }
    }
}
