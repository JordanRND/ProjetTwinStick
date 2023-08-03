using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesV1;
    [SerializeField] private GameObject[] enemiesV2;
    [SerializeField] private GameObject[] enemiesV3;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private bool[] playerIsInTheRoom;
    public int enemiesCounter = 0;
    private bool vague1;
    private bool vague2;
    private bool vague3;
    [SerializeField] private Collider entranceZone;

    public void Start()
    {
        enemiesCounter = enemiesV1.Length;
    }

    private IEnumerator AllPlayersAreInTheRoom()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject enemy in enemiesV1)
        {
            enemy.SetActive(true);
        }
        entranceZone.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InputManager inputManager))
        {
            playerIsInTheRoom[inputManager.noOfPlayer - 1] = true;
            if (playerIsInTheRoom[0] && playerIsInTheRoom[1])
            {
                StartCoroutine(AllPlayersAreInTheRoom());
            }
        }
    }

    public void EnemiesKlled()
    {
        enemiesCounter--;
        StartCoroutine(VagueManager());
    }

    public IEnumerator VagueManager()
    {
        while (!vague1)
        {
            if (enemiesCounter <= 0)
            {
                yield return new WaitForSeconds(2f);
                enemiesCounter = enemiesV2.Length;
                foreach (GameObject enemy in enemiesV2)
                {
                    enemy.SetActive(true);
                }
                vague1 = true;
            }
            yield return null;
        }

        while (!vague2)
        {
            if (enemiesCounter <= 0)
            {
                yield return new WaitForSeconds(2f);
                enemiesCounter = enemiesV3.Length;
                foreach (GameObject enemy in enemiesV3)
                {
                    enemy.SetActive(true);
                }
                vague2 = true;
            }
            yield return null;
        }

        if (enemiesCounter <= 0 && vague1 == true && vague2 == true)
        {
            vague3 = true;
            yield return new WaitForSeconds(2f);
            if (vague3 == true)
            {
                foreach (GameObject door in doors)
                {
                    door.SetActive(false);
                }
            }
        }

    }
    private void Update()
    {

    }
}
