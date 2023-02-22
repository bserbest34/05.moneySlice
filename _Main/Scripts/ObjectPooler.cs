using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    MoneySpawner moneySpawner;
    GManager gManager;
    void Start()
    {
        gManager = FindObjectOfType<GManager>();
        moneySpawner = FindObjectOfType<MoneySpawner>();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        moneySpawner.moneys.Add(objectToSpawn);
        //StartCoroutine(WaitRemove(objectToSpawn));

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public GameObject SpawnSlicedMoney(Material mat, Quaternion rotation, string tag, Vector3 position, string valueTag, Material vfxMat, Vector3 expPos, Quaternion vfxRot)
    {
        GameObject slicedMoney = poolDictionary[tag].Dequeue();

        slicedMoney.SetActive(true);
        slicedMoney.transform.rotation = rotation;
        slicedMoney.transform.position = position;

        slicedMoney.transform.Find("RightBanknote").Find("Banknote").GetComponent<MeshRenderer>().material = mat;
        slicedMoney.transform.Find("LeftBanknote").Find("Banknote").GetComponent<MeshRenderer>().material = mat;
        slicedMoney.transform.Find("RightBanknote").Find("Banknote").GetComponent<Rigidbody>().AddExplosionForce(50 * Time.deltaTime, expPos, 1);
        slicedMoney.transform.Find("LeftBanknote").Find("Banknote").GetComponent<Rigidbody>().AddExplosionForce(50 * Time.deltaTime, expPos, 1);


        GameObject vfx = slicedMoney.transform.Find("MoneyCut").gameObject;
        vfx.transform.SetParent(null);
        vfx.transform.position = new Vector3(vfx.transform.position.x, vfx.transform.position.y, 5);
        vfx.transform.rotation = Quaternion.Euler(vfx.transform.rotation.x, 90, vfxRot.z);
        vfx.transform.Find("MoneyCut").GetComponent<ParticleSystem>().Play();
        vfx.transform.Find("MoneyExplosionDecalGreen").GetComponent<ParticleSystem>().Play();
        slicedMoney.transform.Find("RightBanknote").Find("Banknote").tag = valueTag;
        slicedMoney.transform.Find("LeftBanknote").Find("Banknote").tag = valueTag;
        //StartCoroutine(MoneyBorder(slicedMoney));

        IPooledObject pooledObject = slicedMoney.GetComponent<IPooledObject>();

        if(pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(slicedMoney);

        return slicedMoney;
    }

    public GameObject SpawnSlicedMoneyTwo(Material mat, Quaternion rotation, string tag, Vector3 position, Material vfxMat, Vector3 expPos)
    {
        GameObject slicedMoneyTwo = poolDictionary[tag].Dequeue();

        slicedMoneyTwo.SetActive(true);
        slicedMoneyTwo.transform.rotation = rotation;
        slicedMoneyTwo.transform.position = position;
        slicedMoneyTwo.transform.Find("RightBanknote").Find("Banknote").GetComponent<MeshRenderer>().material = mat;
        slicedMoneyTwo.transform.Find("LeftBanknote").Find("Banknote").GetComponent<MeshRenderer>().material = mat;
        slicedMoneyTwo.transform.Find("LeftBanknote").Find("Banknote").GetComponent<Rigidbody>().AddExplosionForce(50 * Time.deltaTime, expPos, 1); //AddExplosionForce(250 * Time.deltaTime , transform.up, 1);
        slicedMoneyTwo.transform.Find("RightBanknote").Find("Banknote").GetComponent<Rigidbody>().AddExplosionForce(50 * Time.deltaTime, expPos, 1);


        GameObject vfx = slicedMoneyTwo.transform.Find("MoneyCut").gameObject;
        vfx.transform.position = new Vector3(vfx.transform.position.x, vfx.transform.position.y, 5);
        vfx.transform.SetParent(null);
        vfx.transform.Find("MoneyCut").GetComponent<ParticleSystem>().Play();
        vfx.transform.Find("MoneyExplosionDecalGreen").GetComponent<ParticleSystem>().Play();
        //StartCoroutine(MoneyBorder(slicedMoneyTwo));
        IPooledObject pooledObject = slicedMoneyTwo.GetComponent<IPooledObject>();

        if(pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(slicedMoneyTwo);

        return slicedMoneyTwo;
    }
    IEnumerator WaitRemove(GameObject g)
    {
        yield return new WaitForSeconds(3);
        moneySpawner.moneys.Remove(g);
    }
}
