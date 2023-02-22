using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 500;
    public float power = 1000;
    GManager gManager;
    Rigidbody rb;
    public float startForce = 650;
    private void Start()
    {
        gManager = FindObjectOfType<GManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * startForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade"))
        {
            CameraShake.Instance.ShakeCamera(5, 0.1f);
            GetComponent<SphereCollider>().enabled = false;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
            MoneyManager.Instance.IncreaseCurrentMoneyAndWrite(-(MoneyManager.Instance.currentMoney * 30) / 100);
            StartCoroutine(DeleteMoneies());
            transform.Find("ExplosionFireballFire").GetComponent<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            Vibrations.Failure();
            Destroy(gameObject, 5);
        }
    }
    IEnumerator DeleteMoneies()
    {
        for (int i = 0; i < gManager.slicedMoneyList.Count; i++)
        {
            Destroy(gManager.slicedMoneyList[i]);
            yield return new WaitForSeconds(0.1f);
        }
        gManager.slicedMoneyList.Clear();
    }
}