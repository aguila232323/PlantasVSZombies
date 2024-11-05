using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{



   
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float range;
    private GameObject target;
    [SerializeField] private AudioClip[] ShootsSounds;
    private AudioSource source;


    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layer);
        if (hit.collider)
        {
            target = hit.collider.gameObject;
            Explode();
        }
    }
    

    void Explode()
    {
        source.PlayOneShot(ShootsSounds[Random.Range(0, ShootsSounds.Length)]);
        

        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        
    }
}
