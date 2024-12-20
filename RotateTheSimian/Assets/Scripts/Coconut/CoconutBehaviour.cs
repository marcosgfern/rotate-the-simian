using UnityEngine;
using UnityEngine.UIElements;

public class CoconutBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float fallingSpeed = 2;

    [SerializeField] private bool fall = false;

    [Header("References")]
    [Tooltip("Prefab must be disabled by default.")]
    [SerializeField] private GameObject disappearParticlePrefab;

    private CoconutSide side;

    public bool Fall
    {
        get => fall;

        set => fall = value;
    }


    // Update is called once per frame
    void Update()
    {
        if (fall)
        {
            transform.position += fallingSpeed * Time.deltaTime * Vector3.down;
        }
    }

    public void ResetCoconut(CoconutSide side)
    {
        this.side = side;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                break;

            case "Floor":
                this.gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }
}
