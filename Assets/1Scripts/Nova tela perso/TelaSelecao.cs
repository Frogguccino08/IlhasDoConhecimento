using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TelaSelecao : MonoBehaviour
{
    public List<GameObject> persosDesc = new List<GameObject>();
    public GameObject pequeno;
    public GameObject canva;
    public GameObject descCompleta;
    public PersonagemSelecionado pc;

    public TMP_Text maxPoint;

    string material = "???";

    void Start()
    {
        pc = PersonagemSelecionado.instance;
        pc.CarregarInfo();

        foreach (PCsSO boneco in pc.persos)
        {
            ColocarPersonagem(boneco);
        }

        PontoMaximo();
    }

    public void ColocarPersonagem(PCsSO boneco)
    {
        int index = pc.persos.IndexOf(boneco);

        int coluna = index % 3;
        int linha  = index / 3;

        persosDesc.Add(Instantiate(pequeno, transform.position, Quaternion.identity));

        persosDesc[index].transform.SetParent(canva.transform);

        persosDesc[index].transform.localPosition =new Vector3(-9.2f + (coluna * 7f), 3.9f - (linha * 2.5f), 0);

        if (pc.unlock[pc.persos.IndexOf(boneco)] == true)
        {
            persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().nome.text = pc.persos[pc.persos.IndexOf(boneco)].nome;
        }
        else
        {
            persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().nome.text = "???";
        }

        if (pc.persos[pc.persos.IndexOf(boneco)].nome.Length > 18)
        {
            persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().nome.fontSize = 0.35f;
        }
        else
        {
            persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().nome.fontSize = 0.4f;
        }

        switch (pc.persos[pc.persos.IndexOf(boneco)].material)
        {
            case 1:
                material = "Papel";
                persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
                break;
            case 2:
                material = "Plástico";
                persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
                break;
            case 3:
                material = "Vidro";
                persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
                break;
            case 4:
                material = "Metal";
                persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
                break;
            case 5:
                material = "Orgânico";
                persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().material.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
                break;
        }
                
        persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().materialTxt.text = material;

        persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().pc = boneco;

        persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().personagem.GetComponent<Image>().sprite = pc.persos[pc.persos.IndexOf(boneco)].imgMenu;

        if (pc.unlock[pc.persos.IndexOf(boneco)] == false)
        {
            persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().personagem.GetComponent<Image>().color = Color.black;
        }
        else
        {
            persosDesc[pc.persos.IndexOf(boneco)].GetComponent<Persopequeno>().personagem.GetComponent<Image>().color = Color.white;
        }
    }

    public void PontoMaximo()
    {
            maxPoint.text = "Recorde modo Rush: " + pc.maxRush;
            if(pc.persoMax != null) maxPoint.text = "Recorde modo Rush: " + pc.maxRush + " (" + pc.persoMax + ")";
    }
}
