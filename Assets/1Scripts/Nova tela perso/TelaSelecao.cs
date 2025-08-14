using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TelaSelecao : MonoBehaviour
{
    public List<GameObject> persosDesc = new List<GameObject>();
    public List<PCsSO> perso = new List<PCsSO>();
    public GameObject pequeno;
    public GameObject canva;

    void Start()
    {
        foreach (PCsSO boneco in perso)
        {
            int index = perso.IndexOf(boneco);
            int down = 0;

            for (int i = 0; i <= index; i++)
            {
                if ((index + 1) % 3 == 0)
                {
                    down++;
                }
            }

            persosDesc.Add(Instantiate(pequeno, transform.position, Quaternion.identity));

            
            persosDesc[perso.IndexOf(boneco)].transform.localPosition = new Vector3(0.5f, 0.5f, 0);
        }
    }
}
