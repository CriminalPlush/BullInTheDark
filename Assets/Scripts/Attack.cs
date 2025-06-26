using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour, Action
{
    private BullAnger bullAnger;
    private BullMovement bullMovement;
    private PlayerWeapon playerWeapon;
    private SwordController swordController;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource damageSound;
    void Start()
    {
        bullAnger = FindObjectOfType<BullAnger>();
        bullMovement = FindObjectOfType<BullMovement>();
        playerWeapon = FindObjectOfType<PlayerWeapon>();
        swordController = FindAnyObjectByType<SwordController>();
    }
    public void Act()
    {
        if (playerWeapon.hasWeapon)
        {
            bullAnger.IncreaseAnger();
            bullMovement.Stun();
            playerWeapon.hasWeapon = false;
            swordController.SwordSpawn();
            attackSound.Play();
            damageSound.Play();
        }
    }
}
