using UnityEngine;

public class Github : MonoBehaviour
{
 
    public string url = "https://github.com/dannya123-blm/SummerIMMB00150058.git";

    public void OpenGitHubRepo()
    {
        Application.OpenURL(url);
    }
}
