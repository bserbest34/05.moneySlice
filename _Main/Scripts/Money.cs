using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Money : MonoBehaviour, IPooledObject
{
    MoneySpawner moneySpawner;
    public GameObject moneySlicedPrefab;
    private float startForce = 650f;
    Rigidbody rb;
    BoxCollider boxCollider;

    public void OnObjectSpawn()
    {
        moneySpawner = FindObjectOfType<MoneySpawner>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        rb.isKinematic = false;
        rb.AddForce(transform.up * startForce * Time.fixedDeltaTime, ForceMode.Impulse);
        transform.Find("MoneyNewModel").GetComponent<MeshRenderer>().enabled = true;
        boxCollider.enabled = true;
        StartCoroutine(SetActiveObject(false));
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Material mat = transform.Find("MoneyNewModel").GetComponent<MeshRenderer>().material;

            Vector3 dir = (other.transform.position - transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(dir);

            switch (tag)
            {
                case Tags.OneDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.OneDollar, moneySpawner.cutVfxMaterials[0], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 1;
                    break;
                case Tags.TwoDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.TwoDollar, moneySpawner.cutVfxMaterials[0], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 2;
                    break;
                case Tags.FiveDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.FiveDollar, moneySpawner.cutVfxMaterials[0], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 5;
                    break;
                case Tags.TenDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.TenDollar, moneySpawner.cutVfxMaterials[0], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 10;
                    break;
                case Tags.FiftyDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.FiftyDollar, moneySpawner.cutVfxMaterials[0], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 50;
                    break;
                case Tags.OneHundredDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.OneHundredDollar, moneySpawner.cutVfxMaterials[1], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 100;
                    break;
                case Tags.TwoHundredDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.TwoHundredDollar, moneySpawner.cutVfxMaterials[1], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 200;
                    break;
                case Tags.FiveHundredDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.FiveHundredDollar, moneySpawner.cutVfxMaterials[2], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 500;
                    break;
                case Tags.ThousandDollar:
                    ObjectPooler.Instance.SpawnSlicedMoney(mat, rotation, "Sliced", transform.position, Tags.ThousandDollar, moneySpawner.cutVfxMaterials[3], transform.position, rot);
                    MoneyManager.Instance.moneyObjectValue = 1000;
                    break;
            }
            Vibrations.Medium();
            moneySpawner.moneys.Remove(gameObject);
            transform.Find("MoneyNewModel").GetComponent<MeshRenderer>().enabled = false;
            boxCollider.enabled = false;
            //Destroy(slicedMoney, 3);
            StartCoroutine(SetActiveObject(true));
            MoneyManager.Instance.CreateCurrentMoney(2, true, transform.position);

        }
    }
    IEnumerator SetActiveObject(bool sliced)
    {
        if (sliced)
        {
            yield return new WaitForSeconds(0.25f);
            gameObject.SetActive(false);
            rb.isKinematic = true;
        }
        else
        {
            yield return new WaitForSeconds(6f);
            gameObject.SetActive(false);
            rb.isKinematic = true;
        }
    }
}

