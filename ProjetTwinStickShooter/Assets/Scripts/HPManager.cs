using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    [SerializeField] private int hpP1 = 5;
    [SerializeField] private int hpP2 = 5;
    [SerializeField] private int noOfPlayer;
    [SerializeField] private GameObject[] heartIcons;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (noOfPlayer == 1)
            {
                hpP1--;
                heartIcons[hpP1].gameObject.SetActive(false);
            }
            if (noOfPlayer == 2)
            {
                hpP2--;
                heartIcons[hpP2].gameObject.SetActive(false);
            }
        }
        if (hpP1 < 1 && hpP2 < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
