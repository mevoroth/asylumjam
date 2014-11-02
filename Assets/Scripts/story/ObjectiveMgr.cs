using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveMgr : MonoBehaviour
{
	public List<Objective> m_objectives = new List<Objective>();
	public TextMesh m_title;
	public int m_objective = 0;
	public void Awake()
	{
		m_title.text = m_objectives[m_objective].Title;
	}
	public void Update()
	{
		if (m_objective >= m_objectives.Count)
		{
			return;
		}
		if (m_objectives[m_objective].IsFinished())
		{
			++m_objective;
			m_title.text = m_objectives[m_objective].Title;
			m_objectives[m_objective].Init();
		}
	}
}
