using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;



    [HideInInspector]    
    public GameObject turret;

    [HideInInspector]    
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;

    BuildManager buildManager;

    private Color startColor;


    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
        buildManager = BuildManager.instance;
    }



    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }



    void BuildTurret (TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log ("Not enough Money to Upgrade");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,  GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log ("Turret Build" );
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log ("Not enough Money to Upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Get rid of the old turret
        Destroy(turret);

        // Build a new Turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,  GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        
        Debug.Log ("Turret Upgraded!" );
    }

    void OnMouseEnter ()
    {
        // if(EventSystem.current.IsPointerOverGameObject())
        //     return;

        if (!buildManager.CanBuild)
            return;
        if(buildManager.HasMoney)
        {
             rend.material.color = hoverColor;
        }

        else
        {
         rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit ()
    {
        rend.material.color =  startColor;
    }

    void OnMouseDown ()
    {
        //   if(EventSystem.current.IsPointerOverGameObject())
        //      return;

        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;
        
        BuildTurret(buildManager.GetTurretToBuild());

    }

    public void SellTurret ()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount() ;

        // Spawn a Cool Effect
        
        Destroy(turret);
        turretBlueprint = null;
    }
    
}
