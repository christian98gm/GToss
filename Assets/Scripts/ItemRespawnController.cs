using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnController : MonoBehaviour
{

    public bool respawnOnStart = false;
    public GameObject prefab;
    public List<Vector3> position;
    public List<Vector3> rotation;

    private List<GameObject> instances;

    // Start is called before the first frame update
    void Start()
    {
        instances = new List<GameObject>();
        if(respawnOnStart)
        {
            SpawnItems();
        }
    }

    public void RespawnItems()
    {
        foreach (var item in instances)
        {
            Destroy(item);
        }
        SpawnItems();
    }

    private void SpawnItems()
    {
        instances.Clear();
        for(int i = 0; i < position.Count; i++)
        {
            Vector3 r = rotation[i];
            instances.Add(Instantiate(prefab, position[i], Quaternion.Euler(r.x, r.y, r.z)));
        }
    }
}
