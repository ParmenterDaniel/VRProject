using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR;
//using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class GunController : MonoBehaviour
{

    //settings
    public float damage = 10f;
    public float maxDistance = 100f;
    public int ammo = 0;

    //public XRController leftController;
    //public XRController rightController;
    [SerializeField]
    public InputDevice righthand;
   
    public Transform gunBarrel;
    public InputFeatureUsage<bool> fireButton = CommonUsages.triggerButton;

    // Start is called before the first frame update
    void Start()
    {
        var rightHandDevices = new List<InputDevice>();
        righthand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo > 0 && IsFireButtonPressed(righthand))
            Shoot();
    }

    void Shoot()
    {
        Debug.Log("Shot!");
        ammo--;
        if (ammo < 0)
            ammo = 0;

        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, maxDistance)) 
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                //hit
                Debug.Log("Hit enemy");
            }
        }
        
    }

    bool IsFireButtonPressed(InputDevice controller)
    {
        if(controller == null) return false;

        //InputDevice inputDevice = controller.inputDevice;
        bool isPressed = false;
        if (controller.isValid)
        {
            controller.TryGetFeatureValue(fireButton, out isPressed);
        }
        return isPressed;
    }

    void AddAmmo(int amount)
    {
        ammo = ammo + amount;
    }
}
