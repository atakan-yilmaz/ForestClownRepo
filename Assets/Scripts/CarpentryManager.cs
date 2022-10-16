//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class CarpentryManager : MonoBehaviour
//{
//    //public List<GameObject> billetList = new List<GameObject>();
//    //public GameObject billetPrefab;
//    //public Transform exitPoint;

//    //bool isWorking;

//    [SerializeField] private Transform[] logPlace = new Transform[10];
//    [SerializeField] private GameObject log;
//    [SerializeField] private float logDeliveryTime, YAxis;

//    private void Start()
//    {
//        for (int i = 0; i < logPlace.Length; i++)
//        {
//            logPlace[i] = transform.GetChild(2).GetChild(i);
//        }

//        StartCoroutine(cutLog(logDeliveryTime));
//    }

//    public IEnumerator cutLog(float Time)
//    {
//        var CountLog = 0;
//        var CL_index = 0;

//        while (CountLog < 100)
//        {
//            GameObject NewLog = Instantiate(log, new Vector3(transform.position.x, -3f, transform.position.z), Quaternion.identity, transform.GetChild(3));

//            NewLog.transform.DOJump(new Vector3(logPlace[CL_index].position.x, logPlace[CL_index].position.y + YAxis, logPlace[CL_index].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);

//            if (CL_index < 9)
//                CL_index++;
//            else
//            {
//                CL_index = 0;
//                YAxis += 0.3f;
//            }

//            yield return new WaitForSecondsRealtime(Time);
//        }
//    }
//}