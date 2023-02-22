using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyIdle3 : MonoBehaviour
{
    Button button;
    Button button2;
    BuyIdle3UIManager buyIdle3UIManager;
    bool fullOpen = false;
    private void Start()
    {
        buyIdle3UIManager = FindObjectOfType<BuyIdle3UIManager>();
        if (PlayerPrefs.GetInt("IsBought3" + "TableUI") == 1 && transform.name == "TableParent")
        {
            StartCoroutine(OnTableObjects());
            transform.Find("Table").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "CourtainUI") == 1 && transform.name == "CourtainParent")
        {
            transform.Find("Courtain").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "ChairUI") == 1 && transform.name == "ChairParent")
        {
            transform.Find("Chair").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "WatchUI") == 1 && transform.name == "WatchParent")
        {
            transform.Find("Watch").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "CarpterUI") == 1 && transform.name == "CarpterParent")
        {
            transform.Find("Carpet").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "ShelfUI") == 1 && transform.name == "ShelfParent")
        {
            transform.Find("Shelf").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "LampUI") == 1 && transform.name == "LampParent")
        {
            transform.Find("Lamp").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "ComputerUI") == 1 && transform.name == "ComputerParent")
        {
            transform.Find("Computer").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        if (PlayerPrefs.GetInt("IsBought3" + "PlantUI") == 1 && transform.name == "PlantParent")
        {
            transform.Find("Plant").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle3UIManager.currentBoughtIdle3Area++;
        }
        //if (PlayerPrefs.GetInt("IsBought" + "ChairLeftUI") == 1 || PlayerPrefs.GetInt("IsBought" + "ChairRightUI") == 1 && transform.name == "ChairLeftParent" || transform.name == "ChairRightParent")
        //{
        //    transform.Find("Chair").gameObject.SetActive(true);
        //    transform.Find("Canvas").gameObject.SetActive(false);
        //    buyAreaUIManager.currentBoughtArea++;
        //}


        if (transform.name == "ChairRightParent")
        {
            button = transform.Find("CanvasLeft").Find("Button").GetComponent<Button>();
            button2 = transform.Find("CanvasRight").Find("Button").GetComponent<Button>();
            button.onClick.AddListener(OpenButtons);
            button2.onClick.AddListener(OpenButtons);
        }
        else
        {
            button = transform.Find("Canvas").Find("Button").GetComponent<Button>();
            button.onClick.AddListener(OpenButtons);
        }
    }
    public void OpenButtons()
    {
        switch (name)
        {
            case "TableParent":
                SetUI(buyIdle3UIManager.tableUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.tableUI);
                buyIdle3UIManager.tableUI.SetActive(true);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "LampParent":
                SetUI(buyIdle3UIManager.lampUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.lampUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(true);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "ComputerParent":
                SetUI(buyIdle3UIManager.computerUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.computerUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(true);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "PlantParent":
                SetUI(buyIdle3UIManager.plantUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.plantUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(true);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "CourtainParent":
                SetUI(buyIdle3UIManager.courtainUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.courtainUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(true);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "ChairParent":
                SetUI(buyIdle3UIManager.chairUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.chairUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(true);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "WatchParent":
                SetUI(buyIdle3UIManager.watchUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.watchUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(true);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "CarpterParent":
                SetUI(buyIdle3UIManager.carpterUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.carpterUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(true);
                buyIdle3UIManager.shelfUI.SetActive(false);
                break;
            case "ShelfParent":
                SetUI(buyIdle3UIManager.shelfUI.GetComponent<BuyAreaUI>().needMoney, buyIdle3UIManager.shelfUI);
                buyIdle3UIManager.tableUI.SetActive(false);
                buyIdle3UIManager.lampUI.SetActive(false);
                buyIdle3UIManager.computerUI.SetActive(false);
                buyIdle3UIManager.plantUI.SetActive(false);
                buyIdle3UIManager.courtainUI.SetActive(false);
                buyIdle3UIManager.chairUI.SetActive(false);
                buyIdle3UIManager.watchUI.SetActive(false);
                buyIdle3UIManager.carpterUI.SetActive(false);
                buyIdle3UIManager.shelfUI.SetActive(true);
                break;
        }
    }

    IEnumerator OnTableObjects()
    {
        yield return new WaitForSeconds(3);
        transform.Find("PlantParent").gameObject.SetActive(true);
        transform.Find("LampParent").gameObject.SetActive(true);
        transform.Find("ComputerParent").gameObject.SetActive(true);
    }
    void SetUI(float money, GameObject ui)
    {
        if (MoneyManager.Instance.money >= money)
        {
            ui.transform.Find("BG").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            ui.transform.Find("Picturepng").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            ui.transform.Find("MoneyBg").GetComponent<Image>().color = new Color(0.1254902f, 0.8588235f, 0, 1);
        }
        else
        {
            ui.transform.Find("BG").GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            ui.transform.Find("Picturepng").GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            ui.transform.Find("MoneyBg").GetComponent<Image>().color = new Color(0.1254902f, 0.8588235f, 0, 0.6f);
        }
    }
}
