using UnityEngine;

public class ReparentPreservePosition : MonoBehaviour
{
    public Transform door;
    public Transform hinge;

    public void ReparentDoor()
    {
        Vector3 worldPosition = door.position; // Save world position
        Quaternion worldRotation = door.rotation; // Save world rotation

        door.SetParent(hinge); // Reparent the door
        door.position = worldPosition; // Restore world position
        door.rotation = worldRotation; // Restore world rotation
    }
}
