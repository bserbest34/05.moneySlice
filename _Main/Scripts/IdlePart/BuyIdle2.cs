using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyIdle2 : MonoBehaviour
{
    Button button;
    Button button2;
    BuyIdle2UIManager buyIdle2UIManager;
    bool fullOpen = false;
    private void Start()
    {
        buyIdle2UIManager = FindObjectOfType<BuyIdle2UIManager>();
        if (PlayerPrefs.GetInt("IsBought2" + "BedUI") == 1 && transform.name == "BedParent")
        {
            transform.Find("Bed").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
        }
        if (PlayerPrefs.GetInt("IsBought2" + "CourtainUI") == 1 && transform.name == "CourtainParent")
        {
            transform.Find("Courtain").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
        }
        if (PlayerPrefs.GetInt("IsBought2" + "LampUI") == 1 && transform.name == "LampParent")
        {
            transform.Find("Lamp").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
        }
        if (PlayerPrefs.GetInt("IsBought2" + "PlantUI") == 1 && transform.name == "PlantParent")
        {
            transform.Find("Plant").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
        }
        if (PlayerPrefs.GetInt("IsBought2" + "TableUI") == 1 && transform.name == "TableParent")
        {
            transform.Find("Table").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
        }
        if (PlayerPrefs.GetInt("IsBought2" + "PictureUI") == 1 && transform.name == "PictureParent")
        {
            transform.Find("Picture").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
        }
        if (PlayerPrefs.GetInt("IsBought2" + "CarpetUI") == 1 && transform.name == "CarpetParent")
        {
            transform.Find("Carpet").gameObject.SetActive(true);
            transform.Find("Canvas").gameObject.SetActive(false);
            buyIdle2UIManager.currentBoughtIdle2Area++;
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
            case "BedParent":
                SetUI(buyIdle2UIManager.bedUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.bedUI);
                buyIdle2UIManager.bedUI.SetActive(true);
                buyIdle2UIManager.courtainUI.SetActive(false);
                buyIdle2UIManager.lampUI.SetActive(false);
                buyIdle2UIManager.plantUI.SetActive(false);
                buyIdle2UIManager.tableUI.SetActive(false);
                buyIdle2UIManager.pictureUI.SetActive(false);
                buyIdle2UIManager.carpetUI.SetActive(false);
                break;
            case "CourtainParent":
                SetUI(buyIdle2UIManager.courtainUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.courtainUI);
                buyIdle2UIManager.bedUI.SetActive(false);
                buyIdle2UIManager.courtainUI.SetActive(true);
                buyIdle2UIManager.lampUI.SetActive(false);
                buyIdle2UIManager.plantUI.SetActive(false);
                buyIdle2UIManager.tableUI.SetActive(false);
                buyIdle2UIManager.pictureUI.SetActive(false);
                buyIdle2UIManager.carpetUI.SetActive(false);
                break;
            case "LampParent":
                SetUI(buyIdle2UIManager.lampUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.lampUI);
                buyIdle2UIManager.bedUI.SetActive(false);
                buyIdle2UIManager.courtainUI.SetActive(false);
                buyIdle2UIManager.lampUI.SetActive(true);
                buyIdle2UIManager.plantUI.SetActive(false);
                buyIdle2UIManager.tableUI.SetActive(false);
                buyIdle2UIManager.pictureUI.SetActive(false);
                buyIdle2UIManager.carpetUI.SetActive(false);
                break;
            case "PlantParent":
                SetUI(buyIdle2UIManager.plantUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.plantUI);
                buyIdle2UIManager.bedUI.SetActive(false);
                buyIdle2UIManager.courtainUI.SetActive(false);
                buyIdle2UIManager.lampUI.SetActive(false);
                buyIdle2UIManager.plantUI.SetActive(true);
                buyIdle2UIManager.tableUI.SetActive(false);
                buyIdle2UIManager.pictureUI.SetActive(false);
                buyIdle2UIManager.carpetUI.SetActive(false);
                break;
            case "TableParent":
                SetUI(buyIdle2UIManager.tableUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.tableUI);
                buyIdle2UIManager.bedUI.SetActive(false);
                buyIdle2UIManager.courtainUI.SetActive(false);
                buyIdle2UIManager.lampUI.SetActive(false);
                buyIdle2UIManager.plantUI.SetActive(false);
                buyIdle2UIManager.tableUI.SetActive(true);
                buyIdle2UIManager.pictureUI.SetActive(false);
                buyIdle2UIManager.carpetUI.SetActive(false);
                break;
            case "PictureParent":
                SetUI(buyIdle2UIManager.pictureUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.pictureUI);
                buyIdle2UIManager.bedUI.SetActive(false);
                buyIdle2UIManager.courtainUI.SetActive(false);
                buyIdle2UIManager.lampUI.SetActive(false);
                buyIdle2UIManager.plantUI.SetActive(false);
                buyIdle2UIManager.tableUI.SetActive(false);
                buyIdle2UIManager.pictureUI.SetActive(true);
                buyIdle2UIManager.carpetUI.SetActive(false);
                break;
            case "CarpetParent":
                SetUI(buyIdle2UIManager.carpetUI.GetComponent<BuyAreaUI>().needMoney, buyIdle2UIManager.carpetUI);
                buyIdle2UIManager.bedUI.SetActive(false);
                buyIdle2UIManager.courtainUI.SetActive(false);
                buyIdle2UIManager.lampUI.SetActive(false);
                buyIdle2UIManager.plantUI.SetActive(false);
                buyIdle2UIManager.tableUI.SetActive(false);
                buyIdle2UIManager.pictureUI.SetActive(false);
                buyIdle2UIManager.carpetUI.SetActive(true);
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
