using UnityEngine;

public class SimianBehaviour : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private KeyCode rotateToLeftKey;
    [SerializeField] private KeyCode rotateToRightKey;

    [Header("Parameters")]
    [SerializeField] private bool ascend = false;
    [SerializeField] private float ascendingSpeed = 1.0f;


    private SimianRotation _simianRotation;

    private void Start()
    {
        _simianRotation = GetComponentInChildren<SimianRotation>();
    }

    void Update()
    {
        if (ascend)
        {
            this.transform.position += ascendingSpeed * Time.deltaTime * Vector3.up;
        }

        if (Input.GetKeyDown(rotateToLeftKey))
        {
            _simianRotation.TryRotateToLeft();
        }

        if (Input.GetKeyDown(rotateToRightKey))
        {
            _simianRotation.TryRotateToRight();
        }
    }
}
