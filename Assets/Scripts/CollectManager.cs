using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> logList = new List<GameObject>();
    public GameObject logPrefab;
    public Transform collectPoint;

    int logLimit = 3;

    private void OnEnable()
    {
        TriggerEventManager.OnLogCollect += GetLog;
        TriggerEventManager.OnLogGive += GiveLog;
    }

    private void OnDisable()
    {
        TriggerEventManager.OnLogCollect -= GetLog;
        TriggerEventManager.OnLogGive -= GiveLog;
    }

    void GetLog()
    {
        if (logList.Count <= logLimit)
        {
            GameObject temp = Instantiate(logPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f+((float)logList.Count / 2), collectPoint.position.z);
            logList.Add(temp);

            if (TriggerEventManager.carpentryManagerExp != null)
            {
                TriggerEventManager.carpentryManagerExp.RemoveLast();
            }
        }
    }

    void GiveLog()
    {
        if (logList.Count > 0)
        {
            TriggerEventManager.workerManager.GetLog();
            RemoveLast();
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
}