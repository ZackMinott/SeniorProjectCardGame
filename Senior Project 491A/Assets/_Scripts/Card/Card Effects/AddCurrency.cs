﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Effect/Add Currency")]
public class AddCurrency : CardEffect
{
    [SerializeField] private int currencyAdditionAmount;
    void AddCurrencyByEffect()
    {
        Debug.Log("Adding currecny from effect");
        TurnManager.Instance.turnPlayer.Currency += currencyAdditionAmount;
    }

    public override void LaunchCardEffect()
    {
        AddCurrencyByEffect();
    }
}
