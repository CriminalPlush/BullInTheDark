using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class BullMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> points;
    public GameObject currentPoint;
    public NavMeshAgent agent;
    private GameObject player;
    private int followPlayerCooldown;
    private float stunCooldown;
    public bool isStunned { get; private set; } = false;
    private BullSound bullSound;
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("Point").ToList();
        agent = GetComponent<NavMeshAgent>();
        SelectDestination();
        StartCoroutine(Cooldown());
        bullSound = FindObjectOfType<BullSound>();  
    }
    void Update()
    {
        if (followPlayerCooldown > 0 && agent.destination != player.transform.position)
        {
            agent.SetDestination(player.transform.position);
            bullSound.playDetectionSound();
        }
        else if (followPlayerCooldown == 0 && agent.destination != currentPoint.transform.position)
        {
            agent.SetDestination(currentPoint.transform.position);
            bullSound.isDetectionSound = false;
        }
        agent.isStopped = isStunned;

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Point" && col.gameObject == currentPoint)
        {
            SelectDestination();
        }
    }
    private void SelectDestination()
    {
        List<GameObject> temp = new List<GameObject>();
        temp.AddRange(points);
        temp.Remove(currentPoint);
        currentPoint = temp[Random.Range(0, temp.Count)];
        agent.SetDestination(currentPoint.transform.position);
    }
    public void DetectPlayer(GameObject _player)
    {
        player = _player;
        followPlayerCooldown = 5;
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        if (followPlayerCooldown > 0)
        {
            followPlayerCooldown--;
        }
        StartCoroutine(Cooldown());
    }
    public void Stun()
    {
        if (stunCooldown <= 0)
        {
            stunCooldown = 6.5f;
            isStunned = true;
            StartCoroutine(StunCooldown());
        }
    }
    private IEnumerator StunCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        if (stunCooldown > 0)
        {
            stunCooldown -= 0.1f;
        }
        else
        {
            isStunned = false;
        }
        StartCoroutine(StunCooldown());
    }
}
