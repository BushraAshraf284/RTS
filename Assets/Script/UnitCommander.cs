using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommander : MonoBehaviour
{
    public GameObject SelectionMarker;
    public LayerMask layerMask;

    private UnitSelection unitSelection;
    private Camera cam;

    private void Awake()
    {
        unitSelection = GetComponent<UnitSelection>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButtonDown(1) && unitSelection.HasUnitsSelected()) 
        {
            Debug.Log("In check");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            var units = unitSelection.GetSelectedUnits();
            Debug.Log(Physics.Raycast(ray, out hit, 100, layerMask));
            if (Physics.Raycast(ray, out hit, 100, layerMask)) 
            {
                Debug.Log(hit.collider.name);
                if(hit.collider.CompareTag("Ground"))
                {
                    Debug.Log("Ground hit");
                   
                    MoveUnitsToPosition(hit.point, units);
                    
                }
            }
        }
    }

    void MoveUnitsToPosition(Vector3 movePos, Unit[] units)
    {
        for(int i =0; i< units.Length; i++)
        {
            units[i].MoveToPosition(movePos);
        }
    }
}
