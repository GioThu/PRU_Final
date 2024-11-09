using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopV1 : MonoBehaviour
{
    public TurretBluePrintV1 standartTurret;
    public TurretBluePrintV1 missileLauncher;

    BuildManagerV1 buildManager;

    private void Start()
    {
        buildManager = BuildManagerV1.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissleLauncher()
    {
        Debug.Log("Another Turret Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
