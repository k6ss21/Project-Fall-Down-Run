
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Jump Settings")]
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    [Space(10)]

    public float moveSpeed;
    Rigidbody rb;

    [Space(10)]
    public float sprintSpeed;
    public float spritEnergyAmount = 10;
    public float currentSprintEnergy;
    public float dischargeMulti;
    public float rechargeMulti;


    [SerializeField] Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSprintEnergy = spritEnergyAmount;
    }

    void Update()
    {
        Jump();
        Sprint();
        Slide();
    }
    private void FixedUpdate()
    {
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
            playerAnimator.SetTrigger("IsJump");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void ForwardMovement()
    {
        transform.position += new Vector3(0, 0, .1f) * moveSpeed * Time.deltaTime;
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (currentSprintEnergy > 0)
            {
                currentSprintEnergy -= 1 * dischargeMulti * Time.deltaTime;
                moveSpeed = sprintSpeed;
                playerAnimator.SetBool("IsSprint", true);
            }
        }
        else
        {
            playerAnimator.SetBool("IsSprint", false);
            currentSprintEnergy += 1 * rechargeMulti * Time.deltaTime;
            if (currentSprintEnergy > spritEnergyAmount)
            {
                currentSprintEnergy = spritEnergyAmount;
            }
        }
    }

    void Slide()
    {
        if (Input.GetKey(KeyCode.E))
        {
            playerAnimator.SetTrigger("IsSlide");
        }
        else
        {
           playerAnimator.ResetTrigger("IsSlide"); 
        }
    }
}
