using System.Collections;
using UnityEngine;

public class SimianBehaviour : MonoBehaviour
{
    public static string CoconutTag = "Coconut";

    [Header("Controls")]
    [SerializeField] private KeyCode rotateToLeftKey;
    [SerializeField] private KeyCode rotateToRightKey;

    [Header("Parameters")]
    [SerializeField] private bool move = false;
    [SerializeField] private bool ascend = true;
    [SerializeField] private float ascendingSpeed = 1.0f;
    [SerializeField] private float descendingSpeed = 1.0f;
    [SerializeField] private float descendingTime = 1.0f;


    private SimianRotation _simianRotation;

    //Y coordinate of how low can simian go when descending
    private float _lowestPoint;


    public bool Move
    {
        get => move;
        set => move = value;
    }

    private void Start()
    {
        _simianRotation = GetComponentInChildren<SimianRotation>();
        _lowestPoint = this.transform.position.y;
    }

    void Update()
    {
        if (move)
        {
            if (ascend)
            {
                this.transform.position += ascendingSpeed * Time.deltaTime * Vector3.up;

                if (Input.GetKeyDown(rotateToLeftKey))
                {
                    _simianRotation.TryRotateToLeft();
                }

                if (Input.GetKeyDown(rotateToRightKey))
                {
                    _simianRotation.TryRotateToRight();
                }
            }

            else
            {
                this.transform.position += descendingSpeed * Time.deltaTime * Vector3.down;
                if (this.transform.position.y < _lowestPoint) {
                    this.transform.position = new Vector3(
                        this.transform.position.x,
                        _lowestPoint,
                        this.transform.position.z);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(CoconutTag))
        {
            StartCoroutine(Descending());
        }
    }

    private IEnumerator Descending()
    {
        ascend = false;
        yield return new WaitForSeconds(descendingTime);
        ascend = true;
    }
}
