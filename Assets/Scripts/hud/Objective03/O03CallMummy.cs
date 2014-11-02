using UnityEngine;
using System.Collections;

public class O03CallMummy : Command
{
	private GameObject m_billy;
	public bool m_once = false;

	IEnumerator DoAction()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		billy.MoveToRoom2();
		while (!billy.ReachedRoom2())
		{
			yield return new WaitForSeconds(0.05f);
		}

		// PICKUP PHONE
		//billy.MoveToPhone();
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
