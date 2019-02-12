using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemEntity : Entity {

    public int m_aggress; //likelihood to attack oppossing attacker (Between 1-20)
    public int m_intel; //likelihood to attack pm with high value (Between 1-20)

    /* //currently underdevelopment
    public string elemWeak;
    public string elemResi;
    */

    public EnemEntity(int hth, int str, int def, int spd, int lvl, int agr, int itl, int xpa)
    {
        m_health = hth;
        m_strength = str;
        m_defense = def;
        m_speed = spd;
        m_level = lvl;
        m_aggress = agr;
        m_intel = itl;
        m_XP = xpa;
    }

    public EnemEntity Tiger = new EnemEntity(100, 10, 5, 10, 4, 16, 4, 150);

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Attack();
        Damage();
        Death();
	}

}
