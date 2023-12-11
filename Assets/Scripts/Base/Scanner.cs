using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _maxDistance;

    private RaycastHit[] _hitsInfo;
    private Queue<Resource> _acceptedHits;
    private Ray _ray;

    public Queue<Resource> GetResources()
    {
        return _acceptedHits;
    }

    private void Awake()
    {
        _ray = new Ray(transform.position, transform.forward);
        _acceptedHits = new Queue<Resource>();
    }

    private void Update()
    {
        _hitsInfo = Physics.SphereCastAll(_ray, _radius);

        //Debug.Log(_hitsInfo.Length);

        for(int i = 0;  i < _hitsInfo.Length; i++)
        {
            if (_hitsInfo[i].collider.tag == "Resource")
            {
                Resource resource;
                _hitsInfo[i].collider.TryGetComponent(out resource);
                _acceptedHits.Enqueue(resource);
            }
        }

        //Debug.Log(_acceptedHits.Count + "число ресурсов");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}