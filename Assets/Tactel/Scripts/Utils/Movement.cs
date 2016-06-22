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
            Boing
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
        public void Linear(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Lerp(start, end, t);
            }
        }

        public IEnumerator LinearAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Lerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator LinearAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Lerp(start, end, t);
                yield return null;
            }
        }

        public void Linear(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Lerp(start, end, t);
            }
        }

        public IEnumerator LinearAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Lerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator LinearAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Lerp(start, end, t);
                yield return null;
            }
        }

        //Ease in
        public void EaseIn(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Coserp(start, end, t);
            }
        }

        public IEnumerator EaseInAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Coserp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Coserp(start, end, t);
                yield return null;
            }
        }

        public void EaseIn(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Coserp(start, end, t);
            }
        }

        public IEnumerator EaseInAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Coserp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Coserp(start, end, t);
                yield return null;
            }
        }

        //Ease out
        public void EaseOut(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Sinerp(start, end, t);
            }
        }

        public IEnumerator EaseOutAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseOutAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
        }

        public void EaseOut(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Sinerp(start, end, t);
            }
        }

        public IEnumerator EaseOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Sinerp(start, end, t);
                yield return null;
            }
        }

        //Ease in out
        public void EaseInOut(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Hermite(start, end, t);
            }
        }

        public IEnumerator EaseInOutAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Hermite(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInOutAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Hermite(start, end, t);
                yield return null;
            }
        }

        public void EaseInOut(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Hermite(start, end, t);
            }
        }

        public IEnumerator EaseInOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Hermite(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator EaseInOutAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Hermite(start, end, t);
                yield return null;
            }
        }

        //Ease Boing
        public void Boing(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Berp(start, end, t);
            }
        }

        public IEnumerator BoingAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Berp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator BoingAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Berp(start, end, t);
                yield return null;
            }
        }

        public void Boing(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Berp(start, end, t);
            }
        }

        public IEnumerator BoingAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject, System.Action<bool> callback)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Berp(start, end, t);
                yield return null;
            }
            callback(true);
        }

        public IEnumerator BoingAsinc(Vector3 start, Vector3 end, float duration, Transform movingObject)
        {
            for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / duration)
            {
                movingObject.position = Mathfx.Berp(start, end, t);
                yield return null;
            }
        }

        /////////////////////////////////////

        public void Move(Vector2 start, Vector2 end, float duration, Transform movingObject, Movement.EaseType easetype = Movement.EaseType.Linear)
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

        public void MoveAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, Movement.EaseType easetype = Movement.EaseType.Linear)
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

        public void MoveAsinc(Vector2 start, Vector2 end, float duration, Transform movingObject, System.Action<bool> callback, Movement.EaseType easetype = Movement.EaseType.Linear)
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