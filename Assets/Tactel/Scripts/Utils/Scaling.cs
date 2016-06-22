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
    /// Simple singleton class to Scale from one point to another with interpolations
    /// </summary>
    public sealed class Scaling : MonoBehaviour    //Monobehaviour because of coroutines
    {
        public enum EaseType
        {
            Linear,
            EaseIn,
            EaseOut,
            EaseInOut,
            Boing
        }

        private static Scaling instance = null;
        public static Scaling Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scaling();
                }
                return instance;
            }
        }

        public void Reset()
        {
            instance = null;
        }
        private Scaling() { }

        #region functions

        //Linear
        public void Linear(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Lerp(start, end, t);
            }
        }

        public IEnumerator LinearAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Lerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator LinearAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Lerp(start, end, t);
                yield return null;
            }
        }

        public void Linear(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Lerp(start, end, t);
            }
        }

        public IEnumerator LinearAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Lerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator LinearAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Lerp(start, end, t);
                yield return null;
            }
        }

        //Ease in
        public void EaseIn(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Coserp(start, end, t);
            }
        }

        public IEnumerator EaseInAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Coserp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Coserp(start, end, t);
                yield return null;
            }
        }

        public void EaseIn(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Coserp(start, end, t);
            }
        }

        public IEnumerator EaseInAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Coserp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Coserp(start, end, t);
                yield return null;
            }
        }

        //Ease out
        public void EaseOut(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Sinerp(start, end, t);
            }
        }

        public IEnumerator EaseOutAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseOutAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
        }

        public void EaseOut(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Sinerp(start, end, t);
            }
        }

        public IEnumerator EaseOutAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseOutAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
        }

        //Ease in out
        public void EaseInOut(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Hermite(start, end, t);
            }
        }

        public IEnumerator EaseInOutAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Hermite(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInOutAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Hermite(start, end, t);
                yield return null;
            }
        }

        public void EaseInOut(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Hermite(start, end, t);
            }
        }

        public IEnumerator EaseInOutAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Hermite(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInOutAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Hermite(start, end, t);
                yield return null;
            }
        }

        //Ease Boing
        public void Boing(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Berp(start, end, t);
            }
        }

        public IEnumerator BoingAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Berp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator BoingAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Berp(start, end, t);
                yield return null;
            }
        }

        public void Boing(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Berp(start, end, t);
            }
        }

        public IEnumerator BoingAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Berp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator BoingAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                scalingObject.localScale = Mathfx.Berp(start, end, t);
                yield return null;
            }
        }

        /////////////////////////////////////

        public void Scale(Vector2 start, Vector2 end, float duration, Transform scalingObject, Scaling.EaseType easetype = Scaling.EaseType.Linear)
        {
            switch (easetype)
            {
                case Scaling.EaseType.Linear:
                    Scaling.Instance.Linear(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.EaseIn:
                    Scaling.Instance.EaseIn(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.EaseOut:
                    Scaling.Instance.EaseOut(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.EaseInOut:
                    Scaling.Instance.EaseInOut(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.Boing:
                    Scaling.Instance.Boing(start, end, duration, scalingObject);
                    break;
            }
        }

        public void Scale(Vector3 start, Vector3 end, float duration, Transform scalingObject, Scaling.EaseType easetype = Scaling.EaseType.Linear)
        {
            switch (easetype)
            {
                case Scaling.EaseType.Linear:
                    Scaling.Instance.Linear(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.EaseIn:
                    Scaling.Instance.EaseIn(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.EaseOut:
                    Scaling.Instance.EaseOut(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.EaseInOut:
                    Scaling.Instance.EaseInOut(start, end, duration, scalingObject);
                    break;
                case Scaling.EaseType.Boing:
                    Scaling.Instance.Boing(start, end, duration, scalingObject);
                    break;
            }
        }

        public void ScaleAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, Scaling.EaseType easetype = Scaling.EaseType.Linear)
        {
            switch (easetype)
            {
                case Scaling.EaseType.Linear:
                    StartCoroutine(Scaling.Instance.LinearAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.EaseIn:
                    StartCoroutine(Scaling.Instance.EaseInAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.EaseOut:
                    StartCoroutine(Scaling.Instance.EaseOutAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.EaseInOut:
                    StartCoroutine(Scaling.Instance.EaseInOutAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.Boing:
                    StartCoroutine(Scaling.Instance.BoingAsinc(start, end, duration, scalingObject));
                    break;
            }
        }

        public void ScaleAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, Scaling.EaseType easetype = Scaling.EaseType.Linear)
        {
            switch (easetype)
            {
                case Scaling.EaseType.Linear:
                    StartCoroutine(Scaling.Instance.LinearAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.EaseIn:
                    StartCoroutine(Scaling.Instance.EaseInAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.EaseOut:
                    StartCoroutine(Scaling.Instance.EaseOutAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.EaseInOut:
                    StartCoroutine(Scaling.Instance.EaseInOutAsinc(start, end, duration, scalingObject));
                    break;
                case Scaling.EaseType.Boing:
                    StartCoroutine(Scaling.Instance.BoingAsinc(start, end, duration, scalingObject));
                    break;
            }
        }

        public void ScaleAsinc(Vector2 start, Vector2 end, float duration, Transform scalingObject, System.Action<bool> callback, Scaling.EaseType easetype = Scaling.EaseType.Linear)
        {
            switch (easetype)
            {
                case Scaling.EaseType.Linear:
                    StartCoroutine(Scaling.Instance.LinearAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.EaseIn:
                    StartCoroutine(Scaling.Instance.EaseInAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.EaseOut:
                    StartCoroutine(Scaling.Instance.EaseOutAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.EaseInOut:
                    StartCoroutine(Scaling.Instance.EaseInOutAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.Boing:
                    StartCoroutine(Scaling.Instance.BoingAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
            }
        }

        public void ScaleAsinc(Vector3 start, Vector3 end, float duration, Transform scalingObject, System.Action<bool> callback, Scaling.EaseType easetype = Scaling.EaseType.Linear)
        {
            switch (easetype)
            {
                case Scaling.EaseType.Linear:
                    StartCoroutine(Scaling.Instance.LinearAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.EaseIn:
                    StartCoroutine(Scaling.Instance.EaseInAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.EaseOut:
                    StartCoroutine(Scaling.Instance.EaseOutAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.EaseInOut:
                    StartCoroutine(Scaling.Instance.EaseInOutAsinc(start, end, duration, scalingObject, (bool callback2) =>
                    {
                        if (callback2)
                        {
                            callback(true);
                        }
                    }));
                    break;
                case Scaling.EaseType.Boing:
                    StartCoroutine(Scaling.Instance.BoingAsinc(start, end, duration, scalingObject, (bool callback2) =>
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