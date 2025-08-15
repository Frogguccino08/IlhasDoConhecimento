using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TelaSelecao : MonoBehaviour
{
    public List<GameObject> persosDesc = new List<GameObject>();
    public List<PCsSO> perso = new List<PCsSO>();
    public GameObject pequeno;
    public GameObject canva;
    public GameObject descCompleta;

    int down = 0;
    string material = "???";

    void Start()
    {
        foreach (PCsSO boneco in perso)
        {
            int o = 0;
            int index = 0;

            while (o <= perso.IndexOf(boneco))
            {
                index++;
                o++;

                if (index > 3)
                {
                    index = 1;
                }
            }

            for (int i = 0; i <= perso.IndexOf(boneco) - 1; i++)
            {
                if ((index - 1) % 3 == 0 && index != 0)
                {
                    down++;
                }
            }

            Debug.Log(perso[perso.IndexOf(boneco)].nome + ", down: " + down + ", index: " + index);

            persosDesc.Add(Instantiate(pequeno, transform.position, Quaternion.identity));

            persosDesc[perso.IndexOf(boneco)].transform.SetParent(canva.transform);
            persosDesc[perso.IndexOf(boneco)].transform.localPosition = new Vector3(-9.2f + ((index - 1) * 7), 5 - (down * 1), 0);

            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().nome.text = perso[perso.IndexOf(boneco)].nome;
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
                    break;
                case 2:
                    material = "Plástico";
                    break;
                case 3:
                    material = "Vidro";
                    break;
                case 4:
                    material = "Metal";
                    break;
                case 5:
                    material = "Orgânico";
                    break;
            }
            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().materialTxt.text = material;

            if (perso.IndexOf(boneco) == perso.Count - 1)
            {
                down = 0;
            }

            persosDesc[perso.IndexOf(boneco)].GetComponent<Persopequeno>().pc = boneco;
        }
    }
}
