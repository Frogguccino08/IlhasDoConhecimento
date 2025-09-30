using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenu : MonoBehaviour
{
    public void Selecao(bool modoHistoria)
    {
        if (modoHistoria == false)
        {
            PersonagemSelecionado.instance.modoHistoria = false;
        }
        else
        {
            PersonagemSelecionado.instance.modoHistoria = true;
        }

        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }

    public void MotorBarco()
    {
        SceneManager.LoadScene("Motor", LoadSceneMode.Single);
    }
}
