using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TelaSelecao : MonoBehaviour
{
    public List<GameObject> persosDesc = new List<GameObject>();
    public List<PCsSO> perso = new List<PCsSO>();
    public GameObject pequeno;
    public GameObject canva;
    public GameObject descCompleta;
    public PersonagemSelecionado pc;

    public TMP_Text maxPoint;

    string material = "???";

    void Start()
    {
        pc = PersonagemSelecionado.instance;


        if (pc.modoHistoria == false)
        {
            Debug.Log("Modo Rush");
        }
        else
        {
            Debug.Log("Modo história");
        }


        foreach (PCsSO boneco in perso)
        {
            ColocarPersonagem(boneco);
        }

        PontoMaximo();
    }

    public void ColocarPersonagem(PCsSO boneco)
    {
        int index = perso.IndexOf(boneco);

        int coluna = index % 3;
        int linha  = index / 3;

        persosDesc.Add(Instantiate(pequeno, transform.position, Quaternion.identity));

        persosDesc[index].transform.SetParent(canva.transform);

        persosDesc[index].transform.localPosition =new Vector3(-9.2f + (coluna * 7f), 3.9f - (linha * 2.5f), 0);

        if (pc.unlock[perso.IndexOf(boneco)] == true)
        {
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().nome.text = perso[perso.IndexOf(boneco)].nome;
        }
        else
        {
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().nome.text = "???";
        }

        if (perso[perso.IndexOf(boneco)].nome.Length > 18)
        {
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().nome.fontSize = 0.35f;
        }
        else
        {
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().nome.fontSize = 0.4f;
        }

        switch (perso[perso.IndexOf(boneco)].material)
        {
            case 1:
                material = "Papel";
                persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
                break;
            case 2:
                material = "Plástico";
                persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
                break;
            case 3:
                material = "Vidro";
                persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
                break;
            case 4:
                material = "Metal";
                persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
                break;
            case 5:
                material = "Orgânico";
                persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
                break;
        }
                
        persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().materialTxt.text = material;

        persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().pc = boneco;

        persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().personagem.GetComponent<Image>().sprite = perso[perso.IndexOf(boneco)].imgMenu;

        if (pc.unlock[perso.IndexOf(boneco)] == false)
        {
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().personagem.GetComponent<Image>().color = Color.black;
        }
        else
        {
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().personagem.GetComponent<Image>().color = Color.white;
        }
    }

    public void PontoMaximo()
    {
        if (pc.modoHistoria == true)
        {
            maxPoint.text = "Recorde modo História: " + pc.maxHistoria;
        }
        else
        {
            maxPoint.text = "Recorde modo Rush: " + pc.maxRush;
            if(pc.persoMax != null) maxPoint.text = "Recorde modo Rush: " + pc.maxRush + " (" + pc.persoMax.nome + ")";
        }
    }
}
