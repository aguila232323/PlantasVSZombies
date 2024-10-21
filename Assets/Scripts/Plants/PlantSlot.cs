using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlantSlot : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private int _priceNumber;
    private GameManager _GameManger;

    private void Start()
    {
        _GameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent<Button>().onClick.AddListener(BuyPlant);
    }

    private void BuyPlant()
    {
        if (_GameManger.getSuns() >= _priceNumber && !_GameManger.getCurrentPlant())
        {
           
            _GameManger.SetSuns(_GameManger.getSuns()-_priceNumber);
            _GameManger.BuyPlant(_gameObject, _sprite);
        }
        
    }

    private void OnValidate()
    {
        if (_sprite != null)
        {
            _icon.enabled = true;
            _icon.sprite = _sprite;
            _price.text = _priceNumber.ToString();
        }else
        {
            _icon.enabled = false;
        }
        
    }
}
