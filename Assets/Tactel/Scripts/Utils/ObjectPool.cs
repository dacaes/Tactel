using UnityEngine;
using System.Collections.Generic;

namespace Tactel
{
    /// <summary>
    /// Clase de la pool. Sealed para evitar sub clases. Singleton para evitar otras instancias.
    /// By: https://unitygem.wordpress.com/object-pooling/
    /// </summary>
    public sealed class ObjectPool
    {
        private Dictionary<string, Queue<GameObject>> container = new Dictionary<string, Queue<GameObject>>();
        private Dictionary<string, GameObject> prefabContainer = new Dictionary<string, GameObject>();

        private static ObjectPool instance = null;
        public static ObjectPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectPool();
                }
                return instance;
            }
        }

        public void Reset()
        {
            instance = null;
        }
        private ObjectPool() { }

        public bool AddToPool(GameObject prefab, int count, Transform parent = null)
        {
            if (prefab == null || count <= 0)
            {
                return false;
            }

            string name = prefab.name;

            if (this.prefabContainer.ContainsKey(name) == false)
            {
                this.prefabContainer.Add(name, prefab);
            }

            if (this.prefabContainer[name] == null)
            {
                this.prefabContainer[name] = prefab;
            }

            for (int i = 0; i < count; i++)
            {
                GameObject obj = PopFromPool(name, true);
                PushToPool(ref obj, true, parent);
            }

            return true;
        }

        public GameObject PopFromPool(GameObject prefab, bool forceInstantiate = false, bool instantiateIfNone = false, Transform container = null)
        {
            if (prefab == null)
            {
                return null;
            }

            return PopFromPool(prefab.name, forceInstantiate, instantiateIfNone, container);
        }

        //Los bools que fuerzan instanciaciones no sirven si previamente no se ha metido ningún gameobject en la prefabContainer mediante AddToPool
        public GameObject PopFromPool(string prefabName, bool forceInstantiate = false, bool instantiateIfNone = false, Transform container = null)
        {
            if (prefabName == null || this.prefabContainer.ContainsKey(prefabName) == false)
            {
                return null;
            }

            if (forceInstantiate == true)
            {
                return CreateObject(prefabName, container);
            }

            GameObject obj = null;
            Queue<GameObject> queue = FindInContainer(prefabName);

            if (queue.Count > 0)
            {
                obj = queue.Dequeue();
                obj.transform.parent = container;
                obj.SetActive(true);
            }

            if (obj == null && instantiateIfNone == true)
            {
                return CreateObject(prefabName, container);
            }

            return obj;
        }

        public void PushToPool(ref GameObject obj, bool retainObject = true, Transform parent = null)
        {
            if (obj == null)
            {
                return;
            }

            if (retainObject == false)
            {
                Object.Destroy(obj);
                obj = null;
                return;
            }

            if (parent != null)
            {
                obj.transform.parent = parent;
            }

            Queue<GameObject> queue = FindInContainer(obj.name);
            queue.Enqueue(obj);
            obj.SetActive(false);
            obj = null;
        }

        public void ReleaseItems(GameObject prefab, bool destroyObject = false)
        {
            if (prefab == null)
            {
                return;
            }

            Queue<GameObject> queue = FindInContainer(prefab.name);
            if (queue == null)
            {
                return;
            }

            while (queue.Count > 0)
            {
                GameObject obj = queue.Dequeue();
                if (destroyObject == true)
                {
                    Object.Destroy(obj);
                }
            }
        }

        public void ReleasePool()
        {
            foreach (var kvp in this.container)
            {
                Queue<GameObject> queue = kvp.Value;
                while (queue.Count > 0)
                {
                    GameObject obj = queue.Dequeue();
                    Object.Destroy(obj);
                }
            }
            this.container = null;
            this.container = new Dictionary<string, Queue<GameObject>>();
            this.prefabContainer.Clear();
            this.prefabContainer = null;
            this.prefabContainer = new Dictionary<string, GameObject>();
        }

        private Queue<GameObject> FindInContainer(string prefabName)
        {
            if (this.container.ContainsKey(prefabName) == false)
            {
                this.container.Add(prefabName, new Queue<GameObject>());
            }
            return this.container[prefabName];
        }

        private GameObject CreateObject(string prefabName, Transform container)
        {
            GameObject obj = (GameObject)Object.Instantiate(prefabContainer[prefabName]);
            obj.name = prefabName;
            obj.transform.parent = container;
            return obj;
        }
    }
}