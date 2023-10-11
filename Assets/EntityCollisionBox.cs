using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBox : MonoBehaviour
{
    public LayerMask avoidLayer;
    public PlayerController playerController;
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
                playerController._OnFloor = true;

            }
            else
            {
                playerController._OnFloor = false;
            }
        }
     
    }

    private void OnTriggerExit(Collider collision)
    {
        var col = collision.gameObject;
        if (col.layer != LayerMask.NameToLayer("Player"))
        {
             inCollision = false;
            playerController._OnFloor = false;

        }
      

    }

    public enum collisionType 
    {
        floor,
        enemy
    }
}
