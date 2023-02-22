using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public class IdleCharacter : MonoBehaviour
{
    internal float lastCollectionTime;

    public GameObject moneyInstantiateSystem;
    internal bool onProcess;
    JoystickControl playerJoystick;

    internal GameObject ballStackPoint;
    BallDistributorManager ballDistributorManager;
    internal List<GameObject> stackingBallList = new List<GameObject>();
    public int maxBallCount = 6;
    public GameObject fullText;

    void Start()
    {
        playerJoystick = GetComponent<JoystickControl>();
        ballDistributorManager = FindObjectOfType<BallDistributorManager>();
        ballStackPoint = transform.Find("MoneyStackPoint").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case Tags.Money:
                Vibrations.Light();
                SetMoney(other);
                break;
            default:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case Tags.UpgradeSpeed:
                Color aColor = other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color;
                aColor.a = 200f / 255f;
                other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color = aColor;
                break;
            case Tags.NewArea:
                Color bColor = other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color;
                bColor.a = 200f / 255f;
                other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color = bColor;
                break;
        }

        if (!playerJoystick.isRelase)
            return;

        switch (other.tag)
        {
            case Tags.UpgradeSpeed:
                if (onProcess)
                    return;
                other.GetComponent<UpgradeArea>().SetMoneyToUpgradeArea();
                onProcess = true;
                break;
            case Tags.NewArea:
                if (onProcess)
                    return;
                other.GetComponent<BuyNewArea>().UnlockNewArea();
                onProcess = true;
                break;
            case Tags.RafBallArea:
                if (Time.time - lastCollectionTime > 0.3f && stackingBallList.Count <= maxBallCount)
                {
                    if (stackingBallList.Count >= maxBallCount)
                    {
                        fullText.SetActive(true);
                    }
                    else
                    {
                        ballDistributorManager.GetBall();
                        lastCollectionTime = Time.time;
                    }
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case Tags.UpgradeSpeed:
                Vibrations.Light();
                onProcess = false;
                Color aColor = other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color;
                aColor.a = 100f / 255f;
                other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color = aColor;
                break;
            case Tags.NewArea:
                Vibrations.Light();
                onProcess = false;
                Color bColor = other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color;
                bColor.a = 100f / 255f;
                other.transform.Find("Canvas").Find("ImageBg").GetComponent<ProceduralImage>().color = bColor;
                break;
            case Tags.RafBallArea:
                fullText.gameObject.SetActive(false);
                break;
        }
    }

    internal void InstantiateMoney()
    {
        var temp = Instantiate(moneyInstantiateSystem, transform.position, Quaternion.identity, null);
        temp.SetActive(true);
        Destroy(temp, 3f);
    }

    internal virtual void SetMoney(Collider other)
    {
        Destroy(other.gameObject);
        MoneyManager.Instance.CreateMoney(1, true, other.transform.position);
    }
}