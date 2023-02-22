using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlicedMoney : MonoBehaviour
{
    public GameObject slicedMoney;
    BoxCollider boxCollider;
    MeshCollider meshCollider;
    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        boxCollider = GetComponent<BoxCollider>();
        StartCoroutine(BoxColliderSetTrue());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            Debug.Log("TUTORIAL");
            transform.Find("Hand").gameObject.SetActive(false);
            Vector2 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject tutorialSliced = Instantiate(slicedMoney, transform.position, rotation);

            GetComponent<MeshRenderer>().enabled = false;
            boxCollider.enabled = false;
            meshCollider.enabled = false;
            MoneyManager.Instance.moneyObjectValue = 1;
            MoneyManager.Instance.CreateCurrentMoney(1, true, transform.position);
            PlayerPrefs.SetInt(Key.TutorialShowed, 2);
            Destroy(gameObject, 5f);
        }
    }

    IEnumerator BoxColliderSetTrue()
    {
        yield return new WaitForSeconds(0.5f);
        boxCollider.isTrigger = true;
    }
}
