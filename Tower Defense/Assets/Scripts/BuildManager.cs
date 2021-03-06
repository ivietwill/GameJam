using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; 
    private TurretBlueprint turretToBuild;

    private Nodes selectedNode;

    public GameObject buildEffect;
    public NodeUI nodeUI;

    

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in Scene!");
            return;
        }
        instance = this;
    }

  
    // public GameObject GetTurretToBuild ()
    // {
    //     return turretToBuild;
    // }

    public bool CanBuild {get {return turretToBuild != null;}}
    public bool HasMoney {get {return PlayerStats.Money >= turretToBuild.cost; }}


    public void SelectNode (Nodes node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

        public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }


    public  void SelectTurretToBuild (TurretBlueprint turret)
    {

        turretToBuild = turret;
        DeselectNode();
    }


    public TurretBlueprint GetTurretToBuild ()
    {
        {
            return turretToBuild;
        }
    }




   
 
}
