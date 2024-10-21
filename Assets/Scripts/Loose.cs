using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loop : MonoBehaviour
{
    [SerializeField] private Animator animation;
    private bool hasLost;
    [SerializeField] private AudioClip Music;
    [SerializeField] private AudioClip Scream;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource SourceMusic;

    
    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (hasLost || collision.GetComponent<ZombieMovement>().Dead)
            {
                return;
            }
            hasLost = true;
            animation.Play("DeathAnimation");
            source.PlayOneShot(Music);
            source.PlayOneShot(Scream);
            SourceMusic.Stop();
            Invoke("RestartScene",10);
        }
    }
    void RestartScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
