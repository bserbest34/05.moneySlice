using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyThrower : MonoBehaviour
{
    public GameObject money;
    float lastThrowTime = 0;

    void Update()
    {
        if(Time.time - lastThrowTime > 3f)
        {
            for (int i = 0; i < 10; i++)
            {
                var inst = Instantiate(money, transform.position, Quaternion.Euler(new Vector3(0, Random.Range(0, 2) % 2 == 0 ? 0 : 90, 0)));
                inst.transform.DOJump(new Vector3(transform.position.x + Random.Range(-5f, 5f), 0.47f, transform.position.z - Random.Range(9, 12f)), 10, 1, 1f);
            }
            lastThrowTime = Time.time;
        }
    }
}
