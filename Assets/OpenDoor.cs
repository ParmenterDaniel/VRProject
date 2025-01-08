using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject door;
    public XRBaseInteractor interactor;
    private bool opened = false;
    public float openRot, speed;
    public AudioSource source;
    private bool playsound = true;

    void Start()
    {
        interactor.selectEntered.AddListener(OpenDoorWithKey);
    }

    // Update is called once per frame
    void Update()
    {

        if (opened)
        {
            if (playsound)
            {
                source.Play();
                playsound = false;
            }
            Vector3 currentRot = transform.localEulerAngles;
            if (currentRot.y != openRot)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRot, currentRot.z), speed * Time.deltaTime);

            }
        }
    }

    void OpenDoorWithKey(SelectEnterEventArgs e)
    {
        opened = true;
    }
}
