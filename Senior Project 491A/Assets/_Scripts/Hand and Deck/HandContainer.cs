﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class HandContainer : PlayerCardContainer
{
    public Hand hand;
    public Deck playerDeck;
    public Graveyard playerGrave;
    public PlayerCard phantomCard;

    [SerializeField] private int DefaultHandSize = 5;

//    private void Awake()
//    {
//        InitialCardDisplay();
//    }

    private void OnEnable()
    {
        UIHandler.EndTurnClicked += DestroyHand;
        TurnManager.PlayerSwitched += InitialCardDisplay;
    }

    private void OnDisable()
    {
        UIHandler.EndTurnClicked -= DestroyHand;
        TurnManager.PlayerSwitched -= InitialCardDisplay;
    }


    protected override void InitialCardDisplay()
    {
        PlayerCard cardDrawn = null;

        for (int i = 0; i < DefaultHandSize; i++)
        {
            if (playerDeck.cardsInDeck.Count > 0)
            {
                cardDrawn = (PlayerCard)playerDeck.cardsInDeck.Pop();
            }
            else
            {
                if (playerGrave.graveyard.Count > 0)
                {
                    for (int j = 0; j < playerGrave.graveyard.Count; j++)
                    {
                        playerDeck.cardsInDeck.Push(playerGrave.graveyard[j]);
                        playerGrave.graveyard.Remove(playerGrave.graveyard[j]);
                    }
                    playerDeck.Shuffle();
                    cardDrawn = (PlayerCard)playerDeck.cardsInDeck.Pop();
                }
                else
                {
                    // Draw a phantom card
                    cardDrawn = phantomCard;
                }
            }

            if (cardDrawn == null)
            {
                Debug.Log("null card");
                return;
            }

            // Set the PlayerCardContainer's PlayerCardHolder to the cardDrawn
            holder.card = cardDrawn;
            // Place it on the grid!
            PlayerCardHolder cardHolder =  Instantiate(holder, containerGrid.freeLocations.Pop(), Quaternion.identity, this.transform);

            if (!containerGrid.cardLocationReference.ContainsKey(cardHolder.gameObject.transform.position))
                containerGrid.cardLocationReference.Add(cardHolder.gameObject.transform.position, cardHolder);
            else
                containerGrid.cardLocationReference[cardHolder.gameObject.transform.position] = cardHolder;
    
            hand.hand.Add(cardDrawn);
        }
    }

    private void DestroyHand()
    {
        foreach (var locationReferenceKeyValuePair in containerGrid.cardLocationReference)
        {
            if (locationReferenceKeyValuePair.Value != null)
            {
                Destroy(locationReferenceKeyValuePair.Value.gameObject);
            }
            containerGrid.freeLocations.Push(locationReferenceKeyValuePair.Key);
        }
    }

    /// <summary>
    /// Places a player's card onto the hand grid.
    /// </summary>
    /// <param name="card"></param>
    private void PlaceCard(PlayerCard cardToPlace)
    {
        //Vector2 spawnPoint;
        //spawnPoint = handGrid.GetNearestPointOnGrid(cardSpot);

        //if (handGrid.IsPlaceable(spawnPoint))
        //{
        //    card.SetCoord(spawnPoint);
        //    hand.Add(card);

        //    inHandObjects.Add(Instantiate(card, this.transform).gameObject);
        //    cardsInHand += 1;
        //    cardSpot.x += handGrid.size;
        //}
    }
}
