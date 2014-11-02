using UnityEngine;
using System.Collections;

public class Objective03 : Objective
{
	public GameObject m_cmdList;
	public CommandList m_view;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
