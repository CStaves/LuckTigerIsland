using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemChara : CharaClass {

    public int aggress; //likelihood to attack oppossing attacker (Between 1-20)
    public int intel; //likelihood to attack pm with high value (Between 1-20)
    public int XP; //amount of xp they give

    /* //currently underdevelopment
    public string elemWeak;
    public string elemResi;
    */

    public EnemChara(int hth, int str, int def, int spd, int lvl, int agr, int itl, int xpa)
    {
        health = hth;
        strength = str;
        defense = def;
        speed = spd;
        level = lvl;
        aggress = agr;
        intel = itl;
        XP = xpa;
    }

    public EnemChara Tiger = new EnemChara(100, 10, 5, 10, 4, 16, 4, 150);

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
