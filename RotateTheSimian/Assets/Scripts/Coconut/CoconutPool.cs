using UnityEngine;

public class CoconutPool : MonoBehaviour
{
    public GameObject coconutPrefab;

    public int initialSize = 8;


    private void Start()
    {
        for (int i = 0; i < initialSize; i ++)
        {
            Instantiate(coconutPrefab, this.transform).SetActive(false);
        }
    }

    /* Gets an exisiting coconut in pool and returns it, not active.
     * Returns: Component CoconutBehaviour of coconut.
     */
    public CoconutBehaviour GetCoconut()
    {
        CoconutBehaviour coconut = null;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (!this.transform.GetChild(i).gameObject.activeSelf
                    && this.transform.GetChild(i).name == (coconutPrefab.name + "(Clone)"))
            {
                coconut = this.transform.GetChild(i).GetComponent<CoconutBehaviour>();
                break;
            }
        }

        if (coconut == null)
        {
            return AddCoconutToPool();
        }
        else
        {
            return coconut;
        }
    }


    /* Instantiates a new coconut in the pool. */
    private CoconutBehaviour AddCoconutToPool()
    {
        GameObject coconut = Instantiate(coconutPrefab, this.transform);
        coconut.SetActive(false);
        return coconut.GetComponent<CoconutBehaviour>();
    }
}