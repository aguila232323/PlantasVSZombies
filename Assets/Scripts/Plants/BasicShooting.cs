using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float cooldown;
    [SerializeField] private float range;
    [SerializeField] private LayerMask layer;
    private bool canShoot;
    private GameObject target;
    [SerializeField] private AudioClip[] ShootsSounds;
    private AudioSource source;


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
        source.PlayOneShot(ShootsSounds[Random.Range(0,ShootsSounds.Length)]);
        canShoot = false;

        GameObject myBullet = Instantiate(bullet,shootOrigin.position,Quaternion.identity);
        Invoke("ResetCooldown",cooldown);
    }
}
