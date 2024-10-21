using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public GameObject sunObject;
    public float coolDown;


    void spawnSun()
    {

       GameObject mySun =  Instantiate(sunObject,transform.position,Quaternion.identity);
       mySun.GetComponent<SunScript>().DropToY = transform.position.y-1;
    }
    
    void Start()
    {
        InvokeRepeating("spawnSun", coolDown, coolDown);
    }
}
