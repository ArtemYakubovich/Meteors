using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private Meteor[] _meteors;
    [SerializeField] private int _initialMeteors;
    [SerializeField] private Cooldown _spawnCooldown;

    private Bounds _screenBounds;

    private void Start()
    {
        _screenBounds = FindObjectOfType<ScreenBounds>().TresholdBounds;
        SpawnMeteors(_initialMeteors);
    }

    private void Update()
    {
        if(_spawnCooldown.IsReady)
        {
            SpawnRandomMeteor();
            _spawnCooldown.Reset();
        }
    }

    private void SpawnMeteors(int count)
    {
        for(int i = 0; i < count; i++)
        {
            SpawnRandomMeteor();
        }
    }

    private void SpawnRandomMeteor()
    {
        int randomMeteorIndex = Random.Range(0, _meteors.Length);
        Meteor meteorPrefab = _meteors[randomMeteorIndex];

        float yPos = Random.value > 0.5f ? _screenBounds.min.y : _screenBounds.max.y;
        float xPos = Random.Range(_screenBounds.min.x, _screenBounds.max.x);
        Vector2 randomOutOfScreenPosition = new Vector2(xPos, yPos);

        Meteor meteor = Instantiate(meteorPrefab, randomOutOfScreenPosition, Quaternion.identity, transform);
        meteor.Launch();
    }
}
