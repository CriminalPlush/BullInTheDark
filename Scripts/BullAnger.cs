using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BullAnger : MonoBehaviour
{
    private int angerLevel = 0;
    private BullMovement bullMovement;
    [SerializeField] private Texture brickCorrupted;
    [SerializeField] private Texture everythingCorrupted;
    [SerializeField] private GameObject theEnd;
    void Start()
    {
        bullMovement = FindObjectOfType<BullMovement>();
    }
    public void IncreaseAnger()
    {
        angerLevel++;
        switch (angerLevel)
        {
            case 1:
                bullMovement.agent.speed += 0.25f;
                GameObject[] fires = GameObject.FindGameObjectsWithTag("Fire");
                for (int i = 0; i < fires.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Destroy(fires[i]);
                    }
                }
                break;
            case 2:
                bullMovement.agent.speed += 0.25f;
                fires = GameObject.FindGameObjectsWithTag("Fire");
                for (int i = 0; i < fires.Length; i++)
                {
                    Destroy(fires[i]);
                }
                GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
                foreach (var x in walls)
                {
                    x.GetComponent<MeshRenderer>().material.mainTexture = brickCorrupted;
                }
                break;
            case 3:
                bullMovement.agent.speed += 0.25f;
                walls = GameObject.FindGameObjectsWithTag("Wall");
                foreach (var x in walls)
                {
                    x.GetComponent<MeshRenderer>().material.mainTexture = everythingCorrupted;
                }
                break;
            case 4:
                theEnd.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}
