using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TrapBase : MonoBehaviour {

    public delegate void OnTrapped(Brother b);
    public event OnTrapped onTrappedStart;

   public event OnTrapped onTrappedExit;

    protected BoxCollider2D boxCollider;

    public virtual void Start()
    {
        boxCollider = GetComponent <BoxCollider2D>();

        //ensure that the collider is a trigger.
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (onTrappedStart != null)
                onTrappedStart(other.gameObject.GetComponent<Brother>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(onTrappedExit != null)
                onTrappedExit(other.gameObject.GetComponent<Brother>());
        }
    }


}
