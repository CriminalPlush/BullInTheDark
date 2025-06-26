using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float interactionDistance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.GetComponent<Action>() != null && Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<Action>().Act();
            }
        }
    }
}
