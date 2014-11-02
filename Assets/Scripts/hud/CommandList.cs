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

	// Update is called once per frame
	void Update ()
	{
		//m_timer -= Time.deltaTime;
		//int count = 0;
		//for (int i = 0; i < transform.childCount; ++i)
		//{
		//	count += (transform.GetChild(i).GetComponent<Command>().m_selected ? 1 : 0);
		//	if (count == MAX_COMMANDS)
		//	{
		//		break;
		//	}
		//}
		//if (count == MAX_COMMANDS || m_timer <= 0f)
		//{
		//	Collider[] commands = transform.GetComponentsInChildren<Collider>();
		//	for (int i = 0; i < commands.Length; ++i)
		//	{
		//		commands[i].enabled = false;
		//	}
		//}
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
			slot.transform.localPosition = new Vector3(
				-8f, 4f - 1f * i, 0.5f
			);
			slot.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
		}
	}
}
