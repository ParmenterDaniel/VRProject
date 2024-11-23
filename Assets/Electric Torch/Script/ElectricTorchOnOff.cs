using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElectricTorchOnOff : MonoBehaviour
{
    EmissionMaterialGlassTorchFadeOut _emissionMaterialFade;
    BatteryPowerPickup _batteryPower;
    XRGrabInteractable parentGrabInteractable; // Reference to parent's XRGrabInteractable

    public enum LightChoose
    {
        noBattery,
        withBattery
    }

    public LightChoose modoLightChoose;
    public bool _PowerPickUp = false;
    public float intensityLight = 2.5f;
    private bool _flashLightOn = false; // Tracks light state
    [SerializeField] float _lightTime = 10.0f; // Time before battery runs out
    private float _lightTimer; // Internal timer for battery operation

    private void Awake()
    {
        _batteryPower = FindObjectOfType<BatteryPowerPickup>();
        _emissionMaterialFade = GetComponent<EmissionMaterialGlassTorchFadeOut>();
    }

    void Start()
    {
        // Find the XRGrabInteractable component on the parent object
        Transform parent = transform.parent;
        if (parent != null)
        {
            parentGrabInteractable = parent.GetComponent<XRGrabInteractable>();
        }

        if (parentGrabInteractable != null)
        {
            // Add listener to the parent's activated event
            parentGrabInteractable.activated.AddListener(args => ToggleLight());
        }

        // Ensure the light starts in the off state
        GetComponent<Light>().intensity = 0.0f; // Turn light off
        _flashLightOn = false;                 // Ensure the flag matches the state
        _emissionMaterialFade?.OffEmission();  // Disable emission material

        _lightTimer = _lightTime; // Initialize the timer
    }

    void Update()
    {
        if (modoLightChoose == LightChoose.withBattery && _flashLightOn)
        {
            // Decrease the timer while the light is on
            _lightTimer -= Time.deltaTime;

            if (_lightTimer <= 0.0f)
            {
                // Time expired, turn off the light
                TurnOffLight();
            }
        }
    }

    void ToggleLight()
    {
        if (_flashLightOn)
        {
            TurnOffLight();
        }
        else
        {
            TurnOnLight();
        }
    }

    void TurnOnLight()
    {
        if (modoLightChoose == LightChoose.noBattery || _lightTimer > 0.0f)
        {
            _flashLightOn = true;
            GetComponent<Light>().intensity = intensityLight;
            _emissionMaterialFade?.OnEmission();
        }
    }

    void TurnOffLight()
    {
        _flashLightOn = false;
        GetComponent<Light>().intensity = 0.0f;
        _emissionMaterialFade?.OffEmission();
    }

    public void RechargeBattery(float additionalTime)
    {
        if (modoLightChoose == LightChoose.withBattery)
        {
            _lightTimer += additionalTime;
            _lightTimer = Mathf.Clamp(_lightTimer, 0.0f, _lightTime); // Ensure it doesn't exceed the initial max time
        }
    }
}






/*
// - ElectricTorchOnOff - Script by Marcelli Michele

// This script is attached in primary model (default) of the Electric Torch.
// You can On/Off the light and choose any letter on the keyboard to control it
// Use the "battery" or no and the duration time
// Change the intensity of the light

using UnityEngine;

public class ElectricTorchOnOff : MonoBehaviour
{
	EmissionMaterialGlassTorchFadeOut _emissionMaterialFade;
	BatteryPowerPickup _batteryPower;
	//

	public enum LightChoose
    {
		noBattery,
		withBattery
    }

	public LightChoose modoLightChoose;
	[Space]
	[Space]
	public string onOffLightKey = "F";
	private KeyCode _kCode;
	[Space]
	[Space]
	public bool _PowerPickUp = false;
	[Space]
	public float intensityLight = 2.5F;
	private bool _flashLightOn = false;
	[SerializeField] float _lightTime = 0.05f;


	private void Awake()
    {
		_batteryPower = FindObjectOfType<BatteryPowerPickup>();
	}
    void Start()
	{
		GameObject _scriptControllerEmissionFade = GameObject.Find("default");

		if (_scriptControllerEmissionFade != null)
		{
			_emissionMaterialFade = _scriptControllerEmissionFade.GetComponent<EmissionMaterialGlassTorchFadeOut>();
		}
		if (_scriptControllerEmissionFade  == null) {Debug.Log("Cannot find 'EmissionMaterialGlassTorchFadeOut' script");}

		_kCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), onOffLightKey);
	}

	void Update()
	{
		// detecting parse error keyboard type
		if (System.Enum.TryParse(onOffLightKey, out _kCode))
		{
			_kCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), onOffLightKey);
		}
        //

        switch (modoLightChoose)
        {
            case LightChoose.noBattery:
				NoBatteryLight();
				break;
            case LightChoose.withBattery:
				WithBatteryLight();
				break;
        }
	}

	void InputKey()
    {
		if (Input.GetKeyDown(_kCode) && _flashLightOn == true)
		{
			_flashLightOn = false;

		}
		else if (Input.GetKeyDown(_kCode) && _flashLightOn == false)
		{
			_flashLightOn = true;

		}
	}

	void NoBatteryLight()
    {
		if (_flashLightOn)
		{
			GetComponent<Light>().intensity = intensityLight;
			_emissionMaterialFade.OnEmission();
		}
		else
		{
			GetComponent<Light>().intensity = 0.0f;
			_emissionMaterialFade.OffEmission();
		}
		InputKey();
	}

	void WithBatteryLight()
    {

		if (_flashLightOn)
		{
			GetComponent<Light>().intensity = intensityLight;
			intensityLight -= Time.deltaTime * _lightTime;
			_emissionMaterialFade.TimeEmission(_lightTime);
            
			if (intensityLight < 0)
            {
				intensityLight = 0;
			}
			if (_PowerPickUp == true)
			{
				intensityLight = _batteryPower.PowerIntensityLight;
			}
		}
		else
		{
			GetComponent<Light>().intensity = 0.0f;
			_emissionMaterialFade.OffEmission();

			if (_PowerPickUp == true)
			{
				intensityLight = _batteryPower.PowerIntensityLight;
			}
		}

		InputKey();
	}
}*/
