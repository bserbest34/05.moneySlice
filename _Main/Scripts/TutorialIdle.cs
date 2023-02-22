using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIdle : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.GetInt("IdleTutorial", 0);

        if(PlayerPrefs.GetInt("IdleTutorial") == 1)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (transform.parent.parent.Find("Couch").transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(false);
            PlayerPrefs.SetInt("IdleTutorial", 1);
        }
    }
}
