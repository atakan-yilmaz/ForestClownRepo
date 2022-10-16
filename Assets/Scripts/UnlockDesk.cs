using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using DG.Tweening;

public class UnlockDesk : MonoBehaviour
{
    [SerializeField] private GameObject unlockProgressObj;
    [SerializeField] private GameObject newShack;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI dollarAmount;
    [SerializeField] private int shackPrice, shackRemainPrice;
    [SerializeField] private float ProgressValue;

    public NavMeshSurface buildNavMesh;

    private void Start()
    {
        dollarAmount.text = shackPrice.ToString("0");
        shackRemainPrice = shackPrice;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("Money") > 0)
        {
            ProgressValue = Mathf.Abs(1f - CalculateMoney() / shackPrice);

            if (PlayerPrefs.GetInt("Money") >= shackPrice)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - shackPrice);

                shackRemainPrice = 0;
            }
            else
            {
                shackRemainPrice -= PlayerPrefs.GetInt("Money");
                PlayerPrefs.SetInt("Money", 0);
            }

            progressBar.fillAmount = ProgressValue;

            CharacterController.CharacterControllerInstance.MoneyCounter.text = PlayerPrefs.GetInt("Money").ToString("0");
            dollarAmount.text = shackRemainPrice.ToString("0");

            if (shackRemainPrice == 0)
            {
                GameObject shack = Instantiate(newShack, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0f, 90f, 0f));

                shack.transform.DOScale(1.1f, 1f).SetEase(Ease.OutElastic);
                shack.transform.DOScale(1f, 1f).SetDelay(1.1f).SetEase(Ease.OutElastic);

                unlockProgressObj.SetActive(false);

                buildNavMesh.BuildNavMesh();
            }
        }
    }

    private float CalculateMoney()
    {
        return shackPrice - PlayerPrefs.GetInt("Money");
    }
}