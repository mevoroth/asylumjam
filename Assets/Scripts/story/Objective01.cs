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
		return m_cameraSystem.m_current == (int)ObjectiveMgr.Scene.BEDROOM;
	}
	public override void Init()
	{
		m_cameraSystem.AbsoluteSetCurrent((int)ObjectiveMgr.Scene.KITCHEN);
	}
	public override void UpdateStates(ref bool[] STATES)
	{
	}
}
