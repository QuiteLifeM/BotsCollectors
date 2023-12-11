using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsGrabbed { get; private set; }
    public bool IsFound { get; private set; }

    public void SetFound()
    {
        IsFound = true;
    }

    private void Awake()
    {
        IsFound = false;
        IsGrabbed = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Unit unit))
        {
            IsGrabbed = true;
        }
    }
}