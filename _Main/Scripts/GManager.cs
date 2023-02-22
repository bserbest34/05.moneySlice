using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    MoneySpawner moneySpawner;
    private int targetMoney;
    public int increasedTargetMoney = 10;
    public TextMeshProUGUI targetMoneyText;
    public GameObject mainCamera, secondCamera;
    public GameObject nextLevelButton, levelImage;
    public Camera cam;
    GameObject upgradeButtons;
    public GameObject idle1, idle2, idle3;
    internal int whichIdle;
    [SerializeField] internal List<GameObject> slicedMoneyList = new List<GameObject>();
    public GameObject panel;
    public TextMeshProUGUI currentMoney;
    bool isInProcess = false;
    public GameObject currentMoneyText;
    public GameObject goalText;
    float temp = 0;
    public Button idleTransitionButton;
    public GameObject idleTransition;
    public GameObject loadingScreen;
    bool isFinished = false;
    bool moneyTransfer = false;
    Blade blade;

    private void Start()
    {
        blade = FindObjectOfType<Blade>();
        moneySpawner = FindObjectOfType<MoneySpawner>();
        Debug.Log(PlayerPrefs.GetInt(Key.Level));
        if (PlayerPrefs.GetInt(Key.Level) == 1)
        {
            targetMoney = 500;
        }
        if (PlayerPrefs.GetInt(Key.Level) == 2)
        {
            targetMoney = 5000;
        }
        if (PlayerPrefs.GetInt(Key.Level) == 3)
        {
            targetMoney = 20000;
        }
        if (PlayerPrefs.GetInt(Key.Level) == 4)
        {
            targetMoney = 50000;
        }
        if (PlayerPrefs.GetInt(Key.Level) == 5)
        {
            targetMoney = 75000;
        }
        if (PlayerPrefs.GetInt(Key.Level) > 5)
        {
            targetMoney = PlayerPrefs.GetInt("TargetMoney", 100000);
            PlayerPrefs.SetInt("TargetMoney", targetMoney + 50000);
            targetMoney = PlayerPrefs.GetInt("TargetMoney");
        }

        whichIdle = PlayerPrefs.GetInt("IdleArea", 1);
        if(PlayerPrefs.GetInt("IdleArea") == 0)
        {
            PlayerPrefs.SetInt("IdleArea", 1);
            whichIdle = PlayerPrefs.GetInt("IdleArea");
        }
        upgradeButtons = GameObject.Find("Canvas").transform.Find("UpgradeButtons").gameObject;
        targetMoneyText.text = targetMoney.ToString();
        SetIdleArea();
        //MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-MoneyManager.Instance.currentMoney);
        idleTransitionButton.onClick.AddListener(IdleTransition);
    }

    private void Update()
    {
        if(MoneyManager.Instance.currentMoney >= targetMoney)
        {
            moneySpawner.enabled = false;
            if (!isFinished)
            {
                idleTransition.SetActive(true);
            }
            if (!isInProcess && moneyTransfer)
            {
                isInProcess = true;
                StartCoroutine(MoneyTransfer());
            }
        }
        Debug.Log("whichidle " + whichIdle);
        Debug.Log("whichidleplayerprefs " + PlayerPrefs.GetInt("IdleArea"));
    }
    void SetIdleArea()
    {
        switch (whichIdle)
        {
            case 1:
                idle1.SetActive(true);
                idle2.SetActive(false);
                idle2.SetActive(false);
                break;
            case 2:
                idle1.SetActive(false);
                idle2.SetActive(true);
                idle3.SetActive(false);
                break;
            case 3:
                idle1.SetActive(false);
                idle2.SetActive(false);
                idle3.SetActive(true);
                break;
        }
    }
    IEnumerator MoneyTransfer()
    {
        float temp = float.Parse(targetMoneyText.text);
        MoneyManager.Instance.currentMoney = temp;
        for (int i = 0; i < temp; i++)
        {
            if (MoneyManager.Instance.currentMoney < 1)
                break;
            if (temp >= 500)
            {
                targetMoneyText.text = (float.Parse(targetMoneyText.text) - 100).ToString();
                MoneyManager.Instance.IncreaseMoneyAndWrite(100);
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-100);
                if (float.Parse(targetMoneyText.text) < 0)
                {
                    targetMoneyText.text = "0";
                }
                yield return new WaitForSeconds(2 / temp);
            }
            else if (temp >= 1000)
            {
                targetMoneyText.text = (float.Parse(targetMoneyText.text) - 100).ToString();
                MoneyManager.Instance.IncreaseMoneyAndWrite(100);
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-100);
                if (float.Parse(targetMoneyText.text) < 0)
                {
                    targetMoneyText.text = "0";
                }
                yield return new WaitForSeconds(2 / temp);
            }
            else if (temp >= 5000)
            {
                targetMoneyText.text = (float.Parse(targetMoneyText.text) - 1000).ToString();
                MoneyManager.Instance.IncreaseMoneyAndWrite(1000);
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-1000);
                if (float.Parse(targetMoneyText.text) < 0)
                {
                    targetMoneyText.text = "0";
                }
                yield return new WaitForSeconds(2 / temp);
            }
            else if (temp >= 20000)
            {
                targetMoneyText.text = (float.Parse(targetMoneyText.text) - 1000).ToString();
                MoneyManager.Instance.IncreaseMoneyAndWrite(1000);
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-1000);
                if (float.Parse(targetMoneyText.text) < 0)
                {
                    targetMoneyText.text = "0";
                }
                yield return new WaitForSeconds(2 / temp);
            }
            else if (temp >= 50000)
            {
                targetMoneyText.text = (float.Parse(targetMoneyText.text) - 10000).ToString();
                MoneyManager.Instance.IncreaseMoneyAndWrite(10000);
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-10000);
                if (float.Parse(targetMoneyText.text) < 0)
                {
                    targetMoneyText.text = "0";
                }
                yield return new WaitForSeconds(2 / temp);
            }
            else if (temp >= 1000000)
            {
                targetMoneyText.text = (float.Parse(targetMoneyText.text) - 100000).ToString();
                MoneyManager.Instance.IncreaseMoneyAndWrite(100000);
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-100000);
                if (float.Parse(targetMoneyText.text) < 0)
                {
                    targetMoneyText.text = "0";
                }
                yield return new WaitForSeconds(2 / temp);
            }
        }
        targetMoneyText.gameObject.SetActive(false);
        goalText.SetActive(false);
    }

    void IdleTransition()
    {
        moneySpawner.finish = false;
        blade.setKnife = false;
        blade.knife.SetActive(false);
        mainCamera.SetActive(false);
        cam.orthographic = false;
        upgradeButtons.SetActive(false);
        levelImage.SetActive(false);
        nextLevelButton.SetActive(true);
        panel.SetActive(false);
        currentMoneyText.gameObject.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(CloseLoadingScreen());
        idleTransition.SetActive(false);
        isFinished = true;
        StartCoroutine(MoneyTransferSetTrue());
        //StartCoroutine(MoneyTransfer());
    }
    IEnumerator MoneyTransferSetTrue()
    {
        yield return new WaitForSeconds(3f);
        moneyTransfer = true;
    }
    IEnumerator CloseLoadingScreen()
    {
        yield return new WaitForSeconds(2f);
        loadingScreen.SetActive(false);
    }

}

