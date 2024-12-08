using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollisionWithGun : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Magazine"))
            Debug.Log("hitting Magazine");
    }




}
