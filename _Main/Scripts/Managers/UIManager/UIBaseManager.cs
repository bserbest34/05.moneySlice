using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBaseManager : Singleton<UIBaseManager>
{
    MoneySpawner moneySpawner;
    Button tapToStartBtn;
    Button tapToRetryBtn;
    Button tapToContinue;
    GameObject successPanel;
    GameObject failPanel;
    TextMeshProUGUI levelText;
    GameObject idleToRunnerLoadingScreen;

    public bool isCpiVideo = false;

    internal delegate void GameStatus();

    internal virtual void Start()
    {
        moneySpawner = FindObjectOfType<MoneySpawner>();
        CPIVideo();
        InitObjects();
        AddListeners();

        tapToStartBtn.gameObject.SetActive(true);
    }

    internal virtual void TapToContinue()
    {
        tapToContinue.onClick.RemoveAllListeners();
        idleToRunnerLoadingScreen.SetActive(true); 
        MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-MoneyManager.Instance.currentMoney);
    }

    internal virtual void TapToRetry()
    {
        tapToRetryBtn.onClick.RemoveAllListeners();
    }

    internal virtual void TapToStart()
    {
        tapToStartBtn.onClick.RemoveAllListeners();
        tapToStartBtn.gameObject.SetActive(false);
        moneySpawner.isGameStart = true;
    }

    internal virtual void SuccesGame()
    {
        if (successPanel.activeSelf) return;
        Vibrations.Succes();
        successPanel.SetActive(true);
    }

    internal virtual void FailGame()
    {
        if (failPanel.activeSelf) return;
        Vibrations.Failure();
        failPanel.SetActive(true);
    }

    void InitObjects()
    {
        levelText = transform.Find("LevelBar").GetComponentInChildren<TextMeshProUGUI>();
        tapToStartBtn = transform.Find("FullscreenButton").GetComponent<Button>();
        failPanel = transform.Find("FullscreenFail").gameObject;
        tapToRetryBtn = failPanel.GetComponentInChildren<Button>();
        successPanel = transform.Find("FullscreenSuccess").gameObject;
        tapToContinue = successPanel.GetComponentInChildren<Button>();
        levelText.SetText("LVL " + PlayerPrefs.GetInt(Key.Level, 1).ToString());
        idleToRunnerLoadingScreen = transform.Find("IdleToRunnerLoading").gameObject;
    }

    void AddListeners()
    {
        tapToContinue.onClick.AddListener(TapToContinue);
        tapToRetryBtn.onClick.AddListener(TapToRetry);
        tapToStartBtn.onClick.AddListener(TapToStart);
    }

    public void CPIVideo()
    {
        if (isCpiVideo)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<CanvasGroup>() == null) continue;
                child.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }
}
