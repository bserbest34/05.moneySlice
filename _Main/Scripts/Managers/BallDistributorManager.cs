using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BallDistributorManager : MonoBehaviour
{
    [SerializeField] internal List<GameObject> rafBalls = new List<GameObject>();

    IdleCharacter idleMoneyManager;
    float lastInstantiateTime = 0;

    private void Start()
    {
        idleMoneyManager = FindObjectOfType<IdleCharacter>();
    }
    private void Update()
    {
        if (rafBalls.Find(x => !x.activeInHierarchy) == null || Time.time - lastInstantiateTime < 6) return;
        RafBallActive();
    }
    
    void RafBallActive()
    {
        rafBalls.FindLast(x => !x.activeInHierarchy).SetActive(true);
        lastInstantiateTime = Time.time;
    }

    public void GetBall()
    {
        GameObject temp = (rafBalls.Find(x => x.activeInHierarchy));
        if (temp == null) return;
        GameObject ball = Instantiate(temp, temp.transform.position, Quaternion.identity);
        temp.SetActive(false);
        ball.transform.parent = idleMoneyManager.ballStackPoint.transform;
        idleMoneyManager.stackingBallList.Add(ball);
        ball.transform.DOLocalMove(new Vector3(0, idleMoneyManager.ballStackPoint.transform.position.y + (7.6f * idleMoneyManager.stackingBallList.Count), 0), 0.25f);
        StartCoroutine(SetNull(ball));
        ball.AddComponent<BallMovement>();
        ball.GetComponent<BallMovement>().index = idleMoneyManager.stackingBallList.Count;
        ball.GetComponent<BallMovement>().followedCube = idleMoneyManager.ballStackPoint.transform;
    }

    IEnumerator SetNull(GameObject ball)
    {
        yield return new WaitForSeconds(0.25f);
        ball.transform.parent = null;
    }
}
