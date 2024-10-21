using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sunObject;


    void Start()
    {
        SpawnSun();

    }

    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject, new Vector3(Random.Range(-5.2f, 3.15f), 5.6f, 0), Quaternion.identity);
        mySun.GetComponent<SunScript>().DropToY = Random.Range(2.83f, -4);
        Invoke("SpawnSun",7f);

    }


}
