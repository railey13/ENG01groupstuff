using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    [SerializeField] private List<GameObject> CubeList;

    public const string NUM_SPAWN_KEYS = "NUM_SPAWN_KEYS";

    // Start is called before the first frame update
    void Start()
    {
        this.Cube.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.SpawnSystem.ON_CUBE_SPAWN_BUTTON_CLICKED, this.SpawnCubes);
        EventBroadcaster.Instance.AddObserver(EventNames.SpawnSystem.ON_DESPAWN_BUTTON_CLICKED, this.DespawnCubes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.SpawnSystem.ON_CUBE_SPAWN_BUTTON_CLICKED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SpawnSystem.ON_DESPAWN_BUTTON_CLICKED);
    }

    private void SpawnCubes(Parameters parameters)
    {
        int SpawnAmount = parameters.GetIntExtra(NUM_SPAWN_KEYS, 1);
        for (int i = 0; i < SpawnAmount; i++)
        {
            CubeList.Add(ObjectUtils.SpawnDefault(this.Cube, this.transform, this.transform.localPosition));
        }
        
    }

    private void DespawnCubes()
    {
        for(int i = 0; i < this.CubeList.Count; i++)
        {
            GameObject.Destroy(this.CubeList[i].gameObject);
        }
        this.CubeList.Clear();
    }

    
}
