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

    public void SetTarget(Resource resource)
    {
        _resource = resource;

        if( _resource.IsGrabbed)
        {
            return;
        }

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

    public void SetTarget(Flag flag)
    {
        _mover.SetTarget(flag.transform.position);
        IsVacant = false;
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
            if (resource == _resource && resource.IsGrabbed != true)
            {
                _resource.SetGrabbed();
                _resource.transform.SetParent(transform);
                _mover.SetTarget(_basePosition);
            }
        }

        if (collider.TryGetComponent(out Base unitBase))
        {
            if (_resource != null)
            {
                IsVacant = true;
                _resource.transform.SetParent(unitBase.transform);
                _mover.SetTarget(transform.position);
            }
        }

        if (collider.TryGetComponent(out Flag flag))
        {
            IsVacant = true;
        }
    }
}
