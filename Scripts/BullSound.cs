using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BullSound : MonoBehaviour
{
    [SerializeField] private AudioSource detectionSound;
    public bool isDetectionSound = false;
    private BullMovement bullMovement;
    private GameObject player;
    void Start()
    {
        bullMovement = FindObjectOfType<BullMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
    }

    public void playDetectionSound()
    {
        if (isDetectionSound == false)
        {
            isDetectionSound = true;
            detectionSound.Play();
        }
    }
}
