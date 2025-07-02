using TMPro;
using UnityEngine;

public class DanoTxt : MonoBehaviour
{
    //Variavel que precisa
    public float dano;

    //Função start que chama a parte de trocar o texto
    void Start()
    {
        TrocarTexto(dano);
    }

    //Muda o texto no objeto para a quantidade de dano
    public void TrocarTexto(float dano)
    {
        GetComponent<TMP_Text>().text = dano.ToString();
    }

    //Função adicionada no fim da animação que destroi o objeto
    public void AcabouAnim()
    {
        Destroy(gameObject);
    }
}
