using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckForKey : MonoBehaviour
{
    public XRBaseInteractor interactor;
    public DoorController doorController;
    bool opened = false;

    private void Start()
    {
        interactor.selectEntered.AddListener(OpenDoorWithKey);
    }

    public void OpenDoorWithKey(SelectEnterEventArgs e)
    {
        if (!opened)
        {
            doorController.OpenDoor();
            opened = true;
        }
        
    }
}
