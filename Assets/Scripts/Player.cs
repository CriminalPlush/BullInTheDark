using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int HP = 1;
    [SerializeField] private GameObject deathPanel;
    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
    }


    public void GetDamage()
    {
        HP--;
    }

    private void Die()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(this);
    }
}
