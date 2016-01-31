using UnityEngine;

public class MateSpawner : MonoBehaviour
{
    private BackgroundScrolling _background;
    private float _nextSpawn;

    public GameObject[] MatePrefabs;
    public float SpawnInterval = 8.0f;
    public float SpawnIntervalRange = 3.0f;

    // Use this for initialization
    void Start()
    {
        _background = GameObject.FindGameObjectWithTag("World")
            .GetComponent<BackgroundScrolling>();

        if(MatePrefabs == null || MatePrefabs.Length == 0)
        {
            Debug.LogError("No prefabs set on Mate Spawner");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextSpawn == default(float))
        {
            SetNextSpawn();
        }

        if (_nextSpawn < Time.time)
        {
            SpawnMate();
        }
    }

    void SpawnMate()
    {
        var mateType = Random.Range(0, MatePrefabs.Length);
        var prefab = MatePrefabs[mateType];

        Debug.Log("Spawning Mate");
        var mate = (GameObject)GameObject.Instantiate(prefab, new Vector3(
            transform.position.x,
            transform.position.y + Random.Range(-2.5f, 2.5f),
            transform.position.z), Quaternion.identity);

        SetNextSpawn();

        mate.GetComponentInChildren<MatingZone>().FlyAwayTime = _nextSpawn;
    }

    private void SetNextSpawn()
    {
        var timeTillNextSpawn = SpawnInterval + Random.Range(0, SpawnIntervalRange);
        _nextSpawn = Time.time + timeTillNextSpawn;
    }
}
