using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Base))]
public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private Point[] _point;
    [SerializeField] private Unit _unit;
    [SerializeField] private int _unitCount;

    private List<Unit> _units;
    private Base _base;

    public List<Unit> GetUnits()
    {
        List<Unit> units = new List<Unit>(_units);
        _units.Clear();

        return units;
    }

    public void SpawnOneUnit()
    {
        int index = Random.Range(0, _point.Length);
        Unit newUnit = Instantiate(_unit, _point[index].transform.position, Quaternion.identity);
        newUnit.SetBasePosition(transform.position);
        _units.Add(newUnit);
    }

    private void Awake()
    {
        _base = GetComponent<Base>();
        _units = new List<Unit>();
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _unitCount; i++)
        {
            SpawnOneUnit();
        }
    }
}
