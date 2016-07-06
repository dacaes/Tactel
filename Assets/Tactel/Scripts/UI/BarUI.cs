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

/// <summary>
/// Simple class to have a life/power/whatever bar.
/// Locate it into a Canvas.
/// Tested on Unity 5.3.4f1.
/// </summary>
public class BarUI : MonoBehaviour
{
	#region vars
	private const float percentage = 10f;
	private const float duration = 0.5f;
	private Image mask;
	private Image bar;
	private Vector2 barFullAnchor;
	private Vector2 barEmptyAnchor;
	private float width;
	private float theoricCurrentX;

	public bool modifying { get; private set;}

#if UNITY_EDITOR
	public bool grow;
	public bool decrease;
	public bool animate;
#endif
	#endregion

	#region functions
	protected virtual void Change(float percentage)
	{
		float newAnchorX = mask.rectTransform.anchoredPosition.x + width * 1 / percentage;
		if (newAnchorX <= barFullAnchor.x && newAnchorX >= barEmptyAnchor.x)
			mask.rectTransform.anchoredPosition = new Vector2(newAnchorX, barFullAnchor.y);
	}

	/// <summary>
	/// Grow the percentage given.
	/// </summary>
	/// <param name="percentage">quantity</param>
	public virtual void Grow(float percentage = percentage)
	{
		Change(percentage);
	}

	/// <summary>
	/// Decrease the percentage given.
	/// </summary>
	/// <param name="percentage">quantity</param>
	public virtual void Decrease(float percentage = percentage)
	{
		Change(-percentage);
	}

