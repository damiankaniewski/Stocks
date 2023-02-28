using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyPrinter : MonoBehaviour
{
    public TextMeshProUGUI[] moneyText;
    public TextMeshProUGUI[] companyName;
    public TextMeshProUGUI[] price;
    public TextMeshProUGUI[] value;
    public TextMeshProUGUI[] changeText;
    private string stockValueChangeText = null;

    private GameManager gameManager;
    private StockManager stockManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        stockManager = FindObjectOfType<StockManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < moneyText.Length; i++)
        {
            moneyText[i].SetText(gameManager.money.ToString("F2") + "$");
        }

        for (int i = 0; i < companyName.Length; i++)
        {
            companyName[i].SetText(stockManager.stocks[i].companyName);
            price[i].SetText(stockManager.stocks[i].stockPrice.ToString("F2") + "$");
        }

        for (int i = 0; i < value.Length; i++)
        {
            value[i].SetText(gameManager.amount.ToString());
        }

        PrintChange();
    }

    public void PrintChange()
    {
        for (int i = 0; i < changeText.Length; i++)
        {
            if (stockManager.stocks[i].stockValueChange > 0)
            {
                stockValueChangeText = "+" + stockManager.stocks[i].stockValueChange.ToString("F2") + "$";
                changeText[i].color = Color.green;
            }
            else if (stockManager.stocks[i].stockValueChange == 0)
            {
                stockValueChangeText = "---";
                changeText[i].color = Color.white;
            }
            else
            {
                stockValueChangeText = stockManager.stocks[i].stockValueChange.ToString("F2") + "$";
                changeText[i].color = Color.red;
            }

            changeText[i].SetText(stockValueChangeText);
        }
    }
}