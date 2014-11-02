using UnityEngine;
using System.Collections;

public class O02SwitchOffTheLight : Command
{
	public Light m_light;

	public override void Execute()
	{
		// Switch off
		m_light.enabled = false;
	}
}
