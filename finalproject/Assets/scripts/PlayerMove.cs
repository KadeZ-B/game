using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    public float Speed
    {
        get { return speed; }
    }

    private Rigidbody2D rb;
    private Tilemap wallsTilemap;
    private Bounds playerBounds;
    private Animator m_animator;
    private Vector2 movement;

    // Dirty Flag
    private bool isPositionDirty = true;

    public interface IPlayerObserver
    {
        void OnPlayerMove(Vector2 movement);
    }

    private List<IPlayerObserver> playerObservers = new List<IPlayerObserver>();

    public void AddObserver(IPlayerObserver observer)
    {
        playerObservers.Add(observer);
    }

    public void RemoveObserver(IPlayerObserver observer)
    {
        playerObservers.Remove(observer);
    }

    private void NotifyObservers(Vector2 movement)
    {
        foreach (var observer in playerObservers)
        {
            observer.OnPlayerMove(movement);
        }
    }

    public void ModifySpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        wallsTilemap = GameObject.Find("WallsMap").GetComponent<Tilemap>();
        CalculatePlayerBounds();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY);
        movement.Normalize();

        NotifyObservers(movement);

        if (moveX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (moveX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Mathf.Abs(moveX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);
        else
            m_animator.SetInteger("AnimState", 0);

        // Set the position dirty when movement is detected
        if (moveX != 0 || moveY != 0)
        {
            isPositionDirty = true;
        }
    }

    void FixedUpdate()
{
    // Check if the position is dirty before updating
    if (isPositionDirty)
    {
        UpdatePlayerPosition();
        isPositionDirty = false; // Reset the dirty flag after updating
    }

    // Apply the movement to rb.velocity
    rb.velocity = movement * speed;

    CheckForWallCollisions();
}

    void CalculatePlayerBounds()
    {
        playerBounds = GetComponent<Collider2D>().bounds;
    }

    void UpdatePlayerPosition()
    {
        // Update the player's position logic goes here
        // For example, rb.position = new Vector2(...);

        // ... Other code ...
    }

    void CheckForWallCollisions()
    {
        Vector2 currentPosition = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, rb.velocity.normalized, rb.velocity.magnitude * Time.deltaTime, LayerMask.GetMask("Walls"));

        if (hit.collider != null)
        {
            Vector2 newTargetPosition = hit.point - rb.velocity.normalized * playerBounds.extents.magnitude * 1.1f;
            rb.position = newTargetPosition;
            rb.velocity = Vector2.zero;
        }
    }
}
