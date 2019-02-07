using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntity : MonoBehaviour {


    [SerializeField]
    protected int m_Health;
    [SerializeField]
    protected int m_Damage;
    [SerializeField]
    protected int m_Speed;
    [SerializeField]
    protected bool m_attackedAlready = false;
    [SerializeField]
    private int m_requiredTurn;
    [SerializeField]
    private int entityNumber;
    [SerializeField]
    private int m_TargetedPlayer;
    [SerializeField]
    private int m_enemyNumber;
    [SerializeField]
    private string side;
    protected float baseRequiredSpeedForTurn = 100;
    [SerializeField]
    protected float requiredSpeedForTurn;
    [SerializeField]
    protected bool myTurn = false;

    public float GetSpeed() { return m_Speed; }

    // Use this for initialization
    void Start () {

        requiredSpeedForTurn = baseRequiredSpeedForTurn - m_Speed;

    }
    IEnumerator returnPlayer()
    {
        BattleControl.side = "Player";
        BattleControl.willDamage = "y";
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
        BattleControl.isPaused = false;
        m_attackedAlready = false;

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
    void Update()
    {
        while (BattleControl.speedCounter == requiredSpeedForTurn && side == "player")
        {
            BattleControl.isPaused = true;

            if (Input.GetKeyDown("1") && !m_attackedAlready)
            {
                m_attackedAlready = true;
                BattleControl.currentDamage = m_Damage;
                BattleControl.currentTarget = 1;
                transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
                StartCoroutine(returnPlayer());
                break;
            }
            if (Input.GetKeyDown("2") && !m_attackedAlready)
            {
                m_attackedAlready = true;
                BattleControl.currentDamage = m_Damage;
                BattleControl.currentTarget = 2;
                transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
                StartCoroutine(returnPlayer());
                break;
            }
            if (Input.GetKeyDown("3") && !m_attackedAlready)
            {
                m_attackedAlready = true;
                BattleControl.currentDamage = m_Damage;
                BattleControl.currentTarget = 3;
                transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
                StartCoroutine(returnPlayer());
                break;
            }
            if (Input.GetKeyDown("4") && !m_attackedAlready)
            {
                m_attackedAlready = true;
                BattleControl.currentDamage = m_Damage;
                BattleControl.currentTarget = 4;
                transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
                StartCoroutine(returnPlayer());
                break;
            }
        }
        while (BattleControl.speedCounter == requiredSpeedForTurn && side == "enemy")
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
            if (m_Health <= 0)
            {
                Debug.Log("The enemy is dead");
            }

        }
            if (BattleControl.willDamage == "y" && BattleControl.currentTarget == entityNumber && BattleControl.side == "Enemy")
       {
                m_Health -= BattleControl.currentDamage;
                BattleControl.willDamage = "n";
                BattleControl.currentTarget = 0;
                BattleControl.side = " ";

       }
 
    }
    public void SetRequiredTurn(int turnNo)
    {
        m_requiredTurn = turnNo;
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
    void TakeDamage(int damageTaken)
    {
        Debug.Log("Enemy taking damage");
        m_Health -= damageTaken;
    }
}

