using UnityEngine;
using UnityEngine.UIElements;

public class CoconutBehaviour : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float fallingSpeed = 2;

    [SerializeField] private bool fall = false;


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
}
