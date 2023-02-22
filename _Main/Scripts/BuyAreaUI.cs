using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyAreaUI : MonoBehaviour
{
    Button button;
    BuyAreaUIManager buyAreaUIManager;
    TextMeshProUGUI moneyAmount;
    public int needMoney;
    internal int isBought = 0;
    Image BG, picture, moneyBG;

    private void Awake()
    {
        isBought = PlayerPrefs.GetInt("IsBought" + transform.name);
    }
    private void Start()
    {
        moneyAmount = transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        moneyAmount.text = needMoney.ToString();
        buyAreaUIManager = FindObjectOfType<BuyAreaUIManager>();
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(SetMoneyNewArea);
        BG = transform.Find("BG").GetComponent<Image>();
        picture = transform.Find("Picturepng").GetComponent<Image>();
        moneyBG = transform.Find("MoneyBg").GetComponent<Image>();
    }
    private void Update()
    {
    }
    void SetMoneyNewArea()
    {
        if(MoneyManager.Instance.money >= needMoney)
        {
            MoneyManager.Instance.IncreaseMoneyAndWrite(-needMoney);
            BuyObject();
        }
        else
        {
            Vibrations.Failure();
        }
    }
    void BuyObject()
    {
        isBought = 1;
        PlayerPrefs.SetInt("IsBought" + transform.name, isBought);
        Debug.Log(PlayerPrefs.GetInt("IsBought"+ transform.name) + transform.name);
        switch (name)
        {
            case "WindowsAndPictureUI":
                buyAreaUIManager.buyableObjects[0].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[0].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
            case "CouchUI":
                buyAreaUIManager.buyableObjects[1].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[1].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
            case "CarpetUI":
                buyAreaUIManager.buyableObjects[2].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[2].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
            case "ChairRightUI":
                buyAreaUIManager.buyableObjects[3].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[3].transform.parent.Find("CanvasLeft").gameObject.SetActive(false);
                buyAreaUIManager.buyableObjects[3].transform.parent.Find("CanvasRight").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
            case "LampUI":
                buyAreaUIManager.buyableObjects[4].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[4].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
            case "PlantUI":
                buyAreaUIManager.buyableObjects[5].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[5].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
            case "TVUI":
                buyAreaUIManager.buyableObjects[6].gameObject.SetActive(true);
                buyAreaUIManager.buyableObjects[6].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyAreaUIManager.currentBoughtArea++;
                break;
        }
    }
}
