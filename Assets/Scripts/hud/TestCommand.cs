using UnityEngine;
using System.Collections;

public class TestCommand : Command
{
	public override void Execute()
	{
		Debug.Log("TOPLEL COMMAND!: " + m_command);
	}
}
