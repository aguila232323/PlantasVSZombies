using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;
using Unity.Burst.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject currentPlant;
    [SerializeField] private Sprite currentPlantSprite;
    [SerializeField] private Transform tiles;
    [SerializeField] private LayerMask tileMask;
    [SerializeField] private int suns;
    [SerializeField] private TextMeshProUGUI sunText;
    [SerializeField] private LayerMask sunMask;

    public AudioClip[] plantsSound;
    private AudioSource source;
    


    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }
    public void BuyPlant(GameObject plant, Sprite sprite)
    {
        currentPlant = plant;
        currentPlantSprite = sprite;
    }


    void Update()
    {
        sunText.text = suns.ToString();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);

        foreach (Transform tile in tiles)
            tile.GetComponent<Renderer>().enabled = false;
        if (hit.collider && currentPlant)
        {
            hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlantSprite;
            hit.collider.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetMouseButtonDown(0) && !hit.collider.GetComponent<Tile>().plant)
            {

                plant(hit.collider.gameObject);
            }
        }

        RaycastHit2D SunHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, sunMask);

        if (SunHit.collider)
        {
            if (Input.GetMouseButtonDown(0))
            {
                source.PlayOneShot(plantsSound[1]);
                suns += 25;
                Destroy(SunHit.collider.gameObject);
            }
        }

    }
    public int getSuns()
    {
        return suns;

    }
    public void SetSuns(int Suns)
    {
        suns = Suns;

    }
    public GameObject getCurrentPlant()
    {
        return currentPlant;
    }
    void plant(GameObject hit)
    {
        source.PlayOneShot(plantsSound[0]);
        GameObject plant = Instantiate(currentPlant, hit.transform.position, Quaternion.identity);
        hit.GetComponent<Tile>().plant =true;
        plant.GetComponent<PlantStats>().setTile(hit.GetComponent<Tile>());
        currentPlant = null;
        currentPlantSprite = null;
    }
    public void Win()
    {
        
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(0);
            return;
        }
        PlayerPrefs.SetInt("Level Save", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

