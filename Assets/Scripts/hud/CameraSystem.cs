using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSystem : MonoBehaviour
{
	public List<Camera> m_cameras;
	public int m_current = 0;

	public const int MAIN_CAM_LAYER = 0;
	public const int SUB_CAM_LAYER = 10;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_cameras[m_current].rect = new Rect(0f, 0f, 1f, 1f);
		m_cameras[m_current].depth = MAIN_CAM_LAYER;

		for (int i = 0, camCount = 0; i < m_cameras.Count; ++i)
		{
			if (i != m_current)
			{
				m_cameras[i].rect = new Rect(0.69f, 0.66f - 0.325f * camCount, 0.3f, 0.3f);
				Debug.Log("subcam:" + (1.0f - 0.325f * camCount));
				m_cameras[i].depth = SUB_CAM_LAYER;
				++camCount;
			}
		}
	}
}
