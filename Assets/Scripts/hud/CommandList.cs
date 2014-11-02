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

	public enum State
	{
		BEGIN,
		CHOOSE,
		END,
		IDLE
	}

	// Update is called once per frame
	void Update ()
	{
		switch (m_state)
		{
			case State.BEGIN:
				m_timer = MAX_TIMER;
				m_selectedAnswers.gameObject.SetActive(true);
				m_state = State.CHOOSE; // NEED TEMPO ?
				break;
			case State.CHOOSE:
				m_timer -= Time.deltaTime;
				int count = 0;
				for (int i = 0; i < m_commandList.Count; ++i)
				{
					count += (m_commandList[i].m_selected ? 1 : 0);
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
					m_state = State.END;
				}
				break;
			case State.END:
				int selectedCount = 0;
				for (int i = 0; i < m_commandList.Count; ++i)
				{
					if (m_commandList[i].m_selected)
					{
						m_commandList[i].Execute();
						++selectedCount;
					}
				}
				m_state = State.IDLE;
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

	public void Set(Command[] cmdlist)
	{
		for (int i = 0; i < transform.childCount; ++ i)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
		for (int i = 0; i < cmdlist.Length; ++i)
		{
			GameObject slot = (GameObject)Instantiate(m_pattern);
			slot.transform.parent = transform;
			m_commandList.Add(cmdlist[i]);
			slot.GetComponent<TextMesh>().text = cmdlist[i].m_command;
			Selector sel = slot.AddComponent<Selector>();
			sel.m_cmd = cmdlist[i];
			slot.transform.localPosition = new Vector3(
				-8f, 3.5f - 1f * i, 0.5f
			);
			slot.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

			m_state = State.BEGIN;
		}
	}
}
