using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	public Command m_cmd;
	public void Toggle()
	{
		m_cmd.m_selected = !m_cmd.m_selected;
	}
	public void OnMouseDown()
	{
		Toggle();
	}
}
