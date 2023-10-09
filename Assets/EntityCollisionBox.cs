using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollisionBox : MonoBehaviour
{
    public bool inCollision = false;
    public collisionType type;

    private void OnCollisionEnter(Collision collision)
    {
        inCollision = true;
        var col = collision.gameObject;
        if (col.layer == LayerMask.NameToLayer("Floor"))
        {
            type = collisionType.floor;
           
        }
        
      
    }


    public enum collisionType 
    {
        floor,
        enemy
    }
}
