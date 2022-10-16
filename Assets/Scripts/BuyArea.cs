using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyArea : MonoBehaviour
{
    public GameObject shackGameObject, buyGameObject;
    public Image progressImage;

    public float cost, currentMoney, progress;

    public void Buy(int goldAmount)
    {
        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;

        if (progress >= 1)
        {
            buyGameObject.SetActive(false);
            shackGameObject.SetActive(true);
            this.enabled = false;
        }
    }
}