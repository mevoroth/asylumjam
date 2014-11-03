using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Billy : MonoBehaviour
{
	private NavMeshAgent m_billy;

	public GameObject m_teddyBear;
	public GameObject m_room1;
	public GameObject m_room2;
	public GameObject m_room3;
	public GameObject m_room1Door;
	public GameObject m_room2Door0;
	public GameObject m_room2Door1;
	public GameObject m_room3Door;

	public GameObject m_room1Warp;
	public GameObject m_room2Warp0;
	public GameObject m_room2Warp1;
	public GameObject m_room3Warp;

	public Door m_room1DoorObj;
	public Door m_room2Door0Obj;
	public Door m_room2Door1Obj;

	public GameObject m_room2Alarm;
	public GameObject m_room2Window;
	public GameObject m_phone;

	public Animator m_animator;

	public Vector2 m_dest;

	public enum Location
	{
		ROOM1,
		ROOM2,
		ROOM3
	}
	private Location m_loc = Location.ROOM1;
	public void Awake()
	{
		m_billy = GetComponent<NavMeshAgent>();
		m_animator = GetComponentInChildren<Animator>();
	}
	public void MoveToTeddyBear()
	{
		m_billy.SetDestination(m_teddyBear.transform.position);
		m_dest = new Vector2(
			m_teddyBear.transform.position.x,
			m_teddyBear.transform.position.z
		);
		Debug.Log("MoveToTeddyBear");
		m_animator.SetBool("Walking", true);
	}

	public void MoveToRoom1()
	{
		
	}

	public void MoveToPhone()
	{
		m_billy.SetDestination(m_phone.transform.position);
		m_dest = new Vector2(
			m_phone.transform.position.x,
			m_phone.transform.position.z
		);
		m_animator.SetBool("Walking", true);
	}

	IEnumerator MoveToRoom2Corout()
	{
		m_billy.SetDestination(m_room1Door.transform.position);
		m_dest = new Vector2(
			m_room1Door.transform.position.x,
			m_room1Door.transform.position.z
		);
		m_animator.SetBool("Walking", true);
		while (!Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_room1DoorObj.Open();
		while (!m_room1DoorObj.Finished())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_billy.SetDestination(m_room1Warp.transform.position);
		m_dest = new Vector2(
			m_room1Warp.transform.position.x,
			m_room1Warp.transform.position.z
		);
		while (!Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_billy.Warp(m_room2Warp0.transform.position);
		m_dest = new Vector2(
			m_room2Warp0.transform.position.x,
			m_room2Warp0.transform.position.z
		);
		m_room2Door0Obj.Open();
		while (!m_room2Door0Obj.Finished())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_billy.SetDestination(m_room2Door0.transform.position);
		m_dest = new Vector2(
			m_room2Door0.transform.position.x,
			m_room2Door0.transform.position.z
		);
		while (!Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_room2Door0Obj.Close();
		while (!m_room2Door0Obj.Finished())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_loc = Location.ROOM2;
	}

	public void MoveToRoom2()
	{
		Debug.Log("MOVE ROOM2");
		if (m_loc != Location.ROOM2)
		{
			StartCoroutine("MoveToRoom2Corout");
		}
	}

	//IEnumerator MoveToAlarmCorout()
	//{
	//	while (!Reached())
	//	{
	//		yield return new WaitForSeconds(0.05f);
	//	}
	//	yield return null;
	//}

	public void MoveToAlarm()
	{
		//StartCoroutine("MoveToAlarmCorout");
		m_billy.SetDestination(m_room2Alarm.transform.position);
	}

	public void MoveToRoom3()
	{

	}

	public void MoveToRoom1Door()
	{

	}

	public void MoveToRoom2Door0()
	{

	}

	public void MoveToRoom2Door1()
	{

	}

	public void MoveToRoom3Door()
	{

	}

	public bool Reached()
	{
		bool reached = Vector2.Distance(
			m_dest,
			new Vector2(
				transform.position.x,
				transform.position.z
			)
		) <= 0.001f;
		m_animator.SetBool("Walking", !reached);
		return reached;
	}
	public bool ReachedRoom2()
	{
		return m_loc == Location.ROOM2;
	}
	bool m_openclosefinished = false;
	public bool OpenCloseDoorFinished()
	{
		return m_openclosefinished;
	}
	IEnumerator OpenCloseDoorCorout()
	{
		m_billy.SetDestination(m_room2Door0.transform.position);
		m_dest = new Vector2(
			m_room2Door0.transform.position.x,
			m_room2Door0.transform.position.z
		);
		while (!Reached())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_room2Door0Obj.Close();
		while (!m_room2Door0Obj.Finished())
		{
			yield return new WaitForSeconds(0.05f);
		}
		m_openclosefinished = true;
	}
	public void OpenCloseDoor()
	{
		m_openclosefinished = false;
		StartCoroutine("OpenCloseDoorCorout");
	}
	public void SetToIdle()
	{
		m_animator.SetBool("Walking", false);
	}
}
