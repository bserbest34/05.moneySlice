using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyNewThing : MonoBehaviour
{
    public float cost = 20;
    float openPart = 0;

    Image image;
    TextMeshProUGUI text;
    float time = 0;

    private void SaveSystem()
    {
        PlayerPrefs.SetFloat("IsBought" + transform.name, openPart);
    }

    private void Awake()
    {
        openPart = PlayerPrefs.GetFloat("IsBought" + transform.name);
        if (openPart >= cost)
        {
            transform.Find("Canvas").gameObject.SetActive(false);
            transform.Find("NewArea").gameObject.SetActive(true);
        }
    }

    void Start()
    {
        image = transform.Find("Canvas").Find("Image").GetComponent<Image>();
        text = transform.Find("Canvas").Find("TextMP").GetComponent<TextMeshProUGUI>();
        
        image.fillAmount = openPart * (1 / cost);
        text.text = cost - openPart + "$";
    }
    private void OnTriggerStay(Collider other)
    {

        if(other.CompareTag("Player") && FindObjectOfType<JoystickControl>().isRelase)
        {
            if(Time.time - time > 0.1)
            {
                if (MoneyManager.Instance.money <= 0)
                {
                    transform.Find("Canvas").Find("NotEnough").gameObject.SetActive(true);
                    transform.Find("Canvas").Find("TextMP").transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f);
                    return;
                }

                if(MoneyManager.Instance.money > (int)cost / 20 && cost - openPart >= (int)cost / 20)
                {
                    MoneyManager.Instance.IncreaseMoneyAndWrite(-(int)cost / 20);
                    openPart += (int)cost / 20;
                }else
                {
                    if(cost - openPart > MoneyManager.Instance.money)
                    {
                        var m = MoneyManager.Instance.money;
                        MoneyManager.Instance.IncreaseMoneyAndWrite(-m);
                        openPart += m;
                    }else
                    {
                        var m = cost - openPart;
                        MoneyManager.Instance.IncreaseMoneyAndWrite(-m);
                        openPart += m;
                    }
                }
                image.fillAmount = openPart * (1 / cost);
                text.text = cost - openPart + "$";
                time = Time.time;
                if (openPart >= cost)
                {
                    transform.Find("Canvas").gameObject.SetActive(false);
                    transform.Find("NewArea").gameObject.SetActive(true);
                    openPart = cost;
                }
                SaveSystem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.Find("Canvas").Find("NotEnough").gameObject.SetActive(false);
        }
    }
}
