﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MinionCardHolder : EnemyCardHolder
{
    
    public delegate void _cardDestroyed(EnemyCardHolder destroytedCard);
    public static event _cardDestroyed CardDestroyed;

    public delegate void _MinionCardClicked(MinionCardHolder cardClicked);

    public static event _MinionCardClicked MinionCardClicked;
    
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDestroy()
    {
        Debug.Log("minion card was destroyed");
        base.OnDestroy();
        if(CardDestroyed != null)
            CardDestroyed.Invoke(this);
    }

    protected override void OnMouseDown()
    {
        MinionCardClicked?.Invoke(this);
    }
}
