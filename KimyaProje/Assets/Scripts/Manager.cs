using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }


}
