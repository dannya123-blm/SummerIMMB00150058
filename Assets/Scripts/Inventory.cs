using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int totalKeys = 0;
    public int keysCollected = 0;
    public Text keyText;

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

