using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteraction : MonoBehaviour
{
    public DoorController doorController;  // Reference to the DoorController script

    private void OnEnable()
    {
        // Get the XRSimpleInteractable component
        XRSimpleInteractable simpleInteractable = GetComponent<XRSimpleInteractable>();

        // Subscribe to the "on select entered" event (button press)
        simpleInteractable.onSelectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        // Get the XRSimpleInteractable component
        XRSimpleInteractable simpleInteractable = GetComponent<XRSimpleInteractable>();

        // Unsubscribe from the event to prevent memory leaks
        simpleInteractable.onSelectEntered.RemoveListener(OnButtonPressed);
    }

    // Called when the button is pressed (poke interaction)
    private void OnButtonPressed(XRBaseInteractor interactor)
    {
        // Call the door controller to toggle the door open/close
        if (doorController != null)
        {
            doorController.ToggleDoor();
        }
    }
}
