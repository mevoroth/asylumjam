using UnityEngine;
using System.Collections;

public class O02ReadABook : Command
{
	public bool m_once = false;
	public override void Execute()
	{
		if (m_once)
		{
			return;
		}
		m_once = true;
		// Read a book
		SetFinished();
	}
}
