using System.Collections;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Point[] _points;
    [SerializeField] private Resource _resource;

    private WaitForSeconds _waitForSeconds;
    private float _delay = 6f;

    private void Awake()
    {
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

            yield return _waitForSeconds;
        }
    }
}
