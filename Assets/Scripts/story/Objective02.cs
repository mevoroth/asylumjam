using UnityEngine;
using System.Collections;

public class Objective02 : Objective
{
	public GameObject m_cmdList;
	public CommandList m_view;

	public override bool IsFinished()
	{
		return WildCardFinished;
	}
	public override void Init()
	{
		Command[] cmdlist = m_cmdList.GetComponentsInChildren<Command>();
		m_view.Set(cmdlist);
		//m_view.m_timer = 
	}
	public override void UpdateStates(ref bool[] STATES)
	{
		STATES[(int)ObjectiveMgr.State.LIGHT_OFF] = m_cmdList.GetComponentInChildren<O02SwitchOffTheLight>().m_selected;
	}
}
