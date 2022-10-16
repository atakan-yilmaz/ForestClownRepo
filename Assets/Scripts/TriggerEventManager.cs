using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnLogCollect;

    public static CarpentryManagerExp carpentryManagerExp;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnLogGive;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;

    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingShack;

    public static BuyArea areaToBuy;

    public static WorkerManager workerManager;

    bool isCollecting, isGiving;

    private void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnLogCollect();
            }
            if (isGiving == true)
            {
                OnLogGive();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            OnBuyingShack();
            areaToBuy = other.gameObject.GetComponent<BuyArea>();
        }
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;

            carpentryManagerExp = other.gameObject.GetComponent<CarpentryManagerExp>();
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;

            carpentryManagerExp = null;

            Debug.Log("exit");
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGiving = false;
            workerManager = null;
            Debug.Log("workArea");
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            areaToBuy = null;
            Debug.Log("BuyArea");
        }
    }
}