using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private RoomManager roomManager;
    [SerializeField] private GameObject enemy;
    public enum EnemyState
    {
        Chase,
        Attack
    }

    [SerializeField] private EnemyState curentState;

    private void Chase()
    {

    }

    private void Attack()
    {

    }

    private void CheckForState()
    {

    }

    public void KilledEnemy()
    {
        if (!enemy.activeSelf)
        {
            roomManager.killedEnemies++;
        }
    }

    private void Update()
    {
        CheckForState();

        switch (curentState)
        {
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack: 
                Attack();
                break;
        }
        KilledEnemy();
    }
}
