using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /**************************************************************************************************************************************************
     ************************************************                   Variables                   ***************************************************
     *************************************************************************************************************************************************/

    public GameObject m_PlayerPrefab;
    public GameObject m_EnemiesPrefab;

    private PlayerController m_PlayerController;
    private EnemiesController m_EnemiesController;

    /**************************************************************************************************************************************************
     ************************************************                   Function                    ***************************************************
     *************************************************************************************************************************************************/

    private void Awake()
    {
        //Instancie le Player
        m_PlayerPrefab = GameObject.Instantiate(m_PlayerPrefab, Vector3.left, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
        m_PlayerController = m_PlayerPrefab.GetComponent<PlayerController>();

        m_EnemiesPrefab = GameObject.Instantiate(m_EnemiesPrefab, Vector3.left, Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
        m_EnemiesController = m_EnemiesPrefab.GetComponent<EnemiesController>();
    }

    private void Start()
    {
        if (m_EnemiesPrefab.transform.childCount != 0)
        {
            m_PlayerController.GetComponent<PeopleController>().SetTarget(m_EnemiesPrefab.transform.GetChild(0).gameObject);
        }
    }
}
