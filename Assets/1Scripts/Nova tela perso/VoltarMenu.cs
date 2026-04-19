using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public void Onclick()
    {
        if(PersonagemSelecionado.instance.isHistoria && SceneManager.GetActiveScene().name != "Mapa")
        {
            SceneManager.LoadScene("Mapa", LoadSceneMode.Single);
        }
        else
        {
            PersonagemSelecionado.instance.isHistoria = false;
            SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(PersonagemSelecionado.instance.isHistoria && SceneManager.GetActiveScene().name != "Mapa")
            {
                SceneManager.LoadScene("Mapa", LoadSceneMode.Single);
            }
            else
            {
                PersonagemSelecionado.instance.isHistoria = false;
                SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
            }
        }
    }
}
