using UnityEngine;
using System.Collections;

public class O03GoCloseTheDoor : Command
{
	public GameObject m_billy;
	public bool m_once = false;
	public TextMesh m_textMesh;

	IEnumerator ShowText()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		billy.MoveToRoom2();
		while (!billy.ReachedRoom2())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_textMesh.text = "Billy is locking the door";
		m_textMesh.color = new Color(
			m_textMesh.color.r,
			m_textMesh.color.g,
			m_textMesh.color.b,
			0f
		);
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
		yield return new WaitForSeconds(1f);
		SetFinished();
		yield return null;
	}

	void Awake()
	{
		m_billy = GameObject.Find("#Character#");
	}
	
	public override void Execute()
	{
		if (m_once)
		{
			return;
		}
		m_once = true;
		StartCoroutine("ShowText");
	}
}
