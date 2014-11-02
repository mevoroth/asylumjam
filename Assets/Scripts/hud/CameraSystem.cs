using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSystem : MonoBehaviour
{
	public List<Camera> m_cameras;
	public int m_current = 0;

	public const int MAIN_CAM_LAYER = 0;
	public const int SUB_CAM_LAYER = 10;

	public Rect m_mainCam = new Rect(0.15f, 0.15f, 0.6f, 0.6f);
	public Rect m_subCams = new Rect(0.75f, 0.75f, 0.2f, 0.2f);
	public float m_step = 0.25f;

	// Update is called once per frame
	void Update ()
	{
		m_cameras[m_current].rect = m_mainCam;
		m_cameras[m_current].depth = MAIN_CAM_LAYER;

		for (int i = 0, camCount = 0; i < m_cameras.Count; ++i)
		{
			if (i != m_current)
			{
				m_cameras[i].rect = new Rect(
					m_subCams.x,
					m_subCams.y - m_step * camCount,
					m_subCams.width,
					m_subCams.height
				);
				m_cameras[i].depth = SUB_CAM_LAYER;
				++camCount;
			}
		}
	}

	public void SetCurrent(int current)
	{
		int newVal = (m_current > current ? current : current + 1);
		if (newVal >= m_cameras.Count)
		{
			return;
		}
		m_current = newVal;
	}

	public void AbsoluteSetCurrent(int current)
	{
		m_current = current;
	}
}
