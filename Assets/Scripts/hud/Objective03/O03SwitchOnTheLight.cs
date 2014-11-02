using UnityEngine;
using System.Collections;

public class O03SwitchOnTheLight : Command
{
	public Light m_light;

	public override void Execute()
	{
		m_light.enabled = true;
	}
}
