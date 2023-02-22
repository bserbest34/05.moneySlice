using UnityEngine;

//Notes:
// PlayerPrefs.GetInt(Key.Button1_Level)
public class UpgradeSystemManager : UpgradeSystemBaseManager
{
    MoneySpawner moneySpawner;
    BladeAI bladeAI;
    Blade blade;
    internal override void Start()
    {
        base.Start();
        //UIManager.OnStart += CloseButtons;
        moneySpawner = FindObjectOfType<MoneySpawner>();
        bladeAI = FindObjectOfType<BladeAI>();
        blade = FindObjectOfType<Blade>();
    }
    internal override void Update()
    {
        base.Update();
    }

    void OnClickUpgrade1()
    {
        blade.knife.SetActive(false);

        if (PlayerPrefs.GetFloat(Key.CurrentMoney) < int.Parse(upgrade1MoneyText.text)) return;
        PlayerPrefs.SetInt(Key.Button1_Level, PlayerPrefs.GetInt(Key.Button1_Level) + 1);
        SetMoney(PlayerPrefs.GetFloat(Key.Button1_Money));
        if(PlayerPrefs.GetInt(Key.Button1_Level) < 10)
        {
            PlayerPrefs.SetFloat(Key.Button1_Money, upgrade1IncreasingMoneyAmountPerLevel);
        }
        else
        {
            PlayerPrefs.SetFloat(Key.Button1_Money, (PlayerPrefs.GetFloat(Key.Button1_Money) / percent * 100));
        }
        upgrade1MoneyText.text = PlayerPrefs.GetFloat(Key.Button1_Money).ToString(MoneyManager.Instance.moneyFormat);
        upgarede1LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button1_Level).ToString();

        SetUpgradeSystem();
        moneySpawner.MoneyCreateDelayUpgrade();
    }

    void OnClickUpgrade2()
    {
        blade.knife.SetActive(false);
        if (PlayerPrefs.GetFloat(Key.CurrentMoney) < int.Parse(upgrade2MoneyText.text)) return;
        PlayerPrefs.SetInt(Key.Button2_Level, PlayerPrefs.GetInt(Key.Button2_Level) + 1);
        SetMoney(PlayerPrefs.GetFloat(Key.Button2_Money));
        if(PlayerPrefs.GetInt(Key.Button2_Level) < 10)
        {
            PlayerPrefs.SetFloat(Key.Button2_Money, upgrade2IncreasingMoneyAmountPerLevel);
        }
        else
        {
            PlayerPrefs.SetFloat(Key.Button2_Money, (PlayerPrefs.GetFloat(Key.Button2_Money) / percent * 100));
        }
        upgrade2MoneyText.text = PlayerPrefs.GetFloat(Key.Button2_Money).ToString(MoneyManager.Instance.moneyFormat);
        upgarede2LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button2_Level).ToString();

        SetUpgradeSystem();

        moneySpawner.MoneyUpgradeCount();
        moneySpawner.MoneyUpgrade();
    }

    void OnClickUpgrade3()
    {
        blade.knife.SetActive(false);
        if (PlayerPrefs.GetFloat(Key.CurrentMoney) < int.Parse(upgrade3MoneyText.text)) return;
        PlayerPrefs.SetInt(Key.Button3_Level, PlayerPrefs.GetInt(Key.Button3_Level) + 1);
        SetMoney(PlayerPrefs.GetFloat(Key.Button3_Money));
        if(PlayerPrefs.GetInt(Key.Button3_Level) < 10)
        {
            PlayerPrefs.SetFloat(Key.Button3_Money, upgrade3IncreasingMoneyAmountPerLevel);
        }
        else
        {
            PlayerPrefs.SetFloat(Key.Button3_Money, (PlayerPrefs.GetFloat(Key.Button3_Money) / percent * 100));
        }
        upgrade3MoneyText.text = PlayerPrefs.GetFloat(Key.Button3_Money).ToString(MoneyManager.Instance.moneyFormat);
        upgarede3LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button3_Level).ToString();

        SetUpgradeSystem();
        bladeAI.BladeUpgrade();
    }

    void OnClickUpgrade4()
    {
        if (PlayerPrefs.GetFloat(Key.CurrentMoney) < int.Parse(upgrade4MoneyText.text)) return;
        PlayerPrefs.SetInt(Key.Button4_Level, PlayerPrefs.GetInt(Key.Button4_Level) + 1);
        SetMoney(PlayerPrefs.GetFloat(Key.Button4_Money));
        PlayerPrefs.SetFloat(Key.Button4_Money, (PlayerPrefs.GetFloat(Key.Button4_Money) + upgrade2IncreasingMoneyAmountPerLevel));

        upgrade4MoneyText.text = PlayerPrefs.GetFloat(Key.Button4_Money).ToString(MoneyManager.Instance.moneyFormat);
        upgarede4LevelText.text = "LVL " + PlayerPrefs.GetInt(Key.Button4_Level).ToString();

        SetUpgradeSystem();
    }

    internal override void InitObjects()
    {
        base.InitObjects();
        upgrade1Button.onClick.AddListener(OnClickUpgrade1);
        upgrade2Button.onClick.AddListener(OnClickUpgrade2);
        upgrade3Button.onClick.AddListener(OnClickUpgrade3);
        upgrade4Button.onClick.AddListener(OnClickUpgrade4);
    }

    void CloseButtons()
    {
        if(upgrade1GameObject != null)
            upgrade1GameObject.SetActive(false);
        if (upgrade2GameObject != null)
            upgrade2GameObject.SetActive(false);
        if (upgrade3GameObject != null)
            upgrade3GameObject.SetActive(false);
        if (upgrade4GameObject != null)
            upgrade4GameObject.SetActive(false);
    }
}