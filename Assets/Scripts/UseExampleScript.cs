using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleChildOnInput : MonoBehaviour
{
    public GameObject childObject;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(ToggleChild);
        }

        if (childObject != null)
        {
            childObject.SetActive(false);
        }
    }

    private void ToggleChild(ActivateEventArgs args)
    {
        if (childObject != null)
        {
            childObject.SetActive(!childObject.activeSelf);
        }
    }
}
