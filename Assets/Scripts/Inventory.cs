using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int totalKeys = 0;
    public int keysCollected = 0; // Make this public
    public Text keyText; // Reference to the UI Text element

    void Start()
    {
        UpdateKeyText();
    }

    public void CollectKey()
    {
        keysCollected++;
        UpdateKeyText();
    }

    private void UpdateKeyText()
    {
        keyText.text = "Keys: " + keysCollected + "/" + totalKeys;
    }
}
