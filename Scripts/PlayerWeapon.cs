using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public bool hasWeapon = true;
    [SerializeField] private MeshRenderer swordImage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        swordImage.enabled = hasWeapon;
    }
}
