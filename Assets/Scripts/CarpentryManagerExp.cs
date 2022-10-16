using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpentryManagerExp : MonoBehaviour
{
    public List<GameObject> logList = new List<GameObject>();
    public GameObject logPrefab;
    public Transform exitPoint;
    bool isWorking;

    int stackCount = 5;

    void Start()
    {
        StartCoroutine(CutLog());
    }

    public void RemoveLast() //ilk stacklenen log'u almak icin 
    {
        Destroy(logList[logList.Count - 1]);

        logList.RemoveAt(logList.Count - 1);
    }

    IEnumerator CutLog()
    {
        while (true)
        {
            float logCount = logList.Count;

            int rowCount = (int)logCount / stackCount;

            if (isWorking == true)
            {
                GameObject temp = Instantiate(logPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x + ((float)rowCount), (logCount % stackCount) / 2, exitPoint.position.z); // % mod alma islemidir.

                logList.Add(temp);

                if (logList.Count > 19)
                {
                    isWorking = false;
                }
            }
            else if (logList.Count < 19)
            {
                isWorking = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}