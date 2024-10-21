using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverColor : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    private Color normalColor;
    [SerializeField] private Color hoverColor;

    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        normalColor = buttonText.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        buttonText.color = normalColor;
    }
}
