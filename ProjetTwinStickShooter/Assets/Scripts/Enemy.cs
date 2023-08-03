using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private RoomManager roomManager;
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

    public void OnDisable()
    {
        roomManager.EnemiesKlled();
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

    }
}
