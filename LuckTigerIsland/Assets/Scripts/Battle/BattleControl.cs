using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleControl : MonoBehaviour {


    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    public bool loadSpeeds;
    public bool sortSpeeds;
    //public BattlePlayer[] m_players;
    //public Enemy_AI[] m_enemies;
    public static int currentTurn;
	public static string willDamage; //state n for no damage taken, state y for damage taken. Alternate state could indicate invulnerable or other in future.
	public static int currentDamage;
	public static int currentTarget;
	public static string side;
	public static int totalFighters = 8; //will be used to check when to reset the turn timer and stuff.

    private int Player1Speed;
    private int Player2Speed;
    private int Player3Speed;
    private int Player4Speed;

    private int Enemy1Speed;
    private int Enemy2Speed;
    private int Enemy3Speed;
    private int Enemy4Speed;

    // Use this for initialization
    void Start () {
		currentTurn = 1;
		willDamage = "n";
		currentDamage = 0;
		currentTarget = 0;
		Debug.Log("Setup complete");
		NewTurn();

        loadSpeed();
        sortSpeed();
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
		//Debug.Log(willDamage + " " + currentDamage + "On target: " + side + " " + currentTarget);
		if (currentTurn > 8)
		{
            NewTurn();
		}



	}

    bool loadSpeed() //add later a error handeler that wouls throw an error if this returned false
    {
     
        Player1Speed = Player1.GetComponent<BattlePlayer>().GetSpeed();
        Player2Speed = Player2.GetComponent<BattlePlayer>().GetSpeed();
        Player3Speed = Player3.GetComponent<BattlePlayer>().GetSpeed();
        Player4Speed = Player4.GetComponent<BattlePlayer>().GetSpeed();

        Enemy1Speed = Enemy1.GetComponent<Enemy_AI>().GetSpeed();
        Enemy2Speed = Enemy2.GetComponent<Enemy_AI>().GetSpeed();
        Enemy3Speed = Enemy3.GetComponent<Enemy_AI>().GetSpeed();
        Enemy4Speed = Enemy4.GetComponent<Enemy_AI>().GetSpeed();

        return true;
    }

    bool sortSpeed()
    {
        List<int> speedList = new List<int>(8) {Player1Speed, Player2Speed, Player3Speed, Player4Speed, Enemy1Speed, Enemy2Speed, Enemy3Speed, Enemy4Speed };

        speedList.Sort();

        for (int i=0; i<speedList.Count;i++)
        {
            Debug.Log(speedList[i]);
        }



        return true;
    }
}
