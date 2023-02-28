using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class StockPrinter : MonoBehaviour
{
    private StockManager stockManager;
    private MoneyPrinter moneyPrinter;
    public TextMeshProUGUI[] stocksPricesText;
    public TextMeshProUGUI[] stocksRandomEventText;

    private string stockPrice;
    private string randomEventText;

    void Start()
    {
        stockManager = FindObjectOfType<StockManager>();
        moneyPrinter = FindObjectOfType<MoneyPrinter>();
        InvokeRepeating("StockUpdate", 1, 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetText();
            StockUpdate();
        }

        for (int i = 0; i < stocksPricesText.Length; i++)
        {
            stocksPricesText[i].SetText(stockPrice);
        }

        for (int i = 0; i < stocksRandomEventText.Length; i++)
        {
            stocksRandomEventText[i].SetText(randomEventText);
        }
    }

    public void StockUpdate()
    {
        ResetText();
        for (int i = 0; i < stockManager.stocks.Length; i++)
        {
            string stockValue = stockManager.stocks[i].stockPrice.ToString("F2") + "$";
            string stockValueChange = null;
            if (stockManager.stocks[i].stockValueChange > 0)
            {
                stockValueChange = "+" + stockManager.stocks[i].stockValueChange.ToString("F2") + "$";
            }
            else if (stockManager.stocks[i].stockValueChange == 0)
            {
                stockValueChange = "---";
            }
            else
            {
                stockValueChange = stockManager.stocks[i].stockValueChange.ToString("F2") + "$";
            }

            stockPrice += (stockManager.stocks[i].companyName + ": " + stockValue + "\t\t" + stockValueChange + "\n");
            
        }
    }

    public void ResetText()
    {
        stockPrice = "";
    }

    public void SetRandomEventText(int eventIndex, int companyIndex)
    {
        for (int i = 0; i < stockManager.randomEvents.Length; i++)
        {
            if (stockManager.randomEvents[eventIndex].priceChange == 0) //price set
            {
                randomEventText = stockManager.stocks[companyIndex].companyName + " ----- " +
                                  stockManager.randomEvents[eventIndex].name + "\n" +
                                  stockManager.randomEvents[eventIndex].text + " Stock price: " +
                                  stockManager.randomEvents[eventIndex].priceSet + "$";
            }
            else //price change
            {
                if (stockManager.randomEvents[eventIndex].priceChange > 0)
                {
                    randomEventText = stockManager.stocks[companyIndex].companyName + " ----- " +
                                      stockManager.randomEvents[eventIndex].name + "\n" +
                                      stockManager.randomEvents[eventIndex].text + " Stock price change: +" +
                                      stockManager.randomEvents[eventIndex].priceChange + "$";
                }
                else
                {
                    randomEventText = stockManager.stocks[companyIndex].companyName + " ----- " +
                                      stockManager.randomEvents[eventIndex].name + "\n" +
                                      stockManager.randomEvents[eventIndex].text + " Stock price change: " +
                                      stockManager.randomEvents[eventIndex].priceChange + "$";
                }
            }
        }
    }
}