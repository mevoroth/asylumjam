using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour
{
	public string m_title;
	public string Title
	{
		get { return m_title; }
	}
	public bool m_wildCardFinished = false;
	public bool WildCardFinished
	{
		get { return m_wildCardFinished; }
		set { m_wildCardFinished = value; }
	}
	public abstract bool IsFinished();
	public abstract void Init();

	public abstract void UpdateStates(ref bool[] STATES);
}
