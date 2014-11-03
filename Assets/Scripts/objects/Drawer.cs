using UnityEngine;
using System.Collections;

public class Drawer : MonoBehaviour {
	public Vector3 m_begin = new Vector3(-1.377893f, 0.6931273f, 2.954115f);
	public Vector3 m_end = new Vector3(-1.377893f, 0.6931273f, 2.65f);

	IEnumerator OpenDrawer()
	{
		for (float t = 0f; t < 1f; t += 0.05f)
		{
			transform.position = Vector3.Lerp(m_begin, m_end, t);
			yield return new WaitForSeconds(0.05f);
		}
		transform.position = m_end;
	}

	public void Open()
	{
		StartCoroutine("OpenDrawer");
	}
}
