using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, Action
{
    private PlayerWeapon playerWeapon;
    void Start()
    {
        playerWeapon = FindObjectOfType<PlayerWeapon>();
    }
    public void Act()
    {
        if (this.enabled == true)
        {
            playerWeapon.hasWeapon = true;
            GetComponent<AudioSource>().enabled = false;
            this.enabled = false;
        }
    }
}
