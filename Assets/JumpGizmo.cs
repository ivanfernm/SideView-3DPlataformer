using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGizmo : MonoBehaviour
{
    public PlayerController playerController;

    public Vector2 playerOffset;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            transform.position = other.transform.position;
        }
    }
    
    public void UpdateJumpGizmo(Vector2 offset)
    {
        playerOffset = new Vector2(offset.x,calculateRaycast().y);
        transform.position = playerController.transform.position + (Vector3)playerOffset;

    }

    Vector3 calculateRaycast() 
    {
        // Raycast example:
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
           // Debug.Log("Hit floor at point: " + hit.point);
            
            return hit.point;
        }
        else
        {
           // Debug.Log("No hit");
            return Vector3.zero;
        }   
    }
    
}
