using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Rigidbody2D rb;
    private Tilemap wallsTilemap;
    private Bounds playerBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Find the "WallsMap" Tilemap in the scene (replace with your actual Tilemap name)
        wallsTilemap = GameObject.Find("WallsMap").GetComponent<Tilemap>();

        // Calculate the player's bounds for precise collision checks
        CalculatePlayerBounds();
    }

    void Update()
{
    float moveX = Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");

    Vector2 movement = new Vector2(moveX, moveY);
    movement.Normalize();

    // Cast a ray to check for walls in the forward direction
    RaycastHit2D hitForward = Physics2D.Raycast(transform.position, movement, movement.magnitude * Time.deltaTime, LayerMask.GetMask("Walls"));

    // Cast a ray to check for walls on the sides
    RaycastHit2D hitSide = Physics2D.Raycast(transform.position, Vector2.right * moveX, Mathf.Abs(moveX) * Time.deltaTime, LayerMask.GetMask("Walls"));

    if (hitForward.collider == null || hitForward.distance > 0.1f)
    {
        // No wall detected in the forward direction, apply the movement
        rb.velocity = movement * speed;
    }
    else
    {
        // Wall detected in the forward direction, stop the movement
        rb.velocity = Vector2.zero;
    }

    if (hitSide.collider != null)
    {
        // Wall detected on the side, prevent movement in that direction
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}





    void CalculatePlayerBounds()
    {
        // Calculate the player's bounds based on the collider
        playerBounds = GetComponent<Collider2D>().bounds;
    }

    void CheckForWallCollisions()
    {
        Vector2 currentPosition = transform.position;

        // Perform a raycast in the direction of movement
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, rb.velocity.normalized, rb.velocity.magnitude * Time.deltaTime, LayerMask.GetMask("Walls"));

        // Check if the ray hit a wall tile
        if (hit.collider != null)
        {
            // Calculate the new position to prevent collision
            Vector2 newTargetPosition = hit.point - rb.velocity.normalized * playerBounds.extents.magnitude * 1.1f;
            rb.position = newTargetPosition;
            rb.velocity = Vector2.zero;
        }
    }
}
