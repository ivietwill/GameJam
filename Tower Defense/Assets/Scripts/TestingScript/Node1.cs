using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
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
            return;
        }
        // GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        // turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}