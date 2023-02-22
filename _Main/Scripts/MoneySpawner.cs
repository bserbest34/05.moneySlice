using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoneySpawner : MonoBehaviour
{
    internal string moneyTag;
    public GameObject moneyPrefab;
    public Transform[] spawnPoints;
    public Transform[] bombSpawnPoints;
    public GameObject OneDollarPrefab, TwoDollarPrefab, FiveDollarPrefab, TenDollarPrefab, FiftyDollarPrefab, OneHundredDollarPrefab,TwoHundredDollar, FiveHundredDollar, ThousandDollarPrefab;
    public Material[] cutVfxMaterials;
    public GameObject taxPrefab;
    public GameObject bombPrefab;
    public float minDelay = .1f;
    public float maxDelay = 1f;
    internal int updradeCount;
    internal int upgradeMoneyCount;
    float spawnTime = 2.75f;
    float threeSpawnTime = 3.5f;
    float fourSpawnTime = 4.5f;
    float time;
    public List<GameObject> moneys = new List<GameObject>();
    internal bool isGameStart = false;
    internal bool started = false;
    internal bool finish = true;
    private void Start()
    {
        updradeCount = PlayerPrefs.GetInt("MoneyUpgrade", 0);
        upgradeMoneyCount = PlayerPrefs.GetInt("UpgradeMoneyCount", 1);
        //MoneyCreateDelayUpgrade();
        MoneyUpgrade();
        //if (isGameStart)
        //{
        //    StartSpawn();
        //    StartCoroutine(SpawnTax());
        //    StartCoroutine(SpawnBomb());
        //}
    }
    private void Update()
    {
        if (isGameStart && PlayerPrefs.GetInt(Key.TutorialShowed) == 2)
        {
            if (!started)
            {
                started = true;
                StartSpawn();
                StartCoroutine(SpawnTax());
                StartCoroutine(SpawnBomb());
            }
            time += Time.deltaTime;
            SpawnMoney();
        }
    }
    void StartSpawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnedMoney, 5f);
    }
    IEnumerator SpawnTax()
    {
        while (finish)
        {
            yield return new WaitForSeconds(Random.Range(10,15));
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedTax = Instantiate(taxPrefab, spawnPoint.position, spawnPoint.rotation);
            Vibrations.Soft();
            Destroy(spawnedTax, 5f);
        }
    }
    IEnumerator SpawnBomb()
    {
        while (finish)
        {
            yield return new WaitForSeconds(Random.Range(10, 15));
            int spawnIndex = Random.Range(0, bombSpawnPoints.Length);
            Transform spawnPoint = bombSpawnPoints[spawnIndex];

            GameObject spawnedBomb = Instantiate(bombPrefab, spawnPoint.position, spawnPoint.rotation);
            Vibrations.Soft();
            Destroy(spawnedBomb, 5f);
        }
    }
    void OneMoneySpawner()
    {
        if(spawnTime < time)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            time = 0;
        }
    }
    void TwoMoneySpawner()
    {
        int random;
        if(spawnTime < time)
        {
            random = Random.Range(1, 3);
            if(random == 1)
            {
                StartCoroutine(TwoMoneySpawnNonDelay());
            }
            if(random == 2)
            {
                StartCoroutine(TwoMoneySpawnDelayed());
            }
            time = 0;
        }
    }
    IEnumerator TwoMoneySpawnDelayed()
    {
        for (int i = 0; i < 2; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(1.2f);
        }
    }
    IEnumerator TwoMoneySpawnNonDelay()
    {
        for (int i = 0; i < 2; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
    }
    void ThreeMoneySpawner()
    {
        int random;
        if(threeSpawnTime < time)
        {
            random = Random.Range(1, 5);
            Debug.Log("Random" + random);
            if (random == 1)
            {
                StartCoroutine(ThreeMoneySpawnDelayed());
            }
            if (random == 2)
            {
                StartCoroutine(TwoAndOneSpawn());
            }
            if (random == 3)
            {
                StartCoroutine(ThreeSpawnNonDelay());
            }
            if (random == 4)
            {
                StartCoroutine(OneAndTwoSpawn());
            }
            time = 0;
        }
    }
    IEnumerator ThreeMoneySpawnDelayed()
    {
        for (int i = 0; i < 3; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.75f);
        }
    }
    IEnumerator TwoAndOneSpawn()
    {
        for (int i = 0; i < 2; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(1);
        MoneyUpgrade();
        int spawnIndex1 = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint1 = spawnPoints[spawnIndex1];
        ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint1.position, spawnPoint1.rotation);
        //GameObject spawnedMoney1 = Instantiate(moneyPrefab, spawnPoint1.position, spawnPoint1.rotation);
        //moneys.Add(spawnedMoney1);
        //Destroy(spawnedMoney1, 5f);
        //StartCoroutine(WaitRemove(spawnedMoney1));
        Vibrations.Light();
    }
    IEnumerator ThreeSpawnNonDelay()
    {
        for (int i = 0; i < 3; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
    }
    IEnumerator OneAndTwoSpawn()
    {
        MoneyUpgrade();
        int spawnIndex1 = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint1 = spawnPoints[spawnIndex1];
        ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint1.position, spawnPoint1.rotation);
        //GameObject spawnedMoney1 = Instantiate(moneyPrefab, spawnPoint1.position, spawnPoint1.rotation);
        //moneys.Add(spawnedMoney1);
        //Destroy(spawnedMoney1, 5f);
        //StartCoroutine(WaitRemove(spawnedMoney1));
        Vibrations.Light();
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 2; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
    }
    void FourMoneySpawner()
    {
        int random;
        if (threeSpawnTime < time)
        {
            random = Random.Range(1, 5);
            if (random == 1)
            {
                StartCoroutine(FourSpawnDelayed());
            }
            if (random == 2)
            {
                StartCoroutine(FourSpawnNonDelay());
            }
            if (random == 3)
            {
                StartCoroutine(OneAndThreeSpawn());
            }
            if (random == 4)
            {
                StartCoroutine(TwoAndTwoSpawn());
            }
            time = 0;
        }
    }
    IEnumerator FourSpawnDelayed()
    {
        for (int i = 0; i < 4; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.65f);
        }
    }
    IEnumerator FourSpawnNonDelay()
    {
        for (int i = 0; i < 4; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator OneAndThreeSpawn()
    {
        MoneyUpgrade();
        int spawnIndex1 = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint1 = spawnPoints[spawnIndex1];
        ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint1.position, spawnPoint1.rotation);
        //GameObject spawnedMoney1 = Instantiate(moneyPrefab, spawnPoint1.position, spawnPoint1.rotation);
        //moneys.Add(spawnedMoney1);
        //Destroy(spawnedMoney1, 5f);
        //StartCoroutine(WaitRemove(spawnedMoney1));
        Vibrations.Light();
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 3; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
    }
    IEnumerator TwoAndTwoSpawn()
    {
        for (int i = 0; i < 2; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(1.25f);
        for (int i = 0; i < 2; i++)
        {
            MoneyUpgrade();
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            ObjectPooler.Instance.SpawnFromPool(moneyTag, spawnPoint.position, spawnPoint.rotation);
            //GameObject spawnedMoney = Instantiate(moneyPrefab, spawnPoint.position, spawnPoint.rotation);
            //moneys.Add(spawnedMoney);
            //Destroy(spawnedMoney, 5f);
            //StartCoroutine(WaitRemove(spawnedMoney));
            Vibrations.Light();
            yield return new WaitForSeconds(0.15f);
        }
    }
    void SpawnMoney()
    {
        switch (upgradeMoneyCount)
        {
            case 1:
                //Tek Para
                OneMoneySpawner();
                break;
            case 2:
                //iki para atma. iki ihtimal olacak sekilde.
                //birinci ihtimal: 1 para at ikinciyi 1.5 saniye sonra at.
                //ikinci ihtimal: ikisini birden at.
                TwoMoneySpawner();
                break;
            case 3:
                //uc para atma. 4 ihtimal olacak sekilde.
                //birinci ihtimal: paralari tek tek aralarinda 1 saniye olacak sekilde at.
                //ikinci ihtimal: 2 tane at x saniye sonra 1 tane daha at.
                //ucuncu ihtimal: ucunu ayni anda at.
                //dorduncu ihtimal: 1 at x saniye bekle 2 tane daha at.
                ThreeMoneySpawner();
                break;
            case 4:
                //dort para atma.
                //birinci ihtimal : paralarý tek tek atma.
                //ikinci ihtimal: 1 atip 2 saniye sonra 3 at.
                //ucuncu ihtimal: 2 2 at.
                //dordundu ihtimakl: tum paralari at.
                FourMoneySpawner();
                break;
        }
    }
    public void MoneyCreateDelayUpgrade()
    {
        if (upgradeMoneyCount == 4) return;
        PlayerPrefs.SetInt("UpgradeMoneyCount", upgradeMoneyCount + 1);
        upgradeMoneyCount = PlayerPrefs.GetInt("UpgradeMoneyCount");
    }
    public void MoneyUpgradeCount()
    {
        if (updradeCount == 9) return;
        PlayerPrefs.SetInt("MoneyUpgrade", updradeCount + 1);
        updradeCount = PlayerPrefs.GetInt("MoneyUpgrade");
    }
    public void MoneyUpgrade()
    {
        switch (Random.Range(0, updradeCount + 1))
        {
            case 0:
                moneyTag = Tags.OneDollar;
                break;
            case 1:
                moneyTag = Tags.TwoDollar;
                break;
            case 2:
                moneyTag = Tags.FiveDollar;
                break;
            case 3:
                moneyTag = Tags.TenDollar;
                break;
            case 4:
                moneyTag = Tags.FiftyDollar;
                break;
            case 5:
                moneyTag = Tags.OneHundredDollar;
                break;
            case 6:
                moneyTag = Tags.TwoHundredDollar;
                break;
            case 7:
                moneyTag = Tags.FiveHundredDollar;
                break;
            case 8:
                moneyTag = Tags.ThousandDollar;
                break;
        }
    }

}