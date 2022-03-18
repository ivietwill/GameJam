using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public TurretBlueprint Mortar;
    public TurretBlueprint Balista;
    public TurretBlueprint LaserTower;
    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;

    }
    public void SelectMortar ()
    {
        Debug.Log("Mortar Purchased");
        buildManager.SelectTurretToBuild(Mortar);
    }

    public void SelectBalista ()
    {
        Debug.Log("Balista Purchased");
        buildManager.SelectTurretToBuild(Balista);
    }

    public void SelectLaserTower()
    {
        Debug.Log("Laser Tower Selected");
        buildManager.SelectTurretToBuild(LaserTower);
    }
}
