using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldMove : MonoBehaviour {

    public Vector2 playerInput;
    public float moveSpeed;
    public bool doMove = true;
    public AudioManager audioManager;
    private Rigidbody2D m_rigidbody;
    

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

        if(audioManager == null)
        {
            Debug.LogError("No AudioManager referenced in PlayerWorldMove.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //get player input (WASD)
        int m_xMove = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        int m_yMove = Input.GetKey(KeyCode.S) ? -1 : (Input.GetKey(KeyCode.W) ? 1 : 0);
        playerInput = new Vector2(m_xMove, m_yMove).normalized;

        //Example of playing and stopping a sound.
        if (Input.GetKeyDown("space")) {
            audioManager.PlaySound("Test");
        }
        if (Input.GetKeyDown("e"))
        {
            audioManager.StopSound("Test");
        }
    }

    //FixedUpdate for rigidbody2D
    private void FixedUpdate()
    {
        if (doMove)
        {
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
