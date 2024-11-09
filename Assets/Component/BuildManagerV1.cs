using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManagerV1 : MonoBehaviour
{
    public static BuildManagerV1 instance;

     void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    public GameObject anotherTurretPrefab;

    private TurretBluePrintV1 turretToBuild;

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
 
        }
    }

    public void BuildTurretOn(NodeV2 node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBluePrintV1 turret)
    {
        turretToBuild = turret;
    }
}

