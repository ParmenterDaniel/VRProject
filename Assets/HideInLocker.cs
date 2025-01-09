using UnityEngine;

public class HideInLocker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the PlayerController component and set the 'hidden' variable to true
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.hidden = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the PlayerController component and set the 'hidden' variable to false
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.hidden = false;
            }
        }
    }
}
