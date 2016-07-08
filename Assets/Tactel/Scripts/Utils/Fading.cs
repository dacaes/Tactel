#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Tactel.Math;

namespace Tactel
{
	/// <summary>
	/// Simple singleton class to fade with interpolations
	/// </summary>
	public sealed class Fading : MonoBehaviour    //Monobehaviour because of coroutines
	{
		public enum EaseType
		{
			Linear,
			EaseIn,
			EaseOut,
			EaseInOut,
			Boing
		}

		private static Fading instance = null;
		public static Fading Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Fading();
				}
				return instance;
			}
		}

		public void Reset()
		{
			instance = null;
		}
		private Fading() { }

		#region functions1

		//Linear
		public void Linear(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Lerp(alpha, end, t));
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Lerp(alpha, end, t));
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		public IEnumerator LinearAsinc(float end, float duration, Transform fadingObject, System.Action<bool> callback)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Lerp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Lerp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
			callback(true);
		}

		public IEnumerator LinearAsinc(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Lerp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Lerp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		//Ease in
		public void EaseIn(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Coserp(alpha, end, t));
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Coserp(alpha, end, t));
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		public IEnumerator EaseInAsinc(float end, float duration, Transform fadingObject, System.Action<bool> callback)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Coserp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Coserp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
			callback(true);
		}

		public IEnumerator EaseInAsinc(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Coserp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Coserp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		//Ease out
		public void EaseOut(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Sinerp(alpha, end, t));
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Sinerp(alpha, end, t));
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		public IEnumerator EaseOutAsinc(float end, float duration, Transform fadingObject, System.Action<bool> callback)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Sinerp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Sinerp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
			callback(true);
		}

		public IEnumerator EaseOutAsinc(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Sinerp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Sinerp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		//Ease in out
		public void EaseInOut(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Hermite(alpha, end, t));
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Hermite(alpha, end, t));
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		public IEnumerator EaseInOutAsinc(float end, float duration, Transform fadingObject, System.Action<bool> callback)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Hermite(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Hermite(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
			callback(true);
		}

		public IEnumerator EaseInOutAsinc(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Hermite(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Hermite(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		//Ease Boing
		public void Boing(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Berp(alpha, end, t));
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Berp(alpha, end, t));
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		public IEnumerator BoingAsinc(float end, float duration, Transform fadingObject, System.Action<bool> callback)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Berp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Berp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
			callback(true);
		}

		public IEnumerator BoingAsinc(float end, float duration, Transform fadingObject)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Berp(alpha, end, t));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Berp(alpha, end, t));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		//Ease Custom (AnimationCurve)
		public void Custom(float end, float duration, Transform fadingObject, AnimationCurve curve)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Lerp(alpha, end, curve.Evaluate(t)));
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Lerp(alpha, end, curve.Evaluate(t)));
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}

		public IEnumerator CustomAsinc(float end, float duration, Transform fadingObject, AnimationCurve curve, System.Action<bool> callback)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Lerp(alpha, end, curve.Evaluate(t)));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Lerp(alpha, end, curve.Evaluate(t)));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
			callback(true);
		}

		public IEnumerator CustomAsinc(float end, float duration, Transform fadingObject, AnimationCurve curve)
		{
			Image image = fadingObject.GetComponent<Image>();

			if (image)
			{
				float alpha = image.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					image.color = new Color(image.color.r, image.color.g, image.color.b, Mathfx.Lerp(alpha, end, curve.Evaluate(t)));
					yield return null;
				}
				image.color = new Color(image.color.r, image.color.g, image.color.b, end);
			}
			else
			{

				Text text = fadingObject.GetComponent<Text>();

				float alpha = text.color.a;
				for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, Mathfx.Lerp(alpha, end, curve.Evaluate(t)));
					yield return null;
				}
				text.color = new Color(text.color.r, text.color.g, text.color.b, end);
			}
		}


		/////////////////////////////////////
		public void Fade(float end, float duration, Transform fadingObject, AnimationCurve curve)
		{
			Custom(end, duration, fadingObject, curve);
		}

		public void Fade(float end, float duration, Transform fadingObject, Fading.EaseType easetype = Fading.EaseType.Linear)
		{
			switch (easetype)
			{
				case Fading.EaseType.Linear:
					Fading.Instance.Linear(end, duration, fadingObject);
					break;
				case Fading.EaseType.EaseIn:
					Fading.Instance.EaseIn(end, duration, fadingObject);
					break;
				case Fading.EaseType.EaseOut:
					Fading.Instance.EaseOut(end, duration, fadingObject);
					break;
				case Fading.EaseType.EaseInOut:
					Fading.Instance.EaseInOut(end, duration, fadingObject);
					break;
				case Fading.EaseType.Boing:
					Fading.Instance.Boing(end, duration, fadingObject);
					break;
			}
		}

		public void FadeAsinc(float end, float duration, Transform fadingObject, AnimationCurve curve)
		{
			StartCoroutine(CustomAsinc(end, duration, fadingObject, curve));
		}

		public void FadeAsinc(float end, float duration, Transform fadingObject, Fading.EaseType easetype = Fading.EaseType.Linear)
		{
			switch (easetype)
			{
				case Fading.EaseType.Linear:
					StartCoroutine(Fading.Instance.LinearAsinc(end, duration, fadingObject));
					break;
				case Fading.EaseType.EaseIn:
					StartCoroutine(Fading.Instance.EaseInAsinc(end, duration, fadingObject));
					break;
				case Fading.EaseType.EaseOut:
					StartCoroutine(Fading.Instance.EaseOutAsinc(end, duration, fadingObject));
					break;
				case Fading.EaseType.EaseInOut:
					StartCoroutine(Fading.Instance.EaseInOutAsinc(end, duration, fadingObject));
					break;
				case Fading.EaseType.Boing:
					StartCoroutine(Fading.Instance.BoingAsinc(end, duration, fadingObject));
					break;
			}
		}

		public void FadeAsinc(float end, float duration, Transform fadingObject, AnimationCurve curve, System.Action<bool> callback)
		{
			StartCoroutine(CustomAsinc(end, duration, fadingObject, curve, (bool callback2) =>
			{
				if (callback2)
				{
					callback(true);
				}
			}));
		}

		public void FadeAsinc(float end, float duration, Transform fadingObject, System.Action<bool> callback, Fading.EaseType easetype = Fading.EaseType.Linear)
		{
			switch (easetype)
			{
				case Fading.EaseType.Linear:
					StartCoroutine(Fading.Instance.LinearAsinc(end, duration, fadingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Fading.EaseType.EaseIn:
					StartCoroutine(Fading.Instance.EaseInAsinc(end, duration, fadingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Fading.EaseType.EaseOut:
					StartCoroutine(Fading.Instance.EaseOutAsinc(end, duration, fadingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Fading.EaseType.EaseInOut:
					StartCoroutine(Fading.Instance.EaseInOutAsinc(end, duration, fadingObject, (bool callback2) =>
					{
						if (callback2)
						{
							callback(true);
						}
					}));
					break;
				case Fading.EaseType.Boing:
					StartCoroutine(Fading.Instance.BoingAsinc(end, duration, fadingObject, (bool callback2) =>
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