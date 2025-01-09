using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLocker : MonoBehaviour
{
    public float openRot, speed;
    public float closeRot = 0;
    private bool opened = false;
    public AudioSource audioSource;
    private bool playsound = true;


    // Update is called once per frame
    void Update()
    {
        if (opened)
        {
            Vector3 currentRot = transform.localEulerAngles;
            if (currentRot.y != openRot)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRot, currentRot.z), speed * Time.deltaTime);

            }
        }
        else
        {
            Vector3 currentRot = transform.localEulerAngles;
            if (currentRot.y != closeRot)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closeRot, currentRot.z), speed * Time.deltaTime);

            }
        }
    }

    public void OpenLockerFunc()
    {
        opened = !opened;
    }
}
