#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using Tactel;

public class Mover : MonoBehaviour
{
	[SerializeField]
	private Movement.EaseType ease;
	[SerializeField]
	private AnimationCurve curve;
	[SerializeField]
	private Transform start;
	[SerializeField]
	private Transform end;
	[SerializeField]
	private float duration;

	private Movement movement;

#if UNITY_EDITOR
	[SerializeField]
	private bool play = false;
#endif

	void Start()
	{
		GameObject g = GameObject.Find("TACTEL");

		if (!g)
		{
			g = new GameObject();
			g.name = "TACTEL";
		}

		movement = FindObjectOfType<Movement>() ? FindObjectOfType<Movement>() : g.AddComponent<Movement>();
	}

	public void Move()
	{
		if (ease == Movement.EaseType.Custom)
		{
			movement.Move(start.position, end.position, duration, transform, curve);
		}
		else
		{
			movement.Move(start.position, end.position, duration, transform, ease);
		}
	}

	public void MoveAsinc()
	{
		if (ease == Movement.EaseType.Custom)
		{
			movement.MoveAsinc(start.position, end.position, duration, transform, curve);
		}
		else
		{
			movement.MoveAsinc(start.position, end.position, duration, transform, ease);
		}
	}

	public void MoveAsinc(System.Action<bool> callback)
	{
		if (ease == Movement.EaseType.Custom)
		{
			movement.MoveAsinc(start.position, end.position, duration, transform, curve, (bool callback2) =>
			{
				if(callback2)
				{
					callback(true);
				}
			});
		}
		else
		{
			movement.MoveAsinc(start.position, end.position, duration, transform, (bool callback2) =>
			{
				if (callback2)
				{
					callback(true);
				}
			}, ease);
		}
	}

#if UNITY_EDITOR
	void Update()
	{
		if (play)
		{
			play = false;

			Move();
		}
	}
#endif
}
