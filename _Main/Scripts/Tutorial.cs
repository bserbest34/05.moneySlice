using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    MoneySpawner moneySpawner;
    bool throwMoney = false;
    public GameObject tutorialMoney;
    BoxCollider boxCollider;

    private void Start()
    {
        PlayerPrefs.GetInt(Key.TutorialShowed, 0);
        moneySpawner = FindObjectOfType<MoneySpawner>();
        boxCollider = GetComponent<BoxCollider>();
        StartCoroutine(BoxColliderSetTrue());
    }
    private void Update()
    {
        StartCoroutine(TutorialMoney());
    }
    IEnumerator TutorialMoney()
    {
        if (moneySpawner.isGameStart && !throwMoney && PlayerPrefs.GetInt(Key.TutorialShowed) == 0)
        {
            throwMoney = true;
            transform.DOMove(new Vector3(0.25f, 4, 0), 1);
            yield return new WaitForSeconds(1f);
            transform.Find("Hand").gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            transform.Find("Hand").gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            Vector2 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject tutorialSliced = Instantiate(tutorialMoney, transform.position, rotation);

            transform.Find("MoneyNewModel").GetComponent<MeshRenderer>().enabled = false;
            boxCollider.enabled = false;
            MoneyManager.Instance.moneyObjectValue = 1;
            MoneyManager.Instance.CreateCurrentMoney(2, true, transform.position);
            PlayerPrefs.SetInt(Key.TutorialShowed, 1);
            transform.Find("Hand").gameObject.SetActive(false);
            StartCoroutine(SlicedTutorial(tutorialSliced));
        }
    }
    IEnumerator BoxColliderSetTrue()
    {
        yield return new WaitForSeconds(2);
        boxCollider.isTrigger = true;
    }
    IEnumerator SlicedTutorial(GameObject sliced)
    {
        yield return new WaitForSeconds(0.55f);
        sliced.transform.Find("RightBanknote").Find("Banknote").GetComponent<Rigidbody>().isKinematic = true;
        sliced.transform.Find("LeftBanknote").Find("Banknote").GetComponent<Rigidbody>().isKinematic = true;
        sliced.transform.Find("RightBanknote").Find("Banknote").Find("Hand").gameObject.SetActive(true);
        sliced.transform.Find("RightBanknote").Find("Banknote").Find("Hand").transform.rotation = new Quaternion(9.65f, 180, -34f, 0);
        sliced.transform.Find("LeftBanknote").Find("Banknote").Find("Hand").gameObject.SetActive(true);
        sliced.transform.Find("LeftBanknote").Find("Banknote").Find("Hand").transform.rotation = new Quaternion(9.65f, 180, -34f, 0);
    }
}
