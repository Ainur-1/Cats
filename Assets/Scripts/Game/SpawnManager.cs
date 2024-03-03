using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float _spawnY = 4.5f;
    [SerializeField] private int maxSpawnBallSize = 4;
    [SerializeField] private List<GameObject> _ballPrefabs = new List<GameObject>();

    private GameObject _ball;
    private bool isSpawn = false;
    private RandomBallSelector newSize;
    private static SpawnManager _instance;

    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SpawnManager>();
                if (_instance == null)
                {
                    GameObject spawnManagerObject = new GameObject("SpawnManager");
                    _instance = spawnManagerObject.AddComponent<SpawnManager>();
                }
            }
            return _instance;
        }
    }

    public GameObject Ball
    {
        get { return _ball; }
    }

    public List<GameObject> BallPrefabs
    {
        get { return _ballPrefabs; }
    }

    public float SpawnY
    {
        get { return _spawnY; }
    }

    public void ChangeBall()
    {
        Destroy(_ball);
        SpawnBall(11);
    }

    private void Start()
    {
        SpawnBall(0);
        newSize = new RandomBallSelector(maxSpawnBallSize);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _ball.GetComponent<Rigidbody2D>().gravityScale = 1f;
            isSpawn = true;
        }

        if (_ball.transform.position.y < 3f && isSpawn)
        {
            int size = newSize.SelectRandomBallIndex();
            SpawnBall(size);
            isSpawn = false;
        }
    }

    private void SpawnBall(int size)
    {
        Vector3 spawnPos = new Vector3(0, _spawnY, 0);
        GameObject newBall = Instantiate(_ballPrefabs[size], spawnPos, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().gravityScale = 0f;
        _ball = newBall;
    }
}