using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullAttack : MonoBehaviour
{
    private GameObject player;
    private float attackCooldown;
    [SerializeField] private float attackDistance;
    private BullMovement bullMovement;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bullMovement = FindObjectOfType<BullMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
        {
            StartCoroutine(Attack());
        }
    }
    private IEnumerator Attack()
    {
        if (bullMovement.isStunned == false)
        {
            if (attackCooldown == 0f)
            {
                attackCooldown = 1f;
                FindObjectOfType<Player>().GetDamage();
            }
            if (attackCooldown > 0)
            {
                attackCooldown -= 0.1f;
            }
        }
        yield return new WaitForSeconds(0.1f);

    }
}
