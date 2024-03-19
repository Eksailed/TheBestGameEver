using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;

 
    public Animator Zombieanimator;
    //public Animator ZombieanimatorTWO;

    public float attackDistance = 1;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerhealth;
    private EnemyHealth _enemyhealth;

    public bool IsAlive()
    {
        return _enemyhealth.IsAlive();
    }
    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();       
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerhealth = player.GetComponent<PlayerHealth>();
        _enemyhealth = GetComponent<EnemyHealth>();
    }



    void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();

        PatrolUpdate();

        AttackUpdate();

    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Zombieanimator.SetTrigger("attack");
                //ZombieanimatorTWO.SetTrigger("attack");
            }
        }
    }

    public void AttackDamage()
    {
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance + attackDistance) return;

        _playerhealth.DealDamage(damage);
    }


    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void NoticePlayerUpdate()
    {        

        _isPlayerNoticed = false;
        if (!_playerhealth.IsAlive()) return;

        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }

    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    } 
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}
