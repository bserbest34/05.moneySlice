using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewObject : MonoBehaviour
{
    Button button;
    Button button2;
    BuyAreaUIManager buyAreaUIManager;
    bool fullOpen = false;
    Image BG, picture, moneyBG;
    private void Start()
    {
        buyAreaUIManager = FindObjectOfType<BuyAreaUIManager>();
        if (PlayerPrefs.GetInt("IsBought" + "TVUI") == 1 && transform.name == "TVParent")
        {
            transform.Find("TV").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if (PlayerPrefs.GetInt("IsBought" + "WindowsAndPictureUI") == 1 && transform.name == "WindowsAndPicture")
        {
            transform.Find("WindowAndPictureParent").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if (PlayerPrefs.GetInt("IsBought" + "CarpetUI") == 1 && transform.name == "CarpetParent")
        {
            transform.Find("Carpet").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if (PlayerPrefs.GetInt("IsBought" + "ChairRightUI") == 1 && transform.name == "ChairRightParent")
        {
            transform.Find("Chairs").gameObject.SetActive(true);
            transform.Find("CanvasLeft").gameObject.SetActive(false);
            transform.Find("CanvasRight").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if (PlayerPrefs.GetInt("IsBought" + "CouchUI") == 1 && transform.name == "CouchParent")
        {
            transform.Find("Couch").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if (PlayerPrefs.GetInt("IsBought" + "LampUI") == 1 && transform.name == "LampParent")
        {
            transform.Find("Lamp").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if (PlayerPrefs.GetInt("IsBought" + "PlantUI") == 1 && transform.name == "PlantParent")
        {
            transform.Find("Plant").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyAreaUIManager.currentBoughtArea++;
        }
        if(transform.name == "ChairRightParent")
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
            case "WindowsAndPicture":
                SetUI(buyAreaUIManager.windowsAndPictureUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.windowsAndPictureUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(true);
                buyAreaUIManager.carpetUI.SetActive(false);
                buyAreaUIManager.couchUI.SetActive(false);
                buyAreaUIManager.lampUI.SetActive(false);
                buyAreaUIManager.plantUI.SetActive(false);
                buyAreaUIManager.tvUI.SetActive(false);
                buyAreaUIManager.chairRightUI.SetActive(false);
                break;
            case "CarpetParent":
                SetUI(buyAreaUIManager.carpetUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.carpetUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(false);
                buyAreaUIManager.carpetUI.SetActive(true);
                buyAreaUIManager.couchUI.SetActive(false);
                buyAreaUIManager.lampUI.SetActive(false);
                buyAreaUIManager.plantUI.SetActive(false);
                buyAreaUIManager.tvUI.SetActive(false);
                buyAreaUIManager.chairRightUI.SetActive(false);
                break;
            case "CouchParent":
                SetUI(buyAreaUIManager.couchUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.couchUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(false);
                buyAreaUIManager.carpetUI.SetActive(false);
                buyAreaUIManager.couchUI.SetActive(true);
                buyAreaUIManager.lampUI.SetActive(false);
                buyAreaUIManager.plantUI.SetActive(false);
                buyAreaUIManager.tvUI.SetActive(false);
                buyAreaUIManager.chairRightUI.SetActive(false);
                break;
            case "LampParent":
                SetUI(buyAreaUIManager.lampUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.lampUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(false);
                buyAreaUIManager.carpetUI.SetActive(false);
                buyAreaUIManager.couchUI.SetActive(false);
                buyAreaUIManager.lampUI.SetActive(true);
                buyAreaUIManager.plantUI.SetActive(false);
                buyAreaUIManager.tvUI.SetActive(false);
                buyAreaUIManager.chairRightUI.SetActive(false);
                break;
            case "PlantParent":
                SetUI(buyAreaUIManager.plantUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.plantUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(false);
                buyAreaUIManager.carpetUI.SetActive(false);
                buyAreaUIManager.couchUI.SetActive(false);
                buyAreaUIManager.lampUI.SetActive(false);
                buyAreaUIManager.plantUI.SetActive(true);
                buyAreaUIManager.tvUI.SetActive(false);
                buyAreaUIManager.chairRightUI.SetActive(false);
                break;
            case "TVParent":
                SetUI(buyAreaUIManager.tvUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.tvUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(false);
                buyAreaUIManager.carpetUI.SetActive(false);
                buyAreaUIManager.couchUI.SetActive(false);
                buyAreaUIManager.lampUI.SetActive(false);
                buyAreaUIManager.plantUI.SetActive(false);
                buyAreaUIManager.tvUI.SetActive(true);
                buyAreaUIManager.chairRightUI.SetActive(false);
                break;
            case "ChairRightParent":
                SetUI(buyAreaUIManager.chairRightUI.GetComponent<BuyAreaUI>().needMoney, buyAreaUIManager.chairRightUI);
                buyAreaUIManager.windowsAndPictureUI.SetActive(false);
                buyAreaUIManager.carpetUI.SetActive(false);
                buyAreaUIManager.couchUI.SetActive(false);
                buyAreaUIManager.lampUI.SetActive(false);
                buyAreaUIManager.plantUI.SetActive(false);
                buyAreaUIManager.tvUI.SetActive(false);
                buyAreaUIManager.chairRightUI.SetActive(true);
                break;
        }
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
