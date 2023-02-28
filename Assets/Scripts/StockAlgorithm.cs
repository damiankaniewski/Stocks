using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class StockAlgorithm : MonoBehaviour
{
    private StockManager stockManager;
    private StockPrinter stockPrinter;

    void Start()
    {
        stockManager = FindObjectOfType<StockManager>();
        stockPrinter = FindObjectOfType<StockPrinter>();
        InvokeRepeating("UpdateStockPrices", 1, 10);
        InvokeRepeating("RandomEvent", 1, 30);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void UpdateStockPrices()
    {
        for (int i = 0; i < stockManager.stocks.Length; i++)
        {
            stockManager.stocks[i].oldStockValue = stockManager.stocks[i].stockPrice;

            if (Random.value > 0.5) //50%
            {
                if (Random.value > 0.5)
                {
                    stockManager.stocks[i].stockPrice += Random.Range(0, 1f);
                }
                else
                {
                    stockManager.stocks[i].stockPrice -= Random.Range(0, 1f);
                }
            }

            if (Random.value > 0.98) //2%
            {
                if (Random.value > 0.5)
                {
                    stockManager.stocks[i].stockPrice += Random.Range(3, 8);
                }
                else
                {
                    stockManager.stocks[i].stockPrice -= Random.Range(3, 8);
                }
            }

            if (Random.value > 0.995) //0.5%
            {
                if (Random.value > 0.5)
                {
                    stockManager.stocks[i].stockPrice += Random.Range(8, 15);
                }
                else
                {
                    stockManager.stocks[i].stockPrice -= Random.Range(8, 15);
                }
            }

            if (Random.value > 0.9999) //0.05%
            {
                if (Random.value > 0.5)
                {
                    stockManager.stocks[i].stockPrice += Random.Range(25, 40);
                }
                else
                {
                    stockManager.stocks[i].stockPrice -= Random.Range(25, 35);
                }
            }

            if (stockManager.stocks[i].stockPrice <= 0)
            {
                stockManager.stocks[i].stockPrice = 10;
            }

            stockManager.stocks[i].stockValueChange =
                stockManager.stocks[i].stockPrice - stockManager.stocks[i].oldStockValue;
        }
    }

    private void RandomEvent()
    {
        int x = Random.Range(0, 3);
        if (x == 0)
        {
            int eventIndex = Random.Range(0, stockManager.randomEvents.Length);
            int companyIndex = Random.Range(0, stockManager.stocks.Length);
            
            stockManager.stocks[companyIndex].oldStockValue = stockManager.stocks[companyIndex].stockPrice;
            
            if (stockManager.randomEvents[eventIndex].priceChange == 0) //price set
            {
                stockManager.stocks[companyIndex].stockPrice = stockManager.randomEvents[eventIndex].priceSet;
                
            }
            else //price change
            {
                stockManager.stocks[companyIndex].stockPrice += stockManager.randomEvents[eventIndex].priceChange;
                if (stockManager.stocks[companyIndex].stockPrice < 0)
                {
                    stockManager.stocks[companyIndex].stockPrice = 0.01f;
                }
            }

            stockManager.stocks[companyIndex].stockValueChange =
                stockManager.stocks[companyIndex].stockPrice - stockManager.stocks[companyIndex].oldStockValue;
            
            stockPrinter.SetRandomEventText(eventIndex, companyIndex);
        }
    }
}