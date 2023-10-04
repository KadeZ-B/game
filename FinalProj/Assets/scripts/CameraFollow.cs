using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f; // Adjust the smoothness of camera movement.

    private Transform player; // Reference to the player character's Transform.
    private Vector3 offset;

    private void Start()
    {
        // Find the player character in the scene by tag (or you can use another method to find it).
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate the initial offset between the camera and the player.
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired camera position based on the player's position.
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Optionally, you can add code here to make the camera look at the player.
            // transform.LookAt(player);
        }
    }
}
