using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class Cortacesped : MonoBehaviour
{
    [SerializeField] private float _Speed;

    [SerializeField] private bool isMooving;

    [SerializeField] private AudioClip sound;
    private AudioSource Source;

    private void Start()
    {
        Source = gameObject.AddComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   
            if (!isMooving)
            {
                Source.PlayOneShot(sound);
            }
            collision.GetComponent<ZombieMovement>().Hit(10000000,false);
            isMooving = true;

            
            Destroy(gameObject,8);
        }
    }

    private void Update()
    {
        if (isMooving) {
            transform.position += new Vector3(_Speed * Time.deltaTime, 0, 0);
        }
    }
}
