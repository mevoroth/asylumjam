using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Billy : MonoBehaviour
{
	private NavMeshAgent m_billy;

	public GameObject m_teddyBear;
	public void Awake()
	{
		m_billy = GetComponent<NavMeshAgent>();
	}
	public void MoveToTeddyBear()
	{
		m_billy.SetDestination(m_teddyBear.transform.position);
	}

	public bool Reached()
	{
		//Debug.Log("PATHPENDING = " + m_billy.pathPending);
		//Debug.Log("DIST REMAIN = " + m_billy.remainingDistance);
		//Debug.Log("STOP DIST = " + m_billy.stoppingDistance);
		//Debug.Log("HAS PATH = " + m_billy.hasPath);
		//Debug.Log("VELO = " + m_billy.velocity.sqrMagnitude);
		//return !m_billy.pathPending
		//	&& m_billy.remainingDistance <= m_billy.stoppingDistance
		//	&& (!m_billy.hasPath || m_billy.velocity.sqrMagnitude == 0f);
		return m_billy.remainingDistance <= float.Epsilon;
	}
}
