using UnityEngine;
using System.Collections;

public class Objective04 : Objective
{
	public GameObject m_cmdList;
	public CommandList m_view;

	public override bool IsFinished()
	{
		return false;
	}

	public override void Init()
	{
		// SCRIPTING
		Command[] cmdlist = m_cmdList.GetComponentsInChildren<Command>();
		m_view.Set(cmdlist);
	}

	public override void UpdateStates(ref bool[] STATES)
	{

	}
}
