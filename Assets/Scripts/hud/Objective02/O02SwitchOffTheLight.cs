﻿using UnityEngine;
using System.Collections;

public class O02SwitchOffTheLight : Command
{
	public Light m_light;
	private GameObject m_billy;
	public bool m_once = false;

	IEnumerator SwitchLight()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		while (!billy.Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		// Switch off
		m_light.enabled = false;
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
		StartCoroutine("SwitchLight");
	}
}
