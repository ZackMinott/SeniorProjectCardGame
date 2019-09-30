using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    public Vector2 OriginalPosition;

    public Vector3 OriginalScale;
    private Vector3 offset;
    private Vector3 screenPoint;
    BoxCollider2D playZoneCollider;

    public delegate void _ShopCardClicked(PlayerCardHolder cardClicked);

    public static event _ShopCardClicked ShopCardClicked;

    private void Awake()
    {
        OriginalPosition = this.transform.position;
        OriginalScale = transform.localScale;
    }

    public void OnMouseDown()
    {
        if (this.transform.parent.gameObject.GetComponent<HandContainer>() == null)
        {
            //Debug.Log("Card is in Shop");
            PlayerCardHolder cardClicked = this.gameObject.GetComponent<PlayerCardHolder>();
            ShopCardClicked?.Invoke(cardClicked);
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); //used to grab the z coordinate of the game object 

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void OnMouseUp()
    {
        if (this.gameObject != null && PlayZone.cardInPlayZone == false)
        {
            this.transform.position = OriginalPosition;
        }
    }

    //Zooms the card when the mouse cursor hovers over it
    public void OnMouseEnter()
    {
        Debug.Log("enter");
        //Toggle the Collider on and off when pressing the space bar
        playZoneCollider.enabled = !playZoneCollider.enabled;
        //Output to console whether the Collider is on or not
        Debug.Log("Collider.enabled = " + playZoneCollider.enabled);
        transform.localScale += new Vector3(1.5F, 1.5F, 0); //zooms in the object
        gameObject.transform.position += new Vector3(0, 1, 0);
    }

    //Returns the card to it's original size when the mouse cursor leaves the card object
    public void OnMouseExit()
    {
        Debug.Log("exit");
        transform.localScale = OriginalScale;  //returns the object to its original state
        gameObject.transform.position = OriginalPosition;
    }

    public void OnMouseDrag()
    {
        if (this.transform.parent.gameObject.GetComponent<HandContainer>() == null)
        {
            return;
        }

        //Debug.Log("Attempting to drag and the object is draggable");


        UnityEngine.Vector2 cursorScreenPoint = new UnityEngine.Vector2(Input.mousePosition.x, Input.mousePosition.y); //stores position of cursor in screen space
        UnityEngine.Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset; //grabs the position of the mouse cursor and converts to world space

        transform.position = cursorPosition; //updates position of game object        
    }
}


//public class DragCard : MonoBehaviour
    //{
        //public delegate void _onCardPurschased(PlayerCard cardBought);
        //public static event _onCardPurschased CardPurchased;

        //private Vector3 screenPoint;
        //private Vector3 offset;

        //private PlayerCard card;

        //public bool draggable = true;

        //public void Awake()
        //{
        //    card = GetComponent<PlayerCard>();
        //}

        //void OnMouseDown()
        //{
        //    if (card.inShop)
        //    {
        //        draggable = true;
        //        //if (card.PurchaseCard())
        //        //{
        //        //    if (CardPurchased != null)
        //        //    {
        //        //        CardPurchased.Invoke(card);
        //        //    }
        //        //}
        //    }
        //    else
        //    {
        //        draggable = true;
        //        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); //used to grab the z coordinate of the game object 

        //        offset = gameObject.transform.position -
        //                 Camera.main.ScreenToWorldPoint(
        //                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //    }
        //}

        //void OnMouseDrag()
        //{
        //    if (draggable)
        //    {
        //        UnityEngine.Vector2 cursorScreenPoint = new UnityEngine.Vector2(Input.mousePosition.x, Input.mousePosition.y); //stores position of cursor in screen space
        //        UnityEngine.Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset; //grabs the position of the mouse cursor and converts to world space

        //        transform.position = cursorPosition; //updates position of game object
        //    }
        //}
    //}
