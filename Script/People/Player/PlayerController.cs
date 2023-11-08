using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /**************************************************************************************************************************************************
     ************************************************                   Variables                   ***************************************************
     *************************************************************************************************************************************************/

    private PeopleController m_Player;


    /**************************************************************************************************************************************************
     ************************************************                   Function                    ***************************************************
     *************************************************************************************************************************************************/

    private void Start()
    {
        m_Player = gameObject.GetComponent<PeopleController>();
    }


    public void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            ButtonAttack();
        }
        if (Input.GetKey(KeyCode.S))
        {
            ButtonShield();
        }
        if (Input.GetKey(KeyCode.H))
        {
            ButtonHealt();
        }
        if (Input.GetKey(KeyCode.D))
        {
            DeathPlayer();
        }
    }

    public void ButtonAttack()
    {
        m_Player.Attack();
    }

    public void ButtonShield()
    {
        m_Player.Shield();
    }

    public void ButtonHealt()
    {
        m_Player.Health();
    }

    public void DeathPlayer()
    {
        m_Player.DestroyPeople();
        //Destroy(this);
    }



    /**************************************************************************************************************************************************
     ************************************************               Getter and Setter               ***************************************************
     *************************************************************************************************************************************************/

    public PeopleController GetPlayer() { return m_Player; }
}
