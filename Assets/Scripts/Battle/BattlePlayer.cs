using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : MonoBehaviour {

	[SerializeField]
	private int m_Health = 3;
	[SerializeField]
	private int m_Damage = 10000;
	[SerializeField]
	private int m_Speed = 5;
	[SerializeField]
	private int playerNumber;
	[SerializeField]
	private int m_requiredTurn;
	private int m_TargetedEnemy; //used later maybe
	private bool m_attackedAlready = false;

	// Use this for initialization
	void Start () {
		
	}

	public void SetRequiredTurn(int turnNo)
	{
		m_requiredTurn = turnNo;
	}
	public int GetSpeed()
	{
		return m_Speed;
	}
	IEnumerator returnPlayer()
	{
		BattleControl.side = "Player";
		BattleControl.willDamage = "y";
		yield return new WaitForSeconds(1.5f);
		transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
		BattleControl.currentTurn++;
		m_attackedAlready = false;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1") && BattleControl.currentTurn == m_requiredTurn && !m_attackedAlready)
		{
			m_attackedAlready = true;
			BattleControl.currentDamage = m_Damage;
			BattleControl.currentTarget = 1;
			transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
			StartCoroutine(returnPlayer());
		}
		if (Input.GetKeyDown("2") && BattleControl.currentTurn == m_requiredTurn && !m_attackedAlready)
		{
			m_attackedAlready = true;
			BattleControl.currentDamage = m_Damage;
			BattleControl.currentTarget = 2;
			transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
			StartCoroutine(returnPlayer());
		}
		if (Input.GetKeyDown("3") && BattleControl.currentTurn == m_requiredTurn && !m_attackedAlready)
		{
			m_attackedAlready = true;
			BattleControl.currentDamage = m_Damage;
			BattleControl.currentTarget = 3;
			transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
			StartCoroutine(returnPlayer());
		}
		if (Input.GetKeyDown("4") && BattleControl.currentTurn == m_requiredTurn && !m_attackedAlready)
		{
			m_attackedAlready = true;
			BattleControl.currentDamage = m_Damage;
			BattleControl.currentTarget = 4;
			transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
			StartCoroutine(returnPlayer());
		}
		if (BattleControl.willDamage == "y" && BattleControl.currentTarget == playerNumber && BattleControl.side == "Enemy")
		{
			m_Health -= BattleControl.currentDamage;
			BattleControl.willDamage = "n";
			BattleControl.currentTarget = 0;
			BattleControl.side = " ";

		}
	}
}
