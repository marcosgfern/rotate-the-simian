using UnityEngine;

public class CameraFollowPivot : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = cameraPivot.position;
    }
}
