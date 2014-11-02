using UnityEngine;
using System.Collections;

public class O03TurnOffTheAlarm : Command
{
	public Alarm m_alarm;
	private GameObject m_billy;
	public bool m_once = false;

	IEnumerator DoAction()
	{
		Billy billy = m_billy.GetComponent<Billy>();
		while (!billy.ReachedRoom2())
		{
			yield return new WaitForSeconds(0.05f);
		}
		// TURN OFF ALARM
		billy.MoveToAlarm();
		while (!billy.Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_alarm.TurnOff();
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
