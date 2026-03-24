using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenu : MonoBehaviour
{
    public void Selecao()
    {
        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }

    public void MotorBarco()
    {
        SceneManager.LoadScene("Motor", LoadSceneMode.Single);
    }
}