	/// <summary>
	/// Changes continuously until reach the percentage given and it takes the given duration. Has a callback.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator ChangeAnimated(float percentage = percentage, float duration = duration)
	{
		modifying = true;
		float baseX = mask.rectTransform.anchoredPosition.x;
		float sum = width / percentage;
		sum += (theoricCurrentX - baseX);
		if (baseX + sum <= barFullAnchor.x && baseX + sum >= barEmptyAnchor.x)
		{
			theoricCurrentX = baseX + sum;
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, sum, t), barFullAnchor.y);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + sum, barFullAnchor.y);
		}
		modifying = false;
	}

	/// <summary>
	/// Changes continuously until reach the percentage given and it takes the given duration. Has a callback.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <param name="callback">callback</param>
	/// <returns></returns>
	public IEnumerator ChangeAnimated(System.Action<bool> callback, float percentage = percentage, float duration = duration)
	{
		modifying = true;
		float baseX = mask.rectTransform.anchoredPosition.x;
		float sum = width / percentage;
		sum += (theoricCurrentX - baseX);
		if (baseX + sum <= barFullAnchor.x && baseX + sum >= barEmptyAnchor.x)
		{
			theoricCurrentX = baseX + sum;
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, sum, t), barFullAnchor.y);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + sum, barFullAnchor.y);
		}
		modifying = false;
		callback(true);
	}

	/// <summary>
	/// Grow continuously until reach the percentage given and it takes the given duration.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public void GrowAnimated(float percentage = percentage, float duration = duration)
	{
		StartCoroutine(ChangeAnimated(percentage, duration));
	}

	/// <summary>
	/// Grow continuously until reach the percentage given and it takes the given duration. Has a callback.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <param name="callback">callback</param>
	/// <returns></returns>
	public void GrowAnimated(System.Action<bool> callback, float percentage = percentage, float duration = duration)
	{
		StartCoroutine(ChangeAnimated((bool callback2) =>
		{
			if(callback2)
			{
				callback(true);
			}
		}, percentage, duration));
	}

	/// <summary>
	/// Decrease continuously until reach the percentage given and it takes the given duration.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public void DecreaseAnimated(float percentage = percentage, float duration = duration)
	{
		StartCoroutine(ChangeAnimated(-percentage, duration));
	}

	/// <summary>
	/// Decrease continuously until reach the percentage given and it takes the given duration. Has a callback.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <param name="callback">callback</param>
	/// <returns></returns>
	public void DecreaseAnimated(System.Action<bool> callback, float percentage = percentage, float duration = duration)
	{
		StartCoroutine(ChangeAnimated((bool callback2) =>
		{
			if (callback2)
			{
				callback(true);
			}
		}, -percentage, duration));
	}

	/// <summary>
	/// Get important data and empties the bar.
	/// </summary>
	protected virtual void Awake()
	{
		mask = transform.GetChild(0).GetComponent<Image>();
		bar = transform.GetChild(1).GetComponent<Image>();

		barFullAnchor = mask.rectTransform.anchoredPosition;
		width = mask.rectTransform.sizeDelta.x;

		//move the mask its size to the left
		mask.rectTransform.anchoredPosition = new Vector2(barFullAnchor.x - width, barFullAnchor.y);

		barEmptyAnchor = mask.rectTransform.anchoredPosition;
		theoricCurrentX = barEmptyAnchor.x;
		modifying = false;
	}

	/// <summary>
	/// Fulfill the bar.
	/// </summary>
	public void Fulfill()
	{
		mask.rectTransform.anchoredPosition = barFullAnchor;
	}

	/// <summary>
	/// Fulfill the bar in a time.
	/// </summary>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator FulfillAnimated(float duration = duration)
	{
		modifying = true;
		float baseX = mask.rectTransform.anchoredPosition.x;
		if (baseX != barFullAnchor.x)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, barFullAnchor.x, t), barFullAnchor.y);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + barFullAnchor.x, barFullAnchor.y);
		}
		modifying = false;
	}

	/// <summary>
	/// Fulfill the bar in a time with a callback.
	/// </summary>
	/// <param name="callback">callback</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator FulfillAnimated(System.Action<bool> callback, float duration = duration)
	{
		modifying = true;
		float baseX = mask.rectTransform.anchoredPosition.x;
		if (baseX != barFullAnchor.x)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, barFullAnchor.x, t), barFullAnchor.y);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + barFullAnchor.x, barFullAnchor.y);
		}
		modifying = false;
		callback(true);
	}

	/// <summary>
	/// Empty the bar.
	/// </summary>
	public void Empty()
	{
		mask.rectTransform.anchoredPosition = barEmptyAnchor;
	}

	/// <summary>
	/// Empties the bar in a time.
	/// </summary>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator EmptyAnimated(float duration = duration)
	{
		modifying = true;
		float baseX = mask.rectTransform.anchoredPosition.x;
		if (baseX != barEmptyAnchor.x)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, barEmptyAnchor.x, t), barFullAnchor.y);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + barEmptyAnchor.x, barFullAnchor.y);
		}
		modifying = false;
	}

	/// <summary>
	/// Empties the bar in a time with a callback.
	/// </summary>
	/// <param name="callback">callback</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator EmptyAnimated(System.Action<bool> callback, float duration = duration)
	{
		modifying = true;
		float baseX = mask.rectTransform.anchoredPosition.x;
		if (baseX != barEmptyAnchor.x)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, barEmptyAnchor.x, t), barFullAnchor.y);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + barEmptyAnchor.x, barFullAnchor.y);
		}
		modifying = false;
		callback(true);
	}

#if UNITY_EDITOR
	/// <summary>
	/// Only in Unity Editor, not on Build.
	/// </summary>
	protected void Update()
	{
		/*
		if(Input.GetKeyDown("right"))
		{
			if (animate)
				GrowAnimated();
			else
				Grow();
		}
		if (Input.GetKeyDown("left"))
		{
			if (animate)
				DecreaseAnimated();
			else
				Decrease();
		}
		if (Input.GetKeyDown("up"))
		{
			if (animate)
				StartCoroutine(FulfillAnimated());
			else
				Fulfill();
		}
		if (Input.GetKeyDown("down"))
		{
			if (animate)
				StartCoroutine(EmptyAnimated());
			else
				Empty();
		}
		*/

		if (grow)
		{
			grow = false;
			if (animate)
				GrowAnimated();
			else
				Grow();
		}
		else if (decrease)
		{
			decrease = false;
			if (animate)
				DecreaseAnimated();
			else
				Decrease();
		}
	}
#endif
	#endregion
}
