using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsGrabbed { get; private set; }
    public bool IsFound { get; private set; }

    public void SetFound()
    {
        IsFound = true;
    }

    public void SetGrabbed()
    {
        IsGrabbed = true;
    }

    private void Awake()
    {
        IsFound = false;
        IsGrabbed = false;
    }
}