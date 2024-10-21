using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStats : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private Tile tile;


    private void Start()
    {
        gameObject.layer = 9;
    }


    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            tile.plant = false;
            Destroy(gameObject);
        }
    }
    public void setTile(Tile tile)
    {
        this.tile = tile;
    }
}
