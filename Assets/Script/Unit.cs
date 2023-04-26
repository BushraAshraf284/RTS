using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [Header("Components")]
    public GameObject SelectionVisual;
    public NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void TogggleSelectionVisual(bool toggle)
    {
        SelectionVisual.SetActive(toggle);
    }

    public void MoveToPosition(Vector2 position)
    {
        agent.isStopped = true;
        agent.SetDestination(position);
    }
}
