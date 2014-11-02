using UnityEngine;
using System.Collections;

public class O02WhereIAm : Command
{
	public TextMesh m_textMesh;
	public override void Execute()
	{
		m_textMesh.text = "I'm sorry. I'm late. I've got a lot of work right now!";
	}
}
