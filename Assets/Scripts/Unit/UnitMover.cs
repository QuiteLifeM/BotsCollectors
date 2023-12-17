using UnityEngine;

public class UnitMover : MonoBehaviour
{
    private float _speed = 10f;
    private Vector3 _target;

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
