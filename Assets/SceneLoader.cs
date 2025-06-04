using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMarkerBasedScene()
    {
        SceneManager.LoadScene("MarkerBasedScene");
    }

    public void LoadMarkerlessScene()
    {
        SceneManager.LoadScene("MarkerlessScene");
    }
    public void Loadmenu()
    {
        SceneManager.LoadScene("menu");
    }

}
