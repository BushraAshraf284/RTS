using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Components")]
   public GameObject SelectionVisual;
   public void TogggleSelectionVisual(bool toggle)
    {
        SelectionVisual.SetActive(toggle);
    }
}
