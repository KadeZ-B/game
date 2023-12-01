using UnityEngine;
using UnityEngine.UI;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedBoostAmount = 2.0f;
    public float boostDuration = 5.0f;
    public Text boostDurationText;
    public AudioSource pickupSound;
    private PlayerMovement playerMovement;
    private bool isBoostActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null && !isBoostActive)
            {
                playerMovement.ModifySpeed(playerMovement.Speed + speedBoostAmount);
                ShowBoostDuration();
                StartCoroutine(PlayAndStopPickupSound()); // Use coroutine for audio
            }

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            StartCoroutine(BoostTimer());
        }
    }

    private void ShowBoostDuration()
    {
        isBoostActive = true;

        if (boostDurationText != null)
        {
            boostDurationText.text = "Speed Boost: " + boostDuration.ToString("F1") + "s";
        }
    }

    private System.Collections.IEnumerator PlayAndStopPickupSound()
    {
        if (pickupSound != null)
        {
            pickupSound.Play();

            // Wait for the duration of the audio clip
            yield return new WaitForSeconds(pickupSound.clip.length);

            // Stop the audio after the specified duration
            pickupSound.Stop();
        }
    }

    private System.Collections.IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(boostDuration);

        if (playerMovement != null)
        {
            playerMovement.ModifySpeed(playerMovement.Speed - speedBoostAmount);
        }

        if (boostDurationText != null)
        {
            boostDurationText.text = "";
        }

        Destroy(gameObject);
    }
}
