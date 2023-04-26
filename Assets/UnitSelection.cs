using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [Tooltip("Position at the bottom left not anchor")]
    public RectTransform selectionBox;
    public LayerMask unitMask;
    private Vector2 startPos;
    private Player player;
    private Camera cam;

    public List<Unit> selectedUnits;
    private void Awake()
    {
        player = GetComponent<Player>();
        cam = Camera.main;
        selectionBox.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TogggleSelectionVisual(false);
            TrySelect(Input.mousePosition);
            startPos = Input.mousePosition;

        }

        if(Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox();
        }

        if(Input.GetMouseButton(0))
        {
            UpdateSelectionBoxVisual(Input.mousePosition);
        }
    }

    // Select gameOject on Screen
    void TrySelect(Vector2 mousePos)
    {
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) )
        {
            var unit = hit.transform.GetComponent<Unit>();
            if(player.isMyUnit(unit))
            {
                selectedUnits.Add(unit);
                unit.TogggleSelectionVisual(true);
            }
        }
    }

    // Drawing Box screen
    void UpdateSelectionBoxVisual(Vector2 curPos)
    {
        if(!selectionBox.gameObject.activeInHierarchy) 
            selectionBox.gameObject.SetActive(true);

        float width = curPos.x - startPos.x; // distance between startPos to current Mouse Position on x axis
        float height =  curPos.y- startPos.y; // distance between startPos to current Mouse Position on yaxis
        
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = startPos + new Vector2(width/2, height/2); // from start position to middle of the box. As pivot is in center
    }

    void ReleaseSelectionBox()
    {
        selectionBox.gameObject.SetActive(false);

        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2); // starting point, from middle to first half
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2); // ending point, from middle to second half

        foreach(Unit unit in player.units)
        {
           Vector3 screenPos = cam.WorldToScreenPoint(unit.transform.position);

            if(screenPos.x> min.x && screenPos.y > min.y && 
                screenPos.x < max.x && screenPos.y< max.y) // if less than max and greater than y
            {
                selectedUnits.Add(unit);
                unit.TogggleSelectionVisual(true);
            }
        }
    }
    void TogggleSelectionVisual(bool selected)
    {
        foreach (Unit unit in selectedUnits)
        {
            unit.TogggleSelectionVisual(selected);
        }
    }
    
}
