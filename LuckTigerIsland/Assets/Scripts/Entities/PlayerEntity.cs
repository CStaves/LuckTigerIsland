using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity {

    public int m_EXP;
    public int m_value; //The value of the party member in question, determines the likelihood of being attacked by intelligent enemies.

    //for arguments, use the coding convention. so m_health = _health;
    public PlayerEntity(int hth, int str, int def, int defM, int spd, int lvl, int man, int mp, int exp, int val)
    {
        m_health = hth;
        m_strength = str;
        m_defense = def;
        m_defenseMGC= defM;
        m_speed = spd;
        m_level = lvl;
        m_mana = man;
        m_magicPow = mp;
        m_EXP = exp;
        m_value = val;
    }

    public PlayerEntity Warrior = new PlayerEntity(150, 20, 20, 10, 5, 1, 20, 5, 0, 40);
    public PlayerEntity Wizard = new PlayerEntity(100, 10, 5, 15, 10, 1, 50, 20, 0, 50);
    public PlayerEntity Cleric = new PlayerEntity(125, 10, 10, 20, 15, 1, 50, 15, 0, 75);
    public PlayerEntity Ninja = new PlayerEntity(100, 15, 10, 5, 20, 1, 35, 10, 0, 30);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Attack();
        Damage();
        Death();
    }
}
