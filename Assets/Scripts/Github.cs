using UnityEngine;

public class Github : MonoBehaviour
{
    public string url;

    public void OpenGitHubRepo()
    {
        Application.OpenURL(url);
    }
}
