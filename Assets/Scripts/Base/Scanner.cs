using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _maxDistance;

    private RaycastHit[] _hitsInfo;
    private Queue<Resource> _acceptedHits;
    private Ray _ray;
    private WaitForSeconds _waitForSeconds;
    private float _delay = 2f;

    public Queue<Resource> GetResources()
    {
        return _acceptedHits;
    }

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        _ray = new Ray(transform.position, transform.forward);
        _acceptedHits = new Queue<Resource>();
    }

    private void Start()
    {
        StartCoroutine(Scan());
    }

    private IEnumerator Scan()
    {
        while (enabled)
        {
            _hitsInfo = Physics.SphereCastAll(_ray, _radius);

            for (int i = 0; i < _hitsInfo.Length; i++)
            {
                if (_hitsInfo[i].collider.gameObject.TryGetComponent(out Resource resource))
                {
                    if (resource.IsFound == false)
                    {
                        _acceptedHits.Enqueue(resource);
                    }
                }
            }

            yield return _waitForSeconds;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}