#region LICENSE
//==============================================================================//
//	Copyright (c) 2016 Daniel Castaño Estrella									//
//	This projected is licensed under the terms of the MIT license.				//
//	See accompanying file LICENSE or copy at http://opensource.org/licenses/MIT	//
//==============================================================================//
#endregion

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple class to show a score with sprites of numbers.
/// Locate it into a Canvas.
/// Tested on Unity 5.3.4f1.
/// </summary>
public class ScoreUI : MonoBehaviour
{
    #region vars
#if UNITY_EDITOR
    /// <summary>
    /// Only in Unity Editor, not on Build.
    /// </summary>
    public int currentScore;    //write a score
    public bool refresh;    //press to refresh the digits on screen
    public bool hide;   //press to hide all digits
#endif

    [SerializeField]
    protected Sprite[] numbers; //put the sprites numbers here. 0 to 9.
    protected Image[] digits;
    #endregion

    #region functions
    /// <summary>
    /// Gets the digits to write the score.
    /// </summary>
    protected virtual void Awake()
    {
        //The order needs to be units, tens, hundreds...
        digits = new Image[transform.childCount];
        foreach(Transform i in transform)
        {
            digits[i.GetSiblingIndex()] = i.GetComponent<Image>();
        }
    }

    /// <summary>
    /// Calculates and show the score.
    /// </summary>
    /// <param name="score"> The score to set.</param>
    public virtual void Score(int score)
    {
        int[] n = NumbersIn(score);

        //Si me paso del num máximo
        if(n.Length > digits.Length)
        {
            n = new int[digits.Length];
            for(int i = 0; i < n.Length; i++)
            {
                n[i] = 9;
            }
        }
        else if(n.Length == 0)
        {
            n = new int[1];
            n[0] = 0;
        }
        for(int i = 0, j = n.Length-1; i < digits.Length; i++,j--)
        {
            if (j > -1)
            {
                digits[i].sprite = numbers[n[j]];
                digits[i].gameObject.SetActive(true);
            }
            else
                digits[i].gameObject.SetActive(false);
            
        }
    }

    /// <summary>
    /// Hides all digits of the score.
    /// </summary>
    public virtual void HideScore()
    {
        for (int i = 0; i < digits.Length; i++)
        {
            digits[i].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Break the number.
    /// </summary>
    /// <param name="number"></param>
    /// <returns>Return array of units (int 0-9).</returns>
    protected int[] NumbersIn(int value)
    {
        var numbers = new Stack<int>();

        for (; value > 0; value /= 10)
            numbers.Push(value % 10);

        return numbers.ToArray();
    }

#if UNITY_EDITOR
    /// <summary>
    /// Only in Unity Editor, not on Build.
    /// </summary>
    protected void Update()
    {
        if (refresh)
        {
            refresh = false;
            Score(currentScore);
        }
        if(hide)
        {
            hide = false;
            HideScore();
        }
    }
#endif
    #endregion
}
