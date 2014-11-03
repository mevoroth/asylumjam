using UnityEngine;
using System.Collections;

public class O03TakeTheKnife : Command
{
	public GameObject m_knife;
	public GameObject m_drawer;
	public bool m_once = false;
	IEnumerator DoAction()
	{

	}
	public override void Execute()
	{
		if (m_once)
		{
			return;
		}
		m_once = true;
		StartCoroutine("DoAction");
	}
}
