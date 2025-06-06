using System.Collections.Generic;
using UnityEngine;

public class ConhecimentoControl : MonoBehaviour
{
    public GameObject Vazio;
    public GameObject Cheio;
    public GameObject R;
    public Canvas canva;
    public Player player;

    int i;
    int o;

    public List<GameObject> conhecimentosInstanciados = new List<GameObject>();
    public List<GameObject> RAtivos = new List<GameObject>();

    public void Update()
    {
        if(player.usingR == true)
        {
            int sla = RAtivos.Count - 1;

            if (RAtivos[sla] != null)
                {
                    RAtivos[sla].GetComponent<UnityEngine.UI.Image>().color = new Color32(135, 69, 25, 255);
                }
        }else if(player.usingR == false && player.currentR != 0)
        {
            int sla = RAtivos.Count - 1;

            if (RAtivos[sla] != null)
            {
                RAtivos[sla].GetComponent<UnityEngine.UI.Image>().color = new Color32(24, 24, 24, 255);
            }
        }

        if(player.using3R == true && player.usingR == false)
        {
            foreach(GameObject objR in RAtivos)
            {
                if(objR != null)
                {
                    objR.GetComponent<UnityEngine.UI.Image>().color = new Color32(135, 69, 25, 255);
                }
            }
        }else if(player.using3R == false && player.usingR == false && player.currentR != 0)
        {
            foreach(GameObject objR in RAtivos)
            {
                if(objR != null)
                {
                    objR.GetComponent<UnityEngine.UI.Image>().color = new Color32(24, 24, 24, 255);
                }
            }
        }
    }

    public void SpawnConhecimento(int maximo, int atual)
    {
        foreach (GameObject obj in conhecimentosInstanciados)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        conhecimentosInstanciados.Clear(); 


        for (i = 0; i < maximo; i++)
        {
            GameObject obj;

            if (i < atual)
            {
                obj = Instantiate(Cheio, new Vector3(-9.7f + (i * 0.4f), 2.89f, 0f), Quaternion.identity);
            }
            else
            {
                obj = Instantiate(Vazio, new Vector3(-9.7f + (i * 0.4f), 2.89f, 0f), Quaternion.identity);
            }

            obj.transform.SetParent(canva.transform);
            conhecimentosInstanciados.Add(obj);
        }
    }

    public void SpawnRs()
    {
        foreach (GameObject objR in RAtivos)
        {
            if (objR != null)
            {
                Destroy(objR);
            }
        }
        RAtivos.Clear(); 

        for (o = 1; o <= 3; o++)
        {
            GameObject objR;

            if (player.currentR < o)
            {
                continue;
            }

            objR = Instantiate(R, new Vector3(-3f + (o * 0.4f), 3.7f, 0f), Quaternion.identity);
            objR.transform.SetParent(canva.transform);
            objR.transform.SetSiblingIndex(4);
            RAtivos.Add(objR);
        }
    }
}
