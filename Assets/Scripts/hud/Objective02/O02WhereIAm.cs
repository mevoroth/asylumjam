using UnityEngine;
using System.Collections;

public class O02WhereIAm : Command
{
	public TextMesh m_textMesh;
	public bool m_once = false;
	IEnumerator ShowText()
	{
		yield return new WaitForSeconds(3f);
		for (float i = 0f; i < 1f; i += 0.05f)
		{
			m_textMesh.color = new Color(
				m_textMesh.color.r,
				m_textMesh.color.g,
				m_textMesh.color.b,
				i
			);
			yield return new WaitForSeconds(0.05f);
		}
		m_textMesh.color = new Color(
			m_textMesh.color.r,
			m_textMesh.color.g,
			m_textMesh.color.b,
			1f
		);
		SetFinished();
		yield return null;
	}

	public override void Execute()
	{
		if (m_once)
		{
			return;
		}
		m_once = true;
		m_textMesh.text = "I'm sorry. I'm late. I've got a lot of work right now!";
		m_textMesh.color = new Color(
			m_textMesh.color.r,
			m_textMesh.color.g,
			m_textMesh.color.b,
			0f
		);
		StartCoroutine("ShowText");
	}
}
