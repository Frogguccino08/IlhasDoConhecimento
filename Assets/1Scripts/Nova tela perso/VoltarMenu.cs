using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public void Onclick()
    {
        if(PersonagemSelecionado.instance.isHistoria)
        {
            SceneManager.LoadScene("Mapa", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(PersonagemSelecionado.instance.isHistoria)
            {
                SceneManager.LoadScene("Mapa", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
            }
        }
    }
}
