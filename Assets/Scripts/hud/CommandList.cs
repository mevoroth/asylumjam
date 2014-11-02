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

	public GameObject m_pattern;
	public State m_state = State.IDLE;
	
	public TextMesh m_selectedAnswers;
	public int m_selectedCount = 0;
	public int m_realCount = 0;
	List<Command> m_selectedCmds = new List<Command>();

	public ObjectiveMgr m_objMgr;

	public enum State
	{
		BEGIN,
		CHOOSE,
		END,
		NO_ACTION,
		IDLE
	}

	// Update is called once per frame
	void Update ()
	{
		switch (m_state)
		{
			case State.BEGIN:
				m_selectedAnswers.gameObject.SetActive(true);
				m_state = State.CHOOSE; // NEED TEMPO ?
				break;
			case State.CHOOSE:
				m_timer -= Time.deltaTime;
				int count = 0;

				m_selectedCmds.Clear();
				for (int i = 0; i < m_commandList.Count; ++i)
				{
					if (m_commandList[i].m_selected)
					{
						m_selectedCmds.Add(m_commandList[i]);
						++count;
					}
					if (count == MAX_COMMANDS)
					{
						break;
					}
				}

				// FEEDBACKS !!!
				ShowFeedback(count);

				if (count == MAX_COMMANDS || m_timer <= 0f)
				{
					Collider[] commands = transform.GetComponentsInChildren<Collider>();
					for (int i = 0; i < commands.Length; ++i)
					{
						commands[i].enabled = false;
					}
					m_selectedCount = 0;

					if (count == 0)
					{
						m_state = State.NO_ACTION;
						return;
					}

					m_realCount = count;
					m_state = State.END;
				}
				break;
			case State.NO_ACTION:
				m_state = State.IDLE;
				break;
			case State.END:
				// A CHANGER
				m_selectedCmds[m_selectedCount].Execute();
				if (m_selectedCmds[m_selectedCount].IsFinished())
				{
					++m_selectedCount;
				}
				//for (int i = 0; i < m_commandList.Count; ++i)
				//{
				//	if (m_commandList[i].m_selected)
				//	{
				//		m_commandList[i].Execute();
				//		++selectedCount;
				//	}
				//}

				if (m_selectedCount >= m_realCount)
				{
					m_state = State.IDLE;
					m_objMgr.SetFinished();
				}
				break;
			case State.IDLE:
				m_selectedAnswers.gameObject.SetActive(false);
				break;
		}
	}

	protected void ShowFeedback(int count)
	{
		m_selectedAnswers.text = count + "/" + MAX_COMMANDS;
		// ADD TIMER!!!
	}

	IEnumerator ShowCommands(Command[] cmdlist)
	{
		for (int i = 0; i < cmdlist.Length; ++i)
		{
			GameObject slot = (GameObject)Instantiate(m_pattern);
			slot.transform.parent = transform;
			m_commandList.Add(cmdlist[i]);
			slot.GetComponent<TextMesh>().text = cmdlist[i].m_command;
			slot.GetComponent<TextMesh>().color = new Color(
				slot.GetComponent<TextMesh>().color.r,
				slot.GetComponent<TextMesh>().color.g,
				slot.GetComponent<TextMesh>().color.b,
				0f
			);
			Selector sel = slot.AddComponent<Selector>();
			sel.m_cmd = cmdlist[i];
			slot.transform.localPosition = new Vector3(
				-8f, 3.5f - 1f * i, 0.5f
			);
			slot.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			slot.collider.enabled = false;

			m_state = State.BEGIN;
		}
		for (float t = 0; t < 1f; t += 0.05f)
		{
			for (int i = 0; i < transform.childCount; ++i)
			{
				Color c = transform.GetChild(i).GetComponent<TextMesh>().color;
				transform.GetChild(i).GetComponent<TextMesh>().color = new Color(
					c.r, c.g, c.b, t
				);
			}
			yield return new WaitForSeconds(0.05f);
		}
		for (int i = 0; i < transform.childCount; ++i)
		{
			Color c = transform.GetChild(i).GetComponent<TextMesh>().color;
			transform.GetChild(i).GetComponent<TextMesh>().color = new Color(
				c.r, c.g, c.b, 1f
			);
			transform.GetChild(i).collider.enabled = true;
		}
	}

	public void Set(Command[] cmdlist)
	{
		for (int i = 0; i < transform.childCount; ++ i)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
		StartCoroutine("ShowCommands", cmdlist);
	}
}
