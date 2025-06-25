using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour, Action
{
    private OxAnger oxAnger;
    private OxMovement oxMovement;
    private PlayerWeapon playerWeapon;
    private SwordController swordController;
    void Start()
    {
        oxAnger = FindObjectOfType<OxAnger>();
        oxMovement = FindObjectOfType<OxMovement>();
        playerWeapon = FindObjectOfType<PlayerWeapon>();
        swordController = FindAnyObjectByType<SwordController>();
    }
    public void Act()
    {
        if (playerWeapon.hasWeapon)
        {
            oxAnger.angerLevel++;
            oxMovement.Stun();
            playerWeapon.hasWeapon = false;
            swordController.SwordSpawn();
        }
    }
}
