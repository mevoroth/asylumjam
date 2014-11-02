using UnityEngine;
using System.Collections;

/**
 * Where is Billy?
 */
public class Objective01 : Objective
{
	public CameraSystem m_cameraSystem;
	public override bool IsFinished()
	{
		return m_cameraSystem.m_current == 1;
	}
	public override void Init()
	{
	}
}
