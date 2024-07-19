using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region singleton
    private static ObjectPooler instance;
    public static ObjectPooler Instance { get { return instance; } }
    #endregion
    [System.Serializable]
    public class Pool
    {
        public string tag;

        public Transform prefab;

        public int size;
    }

    [SerializeField] private List<Pool> pools = new List<Pool>();
    [SerializeField] private Dictionary<string, Queue<Transform>> objectPoolDictionary = new Dictionary<string, Queue<Transform>>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        foreach (Pool pool in pools)
        {
            Queue<Transform> queue = new Queue<Transform>();

            for (int i = 0; i < pool.size; i++)
            {
                Transform obj = Instantiate(pool.prefab);

                obj.gameObject.SetActive(false);

                obj.SetParent(transform);

                queue.Enqueue(obj);
            }
            objectPoolDictionary.Add(pool.tag, queue);
        }
    }
    public Transform SpawnObject(string tag, Vector3 position, Quaternion rotation)
    {
        if (!objectPoolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Don't have object with tag : " + tag);
            return null;
        }
        Transform obj;
        while (true)
        {
            obj = objectPoolDictionary[tag].Dequeue();

            objectPoolDictionary[tag].Enqueue(obj);

            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);

                obj.position = position;

                obj.rotation = rotation;

                break;
            }
        }
        return obj;
    }
}