using TMPro;
using UnityEngine;

public class DanoTxt : MonoBehaviour
{
    public float dano;

    void Start()
    {
        TrocarTexto(dano);
    }

    public void TrocarTexto(float dano)
    {
        GetComponent<TMP_Text>().text = dano.ToString();
    }

    public void AcabouAnim()
    {
        Destroy(gameObject);
    }
}
