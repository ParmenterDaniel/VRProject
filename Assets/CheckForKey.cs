using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckForKey : MonoBehaviour
{
    public XRBaseInteractor interactor;
    //public DoorController doorController;
    public Animator animator;
    public AudioSource audioSource;
    bool opened = false;

    private void Start()
    {
        interactor.selectEntered.AddListener(OpenDoorWithKey);
    }

    public void OpenDoorWithKey(SelectEnterEventArgs e)
    {
        if (!opened)
        {
            //doorController.OpenDoor();
            animator.Play("Door Open", 0, 0.0f);
            audioSource.Play();
            opened = true;
        }
        
    }
}
