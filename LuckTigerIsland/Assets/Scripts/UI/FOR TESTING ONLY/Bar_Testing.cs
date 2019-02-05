using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Testing : MonoBehaviour {

    [SerializeField] private Health_Bar_Test m_healthBar;
	// Use this for initialization
	private void Start () {
		m_healthBar.SetBarSize(0.4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
