using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door; // The door object to rotate
    public float rotationAngle = 90f; // Angle to rotate the door
    private bool isDoorOpen = false; // Track whether the door is open or closed

    // This function will be called when the button is pressed (poked)
    public void ToggleDoor()
    {
        if (!isDoorOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    // Rotate the door open
    public void OpenDoor()
    {
        // Rotate the door around its local Y-axis (using Space.Self)
        door.Rotate(0, rotationAngle, 0, Space.Self);  // Ensure rotation is in local space
        isDoorOpen = true;
    }

    // Rotate the door closed
    private void CloseDoor()
    {
        // Rotate back around its local Y-axis
        door.Rotate(0, -rotationAngle, 0, Space.Self);  // Ensure rotation is in local space
        isDoorOpen = false;
    }
}
