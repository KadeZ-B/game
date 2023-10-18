using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float rotationSpeed = 120.0f;
    [SerializeField] float moveInterval = 3.0f; // Time between movement changes

    private Vector3 currentDestination;
    private float timeSinceLastMove;
    private Rigidbody2D skeletonRigidbody;

    void Start()
    {
        skeletonRigidbody = GetComponent<Rigidbody2D>();

        // Start with the initial destination and time
        SetRandomDestination();
    }

    void Update()
    {
        // Check if it's time to change the destination
        timeSinceLastMove += Time.deltaTime;
        if (timeSinceLastMove >= moveInterval)
        {
            SetRandomDestination();
        }

        // Calculate the direction to the current destination, considering only X and Y axes
        Vector2 currentPos2D = new Vector2(transform.position.x, transform.position.y);
        Vector2 dest2D = new Vector2(currentDestination.x, currentDestination.y);
        Vector2 moveDirection = (dest2D - currentPos2D).normalized;

        // Apply rotation based on movement direction
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Cast a ray to check for walls in the forward direction
        RaycastHit2D hitForward = Physics2D.Raycast(currentPos2D, moveDirection, moveSpeed * Time.deltaTime, LayerMask.GetMask("Walls"));

        if (hitForward.collider == null || hitForward.distance > 0.1f)
        {
            // No wall detected in the forward direction, apply movement
            skeletonRigidbody.velocity = moveDirection * moveSpeed;
        }
        else
        {
            // Wall detected in the forward direction, stop the movement
            skeletonRigidbody.velocity = Vector2.zero;
        }
    }

    void SetRandomDestination()
    {
        // Calculate a new random destination within a defined range, considering only X and Y axes
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-5f, 5f);
        currentDestination = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

        // Reset the timer
        timeSinceLastMove = 0f;
    }
}
