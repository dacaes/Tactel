#region LICENSE
//==============================================================================//
//  Copyright (c) 2016 Daniel Castaño Estrella                                  //
//  This projected is licensed under the terms of the MIT license.              //
//  See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT //
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
	private float barFullAnchorX;
	private Vector2 barEmptyAnchor;
	private float barAnchorY;
	private float width;
	private bool canIModify;

#if UNITY_EDITOR
	public bool grow;
	public bool decrease;
	public bool animate;
#endif
	#endregion

	#region functions
	/// <summary>
	/// Grow the percentage given.
	/// </summary>
	/// <param name="percentage">quantity</param>
	public virtual void Grow(float percentage = percentage)
	{
		float newAnchorX = mask.rectTransform.anchoredPosition.x + width * 1 / percentage;
		if (newAnchorX <= barFullAnchorX)
			mask.rectTransform.anchoredPosition = new Vector2(newAnchorX, barAnchorY);
	}

	/// <summary>
	/// Decrease the percentage given.
	/// </summary>
	/// <param name="percentage">quantity</param>
	public virtual void Decrease(float percentage = percentage)
	{
		float newAnchorX = mask.rectTransform.anchoredPosition.x - width * 1 / percentage;
		if (newAnchorX >= barEmptyAnchor.x)
			mask.rectTransform.anchoredPosition = new Vector2(newAnchorX, barAnchorY);
	}

	/// <summary>
	/// Grow continuously until reach the percentage given and it takes the given duration.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator GrowAnimated(float percentage = percentage, float duration = duration)
	{
		canIModify = false;
		float baseX = mask.rectTransform.anchoredPosition.x;
		float sum = width * 1 / percentage;
		if (baseX + sum <= barFullAnchorX)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, sum, t), barAnchorY);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + sum, barAnchorY);
		}
		canIModify = true;
	}

	/// <summary>
	/// Grow continuously until reach the percentage given and it takes the given duration. Has a callback.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <param name="callback">callback</param>
	/// <returns></returns>
	public IEnumerator GrowAnimated(System.Action<bool> callback, float percentage = percentage, float duration = duration)
	{
		canIModify = false;
		float baseX = mask.rectTransform.anchoredPosition.x;
		float sum = width * 1 / percentage;
		if (baseX + sum <= barFullAnchorX)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX + Mathf.Lerp(0, sum, t), barAnchorY);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX + sum, barAnchorY);
		}
		canIModify = true;
		callback(true);
	}

	/// <summary>
	/// Decrease continuously until reach the percentage given and it takes the given duration.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <returns></returns>
	public IEnumerator DecreaseAnimated(float percentage = percentage, float duration = duration)
	{
		canIModify = false;
		float baseX = mask.rectTransform.anchoredPosition.x;
		float sum = width * 1 / percentage;
		if (baseX + sum >= barEmptyAnchor.x)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX - Mathf.Lerp(0, sum, t), barAnchorY);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX - sum, barAnchorY);
		}
		canIModify = true;
	}

	/// <summary>
	/// Decrease continuously until reach the percentage given and it takes the given duration. Has a callback.
	/// </summary>
	/// <param name="percentage">quantity</param>
	/// <param name="duration">time</param>
	/// <param name="callback">callback</param>
	/// <returns></returns>
	public IEnumerator DecreaseAnimated(System.Action<bool> callback, float percentage = percentage, float duration = duration)
	{
		canIModify = false;
		float baseX = mask.rectTransform.anchoredPosition.x;
		float sum = width * 1 / percentage;
		if (baseX + sum >= barEmptyAnchor.x)
		{
			for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
			{
				mask.rectTransform.anchoredPosition = new Vector2(baseX - Mathf.Lerp(0, sum, t), barAnchorY);
				yield return null;
			}
			mask.rectTransform.anchoredPosition = new Vector2(baseX - sum, barAnchorY);
		}
		canIModify = true;
		callback(true);
	}

	/// <summary>
	/// Get important data and empties the bar.
	/// </summary>
	protected virtual void Awake()
	{
		mask = transform.GetChild(0).GetComponent<Image>();
		bar = transform.GetChild(1).GetComponent<Image>();

		barFullAnchorX = mask.rectTransform.anchoredPosition.x;
		barAnchorY = mask.rectTransform.anchoredPosition.y;
		width = mask.rectTransform.sizeDelta.x;

		//move the mask its size to the left
		mask.rectTransform.anchoredPosition = new Vector2(barFullAnchorX - width, barAnchorY);

		barEmptyAnchor = mask.rectTransform.anchoredPosition;
		canIModify = true;
	}

	/// <summary>
	/// Empty the bar
	/// </summary>
	public void Empty()
	{
		mask.rectTransform.anchoredPosition = barEmptyAnchor;
	}

#if UNITY_EDITOR
	/// <summary>
	/// Only in Unity Editor, not on Build.
	/// </summary>
	protected void Update()
	{
		if (grow)
		{
			grow = false;
			if (animate)
				StartCoroutine(GrowAnimated());
			else
				Grow();
		}
		else if (decrease)
		{
			decrease = false;
			if (animate)
				StartCoroutine(DecreaseAnimated());
			else
				Decrease();
		}
	}
#endif
	#endregion
}
