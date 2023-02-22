using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

public class UpgradeArea : MonoBehaviour
{
    public float needMoneyCount;
    ProceduralImage fillImage;
    TextMeshProUGUI textMP;
    bool isOpenProcess = false;
    internal int level = 1;
    JoystickControl jControl;
    IdleCharacter idleMoneyManager;

    void Start()
    {
        idleMoneyManager = GameObject.Find("Player").GetComponent<IdleCharacter>();
        jControl = GameObject.Find("Player").GetComponent<JoystickControl>();
        needMoneyCount = PlayerPrefs.GetFloat("NeedMoneyCount" + transform.name, needMoneyCount);
        level = PlayerPrefs.GetInt("Level" + transform.name, level);
        switch (tag)
        {
            case Tags.UpgradeSpeed:
                for (int i = 0; i < level - 1; i++)
                {
                    jControl.movSpeed++;
                }
                break;
        }

        fillImage = transform.Find("Canvas").Find("Image").GetComponent<ProceduralImage>();
        textMP = transform.Find("Canvas").Find("TextMP").GetComponent<TextMeshProUGUI>();
        textMP.text = (int)needMoneyCount + "$";
    }

    internal void SetMoneyToUpgradeArea()
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

        fillImage.fillAmount = 0;
        needMoneyCount += (int)(needMoneyCount / 2);
        PlayerPrefs.SetFloat("NeedMoneyCount" + transform.name, needMoneyCount);
        level++;
        PlayerPrefs.SetInt("Level" + transform.name, level);

        textMP.text = (int)needMoneyCount + "$";
        switch (tag)
        {
            case Tags.UpgradeSpeed:
                jControl.movSpeed++;
                break;
        }
        isOpenProcess = false;
    }
}
