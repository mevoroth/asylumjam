using UnityEngine;
using System.Collections;

public abstract class Command : MonoBehaviour
{
	public string m_command;
	public bool m_selected = false;
	private bool m_finished = false;

	public abstract void Execute();

	public void OnMouseDown()
	{
		m_selected = true;
	}

	public void SetFinished()
	{
		m_finished = true;
	}

	public bool IsFinished()
	{
		return m_finished;
	}
}
