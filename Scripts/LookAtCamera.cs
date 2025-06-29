using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        Vector3 lookVector = (player.transform.position - transform.position) * -1;
        lookVector.y = 0;//transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = rot;

    }
}
