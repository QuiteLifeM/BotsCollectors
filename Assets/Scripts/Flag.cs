using System;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Base _base;

    public bool IsSet { get; private set; }

    private void Awake()
    {
        IsSet = false;
        gameObject.SetActive(false);
    }

    public void Set()
    {
        IsSet = true;
        gameObject.SetActive(true);
    }

    public void UnSet()
    {
        IsSet = false;
        gameObject.SetActive(false);
    }

    public void BuildBase(Unit unit)
    {
        if (unit == null)
        {
            throw new ArgumentNullException(nameof(unit));
        }

        if (_base != null)
        {
            //TO DO так корректно???
            float half = 0.5f;
            float shift = _base.transform.localScale.y * half;
            Base newBase = Instantiate(_base, transform.position + new Vector3(0f, shift, 0f), Quaternion.identity);
            Debug.Log(newBase);
            newBase.AddUnit(unit);
        }
        else
        {
            Debug.LogError("А базы то нет");
        }
    }
}
