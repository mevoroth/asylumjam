using UnityEngine;
using System.Collections;

public class O02SwitchOffTheLight : Command
{
	public Light m_light;
	public bool m_once = false;

	public override void Execute()
	{
		if (m_once)
		{
			return;
		}
		m_once = true;
		// Switch off
		m_light.enabled = false;
		SetFinished();
	}
}
