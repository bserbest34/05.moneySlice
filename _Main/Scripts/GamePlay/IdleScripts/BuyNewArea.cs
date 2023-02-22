using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public class BuyNewArea : MonoBehaviour
{
    public float needMoneyCount;
    ProceduralImage fillImage;
    TextMeshProUGUI textMP;
    bool isOpenProcess = false;
    internal int isBought = 0;
    IdleCharacter idleMoneyManager;

    void Start()
    {
        idleMoneyManager = GameObject.Find("Player").GetComponent<IdleCharacter>();
        isBought = PlayerPrefs.GetInt("IsBought" + transform.name);

        if (isBought == 1)
        {
            GetComponent<BoxCollider>().enabled = false;
            transform.Find("Canvas").gameObject.SetActive(false);
            transform.Find("NewArea").gameObject.SetActive(true);
        }
        else
        {
            fillImage = transform.Find("Canvas").Find("Image").GetComponent<ProceduralImage>();
            textMP = transform.Find("Canvas").Find("TextMP").GetComponent<TextMeshProUGUI>();
            textMP.text = (int)needMoneyCount + "$";
        }

    }

    internal void UnlockNewArea()
    {
        if (isOpenProcess)
            return;

        isOpenProcess = true;
        if (MoneyManager.Instance.money >= needMoneyCount)
        {
            Vibrations.Succes();
            MoneyManager.Instance.IncreaseMoneyAndWrite(-needMoneyCount);
            idleMoneyManager.InstantiateMoney();
            StartCoroutine(SetFill());
        }else
        {
            Vibrations.Failure();
            transform.Find("Canvas").Find("NotEnough").gameObject.SetActive(true);
            StartCoroutine(SetFalse());
        }
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(1f);
        transform.Find("Canvas").Find("NotEnough").gameObject.SetActive(false);
        isOpenProcess = false;
    }

    IEnumerator SetFill()
    {
        float velocity = 0f;
        while (fillImage.fillAmount < 1)
        {
            yield return new WaitForSeconds(0);
            fillImage.fillAmount = Mathf.SmoothDamp(fillImage.fillAmount, 1, ref velocity, Time.deltaTime * 0.1f, 10);
        }
        isBought = 1;
        PlayerPrefs.SetInt("IsBought" + transform.name, 1);

        GetComponent<BoxCollider>().enabled = false;
        transform.Find("Canvas").gameObject.SetActive(false);
        transform.Find("NewArea").gameObject.SetActive(true);

        isOpenProcess = false;
    }
}
