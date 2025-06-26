using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullSeePlayer : MonoBehaviour
{
    [SerializeField] private float detectionDistance;
    [SerializeField] private BullMovement bullMovement;
    void Start()
    {
        if (bullMovement == null)
        {
            bullMovement = GetComponent<BullMovement>();
        }
    }
    void Update()
    {
        // Loop through 16 directions
        for (int i = 0; i < 16; i++)
        {
            // Calculate the angle for each direction
            float angle = i * Mathf.PI * 2f / 16f; // 360 degrees / 16
            // Convert angle to a direction vector in the XZ plane
            Vector3 direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

            // Perform the raycast
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 0.2f, direction, out hit, detectionDistance))
            {
                if (hit.collider.tag == "Player")
                    bullMovement.DetectPlayer(hit.collider.gameObject);
                Debug.DrawLine(transform.position, hit.point, Color.red);
               // Debug.Log($"Ray {i} hit {hit.collider.gameObject.name} at {hit.point}");
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + direction * detectionDistance, Color.green);
            }
        }
    }
}
