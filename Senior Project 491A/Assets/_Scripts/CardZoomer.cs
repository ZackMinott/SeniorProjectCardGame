using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoomer : MonoBehaviour
{
    private object myGameObject;

    public Vector2 OriginalPosition;

    private void Awake()
    {
        OriginalPosition = this.transform.position;
    }

    public void OnMouseEnter()
    {
        //Debug.Log("enter");
        transform.localScale += new Vector3(1.5F, 1.5F, 1.5F); //zooms in the object
        //TODO: Move the cards up when it's on the bottom and move the cards down when it's on top when it's zoomed.
    }


    public void OnMouseDown()
    {
        //TODO: Minimize the card when its clicked
    }

    public void OnMouseExit()
    {
        //Debug.Log("exit");
        transform.localScale = new Vector3(1, 1, 1);  //returns the object to its original state
    }
}