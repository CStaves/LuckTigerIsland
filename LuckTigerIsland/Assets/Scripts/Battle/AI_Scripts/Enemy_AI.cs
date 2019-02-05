using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_AI : MonoBehaviour {

    public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;

	[SerializeField]
	private int m_Health;
	[SerializeField]
	private int m_Damage;
	[SerializeField]
	private int m_Speed;
	[SerializeField]
	private int m_enemyNumber;
	[SerializeField]
	private int m_TargetedPlayer;
	[SerializeField]
	private int m_requiredTurn;
	[SerializeField]
	private bool m_attackedAlready = false;

	void TakeDamage(int damageTaken)
    {
		Debug.Log("Enemy taking damage");
		m_Health -= damageTaken;
    }

    // Use this for initialization
    void Start () {
		
	}

	void SetRequiredTurn(int turnNo)
	{
		m_requiredTurn = turnNo;
	}
	public int GetSpeed()
	{
		return m_Speed;
	}
	IEnumerator returnEnemy()
	{
		BattleControl.side = "Enemy";
		BattleControl.willDamage = "y";
		yield return new WaitForSeconds(1.5f);
		transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
		BattleControl.currentTurn++;
		m_attackedAlready = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (BattleControl.side == "Player")
		{
			CheckForDamage();
		}
		if (BattleControl.currentTurn == m_requiredTurn && m_attackedAlready == false)
		{
			m_attackedAlready = true;
			m_TargetedPlayer = UnityEngine.Random.Range(1, 4); //determines target for enemy attack
			BattleControl.currentDamage = m_Damage;
			BattleControl.currentTarget = m_TargetedPlayer;
			transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
			StartCoroutine(returnEnemy());
				
		}
        if (m_Health <=0 )
        {
           Debug.Log("The enemy is dead");
        }
	}


	void CheckForDamage()
	{
		if (BattleControl.willDamage == "y" && BattleControl.currentTarget == m_enemyNumber)
		{
			m_Health -= BattleControl.currentDamage;
			Debug.Log("Enemy: " + m_enemyNumber + "health total now: " + m_Health);
			BattleControl.willDamage = "n";
			BattleControl.currentTarget = 0;
			BattleControl.side = " ";
		}

	}
}
