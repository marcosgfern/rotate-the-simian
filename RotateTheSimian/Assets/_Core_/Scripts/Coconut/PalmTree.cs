using UnityEngine;


public enum CoconutSide
{
    Left = 0,
    Right = 1
}

public class PalmTree : MonoBehaviour
{
    [SerializeField] private Transform spawnPointLeft, spawnPointRight;

    public Vector3 GetSpawnPosition(CoconutSide side)
    {
        switch (side)
        {
            case CoconutSide.Left:
                return spawnPointLeft.position;

            case CoconutSide.Right:
                return spawnPointRight.position;

            default:
                return Vector3.zero;
        }
    }
}
