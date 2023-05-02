using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCommander : MonoBehaviour
{
    public GameObject SelectionMarkerPrefab;
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
                    CreateSelectionPrefab(hit.point);
                    
                }
            }
        }
    }

    void MoveUnitsToPosition(Vector3 movePos, Unit[] units)
    {
        Vector3[] destinations = UnitMover.GetUnitGroupDestintion(movePos, units.Length,2);
        for(int i =0; i< units.Length; i++)
        {
            units[i].MoveToPosition(destinations[i]);
        }
    }

    void CreateSelectionPrefab(Vector3 pos)
    {
        Instantiate(SelectionMarkerPrefab, new Vector3(pos.x, 0.01f,pos.z), Quaternion.identity);
    }
}
