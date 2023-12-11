using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Scanner _scanner;
    private UnitSpawner _unitSpawner;
    private List<Unit> _units;
    private Queue<Resource> _scannedResources;

    private void Start()
    {
        _scanner = GetComponent<Scanner>();
        _unitSpawner = GetComponent<UnitSpawner>();
        _units = _unitSpawner.GetUnits();
        _scannedResources = _scanner.GetResources();
    }

    private void Update()
    {
        Work();
    }

    private void Work()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            if (_units[i].IsVacant && _scannedResources.Count > 0)
            {
                Resource resource = _scannedResources.Dequeue();
                _units[i].SetTarget(resource.transform.position);
            }
        }
    }

    //private void Recycle()
    //{
    //    if (transform.childCount > 0)
    //    {
    //        for (int i = 0; i < transform.childCount; i++)
    //        {
    //            Destroy(transform.GetChild(i).gameObject);
    //        }
    //    }
    //}
}