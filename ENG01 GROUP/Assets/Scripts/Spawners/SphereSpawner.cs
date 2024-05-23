using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject templateObj;
    [SerializeField] private List<GameObject> objContainer;
    [SerializeField] private int spawnAmount = 20;

    public const string NUM_SPAWN_KEYS = "NUM_SPAWN_KEYS";

    // Start is called before the first frame update
    void Start()
    {
        this.templateObj.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.SpawnSystem.ON_SPHERE_SPAWN, this.spawnSphere);
        EventBroadcaster.Instance.AddObserver(EventNames.SpawnSystem.ON_SPHERE_DESPAWN, this.destroyAllSpheres);
        EventBroadcaster.Instance.AddObserver(EventNames.SpawnSystem.ON_DESPAWN_BUTTON_CLICKED, this.destroyAllSpheres);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.SpawnSystem.ON_SPHERE_SPAWN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SpawnSystem.ON_SPHERE_DESPAWN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.SpawnSystem.ON_DESPAWN_BUTTON_CLICKED);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnSphere(Parameters parameters)
    {
        this.spawnAmount = parameters.GetIntExtra(NUM_SPAWN_KEYS, 1);
        for (int i = 0; i < this.spawnAmount; i++)
        {
            //spawn little ones
            float offset = 0.01f;
            for (int j = 0; i < this.spawnAmount; i++)
            {
                UnityEngine.Vector3 localPos = this.templateObj.transform.localPosition;
                //spread out
                localPos.x += Random.Range(-offset, offset);
                localPos.y += Random.Range(-offset, offset);
                localPos.z += Random.Range(-offset, offset);

                GameObject newSphere = ObjectUtils.SpawnDefault(this.templateObj, this.transform, localPos);
                this.objContainer.Add(newSphere);
            }
        }
    }

    public void destroyAllSpheres()
    {
        //reset
        for (int i = 0; i < this.objContainer.Count; i++)
        {
            GameObject.Destroy(this.objContainer[i]);
        }

        this.objContainer.Clear();
    }
}
