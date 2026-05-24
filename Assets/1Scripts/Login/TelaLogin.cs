using System.Collections;
using TMPro;
using UnityEngine;

public class TelaLogin : MonoBehaviour
{
    public GameObject btLogin;
    public GameObject scLogin;
    public GameObject scMain;

    public FirebaseRegister FBRegister;
    public TMP_Text nomeEmGame;

    void Start()
    {
        if(InfoPlayer.instance.username != "")
        {
            nomeEmGame.text = InfoPlayer.instance.username;
            FecharTela();
        }
    }

    public void AbrirTela()
    {
        InfoPlayer.instance.CleanReset();
        FBRegister.LogOut();
        btLogin.SetActive(false);
        scLogin.SetActive(true);
        scMain.SetActive(false);
    }

    public void FecharTela()
    {
        btLogin.SetActive(true);
        scLogin.SetActive(false);
        scMain.SetActive(true);
        StartCoroutine(ColocarNome());
    }

    public IEnumerator ColocarNome()
    {
        yield return new WaitForSeconds(0.2f);
        nomeEmGame.text = InfoPlayer.instance.username;
    }
}
