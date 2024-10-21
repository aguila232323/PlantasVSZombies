using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int dmg;
    [SerializeField] private float speed = 0.8f;
    [SerializeField] private bool freeze;


    

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ZombieMovement>(out ZombieMovement zombie))
        {
            zombie.Hit(dmg,freeze);
            Destroy(gameObject);
        }
    }

}
