using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyIdle3UI : MonoBehaviour
{
    Button button;
    BuyIdle3UIManager buyIdle3UIManager;
    TextMeshProUGUI moneyAmount;
    public int needMoney;
    internal int isBoughtIdle3 = 0;

    private void Awake()
    {
        isBoughtIdle3 = PlayerPrefs.GetInt("IsBought3" + transform.name);
    }
    private void Start()
    {
        moneyAmount = transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        moneyAmount.text = needMoney.ToString();
        buyIdle3UIManager = FindObjectOfType<BuyIdle3UIManager>();
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
        isBoughtIdle3 = 1;
        PlayerPrefs.SetInt("IsBought3" + transform.name, isBoughtIdle3);
        Debug.Log(PlayerPrefs.GetInt("IsBought3" + transform.name));
        switch (name)
        {
            case "TableUI":
                buyIdle3UIManager.buyableObjects[0].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[0].transform.parent.Find("LampParent").gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[0].transform.parent.Find("ComputerParent").gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[0].transform.parent.Find("PlantParent").gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[0].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "CourtainUI":
                buyIdle3UIManager.buyableObjects[1].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[1].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "ChairUI":
                buyIdle3UIManager.buyableObjects[2].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[2].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "WatchUI":
                buyIdle3UIManager.buyableObjects[3].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[3].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "CarpterUI":
                buyIdle3UIManager.buyableObjects[4].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[4].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "ShelfUI":
                buyIdle3UIManager.buyableObjects[5].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[5].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "LampUI":
                buyIdle3UIManager.buyableObjects[6].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[6].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "ComputerUI":
                buyIdle3UIManager.buyableObjects[7].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[7].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
            case "PlantUI":
                buyIdle3UIManager.buyableObjects[8].gameObject.SetActive(true);
                buyIdle3UIManager.buyableObjects[8].transform.parent.Find("Canvas").gameObject.SetActive(false);
                transform.gameObject.SetActive(false);
                buyIdle3UIManager.currentBoughtIdle3Area++;
                break;
        }
    }
}
