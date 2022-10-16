using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

public class WorkerManager : MonoBehaviour
{
    public List<GameObject> logList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();

    public Transform logPoint, moneyDropPoint;
    public GameObject logPrefab, moneyPrefab;


    [SerializeField] Animator forestAnim;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
        forestAnim = GetComponent<Animator>();
    }

    IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (logList.Count > 0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x, -1.25f+ ((float)moneyList.Count / 8), moneyDropPoint.position.z);
                moneyList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public void RemoveLast()
    {
        if (logList.Count > 0)
        {
            Destroy(logList[logList.Count - 1]);

            logList.RemoveAt(logList.Count - 1);
        }
    }

    public void Work()
    {
        forestAnim.SetBool("Work", true);

        InvokeRepeating("SubmitLogs", 2f, 1f);
    }

    void SubmitLogs()
    {
        if (transform.childCount>0)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject, 1f);
        }
        else
        {
            forestAnim.SetBool("Work", false);
        }
    }

    public void GetLog()
    {
        GameObject temp = Instantiate(logPrefab);
        temp.transform.position = new Vector3(logPoint.position.x, -1f + ((float)logList.Count / 2), logPoint.position.z);
        logList.Add(temp);
    }

    //stacklenen kutuklerin belli bir sirayla hizalanmasi icin (calismiyor)
    //int stackLog = 5;
    //bool isCutting;

    //public void cutLastLog()
    //{
    //    Destroy(logList[logList.Count - 1]);
    //    logList.RemoveAt(logList.Count - 1);
    //}

    //IEnumerator CutLog()
    //{
    //    while (true)
    //    {
    //        float logCount = logList.Count;

    //        int rowCount = (int)logCount / stackLog;

    //        if (isCutting == true)
    //        {
    //            GameObject temp = Instantiate(logPrefab);
    //            temp.transform.position = new Vector3(logPoint.position.x + ((float)rowCount), (logCount % stackLog) / 2, logPoint.position.z);

    //            logList.Add(temp);

    //            if (logList.Count>19)
    //            {
    //                isCutting = false;
    //            }
    //        }
    //        else if (logList.Count < 19)
    //        {
    //            isCutting = true;
    //        }

    //        yield return new WaitForSeconds(1f);
    //    }
    //}
}