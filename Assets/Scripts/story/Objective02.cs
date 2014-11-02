using UnityEngine;
using System.Collections;

public class Objective02 : Objective
{
	public GameObject m_cmdList;
	public CommandList m_view;
	public override bool IsFinished()
	{
		return false;
	}
	public override void Init()
	{
		Command[] cmdlist = m_cmdList.GetComponentsInChildren<Command>();
		m_view.Set(cmdlist);
	}
}
