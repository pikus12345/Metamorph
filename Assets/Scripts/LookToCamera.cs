using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

}

