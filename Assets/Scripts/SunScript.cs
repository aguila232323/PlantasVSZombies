using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public float DropToY;
    [SerializeField] private float speed = 0.9f;
    void Start()
    {
        
        
        Destroy(gameObject,Random.Range(8,16));
    }
    private void Update()
    {
        if (transform.position.y > DropToY)
        {

            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        
    }

}
