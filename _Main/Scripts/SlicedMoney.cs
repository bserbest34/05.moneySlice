using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SlicedMoney : MonoBehaviour
{
    MoneySpawner moneySpawner;
    public GameObject moneySlicedPrefab;
    Rigidbody rb;
    BoxCollider boxCollider;
    MeshCollider meshCollider;
    GManager gManager;

    private void Start()
    {
        gManager = FindObjectOfType<GManager>();
        moneySpawner = FindObjectOfType<MoneySpawner>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        meshCollider = GetComponent<MeshCollider>();
        StartCoroutine(ColliderOpen());
        StartCoroutine(ScaleChange());
        //StartCoroutine(MoneyBorder());
    }

    IEnumerator ScaleChange()
    {
        yield return new WaitForSeconds(0.6f);
        transform.localScale = new Vector3(20, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            Material mats = GetComponent<MeshRenderer>().material;
            switch (tag)
            {
                case Tags.OneDollar:
                    MoneyManager.Instance.moneyObjectValue = 1;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[0], transform.position);
                    break;
                case Tags.TwoDollar:
                    MoneyManager.Instance.moneyObjectValue = 2;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[0], transform.position);
                    break;
                case Tags.FiveDollar:
                    MoneyManager.Instance.moneyObjectValue = 5;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[0], transform.position);
                    break;
                case Tags.TenDollar:
                    MoneyManager.Instance.moneyObjectValue = 10;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[0], transform.position);
                    break;
                case Tags.FiftyDollar:
                    MoneyManager.Instance.moneyObjectValue = 50;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[0], transform.position);
                    break;
                case Tags.OneHundredDollar:
                    MoneyManager.Instance.moneyObjectValue = 100;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[1], transform.position);
                    break;
                case Tags.TwoHundredDollar:
                    MoneyManager.Instance.moneyObjectValue = 200;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[1], transform.position);
                    break;
                case Tags.FiveHundredDollar:
                    MoneyManager.Instance.moneyObjectValue = 500;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[2], transform.position);
                    break;
                case Tags.ThousandDollar:
                    MoneyManager.Instance.moneyObjectValue = 1000;
                    ObjectPooler.Instance.SpawnSlicedMoneyTwo(mats, rotation, "SlicedMoneyTwo", transform.position, moneySpawner.cutVfxMaterials[3], transform.position);
                    break;
            }
            Vibrations.Medium();
            moneySpawner.moneys.Remove(gameObject);
            GetComponent<MeshRenderer>().enabled = false;
            boxCollider.enabled = false;
            //Destroy(slicedMoney, 3);
            Destroy(gameObject, 0.25f);
            MoneyManager.Instance.CreateCurrentMoney(1, true, transform.position);
        }
    }
    IEnumerator ColliderOpen()
    {
        yield return new WaitForSeconds(0.25f);
        boxCollider.enabled = true;
        boxCollider.isTrigger = true;
        yield return new WaitForSeconds(0.3f);
        boxCollider.isTrigger = false;
    }
    IEnumerator MoneyBorder()
    {
        gManager.slicedMoneyList.Add(gameObject);
        if (gManager.slicedMoneyList.Count >= 90)
        {
            yield return new WaitForSeconds(3f);
            boxCollider.isTrigger = true;
            //g.transform.Find("RightBanknote").Find("Banknote").GetComponent<MeshCollider>().isTrigger = true;
            //g.transform.Find("LeftBanknote").Find("Banknote").GetComponent<MeshCollider>().isTrigger = true;
        }
    }
}
