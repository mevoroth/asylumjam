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
	private bool m_opened = false;
	public void Open()
	{

	}

	public void Close()
	{

	}

	public bool Finished()
	{
		throw new System.NotImplementedException();
	}
}
