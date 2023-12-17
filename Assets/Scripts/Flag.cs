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
        if (_base != null)
        {
            Base newBase = Instantiate(_base, transform.position, Quaternion.identity);
            newBase.GetUnit(unit);
        }
        else
        {
            Debug.Log("А база то не выбрана");
        }
    }
}
