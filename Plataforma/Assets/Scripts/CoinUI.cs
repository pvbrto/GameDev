using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private int coinAmountAtStart;
    [SerializeField] private TMP_Text coinAmount;

    public static int currentCoinAmount = 20;

    void Start()
    {
        currentCoinAmount = coinAmountAtStart;
    }

    void Update()
    {
        coinAmount.text = currentCoinAmount.ToString();

        if (SceneManager.GetActiveScene().name == "Level 1" && currentCoinAmount == 9)
        {
            SceneManager.LoadScene("Level 3");
        }
    }
}