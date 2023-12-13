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

        if (_resource != null)
        {
            IsVacant = false;
            _mover.SetTarget(resource.transform.position);
        }
        else
        {
            IsVacant = true;
        }
    }

    private void Awake()
    {
        IsVacant = true;
        _mover = GetComponent<UnitMover>();
        _mover.SetTarget(transform.position);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Resource resource))
        {
            if (resource == _resource)
            {
                _resource.transform.SetParent(transform);
                _mover.SetTarget(_basePosition);
            }
        }

        if (collider.TryGetComponent(out Base unitBase))
        {
            IsVacant = true;

            if (_resource != null)
            {
                _resource.transform.SetParent(unitBase.transform);
            }
        }
    }
}
