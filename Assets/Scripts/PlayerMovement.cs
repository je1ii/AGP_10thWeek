using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 6f;
    public float acceleration = 15f;
    public float jumpForce = 6f;

    Rigidbody rb;
    Vector3 inputDirection;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetVelocity = inputDirection.normalized * maxSpeed;
        Vector3 velocityChange = targetVelocity - rb.linearVelocity;
        velocityChange.y = 0;
        
        rb.AddForce(velocityChange * acceleration, ForceMode.Acceleration);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
                isGrounded = true;
        
    }
}
