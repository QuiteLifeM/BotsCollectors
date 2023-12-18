using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
[RequireComponent(typeof(UnitSpawner))]
public class Base : MonoBehaviour
{
    private Scanner _scanner;
    private UnitSpawner _unitSpawner;
    private List<Unit> _units = new List<Unit>();
    private Queue<Resource> _scannedResources;
    private int _resourceCount;
    private float _delay = 0.000000000002f;
    private Flag _flag;

    public bool IsProduced { get; private set; }

    private void Start()
    {
        IsProduced = false;
        _scanner = GetComponent<Scanner>();
        _unitSpawner = GetComponent<UnitSpawner>();
        _units.AddRange(_unitSpawner.GetUnits());
        _scannedResources = _scanner.GetResources();
        StartCoroutine(SetUnits());
    }

    private void Update()
    {
        Recycle();
        ExchangeResources();
    }

    public void AddUnit(Unit unit)
    {
        _units.Add(unit);
    }

    public void ReceiveFlag(Flag flag)
    {
        _flag = flag;
        IsProduced = true;
    }

    private IEnumerator SetUnits()
    {
        while (enabled)
        {
            _scannedResources = _scanner.GetResources();
            int index = UnityEngine.Random.Range(0, _units.Count);

            if (_units[index].IsVacant && _scannedResources.Count > 0)
            {
                Resource resource = _scannedResources.Dequeue();
                resource.SetFound();
                _units[index].SetTarget(resource);
            }

            yield return new WaitForSeconds(_delay);
        }
    }

    private void ExchangeResources()
    {
        if (_flag != null && _flag.IsSet)
        {
            if (_resourceCount > 5)
            {
                _resourceCount -= 5;
                int index = UnityEngine.Random.Range(0, _units.Count);

                if (_units[index].IsVacant)
                {
                    _units[index].SetTarget(_flag);
                    Debug.Log(_units[index]);
                    var newUnit = _units[index];
                    _flag.BuildBase(newUnit);
                    _flag.UnSet();
                    _units.RemoveAt(index);
                }
            }
        }
        else
        {
            if (_resourceCount > 3)
            { 
                _resourceCount -= 3;
                _unitSpawner.SpawnOneUnit();
                _units.AddRange(_unitSpawner.GetUnits());
            }
        }
    }

    private void Recycle()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).TryGetComponent(out Resource resource))
                {
                    Destroy(resource.gameObject);
                    _resourceCount++;
                }
            }
        }
    }
}