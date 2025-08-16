using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenu : MonoBehaviour
{
    public void RushMode()
    {
        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }
}
