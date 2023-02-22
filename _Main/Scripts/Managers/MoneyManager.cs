using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private GameObject moneyObject;
    private List<GameObject> moneyList;
    private int moneyPoolCount = 100;

    [SerializeField] private Transform moneyTargetInUI;
    [SerializeField] internal TextMeshProUGUI moneyText;
    [SerializeField] private Transform moneyBG;

    [SerializeField] private Transform currentMoneyTargetInUI;
    [SerializeField] private TextMeshProUGUI currentMoneyText;
    [SerializeField] private Transform currentMoneyBG;

    public float money;
    public float currentMoney;

    internal float moneyObjectValue = 5f;

    private Camera cam;
    internal string moneyFormat = "F0"; //F0 F1 F2

    private void Start()
    {
        //IncreaseMoneyAndWrite(10);
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey(Key.Money))
        {
            money = PlayerPrefs.GetFloat(Key.Money);
            moneyText.text = money.ToString(moneyFormat);
        }
        else
        {
            PlayerPrefs.SetFloat(Key.Money, 0);
            money = 0;
        }

        if (PlayerPrefs.HasKey(Key.CurrentMoney))
        {
            currentMoney = PlayerPrefs.GetFloat(Key.CurrentMoney);
            currentMoneyText.text = currentMoney.ToString(moneyFormat);
        }
        else
        {
            PlayerPrefs.SetFloat(Key.CurrentMoney, 0);
            currentMoney = 0;
        }
        //currentMoney = PlayerPrefs.GetFloat(Key.CurrentMoney);
        //currentMoneyText.text = currentMoney.ToString(moneyFormat);

        InstantiateMoneyPool();

        cam = Camera.main;
        UIManager.OnSuccess += SaveMoney;
    }

    private void InstantiateMoneyPool()
    {
        moneyList = new List<GameObject>();

        for (int i = 0; i < moneyPoolCount; i++)
        {
            GameObject money = Instantiate(moneyObject);
            money.transform.SetParent(transform);
            money.SetActive(false);

            moneyList.Add(money);
        }
    }

    public void CreateCurrentMoney(int count, bool saveMoneyImmediately, Vector3 position) // Use this
    {
        position = cam.WorldToScreenPoint(position);

        for (int i = 0; i < count; i++)
        {
            CreateCurrentMoneyInUI(i * 0.05f, position, saveMoneyImmediately);
        }
    }
    public void CreateMoney(int count, bool saveMoneyImmediately, Vector3 position) // Use this
    {
        position = cam.WorldToScreenPoint(position);

        for (int i = 0; i < count; i++)
        {
            CreateMoneyInUI(i * 0.05f, position, saveMoneyImmediately);
        }
    }

    public void CreateMoney(int count, bool saveMoneyImmediately) // Use this
    {
        Vector3 position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        for (int i = 0; i < count; i++)
        {
            CreateMoneyInUI(i * 0.05f, position, saveMoneyImmediately);
        }
    }


    private void CreateMoneyInUI(float time, Vector3 position, bool saveMoney)
    {

        IncreaseMoneyAndWrite(moneyObjectValue);
        currentMoneyText.transform.DOScale(1.2f, 0.25f).SetLoops(1, LoopType.Yoyo).OnComplete(() =>
        {
            currentMoneyText.transform.DOScale(1, 0.25f);
        });
    }
    private void CreateCurrentMoneyInUI(float time, Vector3 position, bool saveMoney)
    {
        IncreaseCurrentMoneyAndWrite(moneyObjectValue);
        currentMoneyText.transform.DOScale(1.2f, 0.25f).SetLoops(1, LoopType.Yoyo).OnComplete(() =>
        {
            moneyText.transform.DOScale(1, 0.25f);
        });
    }

    public void IncreaseMoneyAndWrite(float addingMoney)
    {
        money += addingMoney;
        moneyText.text = money.ToString(moneyFormat);
        SaveMoney();
    }

    public void IncreaseCurrentMoneyAndWrite(float addingMoney)
    {
        currentMoney += addingMoney;
        currentMoneyText.text = currentMoney.ToString(moneyFormat);
        PlayerPrefs.SetFloat(Key.CurrentMoney, currentMoney);
        //SaveCurrentMoney();
    }
    public void SaveMoney()
    {
        PlayerPrefs.SetFloat(Key.Money, money);
    }
    public void SaveCurrentMoney()
    {
        PlayerPrefs.SetFloat(Key.CurrentMoney, currentMoney);
    }
}