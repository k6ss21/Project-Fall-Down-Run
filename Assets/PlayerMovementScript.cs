using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Jump Settings")]
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    [Space(10)]

    public float moveSpeed ;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }
    private void FixedUpdate() {
        ForwardMovement();
    }
    void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void ForwardMovement()
    {
        transform.position += new Vector3(0,0,.1f) * moveSpeed ;        
    }
}
