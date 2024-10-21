using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ZombieMovement : MonoBehaviour
{
    private float _Speed;
    private int _Health;
    private float _EatCoolDown;
    private float _Range;
    private int _Damage;
    private bool canEat = true;
    [SerializeField] private LayerMask plantMask;
    [SerializeField] private PlantStats _TargetPlant;
    [SerializeField] private ZombiesTypes _Tipe;
    private AudioSource _Source;
    [SerializeField] private AudioClip[] _ZombieSounds;
    [SerializeField] private bool LastZombie;
    public bool Dead;

    private void Start()
    {
        _Health = _Tipe.getHealt();
        _Speed = _Tipe.getSpeed();
        _Damage = _Tipe.getDamage();
        _Range = _Tipe.getRange();
        GetComponent<SpriteRenderer>().sprite = _Tipe.getSprite();
        _EatCoolDown = _Tipe.getCooldown();
        _Source = GetComponent<AudioSource>();

        Invoke("grouns",Random.Range(1f,20f));
    }

    void grouns()
    {
        _Source.PlayOneShot(_ZombieSounds[Random.Range(0, _ZombieSounds.Length)]);
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, _Range, plantMask);
        if (hit.collider)
        {
            _TargetPlant = hit.collider.GetComponent<PlantStats>();
            Eat();
        }
        
    }
    void Eat()
    {
        if (!canEat || !_TargetPlant)
            return;
        canEat = false;
        Invoke("ResetEatCooldown",_EatCoolDown);
        _TargetPlant.Hit(_Damage);
    }

    void ResetEatCooldown()
    {
        canEat = true;

    }


    void FixedUpdate()
    {
        if (!_TargetPlant)
        {
            transform.position -= new Vector3(_Speed * Time.deltaTime, 0, 0);
        }
        
    }
    public void Hit(int damage,bool freeze)
    {
        _Source.PlayOneShot(_Tipe.sound[Random.Range(0,_Tipe.sound.Length)]);
        _Health-=damage;
        if (freeze)
        {
            Freeze();
        }
        if (_Health <= 0)
        {
            if (LastZombie){
                GameObject.Find("GameManager").GetComponent<GameManager>().Win();
            }
            Dead = true;
            GetComponent<SpriteRenderer>().sprite = _Tipe.getSpriteDead();
            Destroy(gameObject, 1);
        }
    }
    public void setTipe(ZombiesTypes tipe)
    {
        _Tipe = tipe;
    }

    public void Freeze()
    {
        CancelInvoke("Unfreeze");
        GetComponent<SpriteRenderer>().color = Color.blue;
        _Speed = _Tipe.getSpeed()/2;
        Invoke("Unfreeze", 5);
    }
    public void Unfreeze()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        _Speed = _Tipe.getSpeed();
    }

    public void setLast(bool last)
    {
        LastZombie = last;
    }
}
