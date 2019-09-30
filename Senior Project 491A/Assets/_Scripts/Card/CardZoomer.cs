using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoomer : MonoBehaviour
{
    public Vector2 OriginalPosition;

    private Vector3 offset;
    private Vector3 screenPoint;

    public delegate void _ShopCardClicked(PlayerCardHolder cardClicked);

    public static event _ShopCardClicked ShopCardClicked;

    //public Bounds bounds;

    //public static Vector3 mousePosition;

    private void Awake()
    {
        OriginalPosition = this.transform.position;
    }

    public void OnMouseDown()
    {
        if (this.transform.parent.gameObject.GetComponent<HandContainer>() == null)
        {
            PlayerCardHolder cardClicked = this.gameObject.GetComponent<PlayerCardHolder>();
            ShopCardClicked?.Invoke(cardClicked);
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); //used to grab the z coordinate of the game object 

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    ////Zooms the card when the mouse cursor hovers over it
    //public void OnMouseEnter()
    //{
    //    Debug.Log("enter");
    //    //Toggle the Collider on and off when pressing the space bar
    //    //m_Collider.enabled = !m_Collider.enabled;
    //    //Output to console whether the Collider is on or not
    //    //Debug.Log("Collider.enabled = " + m_Collider.enabled);
    //    transform.localScale += new Vector3(1.5F, 1.5F, 0); //zooms in the object
    //    gameObject.transform.position += new Vector3(0, 1, 0);        
    //}

    ////Returns the card to it's original size when the mouse cursor leaves the card object
    //public void OnMouseExit()
    //{
    //    Debug.Log("exit");
    //    transform.localScale = OriginalScale;  //returns the object to its original state
    //    gameObject.transform.position = OriginalPosition;
    //}
}