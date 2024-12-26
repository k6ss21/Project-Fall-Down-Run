
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public PlayerMovementScript playerMovementScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            playerMovementScript.isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Ground"))
        {
            playerMovementScript.isGrounded = false;
        }
    }
}
