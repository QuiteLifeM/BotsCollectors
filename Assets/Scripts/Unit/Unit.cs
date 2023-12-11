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

    public void SetTarget(Vector3 target)
    {
        _mover.SetTarget(target);
    }

    public void Work()
    {
        IsVacant = false;
        //Debug.Log("Ворк работае?");
    }

    private void Awake()
    {
        IsVacant = true;
        _mover = GetComponent<UnitMover>();
    }

    //private void Update()
    //{
    //    Work();
    //}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Resource resource))
        {
            _resource = resource;
            IsVacant = false;
            Debug.Log("Столкнулись");
            _resource.transform.SetParent(transform);
            _mover.SetTarget(_basePosition);
        }

        if(collider.TryGetComponent(out Base unitBase))
        {
            IsVacant = true;
            Debug.Log("Пришел на базу");
            _resource.transform.SetParent(unitBase.transform);
        }
    }

    private void GrabResource()
    {

    }
}
