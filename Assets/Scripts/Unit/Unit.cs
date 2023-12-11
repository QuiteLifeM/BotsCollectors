using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(UnitMover))]
public class Unit : MonoBehaviour
{
    private UnitMover _mover;
    private Vector3 _basePosition;
    private Resource _resource;

    public bool IsVacant { get; private set; }

    public void SetBasePosition(Vector3 position)
    {
        _basePosition = position;
    }

    public void SetTargetResource(Resource resource)
    {
        _resource = resource;
        _mover.SetTarget(resource.transform.position);
    }

    private void Awake()
    {
        IsVacant = true;
        _mover = GetComponent<UnitMover>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Resource resource))
        {
            if (resource == _resource)
            {
                IsVacant = false;
                _resource.transform.SetParent(transform);
                _mover.SetTarget(_basePosition);
            }
        }

        if(collider.TryGetComponent(out Base unitBase))
        {
            IsVacant = true;
            _resource.transform.SetParent(unitBase.transform);
        }
    }
}
