using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Color hoverColor;

    private GameObject turret;
    
    private Renderer rend;
    
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

   void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
   {
        Debug.Log("Print");
        print("Testing");
        rend.material.color = hoverColor;
   }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        rend.material.color = startColor;
    }
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        
        if (turret != null)
        {
            Debug.Log("Can't Build There! -  TODO: DIsplay on screen");
            
        }
    }
}
