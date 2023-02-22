using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BladeAI : MonoBehaviour
{
    MoneySpawner moneySpawner;
    internal float upgradeBlade;
    float time;
    
    private void Start()
    {
        moneySpawner = FindObjectOfType<MoneySpawner>();
        upgradeBlade = PlayerPrefs.GetFloat("BladeUpgrade", 10);
    }
    private void Update()
    {
        if(upgradeBlade < 10)
        {
            time += Time.deltaTime;
            if(upgradeBlade <= time)
            {
                CutMoney();
            }
        }
    }
    void CutMoney()
    {
        if(moneySpawner.moneys.Count > 0)
        {
            if (moneySpawner.moneys[0].transform.position.y >= 3)
            {
                moneySpawner.moneys[0].transform.Find("Hand").gameObject.SetActive(true);
                time = 0;
            }
        }
    }
    internal void BladeUpgrade()
    {
        PlayerPrefs.SetFloat("BladeUpgrade", upgradeBlade - 0.5f);
        upgradeBlade = PlayerPrefs.GetFloat("BladeUpgrade");
    }

}
