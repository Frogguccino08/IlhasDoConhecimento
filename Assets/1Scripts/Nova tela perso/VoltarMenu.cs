using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
        }
    }
}
