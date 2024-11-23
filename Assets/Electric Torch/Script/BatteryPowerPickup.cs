using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BatteryPowerPickup : MonoBehaviour
{
    [SerializeField] private float batteryTime = 10.0f; // Time added to the torch when picked up
    private ElectricTorchOnOff torchScript; // Reference to the torch script
    private XRGrabInteractable grabInteractable; // Reference to the grab interactable

    private void Awake()
    {
        // Find the torch in the scene
        torchScript = FindObjectOfType<ElectricTorchOnOff>();
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            // Subscribe to the select entered event
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            // Unsubscribe from the select entered event
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Recharge the torch's battery
        if (torchScript != null)
        {
            torchScript.RechargeBattery(batteryTime);
        }

        // Destroy the battery object after it has been grabbed
        Destroy(gameObject);
    }
}
