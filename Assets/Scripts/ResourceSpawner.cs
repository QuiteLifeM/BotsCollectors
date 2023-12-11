using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private Point[] _points;
    [SerializeField] private Resource _resource;

    WaitForSeconds _sleep;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private void Spawn()
    {
        for(int i = 0; i < _points.Length; i++)
        {
            Resource newResource = Instantiate(_resource, _points[i].transform.position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnDelay()
    {
        while (enabled)
        {
            for (int i = 0; i < _points.Length; i++)
            {
                Resource newResource = Instantiate(_resource, _points[i].transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(4f);
        }
    }
}
