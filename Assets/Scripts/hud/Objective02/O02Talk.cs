using UnityEngine;
using System.Collections;

public class O02Talk : Command
{
	public TextMesh m_textMesh;
	public string m_answer;
	public override void Execute()
	{
		m_textMesh.text = m_answer;
	}
}
