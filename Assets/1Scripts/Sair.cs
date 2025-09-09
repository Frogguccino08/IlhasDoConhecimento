using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair : MonoBehaviour
{
    public GameObject tela;
    public Controle control;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && control.telaSair == false && control.vitoriaOn == false)
        {
            control.telaSair = true;
            control.descricao.SetActive(false);
            tela.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && control.telaSair == true)
        {
            control.telaSair = false;
            tela.SetActive(false);
        }
    }

    public void Voltar()
    {
        control.telaSair = false;
        tela.SetActive(false);
    }

    public void Quitar()
    {
        PersonagemSelecionado.instance.Resetar();
        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }

    public void VitoriaSair()
    {
        control.vitoriaOn = false;
    }
}
