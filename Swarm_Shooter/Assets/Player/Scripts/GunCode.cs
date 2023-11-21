using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunCode : MonoBehaviour
{
    //projectile
    public GameObject FlameBlast;
    //projectile force
    public float shootForce;
    //weapon stats
    public float timeBetweenShooting, reloadTime, timeBetweenShots;
    public int magazineSize;
    public bool allowButtonHold;

    private int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Transform attackPoint;

    private PlayerControls playerControls;

    public bool allowInvoke = true;

    private void Awake()
    {
        //magazine starts full
        bulletsLeft = magazineSize;
        readyToShoot = true;
        playerControls = new PlayerControls();
        playerControls.Controls.Shoot.performed += Shooting =>
        {
            shooting = true;
        };        
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        //if (!MenuController.IsGamePaused)
        //{
            MyInput();
        //}
        
    }

    private void MyInput()
    {
        //Allowed to shoot?
        //if (allowButtonHold)
        //{
            //shooting = Input.GetKey(KeyCode.Mouse0);
        //}
        //else
        //{ 
            //shooting = Input.GetKeyDown(KeyCode.Mouse0);
        //}

        //Reloading
        
        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
            shooting = false;
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }

    }
    public void attemptReload()
    {
        if (bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        
    }
    private void Shoot()
    {
        readyToShoot = false;        

        GameObject currentBullet = Instantiate(FlameBlast, attackPoint.position, attackPoint.rotation);
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;
        Debug.Log(bulletsLeft);
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }        
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
