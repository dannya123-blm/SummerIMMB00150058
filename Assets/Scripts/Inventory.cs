// This code is based on from Create with code series & Robert Smith's Moodle page:
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

    public bool HasAllKeys()
    {
        return keysCollected >= totalKeys;
    }

    private void UpdateKeyText()
    {
        keyText.text = "Keys: " + keysCollected + "/" + totalKeys;
    }
}
