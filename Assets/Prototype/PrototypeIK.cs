using UnityEngine;
using System.Collections;

public class PrototypeIK : MonoBehaviour {
	public Animator m_animator;
	// Use this for initialization
	void Start ()
	{
		m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnAnimatorIK()
	{
		Debug.Log("test");
	}
}
