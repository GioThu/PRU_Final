using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;

public class NodeV2 : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;


    private Renderer rend;
    private Color startColor;

    BuildManagerV1 buildManager;

    public Vector3 GetBuildPosition() 
    {
        return transform.position + positionOffset;
    } 
   void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManagerV1.instance;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
            return;
        if ( turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);

    }
    
        
    
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            GetComponent<Renderer>().material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}