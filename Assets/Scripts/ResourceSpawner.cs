using System.Collections;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Point[] _points;
    [SerializeField] private Resource _resource;

    private WaitForSeconds _waitForSeconds;
    private float _delay;

    private void Awake()
    {
        _delay = Random.Range(1f, 4f);
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        while (enabled)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                Resource newResource = Instantiate(_resource, _points[i].transform.position, Quaternion.identity);
            }

            _delay = Random.Range(1f, 4f);

            yield return _waitForSeconds;
        }
    }
}
