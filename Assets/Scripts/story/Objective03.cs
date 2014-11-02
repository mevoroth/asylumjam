using UnityEngine;
using System.Collections;

public class Objective03 : Objective
{
	public GameObject m_cmdList;
	public CommandList m_view;

	// Update is called once per frame
	public override bool IsFinished()
	{
		return false;
	}
	public override void Init()
	{
		// SCRIPTING BIATCH !

		Command[] cmdlist = m_cmdList.GetComponentsInChildren<Command>();
		m_view.Set(cmdlist);
	}
	public override void UpdateStates(ref bool[] STATES)
	{
		STATES[(int)ObjectiveMgr.State.CLOSED_DOOR] = m_cmdList.GetComponentInChildren<O03GoCloseTheDoor>().m_selected;
		STATES[(int)ObjectiveMgr.State.MOM_CALLED] = m_cmdList.GetComponentInChildren<O03CallMummy>().m_selected;
		STATES[(int)ObjectiveMgr.State.LIGHT_OFF] = !m_cmdList.GetComponentInChildren<O03SwitchOnTheLight>().m_selected;
	}
}
