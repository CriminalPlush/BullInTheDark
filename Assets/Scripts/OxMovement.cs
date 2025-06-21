using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class OxMovement : MonoBehaviour
{
    private List<GameObject> points;
    private GameObject currentPoint;
    private NavMeshAgent agent;
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("Point").ToList();
        agent = GetComponent<NavMeshAgent>();
        SelectDestination();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Point" && col.gameObject == currentPoint)
        {
            SelectDestination();
        }
    }
    private void SelectDestination()
    {
        List<GameObject> temp = points;
        temp.Remove(currentPoint);
        currentPoint = temp[Random.Range(0, temp.Count)];
        agent.SetDestination(currentPoint.transform.position);
    }
}
