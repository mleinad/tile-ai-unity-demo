using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class currencyManager : MonoBehaviour
{
    public Text currencyValue;  // Reference to the Text element displaying the currency value.
    public int currency = 100;
    

    void Start()
    {
        UpdateCurrency(currency); // Initialize the currency value
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddCurrency(10); // Call the function to add 10 to the currency
        }
    }

    public void UpdateCurrency(int newCurrency)
    {
        currency = newCurrency;
        currencyValue.text = currency.ToString();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateCurrency(currency);
    }
}
