using UnityEngine;
using System.Collections;

public class O02TakeYourTeddyBear : Command
{
	public GameObject m_teddyBear;
	private GameObject m_billy;
	public bool m_once = false;

	IEnumerator GetTeddy()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		while (!billy.Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		Debug.Log("test");
		m_teddyBear.transform.parent = m_billy.transform;
		SetFinished();
		yield return null;
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
		// Take the teddy bear
		m_billy.GetComponent<Billy>().MoveToTeddyBear();
		StartCoroutine("GetTeddy");
	}
}
