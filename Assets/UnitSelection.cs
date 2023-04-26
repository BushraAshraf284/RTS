using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public LayerMask unitMask;
    private Player player;
    private Camera cam;

    public List<Unit> selectedUnits;
    private void Awake()
    {
        player = GetComponent<Player>();
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TogggleSelectionVisual(false);


        }
    }

    void TrySelect(Vector2 mousePos)
    {
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
    }
    void TogggleSelectionVisual(bool selected)
    {
        foreach (Unit unit in selectedUnits)
        {
            unit.TogggleSelectionVisual(selected);
        }
    }
    
}
