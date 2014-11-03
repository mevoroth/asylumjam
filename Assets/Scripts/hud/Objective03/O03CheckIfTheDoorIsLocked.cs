using UnityEngine;
using System.Collections;

public class O03CheckIfTheDoorIsLocked : Command
{
	public bool m_once = false;
	private GameObject m_billy;
	public TextMesh m_textMesh;

	public void Awake()
	{
		m_billy = GameObject.Find("#Character#");
	}

	IEnumerator DoAction()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		billy.MoveToRoom2();
		while (!billy.ReachedRoom2())
		{
			yield return new WaitForSeconds(0.05f);
		}

		// OPEN THEN CLOSE DOOR
		billy.OpenCloseDoor();
		while (!billy.OpenCloseDoorFinished())
		{
			yield return new WaitForSeconds(0.05f);
		}
		SetFinished();
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
