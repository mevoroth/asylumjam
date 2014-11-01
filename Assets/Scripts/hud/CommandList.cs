using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandList : MonoBehaviour
{
	public const int MAX_COMMANDS = 4;
	public const float MAX_TIMER = 5f;
	public GameObject m_hudCamera;
	public List<Command> m_commandList;
	public float m_timer = MAX_TIMER;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_timer -= Time.deltaTime;
		int count = 0;
		for (int i = 0; i < transform.childCount; ++i)
		{
			count += (transform.GetChild(i).GetComponent<Command>().m_selected ? 1 : 0);
			if (count == MAX_COMMANDS)
			{
				break;
			}
		}
		if (count == MAX_COMMANDS || m_timer <= 0f)
		{
			Collider[] commands = transform.GetComponentsInChildren<Collider>();
			for (int i = 0; i < commands.Length; ++i)
			{
				commands[i].enabled = false;
			}
		}
	}
}
