using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : MonoBehaviour
{
    /**************************************************************************************************************************************************
     **********************************************                   Variables                   *****************************************************
     *************************************************************************************************************************************************/

    public Animator m_Animator;

    public int m_MaxLife;
    public int m_MaxShield;

    private int m_Life;
    private int m_Shield;
    private int m_Attack;

    private Dice m_Dice;

    private GameObject m_Traget;


    /**************************************************************************************************************************************************
     ************************************************                   Function                    ***************************************************
     *************************************************************************************************************************************************/

    private void Start()
    {
        m_Dice = gameObject.GetComponent<Dice>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_Life = m_MaxLife;
        m_Shield = 0;
    }

    private void FixedUpdate()    
    {        
        Limit();    
    }

    public void Attack()
    {
        if (m_Traget != null)
        {
            //Throw(m_Dice);
            //PeopleController people = GameObjectPeople.GetComponent<PeopleController>();
            //if (people.m_Shield >= m_RandomNbDice)
            //{
            //    people.m_Shield -= m_RandomNbDice;
            //}
            //else
            //{            
            //    people.m_Life -= (m_RandomNbDice - people.m_Shield);
            //}
            m_Animator.SetTrigger("Attack");
            m_Traget.GetComponent<Animator>().SetTrigger("Damage");
        }
        else
        {
            print("[PeopleController] la variable \" m_Traget \"  est nulle. ");
        }
    }

    public void Shield()
    {
        //Throw(m_Dice);
        //m_Shield += m_RandomNbDice;
        m_Animator.SetTrigger("Shield");
    }

    public void Health()
    {
        //Throw(m_Dice);
        //m_Life += m_RandomNbDice;
        m_Animator.SetTrigger("Health");
    }

    private int m_RandomNbDice;

    public void Throw(Dice dice = null) 
    {
        if(dice != null)
        {
            m_RandomNbDice = Random.Range(1, dice.GetSize() + 1);
            print("Nombre aléatoire entre 1 et " + (dice.GetSize() + 1) + " est : " + m_RandomNbDice);
        }
    }

    private void Limit()
    {
        if (m_Shield > m_MaxShield)
        {
            m_Shield = m_MaxShield;
        }
        if (m_Life > m_MaxLife)
        {
            m_Life = m_MaxLife;
        }
    }

    public void DestroyPeople()
    {
        //m_Dice.DestroyDice();
        m_Animator.SetTrigger("Death");
        //Destroy(this, 3);
    }


    /**************************************************************************************************************************************************
     ************************************************               Getter and Setter               ***************************************************
     *************************************************************************************************************************************************/


    public int GetLife() { return m_Life; }

    public int GetShield() { return m_Shield; }

    public int GetDamage() { return m_Attack; }
    public void SetDamage(int Damage) { m_Attack = Damage; }

    public Animator GetAnimator() { return m_Animator; }

    public Dice GetDice() { return m_Dice; }

    public GameObject GetTarget() { return m_Traget; }
    public void SetTarget(GameObject Target) { m_Traget = Target; }
}
