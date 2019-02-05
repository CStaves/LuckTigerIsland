using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour {

	//public BattlePlayer[] m_players;
	//public Enemy_AI[] m_enemies;
	public static int currentTurn;
	public static string willDamage; //state n for no damage taken, state y for damage taken. Alternate state could indicate invulnerable or other in future.
	public static int currentDamage;
	public static int currentTarget;
	public static string side;
	public static int totalFighters = 8; //will be used to check when to reset the turn timer and stuff.

	// Use this for initialization
	void Start () {
		currentTurn = 1;
		willDamage = "n";
		currentDamage = 0;
		currentTarget = 0;
		Debug.Log("Setup complete");
		NewTurn();
	}
	/// <summary>
	/// Resets back to beginning of the turn order. Preferably also calculating speed differences and whatnot.
	/// Currently only resets turn order to begining. So the order is currently P/E/P/E/P/E/P/E with 8 things available.
	/// </summary>
	void NewTurn()
	{
		//for (int i = 0; i<=m_entities.Length; i++)
		//{
		//	for (int j = 1+i; j<= m_entities.Length; i++)
		//	{
		//		if (j >= m_entities.Length)
		//		{
		//			break;

		//		}
		//		if (m_entities[i].GetComponent<BattlePlayer>. > m_entities[j].GetSpeed())
		//		{
		//			m_entities[i].SetRequiredTurn(i);
		//		}
		//	}
		//}
		currentTurn = 1;
		Debug.Log("New turn started");
	}
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(willDamage + " " + currentDamage + "On target: " + side + " " + currentTarget);
		if (currentTurn > 8)
		{
			NewTurn();
			
		}
	}
}
