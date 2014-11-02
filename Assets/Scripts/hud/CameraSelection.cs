using UnityEngine;
using System.Collections;

public class CameraSelection : MonoBehaviour {
	public CameraSystem m_camSystem;
	public int m_camId;

	public void OnMouseDown()
	{
		// SCRIPTER CAM
		m_camSystem.SetCurrent(m_camId);
	}
}
