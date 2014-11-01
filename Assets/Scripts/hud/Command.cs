using UnityEngine;
using System.Collections;

public abstract class Command : MonoBehaviour
{
	public string m_command;
	public bool m_selected = false;

	public abstract void Execute();

	public void OnMouseDown()
	{
		Debug.Log("TOPLEL!");
		m_selected = true;
	}
}
