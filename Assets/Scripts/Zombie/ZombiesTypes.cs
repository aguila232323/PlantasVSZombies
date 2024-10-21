using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewZombieType",menuName ="Zombie")]
public class ZombiesTypes : ScriptableObject
{
    [SerializeField] private int healt;
    [SerializeField] private int damage;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private float range = 0.5f;
    [SerializeField] private float coolDown = 1f;
    [SerializeField] private float speed;
    public AudioClip[] sound;

    public int getHealt(){return healt;}
    public float getSpeed() { return speed; }
    public int getDamage() { return damage; }
    public float getRange() { return range; }
    public float getCooldown() { return coolDown; }
    public Sprite getSprite() { return sprite; }
    public Sprite getSpriteDead() { return deadSprite; }
    

}
