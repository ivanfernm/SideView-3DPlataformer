using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGizmo : MonoBehaviour
{
    public PlayerController playerController;

    [SerializeField] private Vector3 lastHit = Vector3.zero;

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
    
    public void UpdateJumpGizmo(Vector2 offset,bool upJump)
    {
        if (!upJump) { playerOffset = new Vector2(offset.x, calculateRaycastDown().y); }
        else 
        {
            var a = calculateRaycastUP();

            if(offset.y >= a.y) { playerOffset = new Vector2(offset.x, a.y); }
  
            else { playerOffset = offset;}
        }
   
        transform.position = playerController.transform.position + (Vector3)playerOffset;

    }

    Vector3 calculateRaycastDown() 
    {
        // Raycast example:
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
           // Debug.Log("Hit floor at point: " + hit.point);
            lastHit = hit.point;
            return hit.point;
        }
        else
        {
            // Debug.Log("No hit");
            return lastHit;
        }   
    }
    
    Vector3 calculateRaycastUP()
    {
        // Raycast example:
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            // Debug.Log("Hit floor at point: " + hit.point);
            lastHit = hit.point;
            return hit.point;
        }
        else
        {
            // Debug.Log("No hit");
            return lastHit;
        }   
    }
}
