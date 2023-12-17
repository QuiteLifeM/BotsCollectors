using UnityEngine;
using System.Collections.Generic;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Flag _flag;
    private Base _base;

    // Start is called before the first frame update
    void Start()
    {
        _base = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Map map))
                {
                    if (_base != null)
                    {
                        if(_flag.IsSet == false)
                        {
                            Debug.Log("Спавн флага");
                            _flag.transform.position = hit.point;
                            _flag.Set();
                            _base.ReceiveFlag(_flag);
                            _base = null;
                        }
                        else
                        {
                            _flag.transform.position = hit.point;
                            _base.ReceiveFlag(_flag);
                        }
                    }
                }

                if (hit.collider.TryGetComponent(out Base baseOnMap))
                {
                    Debug.Log("ВЫБРАНА БАЗА");
                    _base = baseOnMap;
                }
            }
        }
    }
}
