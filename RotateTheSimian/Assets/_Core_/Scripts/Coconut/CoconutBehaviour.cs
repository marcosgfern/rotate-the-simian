using UnityEngine;
using UnityEngine.UIElements;

public class CoconutBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float fallingSpeed = 2;

    [SerializeField] private bool fall = false;

    [Header("References")]
    [Tooltip("Prefab must be disabled by default.")]
    [SerializeField] private CoconutDisappearParticle disappearParticlePrefab;

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
        fall = true;
        this.side = side;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoconutDisappearParticle particle = Instantiate(disappearParticlePrefab, this.transform.position, this.transform.rotation);
            particle.Side = side;
            particle.gameObject.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
