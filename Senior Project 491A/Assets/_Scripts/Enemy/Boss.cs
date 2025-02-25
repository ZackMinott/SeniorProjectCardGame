﻿/*
    Created by: David Taitingfong
    Date:       2019-04-11
 */


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/*
    This class represents a match's Boss
 */
[CreateAssetMenu(menuName = "Card/Boss Card")]
public class Boss : EnemyCard
{
    [SerializeField]
    private Goal goal;
    [SerializeField]
    private EnemyDeck bossDeck;
}

//public class Boss : EnemyCard
//   {
/* The Boss' Goal */
    //public Goal goal;
    
    /* Boss' health and reward value */
    //public int _health;

    //// from IEnemy
    //public int health
    //{
    //    get { return _health; }
    //    set { _health = value; }
    //}
    //public int rewardValue
    //{
    //    get { return _rewardValue;}
    //    set { _rewardValue = value;}
    //}

    /* The Boss' Deck */
    //public EnemyDeck bossDeck;

    //public CreateGrid EnemyGrid;
    //public BossTurnCardPlayer cardPlayer;

    // Start is called before the first frame update
    //void Start()
    //{
    //    // TODO: Set the goal?
    //    // TODO: Populate the Boss' deck?

    //    this.transform.position = EnemyGrid.GetNearestPointOnGrid(new Vector2(6, 2));

    //}

    //public override void OnMouseDown()
    //{
    //    if (cardPlayer.filledCardZones == 0)
    //    {
    //        Debug.Log("can attack boss");
    //        if (TurnManager.Instance.turnPlayer.GetPower() >= _health)
    //        {
    //            Destroy(this.gameObject);
    //        }
    //        else
    //        {
    //            Debug.Log("not enough power");

    //        }
    //    }
    //}
//}
