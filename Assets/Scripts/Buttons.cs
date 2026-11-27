using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void ToGameplay()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
