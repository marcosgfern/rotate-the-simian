using System.Collections;
using UnityEngine;

public class CoconutDisappearParticle : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float rebounceForce = 10.0f;
    [SerializeField] private float disappearDuration = 1.0f;
    [SerializeField] private float rotationForce = 200.0f;

    private CoconutSide _side;

    //References
    private Rigidbody _rigidbody;
    private Material _material;

    private float _aliveCountdown;

    private Color _temporaryColor;

    public CoconutSide Side
    {
        get => _side;
        set => _side = value;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;
        _aliveCountdown = disappearDuration;
    }


    private void Start()
    {
        float rebounceXDirection = _side.Equals(CoconutSide.Right) ? 1f : -1f;

        _rigidbody.AddForce(new Vector3(rebounceXDirection, 1, 0).normalized * rebounceForce);

        //Add random rotation
        Vector3 torque = new Vector3(
            rotationForce,
            rotationForce,
            rotationForce
            );
        _rigidbody.AddTorque(torque);
    }

    private void Update()
    {
        _aliveCountdown -= Time.deltaTime;

        if(_aliveCountdown < 0)
        {
            Destroy(this);
        }

        _temporaryColor = _material.color;
        _temporaryColor.a = _aliveCountdown / disappearDuration;
        _material.color  = _temporaryColor;
    }


}
