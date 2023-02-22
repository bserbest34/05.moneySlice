using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyIdle2UIManager : MonoBehaviour
{
    GManager gManager;
    public GameObject bedUI, courtainUI, lampUI, plantUI, tableUI, pictureUI, carpetUI;
    public GameObject[] buyableObjects;
    public int currentBoughtIdle2Area = 0;
    bool fullOpen = false;
    bool isClose = true;
    bool isOpen = false;
    public GameObject nextLevelButton1, nextLevelButton2, nextLevelButton3;

    private void Start()
    {
        gManager = FindObjectOfType<GManager>();
    }
    private void FixedUpdate()
    {
        StartCoroutine(FullOpenAnim());
    }
    IEnumerator FullOpenAnim()
    {
        if (!fullOpen)
        {
            if (currentBoughtIdle2Area == 7)
            {
                nextLevelButton1.SetActive(false);
                nextLevelButton2.SetActive(false);
                nextLevelButton3.SetActive(false);
                fullOpen = true;
                if (isClose)
                {
                    PlayerPrefs.SetInt("IdleArea", gManager.whichIdle + 1);
                    gManager.whichIdle = PlayerPrefs.GetInt("IdleArea");
                    isClose = false;
                    yield return new WaitForSeconds(2.5f);
                    buyableObjects[0].gameObject.SetActive(false);
                    buyableObjects[1].gameObject.SetActive(false);
                    buyableObjects[2].gameObject.SetActive(false);
                    buyableObjects[3].gameObject.SetActive(false);
                    buyableObjects[4].gameObject.SetActive(false);
                    buyableObjects[5].gameObject.SetActive(false);
                    buyableObjects[6].gameObject.SetActive(false);
                    yield return new WaitForSeconds(1);
                }
                for (int i = 0; i < buyableObjects.Length; i++)
                {
                    buyableObjects[i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.3f);
                }
                yield return new WaitForSeconds(1);
                UIManager.Instance.SuccesGame();
            }
        }
    }
}