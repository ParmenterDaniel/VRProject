using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnlockPassage : MonoBehaviour
{
    public GameObject gameObject;

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
       if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
