using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyIdle2UI : MonoBehaviour
{
    Button button;
    BuyIdle2UIManager buyIdle2UIManager;
    TextMeshProUGUI moneyAmount;
    public int needMoney;
    internal int isBoughtIdle2 = 0;

    private void Awake()
    {
        isBoughtIdle2 = PlayerPrefs.GetInt("IsBought2" + transform.name);
    }
    private void Start()
    {
        moneyAmount = transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        moneyAmount.text = needMoney.ToString();
        buyIdle2UIManager = FindObjectOfType<BuyIdle2UIManager>();
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(SetMoneyNewArea);
    }
    void SetMoneyNewArea()
    {
        if (MoneyManager.Instance.money >= needMoney)
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
        isBoughtIdle2 = 1;
        PlayerPrefs.SetInt("IsBought2" + transform.name, isBoughtIdle2);
        Debug.Log(PlayerPrefs.GetInt("IsBought2" + transform.name));
        switch (name)
        {
            case "BedUI":
                buyIdle2UIManager.buyableObjects[0].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[0].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
            case "CourtainUI":
                buyIdle2UIManager.buyableObjects[1].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[1].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
            case "LampUI":
                buyIdle2UIManager.buyableObjects[2].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[2].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
            case "PlantUI":
                buyIdle2UIManager.buyableObjects[3].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[3].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
            case "TableUI":
                buyIdle2UIManager.buyableObjects[4].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[4].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
            case "PictureUI":
                buyIdle2UIManager.buyableObjects[5].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[5].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
            case "CarpetUI":
                buyIdle2UIManager.buyableObjects[6].gameObject.SetActive(true);
                buyIdle2UIManager.buyableObjects[6].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle2UIManager.currentBoughtIdle2Area++;
                break;
        }
    }
}
