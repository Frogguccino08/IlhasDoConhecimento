using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
    }
}
