﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

/// <summary>
/// Holds pertinent information specific to PlayerCards. Extends CardHolder.
/// </summary>
[ExecuteInEditMode]
public class PlayerCardHolder : CardHolder
{
    public PlayerCard card;

    [SerializeField] private TextMeshPro attackText;
    [SerializeField] private TextMeshPro costText;
    [SerializeField] private TextMeshPro currencyText;
    [SerializeField] private SpriteRenderer cardEffectCostsIcons;
    [SerializeField] private SpriteRenderer costIcon;
    [SerializeField] private List<GameObject> cardIcons = new List<GameObject>();

    protected override void Awake()
    {
        //Debug.Log("PlayerCardHolder: Awake()");
        //PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;

        //Debug.Log("PlayerCardHolder: += NetworkingClient_EventReceived");
        LoadCardIntoContainer();
    }

    /// <summary>
    /// Called when this object is enabled. Adds EventReceived to the Networking Client.
    /// </summary>
    [ExecuteInEditMode]
    protected override void OnEnable()
    {
        //Debug.Log("PlayerCardHolder: OnEnable()");
        LoadCardIntoContainer();
        //PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    /// <summary>
    /// Called when this object is disabled. Removes EventReceived from the Networking Client.
    /// </summary>
    [ExecuteInEditMode]
    protected override void OnDisable()
    {
        ClearCardFromContainer();
        //PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }


    protected override void LoadCardIntoContainer()
    {
        cardArtDisplay.sprite = card.CardArtwork;
        //Debug.Log("CardArtwork: " + card.CardArtwork.ToString());
        typeIcon.sprite = card.CardTypeArt;
        cardBorder.sprite = card.BorderArt;
        cardEffectTextBox.sprite = card.CardEffectBoxArt;
        cardNameTextBox.sprite = card.NameBoxArt;
        nameText.text = card.CardName;
        cardEffectText.text = card.CardEffectDisplay;
        attackText.text = card.CardAttack.ToString();
        costText.text = card.CardCost.ToString();
        currencyText.text = card.CardCurrency.ToString();
        LoadCostEffectIcons();
    }




    /// <summary>
    /// Removes all references to the Card's information from this holder.
    /// </summary>
    protected override void ClearCardFromContainer()
    {
        card = null;
        cardArtDisplay.sprite = null;
        typeIcon.sprite = null;
        cardBorder.sprite = null;
        cardEffectTextBox.sprite = null;
        cardNameTextBox.sprite = null;
        nameText.text = null;
        cardEffectText.text = null;
        attackText.text = null;
        costText.text = null;
        currencyText.text = null;

        RemoveCardEffectCostIcons();

        if (this.transform.parent.gameObject.GetComponent<HandContainer>() != null)
        {
            costIcon.gameObject.SetActive(false);
        }
    }

    private void LoadCostEffectIcons()
    {
        // Initial spawn point that changes with each card added
        Vector3 spawnPoint = new Vector3(-.55f, .23f, 0f);

        foreach (var cardIconSprite in card.cardCostsIcons)
        {
            SpriteRenderer cardIcon = Instantiate(cardEffectCostsIcons, cardEffectTextBox.transform.position, Quaternion.identity, cardEffectTextBox.transform);
            cardIcon.sortingLayerName = "Player Card" ;
            cardIcons.Add(cardIcon.gameObject);
            cardIcon.transform.position += spawnPoint;
            spawnPoint += new Vector3(.10f, 0f, 0f);
            cardIcon.sprite = cardIconSprite;
        }
    }

    private void RemoveCardEffectCostIcons()
    {
        // Debug.Log(cardIcons.Count);
        for (int i = 0; i < cardIcons.Count; i++)
        {
            DestroyImmediate(cardIcons[i].gameObject);
            // Debug.Log("Object Destroyed " + i);
        }

        cardIcons.Clear();
    }
    
    
//    private void NetworkingClient_EventReceived(EventData obj)
//    {
//        if (obj.Code == LOAD_CARD_EVENT)
//        {
//            //Debug.Log("PlayerCardHolder: LOAD_CARD_EVENT received!");
//            object[] datas = (object[])obj.CustomData;
//
//            LoadCardIntoContainer(datas);
//        }
//    }

    /// <summary>
    /// Loads all of the Card's pertinent information into the holder.
    /// </summary>
    /*protected override void LoadCardIntoContainer()
    {
        //Debug.Log("PlayerCardHolder: LoadCardIntoContainer()");

        if (base.photonView.IsMine)
        {
            // PUN Required
            //object[] cardData;

            //Debug.Log("PlayerCardHolder: photonView.IsMine");

            cardArtDisplay.sprite = card.CardArtwork;
            //Debug.Log("CardArtwork: " + card.CardArtwork.ToString());
            typeIcon.sprite = card.CardTypeArt;
            cardBorder.sprite = card.BorderArt;
            cardEffectTextBox.sprite = card.CardEffectBoxArt;
            cardNameTextBox.sprite = card.NameBoxArt;
            nameText.text = card.CardName;
            cardEffectText.text = card.CardEffectDisplay;
            attackText.text = card.CardAttack.ToString();
            costText.text = card.CardCost.ToString();
            currencyText.text = card.CardCurrency.ToString();

            object[] cardData = new object[]
            {
                cardArtDisplay.sprite,
                typeIcon.sprite,
                cardBorder.sprite,
                cardEffectTextBox.sprite,
                cardNameTextBox.sprite,
                nameText.text,
                cardEffectText.text,
                attackText.text,
                costText.text,
                currencyText.text
            };

            RaiseEventOptions reo = new RaiseEventOptions
            {
                CachingOption = EventCaching.AddToRoomCache,
                InterestGroup = 0,
                TargetActors = null,
                Receivers = ReceiverGroup.Others
            };

            // THIS IS FAILING IDK WHY WHAT THE HECK
            PhotonNetwork.RaiseEvent(LOAD_CARD_EVENT, cardData, reo, SendOptions.SendReliable);

            LoadCostEffectIcons();
        }
    }*/
    
    /// <summary>
    /// Overloaded method used for PUN.
    /// </summary>
    /// <param name="cardData"></param>
//    protected void LoadCardIntoContainer(object[] cardData)
//    {
//        //Debug.Log("PlayerCardHolder: LoadCardIntoContainer(params)");
//
//        cardArtDisplay.sprite = (Sprite)cardData[0];
//        typeIcon.sprite = (Sprite)cardData[1];
//        cardBorder.sprite = (Sprite)cardData[2];
//        cardEffectTextBox.sprite = (Sprite)cardData[3];
//        cardNameTextBox.sprite = (Sprite)cardData[4];
//        nameText.text = (string)cardData[5];
//        cardEffectText.text = (string)cardData[6];
//        attackText.text = (string)cardData[7];
//        costText.text = (string)cardData[8];
//        currencyText.text = (string)cardData[9];
//
//        //LoadCostEffectIcons();
//    }

}
