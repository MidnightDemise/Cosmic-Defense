using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    
    private Renderer renderer;
    public Color color;
    private Color startColor;
    public GameObject turret;
    public Transform planet;
    Quaternion nodeRotation;
    // Start is called before the first frame update
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;
        planet = GameObject.FindWithTag("planet").transform;
    }
    private void OnMouseEnter()
    {
        renderer.material.color = color;
        
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            return;

        }

        GameObject turretToBuild = BuildManager.instance.GetGameTurret();
        nodeRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180f);
        turret = Instantiate(turretToBuild,transform.position,nodeRotation );
        BuildManager.numberOfTurrets.Add(turret);

        turret.transform.SetParent(planet);
       
    }

    private void OnMouseExit()
    {
        renderer.material.color = startColor;
    }
}
