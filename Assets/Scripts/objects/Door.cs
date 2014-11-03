using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public enum Axis
	{
		X, Y, Z
	}
	public Axis m_axis;
	public float m_angle;
	private bool m_finished = false;

	IEnumerator OpenDoor()
	{
		//Vector3 rot = transform.eulerAngles;
		//unsafe
		//{
		//	float* val;
		//	switch (m_axis)
		//	{
		//		case Axis.X:
		//			val = &rot.x;
		//			break;
		//		case Axis.Y:
		//			val = &rot.y;
		//			break;
		//		default:
		//			val = &rot.z;
		//			break;
		//	}
		//	for (float i = 0f; i < 1f; i += 0.05f)
		//	{
		//		*val = Mathf.Lerp(0f, m_angle, i);
		//		yield return new WaitForSeconds(0.05f);
		//	}
		//}
		Vector3 init = transform.eulerAngles;
		switch (m_axis)
		{
			case Axis.X:
				for (float t = 0f; t < 1f; t += 0.05f)
				{
					transform.eulerAngles = Vector3.Lerp(
						new Vector3(0f, init.y, init.z),
						new Vector3(m_angle, init.y, init.z),
						t
					);
					yield return new WaitForSeconds(0.05f);
				}
				break;
			case Axis.Y:
				for (float t = 0f; t < 1f; t += 0.05f)
				{
					transform.eulerAngles = Vector3.Lerp(
						new Vector3(init.x, 0f, init.z),
						new Vector3(init.x, m_angle, init.z),
						t
					);
					yield return new WaitForSeconds(0.05f);
				}
				break;
			default:
				for (float t = 0f; t < 1f; t += 0.05f)
				{
					transform.eulerAngles = Vector3.Lerp(
						new Vector3(init.x, init.y, 0f),
						new Vector3(init.x, init.y, init.z),
						t
					);
					yield return new WaitForSeconds(0.05f);
				}
				break;
		}
		m_finished = true;
	}

	public void Open()
	{
		m_finished = false;
		StartCoroutine("OpenDoor");
	}

	IEnumerator CloseDoor()
	{
		Vector3 init = transform.eulerAngles;
		switch (m_axis)
		{
			case Axis.X:
				for (float t = 0f; t < 1f; t += 0.05f)
				{
					transform.eulerAngles = Vector3.Lerp(
						new Vector3(m_angle, init.y, init.z),
						new Vector3(0f, init.y, init.z),
						t
					);
					yield return new WaitForSeconds(0.05f);
				}
				break;
			case Axis.Y:
				for (float t = 0f; t < 1f; t += 0.05f)
				{
					transform.eulerAngles = Vector3.Lerp(
						new Vector3(init.x, m_angle, init.z),
						new Vector3(init.x, 0f, init.z),
						t
					);
					yield return new WaitForSeconds(0.05f);
				}
				break;
			default:
				for (float t = 0f; t < 1f; t += 0.05f)
				{
					transform.eulerAngles = Vector3.Lerp(
						new Vector3(init.x, init.y, init.z),
						new Vector3(init.x, init.y, 0f),
						t
					);
					yield return new WaitForSeconds(0.05f);
				}
				break;
		}
		m_finished = true;
	}

	public void Close()
	{
		m_finished = false;
		StartCoroutine("CloseDoor");
	}

	public bool Finished()
	{
		return m_finished;
	}
}
