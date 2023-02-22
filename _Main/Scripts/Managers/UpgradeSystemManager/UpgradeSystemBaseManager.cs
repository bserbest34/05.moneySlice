using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSystemBaseManager : MonoBehaviour
{
    [Header("Number of Buttons You Want to Use :")]
    public int upgradeButtonCount = 2;
    public int percent;
    [Space(30)]

    public int upgrade1BeginMoney;
    public int upgrade1IncreasingMoneyAmountPerLevel;
    public int upgrade1Level1;
    public int upgrade1Level2;
    public int upgrade1Level3;
    public int upgrade1Level4;
    public int upgrade1Level5;
    public int upgrade1Level6;
    public int upgrade1Level7;
    public int upgrade1Level8;
    public int upgrade1Level9;
    public int upgrade1Level10;

    public int upgrade2BeginMoney;
    public int upgrade2IncreasingMoneyAmountPerLevel;
    public int upgrade2Level1;
    public int upgrade2Level2;
    public int upgrade2Level3;
    public int upgrade2Level4;
    public int upgrade2Level5;
    public int upgrade2Level6;
    public int upgrade2Level7;
    public int upgrade2Level8;
    public int upgrade2Level9;
    public int upgrade2Level10;

    public int upgrade3BeginMoney;
    public int upgrade3IncreasingMoneyAmountPerLevel;
    public int upgrade3Level1;
    public int upgrade3Level2;
    public int upgrade3Level3;
    public int upgrade3Level4;
    public int upgrade3Level5;
    public int upgrade3Level6;
    public int upgrade3Level7;
    public int upgrade3Level8;
    public int upgrade3Level9;
    public int upgrade3Level10;

    public int upgrade4BeginMoney;
    public int upgrade4IncreasingMoneyAmountPerLevel;

    internal GameObject upgrade1GameObject;
    internal TextMeshProUGUI upgarede1LevelText;
    internal TextMeshProUGUI upgrade1MoneyText;
    internal Button upgrade1Button;
    Image upgrade1Image;
    Image upgrade1MoneyImage;
    Image moneyBG1;

    internal GameObject upgrade2GameObject;
    internal TextMeshProUGUI upgarede2LevelText;
    internal TextMeshProUGUI upgrade2MoneyText;
    internal Button upgrade2Button;
    Image upgrade2Image;
    Image upgrade2MoneyImage;
    Image moneyBG2;

    internal GameObject upgrade3GameObject;
    internal TextMeshProUGUI upgarede3LevelText;
    internal TextMeshProUGUI upgrade3MoneyText;
    internal Button upgrade3Button;
    Image upgrade3Image;
    Image upgrade3MoneyImage;
    Image moneyBG3;

    internal GameObject upgrade4GameObject;
    internal TextMeshProUGUI upgarede4LevelText;
    internal TextMeshProUGUI upgrade4MoneyText;
    internal Button upgrade4Button;
    Image upgrade4Image;
    Image upgrade4MoneyImage;

    internal virtual void Start()
    {
        InitObjects();
        SetUpgradeSystem();
        SetActiveUpgradeButtons();
    }
    internal virtual void Update()
    {
        SetUpgradeSystem();
        UpgradesMoneySet();
    }
    internal void SetUpgradeSystem()
    {
        SetUpgrade1UpgradeSystem();
        SetUpgrade2UpgradeSystem();
        SetUpgrade3UpgradeSystem();
        SetUpgrade4UpgradeSystem();
    }

    void SetUpgrade1UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat(Key.CurrentMoney);
        if (moneytext >= PlayerPrefs.GetFloat(Key.Button1_Money))
        {
            ColorBlock colors = upgrade1Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade1Button.colors = colors;
            upgrade1GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //upgrade1Image.color = new Color(1, 1, 1, 1);
            upgrade1MoneyImage.color = new Color(1, 1, 1, 1);
            moneyBG1.color = Color.green;
        }
        else
        {
            ColorBlock colors = upgrade1Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade1Button.colors = colors;
            upgrade1GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            //upgrade1Image.color = new Color(1, 1, 1, 0.6f);
            upgrade1MoneyImage.color = new Color(1, 1, 1, 0.6f);
            moneyBG1.color = Color.gray;
        }
    }

    void SetUpgrade2UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat(Key.CurrentMoney);
        if (moneytext >= PlayerPrefs.GetFloat(Key.Button2_Money))
        {
            ColorBlock colors = upgrade2Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade2Button.colors = colors;
            upgrade2GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            //upgrade2Image.color = new Color(1, 1, 1, 1);
            moneyBG2.color = Color.green;
            upgrade2MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade2Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade2Button.colors = colors;
            upgrade2GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);

            //upgrade2Image.color = new Color(1, 1, 1, 0.6f);
            moneyBG2.color = Color.gray;
            upgrade2MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade3UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat(Key.CurrentMoney);
        if (moneytext >= PlayerPrefs.GetFloat(Key.Button3_Money))
        {
            ColorBlock colors = upgrade3Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade3Button.colors = colors;
            upgrade3GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            //upgrade3Image.color = new Color(1, 1, 1, 1);
            moneyBG3.color = Color.green;
            upgrade3MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade3Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade3Button.colors = colors;
            upgrade3GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            //upgrade3Image.color = new Color(1, 1, 1, 0.6f);
            moneyBG3.color = Color.gray;
            upgrade3MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    void SetUpgrade4UpgradeSystem()
    {
        float moneytext = PlayerPrefs.GetFloat(Key.CurrentMoney);
        if (moneytext >= PlayerPrefs.GetFloat(Key.Button4_Money))
        {
            ColorBlock colors = upgrade4Button.colors;
            colors.pressedColor = new Color(0.76f, 0.76f, 0.76f, 1);
            upgrade4Button.colors = colors;
            upgrade4GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            upgrade4Image.color = new Color(0, 0.5849056f, 0.01235464f, 1);
            upgrade4MoneyImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            ColorBlock colors = upgrade4Button.colors;
            colors.pressedColor = new Color(1, 1, 1, 1);
            upgrade4Button.colors = colors;
            upgrade4GameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
            upgrade4Image.color = new Color(0, 0.5849056f, 0.01235464f, 0.6f);
            upgrade4MoneyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }

    internal void SetMoney(float number)
    {
        MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-number);
    }

    internal virtual void InitObjects()
    {
        // Upgrade 1
        upgrade1GameObject = transform.Find("Upgrade1").gameObject;
        upgrade1Button = upgrade1GameObject.GetComponent<Button>();
        upgrade1Image = transform.Find("Upgrade1").transform.Find("Image").GetComponent<Image>();
        upgarede1LevelText = transform.Find("Upgrade1").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade1MoneyImage = transform.Find("Upgrade1").transform.Find("Money").GetComponent<Image>();
        upgrade1MoneyText = transform.Find("Upgrade1").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        moneyBG1 = transform.Find("Upgrade1").transform.Find("MoneyBg").GetComponent<Image>();

        // Upgrade 2
        upgrade2GameObject = transform.Find("Upgrade2").gameObject;
        upgrade2Button = upgrade2GameObject.GetComponent<Button>();
        upgrade2Image = transform.Find("Upgrade2").transform.Find("Image").GetComponent<Image>();
        upgarede2LevelText = transform.Find("Upgrade2").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade2MoneyImage = transform.Find("Upgrade2").transform.Find("Money").GetComponent<Image>();
        upgrade2MoneyText = transform.Find("Upgrade2").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        moneyBG2 = transform.Find("Upgrade2").transform.Find("MoneyBg").GetComponent<Image>();

        // Upgrade 3
        upgrade3GameObject = transform.Find("Upgrade3").gameObject;
        upgrade3Button = upgrade3GameObject.GetComponent<Button>();
        upgrade3Image = transform.Find("Upgrade3").transform.Find("Image").GetComponent<Image>();
        upgarede3LevelText = transform.Find("Upgrade3").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade3MoneyImage = transform.Find("Upgrade3").transform.Find("Money").GetComponent<Image>();
        upgrade3MoneyText = transform.Find("Upgrade3").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();
        moneyBG3 = transform.Find("Upgrade3").transform.Find("MoneyBg").GetComponent<Image>();

        // Upgrade 4
        upgrade4GameObject = transform.Find("Upgrade4").gameObject;
        upgrade4Button = upgrade4GameObject.GetComponent<Button>();
        upgrade4Image = transform.Find("Upgrade4").transform.Find("Image").GetComponent<Image>();
        upgarede4LevelText = transform.Find("Upgrade4").transform.Find("Level").GetComponent<TextMeshProUGUI>();
        upgrade4MoneyImage = transform.Find("Upgrade4").transform.Find("Money").GetComponent<Image>();
        upgrade4MoneyText = transform.Find("Upgrade4").transform.Find("MoneyAmount").GetComponent<TextMeshProUGUI>();

        ConfigureInitializedObjects();
    }

    void ConfigureInitializedObjects()
    {
        //Set Level Text
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 0)
        {
            PlayerPrefs.SetInt(Key.Button1_Level, 1);
            upgarede1LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button1_Level).ToString();
        }
        else
        {
            upgarede1LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button1_Level).ToString();
        }

        if (PlayerPrefs.GetInt(Key.Button2_Level) == 0)
        {
            PlayerPrefs.SetInt(Key.Button2_Level, 1);
            upgarede2LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button2_Level).ToString();
        }
        else
        {
            upgarede2LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button2_Level).ToString();
        }

        if (PlayerPrefs.GetInt(Key.Button3_Level) == 0)
        {
            PlayerPrefs.SetInt(Key.Button3_Level, 1);
            upgarede3LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button3_Level).ToString();
        }
        else
        {
            upgarede3LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button3_Level).ToString();
        }

        if (PlayerPrefs.GetInt(Key.Button4_Level) == 0)
        {
            PlayerPrefs.SetInt(Key.Button4_Level, 1);
            upgarede4LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button4_Level).ToString();
        }
        else
        {
            upgarede4LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button4_Level).ToString();
        }

        //Set Money Text
        if (PlayerPrefs.GetFloat(Key.Button1_Money) == 0)
        {
            PlayerPrefs.SetFloat(Key.Button1_Money, upgrade1BeginMoney);
            upgrade1MoneyText.text = PlayerPrefs.GetFloat(Key.Button1_Money).ToString(MoneyManager.Instance.moneyFormat);
        }
        else
        {
            upgrade1MoneyText.text = PlayerPrefs.GetFloat(Key.Button1_Money).ToString(MoneyManager.Instance.moneyFormat);
        }

        if (PlayerPrefs.GetFloat(Key.Button2_Money) == 0)
        {
            PlayerPrefs.SetFloat(Key.Button2_Money, upgrade2BeginMoney);
            upgrade2MoneyText.text = PlayerPrefs.GetFloat(Key.Button2_Money).ToString(MoneyManager.Instance.moneyFormat);
        }
        else
        {
            upgrade2MoneyText.text = PlayerPrefs.GetFloat(Key.Button2_Money).ToString(MoneyManager.Instance.moneyFormat);
        }

        if (PlayerPrefs.GetFloat(Key.Button3_Money) == 0)
        {
            PlayerPrefs.SetFloat(Key.Button3_Money, upgrade3BeginMoney);
            upgrade3MoneyText.text = PlayerPrefs.GetFloat(Key.Button3_Money).ToString(MoneyManager.Instance.moneyFormat);
        }
        else
        {
            upgrade3MoneyText.text = PlayerPrefs.GetFloat(Key.Button3_Money).ToString(MoneyManager.Instance.moneyFormat);
        }

        if (PlayerPrefs.GetFloat(Key.Button4_Money) == 0)
        {
            PlayerPrefs.SetFloat(Key.Button4_Money, upgrade4BeginMoney);
            upgrade4MoneyText.text = PlayerPrefs.GetFloat(Key.Button4_Money).ToString(MoneyManager.Instance.moneyFormat);
        }
        else
        {
            upgrade4MoneyText.text = PlayerPrefs.GetFloat(Key.Button4_Money).ToString(MoneyManager.Instance.moneyFormat);
        }
    }

    void SetActiveUpgradeButtons()
    {
        switch (upgradeButtonCount)
        {
            case 1:
                upgrade1GameObject.SetActive(true);
                break;
            case 2:
                upgrade1GameObject.SetActive(true);
                upgrade2GameObject.SetActive(true);
                break;
            case 3:
                upgrade1GameObject.SetActive(true);
                upgrade2GameObject.SetActive(true);
                upgrade3GameObject.SetActive(true);
                break;
            case 4:
                upgrade1GameObject.SetActive(true);
                upgrade2GameObject.SetActive(true);
                upgrade3GameObject.SetActive(true);
                upgrade4GameObject.SetActive(true);
                break;
        }
    }
    void UpgradesMoneySet()
    {
        Upgrade1MoneySet();
        Upgrade2MoneySet();
        Upgrade3MoneySet();
    }
    void Upgrade1MoneySet()
    {
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 1)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level1;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 2)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level2;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 3)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level3;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 4)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level4;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 5)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level5;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 6)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level6;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 7)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level7;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 8)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level8;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 9)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level9;
        }
        if (PlayerPrefs.GetInt(Key.Button1_Level) == 10)
        {
            upgrade1IncreasingMoneyAmountPerLevel = upgrade1Level10;
        }
    }
    void Upgrade2MoneySet()
    {
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 1)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level1;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 2)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level2;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 3)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level3;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 4)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level4;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 5)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level5;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 6)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level6;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 7)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level7;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 8)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level8;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 9)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level9;
        }
        if (PlayerPrefs.GetInt(Key.Button2_Level) == 10)
        {
            upgrade2IncreasingMoneyAmountPerLevel = upgrade2Level10;
        }
    }
    void Upgrade3MoneySet()
    {
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 1)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level1;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 2)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level2;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 3)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level3;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 4)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level4;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 5)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level5;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 6)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level6;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 7)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level7;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 8)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level8;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 9)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level9;
        }
        if (PlayerPrefs.GetInt(Key.Button3_Level) == 10)
        {
            upgrade3IncreasingMoneyAmountPerLevel = upgrade3Level10;
        }
    }
}
