using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected int m_health;
    protected int m_mana;
    protected int m_strength;
    protected int m_defense;
    protected int m_defenseMGC;
    protected int m_speed;
    protected int m_magicPow;

    public int m_level; //current level of the character
    public int m_XP; //amount of xp given out

    public int tempDMGReduct = 0; //the amount of damage reduced to the intial damage
    public int totalDMG = 0; //total amount of damage that goes through.
    public int chanceToHit;

    //CALCULATION IDEA: (atk: strength / def: defense = tempDMGReduct) atk: strength - tempDMGReduct = totalDMG
    //e.g. (100 / 10 = 10) 100 - 10 = 90
    //e.g. (56 / 8 = 7) 56 - 7 = 49

    public bool attacking = false;
    public bool dmgRecieve = false;
    public bool dmgDealt = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    //void Update ()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    health --;
    //}
    //-----------------------------------------------------------------------------------------------------
    //Setters and Getters
    public void Sethealth(int _health) //The argument should be _health. The body should then be m_health = _health.
    {
        m_health = _health;
    }
    public int GetHealth()
    {
        return m_health;
    }
    public int GetStrength()
    {
        return m_strength;
    }

    public int GetDefense()
    {
        return m_defense;
    }

    public int GetSpeed()
    {
        return m_speed;
    }

    public void SetLevel(int _level)
    {
        m_level = _level;
    }

    public int GetLevel()
    {
        return m_level;
    }

    //-----------------------------------------------------------------------------------------------------
    protected void Attack()
    {
        if (attacking == true)
        {
            chanceToHit = Random.Range(1, 100);

            if (chanceToHit <= 85)
            {
                dmgRecieve = true;
            }
            else
                return;

        }
    }

    protected void Damage()
    {
        if (dmgRecieve == true)
        {
            GetStrength();
            GetDefense();
            tempDMGReduct = GetStrength() / GetDefense();
            totalDMG = GetStrength() - tempDMGReduct;

            dmgRecieve = false;
            dmgDealt = true;

            if (dmgDealt == true)
            {
                m_health = m_health - totalDMG;
                dmgDealt = false;
            }
        }
    }

    protected void Death()
    {
        if (m_health <= 0)
        {
            Destroy(gameObject);
        }

    }
}

