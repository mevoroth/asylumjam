using UnityEngine;
using System.Collections;

public class CurrentCommand : MonoBehaviour
{
	private TextMesh m__textMesh;

	public Command m_currentCommand;

	// Use this for initialization
	void Start ()
	{
		m__textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_currentCommand != null)
		{
			m__textMesh.text = m_currentCommand.m_command;
		}
	}
}
