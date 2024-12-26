using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    Rigidbody rb;

    private void Start() {
        rb= GetComponentInParent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            rb.useGravity = true;
        }
    }
}
