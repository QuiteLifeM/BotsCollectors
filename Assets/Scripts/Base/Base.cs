using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Scanner _scanner;
    private UnitSpawner _unitSpawner;
    private List<Unit> _units;
    private Queue<Resource> _scannedResources;
    private int _resousrceCount;

    private void Start()
    {
        _scanner = GetComponent<Scanner>();
        _unitSpawner = GetComponent<UnitSpawner>();
        _units = _unitSpawner.GetUnits();
    }

    private void Update()
    {
        Work();
        Recycle();
    }
        
    private void Work()
    {
        _scannedResources = _scanner.GetResources();

        for (int i = 0; i < _units.Count; i++)
        {
            if (_units[i].IsVacant && _scannedResources.Count > 0)
            {
                Resource resource = _scannedResources.Dequeue();
                resource.SetFound();
                _units[i].SetTargetResource(resource);
            }
        }
    }

    private void Recycle()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).TryGetComponent(out Resource resource))
                {
                    Destroy(resource.gameObject);
                    _resousrceCount++;
                    Debug.Log($"Количество ресурсов: {_resousrceCount}");
                }
            }
        }
    }
}