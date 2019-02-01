using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldMove : MonoBehaviour {

    public Vector2 playerInput;
    public float moveSpeed;
    public bool doMove = true;
    private Rigidbody2D m_rigidbody;
    private Vector3 m_lastPosition;

	// Use this for initialization
	void Start () {
        try
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }
        catch
        {
            //TODO: Show error here//
            Application.Quit();
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        //get player input (WASD)
        int m_xMove = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        int m_yMove = Input.GetKey(KeyCode.S) ? -1 : (Input.GetKey(KeyCode.W) ? 1 : 0);
        playerInput = new Vector2(m_xMove, m_yMove).normalized;
    }

    //FixedUpdate for rigidbody2D
    private void FixedUpdate()
    {
        if (doMove)
        {
            m_lastPosition = transform.position;

            if (playerInput.magnitude > 0.1f)
            {
                m_rigidbody.drag = 0f;
                m_rigidbody.velocity = playerInput * moveSpeed;
            }
            else
            {
                m_rigidbody.drag = 10f;
            }
        }
        else
        {
            m_rigidbody.simulated = false;
        }
    }


}
