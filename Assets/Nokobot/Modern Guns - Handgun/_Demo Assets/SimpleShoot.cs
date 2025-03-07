﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    public AudioSource source;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip noAmmoSound;
    public XRBaseInteractor interactor;

    public Magazine magazine;
    public float rayDistance = 10f;
    private Color rayColour = Color.red;
    private bool canDamage = false;


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        interactor.selectEntered.AddListener(AddMagazine);
        interactor.selectExited.AddListener(RemoveMagazine);
    }

    private void Update()
    {
        Vector3 rayOrigin = barrelLocation.position;
        Vector3 rayDirection = barrelLocation.forward;   
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, rayColour);
    }

    public void TriggerPull()
    {
        if(magazine && magazine.numBullets > 0)       
            gunAnimator.SetTrigger("Fire");       
           
        else       
            source.PlayOneShot(noAmmoSound);       
    }

    public void AddMagazine(SelectEnterEventArgs e)
    {
        magazine = e.interactable.GetComponent<Magazine>();

        if (magazine == null)
            Debug.Log("NULL MAG");

        source.PlayOneShot(reloadSound);

        Collider magCollider = e.interactable.GetComponentInChildren<Collider>();

        Transform colliders = transform.parent.Find("Colliders");
;
        Collider[] listColliders = colliders.GetComponentsInChildren<Collider>();
;
        foreach(Collider activeCollider in listColliders)
        {
            Physics.IgnoreCollision(magCollider, activeCollider);
        }
    }

    public void RemoveMagazine(SelectExitEventArgs e)
    {
        magazine = null;
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        magazine.numBullets--;
        source.PlayOneShot(shootSound);
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
     
        //RAYCAST TO ENEMY & DAMAGE IF HIT
        Vector3 rayOrigin = barrelLocation.position;
        Vector3 rayDirection = barrelLocation.forward;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
        {
            if (hit.collider.name == "Ghoul")
            {
                GameObject enemy = hit.collider.gameObject;
                GhoulHealth health = enemy.GetComponent<GhoulHealth>();
                if (health != null)
                {
                    health.TakeDamage();
                }
            }
        }
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
