using UnityEngine;

public class MenuFollowPlayer : MonoBehaviour
{
    public Transform playerCamera;
    public float distanceFromPlayer = 2f;

    void Update()
    {
        transform.position = playerCamera.position + playerCamera.forward * distanceFromPlayer;

        transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.position);
    }
}
