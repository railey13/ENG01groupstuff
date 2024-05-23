using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Text spawnText;
    [SerializeField] private int toSpawn = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        this.spawnText.text = "Amount of Objects in Scene:   " + this.toSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSphereButtonClicked()
    {
        int NUM_SPAWNS = 5;
        Parameters param = new Parameters();

        param.PutExtra(SphereSpawner.NUM_SPAWN_KEYS, NUM_SPAWNS);
        
        
            EventBroadcaster.Instance.PostEvent(EventNames.SpawnSystem.ON_SPHERE_SPAWN, param);
            this.toSpawn += NUM_SPAWNS;
            this.spawnText.text = "Amount of Objects in Scene: " + this.toSpawn;
        
    }
    public void OnCubeButtonClicked()
    {
        int NUM_SPAWNS = 5;
        Parameters param = new Parameters();

        param.PutExtra(CubeSpawner.NUM_SPAWN_KEYS, NUM_SPAWNS);
        
        
        EventBroadcaster.Instance.PostEvent(EventNames.SpawnSystem.ON_CUBE_SPAWN_BUTTON_CLICKED, param);
        this.toSpawn += NUM_SPAWNS;
        this.spawnText.text = "Amount of Objects in Scene: " + this.toSpawn;
        
    }
    public void OnDespawnButtonClicked()
    {
      
        EventBroadcaster.Instance.PostEvent(EventNames.SpawnSystem.ON_DESPAWN_BUTTON_CLICKED);
        this.toSpawn = 0;
        this.spawnText.text = "Amount of Objects in Scene: " + this.toSpawn;
        
    }
}
