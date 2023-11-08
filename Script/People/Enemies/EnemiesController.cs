using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    /**************************************************************************************************************************************************
     ************************************************                   Variables                   ***************************************************
     *************************************************************************************************************************************************/

    public GameObject[] m_ListEnemies;

    private int action;


    /**************************************************************************************************************************************************
     ************************************************                   Function                    ***************************************************
     *************************************************************************************************************************************************/

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            float x = 0f;
            float y = 0f;

            // Instancie les différents enemies dans la liste de [EnemieController]
            foreach (GameObject enemy in m_ListEnemies)
            {
                GameObject Enemy = Instantiate(enemy, new Vector3(x, y, 0f), Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
                Enemy.GetComponent<PeopleController>().SetTarget(GameObject.FindGameObjectWithTag("Player"));
                y += 0.5f;
                if(y >= 1.0f)
                {
                    x += 0.5f;
                    y = 0f;
                }
            }
        }
    }

    public void EnemiesPlaying()
    {
        foreach(GameObject enemy in m_ListEnemies)
        {
            PeopleController people = enemy.GetComponent<PeopleController>();
            action = Random.Range(1, 4);

            switch (action)
            {
                case 1:
                    {
                        people.Attack();
                        break;
                    }
                case 2:
                    {
                        people.Shield();
                        break;
                    }
                case 3:
                    {
                        people.Health();
                        break;
                    }
                default:
                    {
                        Debug.Log("[EnemiesController] Erreur lors du switch pour les possibilités de choix des ennemis");
                        break;
                    }
            }
        }
    }

    public void KillEnemy(GameObject enemy)
    {
        enemy.GetComponent<PeopleController>().DestroyPeople();
    }

    public void KillEnemies()
    {
        foreach (GameObject enemy in m_ListEnemies)
        {
            enemy.GetComponent<PeopleController>().DestroyPeople();
        }
    }

    /**************************************************************************************************************************************************
     ************************************************               Getter and Setter               ***************************************************
     *************************************************************************************************************************************************/


    public GameObject[] GetEnemies() { return m_ListEnemies; }
}
