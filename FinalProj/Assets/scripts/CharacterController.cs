using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Reference to the assassin character's Rigidbody component.
    private Rigidbody assassinRigidbody;

    // The layer mask to determine what's considered ground.
    public LayerMask groundLayer;

    // A small offset to cast rays slightly above the character's feet.
    public float groundCheckOffset = 0.1f;

    // The maximum distance to consider the character grounded.
    public float groundCheckDistance = 0.2f;

    // Flag to track whether the character is grounded.
    private bool isGrounded;

    private void Awake()
    {
        // Get a reference to the Rigidbody component attached to the assassin.
        assassinRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Perform a raycast to check if the character is grounded.
        isGrounded = Physics.Raycast(
            transform.position + Vector3.up * groundCheckOffset,
            Vector3.down,
            groundCheckDistance,
            groundLayer
        );

        // If the character is not grounded, prevent them from falling through the map.
        if (!isGrounded)
        {
            // You can adjust the velocity as needed to prevent falling.
            assassinRigidbody.velocity = new Vector3(
                assassinRigidbody.velocity.x,
                0f,
                assassinRigidbody.velocity.z
            );
        }
    }
}
