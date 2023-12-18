using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsGrabbed { get; private set; }
    public bool IsFound { get; private set; }

    private void Awake()
    {
        IsGrabbed = false;
        IsFound = false;
    }

    public void SetFound()
    {
        IsFound = true;
    }

    public void SetGrabbed()
    {
        IsGrabbed = true;
    }
}