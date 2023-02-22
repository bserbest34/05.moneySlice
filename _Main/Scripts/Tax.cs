using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax : MonoBehaviour
{
    public GameObject moneySlicedPrefab;
    public float startForce = 650;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * startForce * Time.fixedDeltaTime, ForceMode.Impulse);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedMoney = Instantiate(moneySlicedPrefab, transform.position, rotation);

            Material[] mats = GetComponent<MeshRenderer>().materials;
            slicedMoney.transform.Find("LeftBanknote").Find("Banknote").GetComponent<MeshRenderer>().materials = mats;
            slicedMoney.transform.Find("RightBanknote").Find("Banknote").GetComponent<MeshRenderer>().materials = mats;
            slicedMoney.transform.Find("RightBanknote").Find("Banknote").GetComponent<Rigidbody>().AddExplosionForce(50, transform.position, 1);
            slicedMoney.transform.Find("LeftBanknote").Find("Banknote").GetComponent<Rigidbody>().AddExplosionForce(50, transform.position, 1);

            Destroy(slicedMoney, 3);
            Destroy(gameObject);
            if(MoneyManager.Instance.currentMoney < 200)
            {
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-MoneyManager.Instance.currentMoney);
            }
            else if(MoneyManager.Instance.currentMoney > 200)
            {
                MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-200);
            }
            Vibrations.Failure();
        }
    }
}
