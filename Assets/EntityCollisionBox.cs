using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBox : MonoBehaviour
{
    public LayerMask avoidLayer;
    public bool inCollision = false;
    public collisionType type;


    private void OnTriggerEnter(Collider collision)
    {
        var col = collision.gameObject;

        if (col.layer != LayerMask.NameToLayer("Player"))
        {
          
            inCollision = true;
            if (col.layer == LayerMask.NameToLayer("Floor"))
            {
                type = collisionType.floor;

            }
        }
     
    }

    private void OnTriggerExit(Collider collision)
    {
        var col = collision.gameObject;
        if (col.layer != LayerMask.NameToLayer("Player"))
        {
             inCollision = false;
           
        }
      

    }

    public enum collisionType 
    {
        floor,
        enemy
    }
}
