using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private StockManager stockManager;

    public float money;
    public int amount; //how many stocks to buy/sell
    public List<int> stocksAmount;

    void Start()
    {
        stockManager = FindObjectOfType<StockManager>();
        money = 1000;
        amount = 1;

        int stockList = stockManager.stocks.Length;

        for (int i = 0; i < stockList; i++)
        {
            stocksAmount.Add(i);
        }

        for (int i = 0; i < stocksAmount.Count; i++)
        {
            stocksAmount[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stocksAmount[0]);

        if (Input.GetKeyDown(KeyCode.O))
        {
            AddMoney(500);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            RemoveMoney(500);
        }
    }

    public void AddMoney(float value)
    {
        money += value;
    }

    public void RemoveMoney(float value)
    {
        money -= value;
    }

    public void BuyStock(int index)
    {
        if (money > amount * stockManager.stocks[index].stockPrice)
        {
            RemoveMoney(amount * stockManager.stocks[index].stockPrice);
            stocksAmount[index] += amount;
        }

        ResetAmount();
    }

    public void SellStock(int index)
    {
        if (stocksAmount[index] > 0)
        {
            if (stocksAmount[index] >= amount)
            {
                AddMoney(amount * stockManager.stocks[index].stockPrice);
                stocksAmount[index] -= amount;
            }
            else
            {
                AddMoney(stocksAmount[index] * stockManager.stocks[index].stockPrice);
                stocksAmount[index] = 0;
            }
        }

        ResetAmount();
    }

    public void AddToValue(int value)
    {
        amount += value;
    }

    public void ResetAmount()
    {
        amount = 1;
    }
}