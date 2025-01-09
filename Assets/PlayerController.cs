using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hidden = false;

    void Update()
    {
        if (hidden)
        {
            Debug.Log("Player is hidden");
        }
        else
        {
            Debug.Log("Player is not hidden");
        }
    }
}
