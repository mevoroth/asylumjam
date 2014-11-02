using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour
{
	public string m_title;
	public string Title
	{
		get { return m_title; }
	}
	public abstract bool IsFinished();
	public abstract void Init();
}
