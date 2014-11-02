using UnityEngine;
using System.Collections;

public class O03LookAtTheGarden : Command
{
	public bool m_once = false;
	private GameObject m_billy;
	IEnumerator DoAction()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		while (!billy.ReachedRoom2())
		{
			yield return new WaitForSeconds(0.05f);
		}

		// LOOK AT GARDEN
		SetFinished();
	}

	public void Awake()
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
		StartCoroutine("DoAction");
	}
}
