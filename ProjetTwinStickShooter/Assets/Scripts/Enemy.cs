using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
