using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestNode : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;
    
    private Renderer rend;
    
    private Color startColor;

    public Vector3 positionOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

   void OnMouseEnter ()
   {
       if(EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("Print");
        print("Testing");
        rend.material.color = hoverColor;
   }

    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
    
    
    void OnMouseDown ()
 
    {
         if(EventSystem.current.IsPointerOverGameObject())
            return;

        
        if (turret != null)
        {
            Debug.Log("Can't Build There! -  TODO: DIsplay on screen");
            return;
        }
        // GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        // turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}
