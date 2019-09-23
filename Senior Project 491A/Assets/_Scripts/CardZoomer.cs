using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoomer : MonoBehaviour
{
    public GameObject playerCard;
    public GameObject enemyCard;

    public Vector2 OriginalPosition;

    public Vector3 screenPoint;
    public Vector3 offset;

    private void Awake()
    {
        OriginalPosition = this.transform.position;
    }

    //when the mouse hovers the card
    public void OnMouseEnter()
    {
        //If playercard is touched, zoom and shift upwards
        //If enemycard is touched, zoom and shift downwards
        
        transform.localScale += new Vector3(1.5F, 1.5F, 1.5F); //zooms in the object
        gameObject.transform.position += new Vector3(0, 1, 0);

        //TODO: Move the cards up when it's on the bottom and move the cards down when it's on top when it's zoomed.
    }

    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); //used to grab the z coordinate of the game object 

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void OnMouseExit()
    {
        //Debug.Log("exit");
        transform.localScale = new Vector3(1, 1, 1);  //returns the object to its original state
        gameObject.transform.position = OriginalPosition;
    }
}