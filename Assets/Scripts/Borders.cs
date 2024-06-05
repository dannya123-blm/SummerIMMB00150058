using UnityEngine;

public class Borders : MonoBehaviour
{
    public Vector3 leftBorderPosition = new Vector3(701.93f, 1.653f, -249.529f);
    public Vector3 leftBorderSize = new Vector3(1f, 10f, 100f); 

    public Vector3 rightBorderPosition = new Vector3(684.9443f, 0.7f, -248.75f);
    public Vector3 rightBorderSize = new Vector3(1f, 10f, 100f);

    void Start()
    {
        CreateBorder("BorderLeft", leftBorderPosition, leftBorderSize);
        CreateBorder("BorderRight", rightBorderPosition, rightBorderSize);
    }

    void CreateBorder(string name, Vector3 position, Vector3 size)
    {
        GameObject border = new GameObject(name);
        border.transform.position = position;
        BoxCollider collider = border.AddComponent<BoxCollider>();
        collider.size = size;
        collider.isTrigger = false; // Ensure collider acts as a physical barrier
    }
}
