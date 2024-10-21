using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlantShoot : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float speed;
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector3.right))
        {
                
                Bullet.GetComponent<Renderer>().sortingOrder = 1;
                Bullet.transform.position = Vector2.MoveTowards(Bullet.transform.position,new Vector2(6f,-1.64f),speed*Time.deltaTime);
               
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
