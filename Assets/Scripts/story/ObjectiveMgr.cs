using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveMgr : MonoBehaviour
{
	public List<Objective> m_objectives = new List<Objective>();
	public TextMesh m_title;
	public TextMesh m_answer;
	public GameObject m_wsith;
	public int m_objective = 0;

	public enum Scene
	{
		BEDROOM = 0,
		KITCHEN = 1,
		LIVINGROOM = 2
	}

	public enum State
	{
		LIGHT_OFF = 0,
		CLOSED_DOOR = 1,
		MOM_CALLED = 2
	}

	public static bool[] STATES =
	{
		false,
		false,
		false
	};

	IEnumerator AnimateHUD()
	{
		m_objectives[m_objective].UpdateStates(ref STATES);
		++m_objective;
		for (float i = 0f; i < 1f; i += 0.05f)
		{
			m_title.color = new Color(
				m_title.color.r,
				m_title.color.g,
				m_title.color.b,
				1f - i
			);
			yield return new WaitForSeconds(0.05f);
		}
		m_title.text = m_objectives[m_objective].Title;
		for (float i = 0f; i < 1f; i += 0.05f)
		{
			m_title.color = new Color(
				m_title.color.r,
				m_title.color.g,
				m_title.color.b,
				i
			);
			yield return new WaitForSeconds(0.05f);
		}
		m_objectives[m_objective].Init();
		m_answer.text = "";
		m_wsith.SetActive(true);
		yield return null;
	}

	public void Awake()
	{
		m_title.text = m_objectives[m_objective].Title;
		m_objectives[m_objective].Init();
		m_answer.text = "";
	}
	public void Update()
	{
		if (m_objective >= m_objectives.Count)
		{
			return;
		}
		if (m_objectives[m_objective].IsFinished())
		{
			StartCoroutine("AnimateHUD");
		}
	}

	public void SetFinished()
	{
		m_objectives[m_objective].WildCardFinished = true;
	}
}
