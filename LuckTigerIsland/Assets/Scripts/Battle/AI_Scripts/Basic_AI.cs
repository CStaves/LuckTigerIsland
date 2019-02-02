using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_AI : MonoBehaviour {

    public GameObject Enemy;

    public int m_Health = 3;
    private int m_Damage = 1;
    public int m_Speed = 10;
    public float Timer;
	private int m_TargetedEnemy;
	void TakeDamage(int damageTaken)
    {
		m_Health -= damageTaken;
		Debug.Log("Player health: " + m_Health);
    }
	
	// Update is called once per frame
	void Update () {

        Timer += Time.deltaTime;

        if (Timer > m_Speed)
        {
			Debug.Log("Timer reset");
            Timer = 0;
            Enemy.gameObject.SendMessage("TakeDamage", m_Damage); // Deal damage to the other entity
		}

        if (m_Health <= 0)
        {
            Debug.Log("The player is dead");
        }
    }


}
