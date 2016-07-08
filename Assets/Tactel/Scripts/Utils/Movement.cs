#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using System.Collections;
using Tactel.Math;

namespace Tactel
{
	/// <summary>
	/// Simple singleton class to move from one point to another with interpolations
	/// </summary>
	public sealed class Movement : MonoBehaviour    //Monobehaviour because of coroutines
	{
		public enum EaseType
		{
			Linear,
			EaseIn,
			EaseOut,
			EaseInOut,
			Boing,
			Custom
		}

		private static Movement instance = null;
		public static Movement Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Movement();
				}
				return instance;
			}
		}

		public void Reset()
		{
			instance = null;
		}
		private Movement() { }

		#region functions

		//Linear
		private void Linear(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Lerp(start, end, t);
			}
		}

		private IEnumerator LinearAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Lerp(start, end, t);
				yield return null;
			}
		}

		private IEnumerator LinearAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Lerp(start, end, t);
				yield return null;
			}
			callback(true);
		}

		//Ease in
		private void EaseIn(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Coserp(start, end, t);
			}
		}

		private IEnumerator EaseInAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Coserp(start, end, t);
				yield return null;
			}
		}

		private IEnumerator EaseInAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Coserp(start, end, t);
				yield return null;
			}
			callback(true);
		}

		//Ease out
		private void EaseOut(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Sinerp(start, end, t);
			}
		}

		private IEnumerator EaseOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Sinerp(start, end, t);
				yield return null;
			}
		}

		private IEnumerator EaseOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Sinerp(start, end, t);
				yield return null;
			}
			callback(true);
		}

		//Ease in out
		private void EaseInOut(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Hermite(start, end, t);
			}
		}

		private IEnumerator EaseInOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Hermite(start, end, t);
				yield return null;
			}
		}

		private IEnumerator EaseInOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Hermite(start, end, t);
				yield return null;
			}
			callback(true);
		}

		//Ease Boing
		private void Boing(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Berp(start, end, t);
			}
		}

		private IEnumerator BoingAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Berp(start, end, t);
				yield return null;
			}
		}

		private IEnumerator BoingAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Berp(start, end, t);
				yield return null;
			}
			callback(true);
		}

		//Ease Custom (AnimationCurve)
		private void Custom(Vector3 start, Vector3 end, float duration, Transform movingObject, AnimationCurve curve)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Lerp(start, end, curve.Evaluate(t));
			}
		}

		private IEnumerator CustomAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, AnimationCurve curve)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Lerp(start, end, curve.Evaluate(t));
				yield return null;
			}
		}

		private IEnumerator CustomAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, AnimationCurve curve, System.Action<bool> callback)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				movingObject.position = Mathfx.Lerp(start, end, curve.Evaluate(t));
				yield return null;
			}
			callback(true);
		}

		/////////////////////////////////////
		public void Move(Vector3 start, Vector3 end, float duration, Transform movingObject, AnimationCurve curve)
		{
			Custom(start, end, duration, movingObject, curve);
		}

		public void Move(Vector3 start, Vector3 end, float duration, Transform movingObject, Movement.EaseType easetype = Movement.EaseType.Linear)
		{
			switch (easetype)
			{
				case Movement.EaseType.Linear:
					Movement.Instance.Linear(start, end, duration, movingObject);
					break;
				case Movement.EaseType.EaseIn:
					Movement.Instance.EaseIn(start, end, duration, movingObject);
					break;
				case Movement.EaseType.EaseOut:
					Movement.Instance.EaseOut(start, end, duration, movingObject);
					break;
				case Movement.EaseType.EaseInOut:
					Movement.Instance.EaseInOut(start, end, duration, movingObject);
					break;
				case Movement.EaseType.Boing:
					Movement.Instance.Boing(start, end, duration, movingObject);
					break;
			}
		}

		public void MoveAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, AnimationCurve curve)
		{
			StartCoroutine(CustomAsinc(start, end, duration, movingObject, curve));
		}

		public void MoveAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, Movement.EaseType easetype = Movement.EaseType.Linear)
		{
			switch (easetype)
			{
				case Movement.EaseType.Linear:
					StartCoroutine(Movement.Instance.LinearAsinc(start, end, duration, movingObject));
					break;
				case Movement.EaseType.EaseIn:
					StartCoroutine(Movement.Instance.EaseInAsinc(start, end, duration, movingObject));
					break;
				case Movement.EaseType.EaseOut:
					StartCoroutine(Movement.Instance.EaseOutAsinc(start, end, duration, movingObject));
					break;
				case Movement.EaseType.EaseInOut:
					StartCoroutine(Movement.Instance.EaseInOutAsinc(start, end, duration, movingObject));
					break;
				case Movement.EaseType.Boing:
					StartCoroutine(Movement.Instance.BoingAsinc(start, end, duration, movingObject));
					break;
			}
		}

		public void MoveAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, AnimationCurve curve, System.Action<bool> callback)
		{
			StartCoroutine(CustomAsinc(start, end, duration, movingObject, curve, (bool callback2) =>
			{
				if (callback2)
				{
					callback(true);
				}
			}));
		}

		public void MoveAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback, Movement.EaseType easetype = Movement.EaseType.Linear)
		{
			switch (easetype)
			{
				case Movement.EaseType.Linear:
					StartCoroutine(Movement.Instance.LinearAsinc(start, end, duration, movingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Movement.EaseType.EaseIn:
					StartCoroutine(Movement.Instance.EaseInAsinc(start, end, duration, movingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Movement.EaseType.EaseOut:
					StartCoroutine(Movement.Instance.EaseOutAsinc(start, end, duration, movingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Movement.EaseType.EaseInOut:
					StartCoroutine(Movement.Instance.EaseInOutAsinc(start, end, duration, movingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Movement.EaseType.Boing:
					StartCoroutine(Movement.Instance.BoingAsinc(start, end, duration, movingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
			}
		}
		#endregion
	}
}