using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// By: http://answers.unity3d.com/questions/1001509/how-to-correctly-load-all-assets-using-resourceslo.html
/// </summary>
public class LoadAllTest : MonoBehaviour
{
    private void Awake()
    {
        // Method #1: Incorrect casting results in InvalidCastException. ==============================================================
        try
        {
            Debug.Log("Loading with Method #1...");
            GameObject[] loadedObjects = (GameObject[])Resources.LoadAll("GameObjects");

            foreach (var go in loadedObjects)
            {
                Debug.Log(go.name);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Method #1 failed with the following exception: ");
            Debug.Log(e);
        }

        // Method #2: Incorrect casting results in array of null objects. ====================================
        try
        {
            Debug.Log("Loading with Method #2...");
            GameObject[] loadedObjects = Resources.LoadAll("GameObjects") as GameObject[];

            foreach (var go in loadedObjects)
            {
                Debug.Log(go.name);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Method #2 failed with the following exception: ");
            Debug.Log(e);
        }

        // Method #3: Incorrect casting results in array of null objects. ====================================
        try
        {
            Debug.Log("Loading with Method #3...");
            GameObject[] loadedObjects = Resources.LoadAll("GameObjects", typeof(GameObject)) as GameObject[];

            foreach (var go in loadedObjects)
            {
                Debug.Log(go.name);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Method #3 failed with the following exception: ");
            Debug.Log(e);
        }

        // Method #4: Incorrect casting results in InvalidCastException. ====================================
        try
        {
            Debug.Log("Loading with Method #4...");
            GameObject[] loadedObjects = (GameObject[])Resources.LoadAll("GameObjects", typeof(GameObject));

            foreach (var go in loadedObjects)
            {
                Debug.Log(go.name);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Method #4 failed with the following exception: ");
            Debug.Log(e);
        }

        // Method #5: DOUBLE KILL! Please don't ever do this. I fear the world may implode. ====================================
        try
        {
            Debug.Log("Loading with Method #5...");
            GameObject[] loadedObjects = (GameObject[])Resources.LoadAll("GameObjects", typeof(GameObject)) as GameObject[];

            foreach (var go in loadedObjects)
            {
                Debug.Log(go.name);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Method #5 failed with the following exception: ");
            Debug.Log(e);
        }

        // Proper Method: Casting correctly for expected type of loaded objects results in a valid list of loaded objects. ============
        try
        {
            Debug.Log("Loading with Proper Method...");

            // This is the short hand version and requires that you include the "using System.Linq;" at the top of the file.
            var loadedObjects = Resources.LoadAll("GameObjects", typeof(GameObject)).Cast<GameObject>();
            foreach (var go in loadedObjects)
            {
                Debug.Log(go.name);
            }

            // Casts each individual UnityEngine.Object into UnityEngine.GameObject and adds it to an actual list of GameObject type. 
            // This one works too but is the long version.

            //var loadedObjects = Resources.LoadAll("GameObjects");
            //List<GameObject> gameObjects = new List<GameObject>();
            //foreach (var loadedObject in loadedObjects)
            //{
            //    gameObjects.Add(loadedObject as GameObject);
            //}

            //foreach (GameObject go in gameObjects)
            //{
            //    Debug.Log(go.name);
            //}
        }
        catch (Exception e)
        {
            Debug.Log("Proper Method failed with the following exception: ");
            Debug.Log(e);
        }

        // ================================================== THOUGHTS =====================================================

        // I would never use this variation because it makes a MASSIVE assumption that all assets inside of the specified folder 
        // are actually GameObjects. If someone down the road places a material (or any non-prefab type) in this folder it will 
        // now cause it to fail loading, because those aren't GameObjects, and it will not be apparent at all.
        Resources.LoadAll("GameObjects");

        // This variation is preferred as specifying "typeof(YourType)" ensures only assets of type "YourType" get loaded.
        // This is essential if you are casting the loaded assets into a specified type.
        Resources.LoadAll("GameObjects", typeof(GameObject));
    }
}