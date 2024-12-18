using UnityEngine;

public enum SimianRotationState
{
    OnLeft = 0,
    LeftToRight = 1,
    OnRight = 2,
    RightToLeft = 3
}

public class SimianRotation : MonoBehaviour
{
    [SerializeField] public float rotationSpeed;

    private SimianRotationState state;

    private void Awake()
    {
        state = SimianRotationState.OnLeft;
    }

    private void Update()
    {
        switch (state)
        {
            case SimianRotationState.OnLeft:
                break;

            case SimianRotationState.LeftToRight:
                RotatingLeftToRight();
                break;

            case SimianRotationState.OnRight:
                break;

            case SimianRotationState.RightToLeft:
                RotatingRightToLeft();
                break;

        }
    }

    public void TryRotateToLeft()
    {
        if (state.Equals(SimianRotationState.OnRight))
        {
            state = SimianRotationState.RightToLeft;
        }
    }

    public void TryRotateToRight()
    {
        if (state.Equals(SimianRotationState.OnLeft))
        {
            state = SimianRotationState.LeftToRight;
        }
    }

    private void RotatingLeftToRight()
    {
        Vector3 newRotation = transform.rotation.eulerAngles + new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        if (newRotation.y >= 180)
        {
            newRotation.y = 180;

            state = SimianRotationState.OnRight;
        }

        transform.rotation = Quaternion.Euler(newRotation);
    }

    private void RotatingRightToLeft()
    {
        Vector3 newRotation = transform.rotation.eulerAngles + new Vector3(0, -rotationSpeed * Time.deltaTime, 0);
        if (newRotation.y <= 0)
        {
            newRotation.y = 0;

            state = SimianRotationState.OnLeft;
        }

        transform.rotation = Quaternion.Euler(newRotation);
    }
}
