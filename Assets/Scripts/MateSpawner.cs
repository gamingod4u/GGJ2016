using UnityEngine;

public class MateSpawner : MonoBehaviour
{
    private BackgroundScrolling _background;
    private float _nextSpawn;

    public GameObject MatePrefab;
    public float SpawnInterval = 8.0f;
    public float SpawnIntervalRange = 3.0f;

    // Use this for initialization
    void Start()
    {
        _background = GameObject.FindGameObjectWithTag("World")
            .GetComponent<BackgroundScrolling>();
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
        Debug.Log("Spawning Mate");
        var mate = (GameObject)GameObject.Instantiate(MatePrefab, new Vector3(
            transform.position.x,
            transform.position.y,
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
