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

    public bool allowInvoke = true;

    private void Awake()
    {
        //magazine starts full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        //Allowed to shoot?
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }

    }

    private void Shoot()
    {
        readyToShoot = false;

        GameObject currentBullet = Instantiate(FlameBlast, attackPoint.position, attackPoint.rotation);
        currentBullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * shootForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;
    }
}
