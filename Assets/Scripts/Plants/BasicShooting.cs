using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BasicShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject[] shootOrigin;
    [SerializeField] private float cooldown;
    [SerializeField] private float range;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Boolean machinegun;
    private bool canShoot;
    private GameObject target;
    [SerializeField] private AudioClip[] ShootsSounds;
    private AudioSource source;
    private int TurretCounter;


    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        Invoke("ResetCooldown", cooldown);
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right,range,layer);
        if (hit.collider)
        {
            target = hit.collider.gameObject;
            Shoot();

        }
    }
    private void ResetCooldown()
    {
        canShoot = true;
    }
    void Shoot()
    {
        if (!canShoot)
        {
            
            return;
        }
        source.PlayOneShot(ShootsSounds[UnityEngine.Random.Range(0,ShootsSounds.Length)]);
        canShoot = false;

        if (shootOrigin.Length ==1 && !machinegun)
        {
            GameObject myBullet = Instantiate(bullet, shootOrigin[0].transform.position, Quaternion.identity);

            Invoke("ResetCooldown", cooldown);
        }
        else
        {
            GameObject myBullet = Instantiate(bullet, shootOrigin[UnityEngine.Random.Range(0, shootOrigin.Length)].transform.position, Quaternion.identity);
            
            
            if (TurretCounter == 3)
            {

                Invoke("ResetCooldown", 2.5f);
                TurretCounter = 0;
            }
            else
            {
                Invoke("ResetCooldown", 0.3f);
                TurretCounter += 1;
            }
            
        }


        
    }
}
