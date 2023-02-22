using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedTwo : MonoBehaviour
{
    GManager gManager;
    BoxCollider boxCollider;
    private void Start()
    {
        gManager = FindObjectOfType<GManager>();
        boxCollider = GetComponent<BoxCollider>();
        //StartCoroutine(MoneyBorder());
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
