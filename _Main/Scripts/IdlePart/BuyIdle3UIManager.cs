using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyIdle3UIManager : MonoBehaviour
{
    BuyAreaUIManager buyAreaUIManager;
    BuyIdle2UIManager buyIdle2UIManager;
    GManager gManager;
    public GameObject tableUI, courtainUI, chairUI, watchUI, carpterUI, shelfUI, lampUI, computerUI, plantUI;
    public GameObject[] buyableObjects;
    public int currentBoughtIdle3Area = 0;
    bool fullOpen = false;
    bool isClose = true;
    bool isOpen = false;
    public GameObject nextLevelButton1, nextLevelButton2, nextLevelButton3;

    private void Start()
    {
        buyAreaUIManager = FindObjectOfType<BuyAreaUIManager>();
        buyIdle2UIManager = FindObjectOfType<BuyIdle2UIManager>();
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
            if (currentBoughtIdle3Area == 9)
            {
                FalseAllIdleArea();
                nextLevelButton1.SetActive(false);
                nextLevelButton2.SetActive(false);
                nextLevelButton3.SetActive(false);
                fullOpen = true;
                if (isClose)
                {
                    PlayerPrefs.SetInt("IdleArea", 0);
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
                    buyableObjects[7].gameObject.SetActive(false);
                    buyableObjects[8].gameObject.SetActive(false);
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

    void FalseAllIdleArea()
    {
        buyAreaUIManager.currentBoughtArea = 0;
        PlayerPrefs.SetInt("IsBought" + "TVUI", 0);
        PlayerPrefs.SetInt("IsBought" + "WindowsAndPictureUI", 0);
        PlayerPrefs.SetInt("IsBought" + "CarpetUI", 0);
        PlayerPrefs.SetInt("IsBought" + "ChairRightUI", 0);
        PlayerPrefs.SetInt("IsBought" + "CouchUI", 0);
        PlayerPrefs.SetInt("IsBought" + "LampUI", 0);
        PlayerPrefs.SetInt("IsBought" + "PlantUI", 0);

        buyIdle2UIManager.currentBoughtIdle2Area = 0;
        PlayerPrefs.SetInt("IsBought2" + "BedUI", 0);
        PlayerPrefs.SetInt("IsBought2" + "CourtainUI", 0);
        PlayerPrefs.SetInt("IsBought2" + "LampUI", 0);
        PlayerPrefs.SetInt("IsBought2" + "PlantUI", 0);
        PlayerPrefs.SetInt("IsBought2" + "TableUI", 0);
        PlayerPrefs.SetInt("IsBought2" + "PictureUI", 0);
        PlayerPrefs.SetInt("IsBought2" + "CarpetUI", 0);

        currentBoughtIdle3Area = 0;
        PlayerPrefs.SetInt("IsBought3" + "TableUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "CourtainUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "ChairUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "WatchUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "CarpterUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "ShelfUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "LampUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "ComputerUI", 0);
        PlayerPrefs.SetInt("IsBought3" + "PlantUI", 0);
    }
}