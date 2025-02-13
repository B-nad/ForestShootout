using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_camera.transform);
    }
}
