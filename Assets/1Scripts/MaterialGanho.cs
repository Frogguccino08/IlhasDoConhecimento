using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaterialGanho : MonoBehaviour
{
    public TMP_Text texto;

    public void Ajustes(int mat, float quant)
    {
        texto.text = quant.ToString();

        switch (mat)
        {
            case 0:
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = new Color32(65, 105, 225, 255);
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = new Color32(155, 17, 30, 255);
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = new Color32(0, 100, 0, 255);
                break;
            case 4:
                GetComponent<SpriteRenderer>().color = new Color32(238, 173, 45, 255);
                break;
            case 5:
                GetComponent<SpriteRenderer>().color = new Color32(120, 64, 8, 255);
                break;
        }
    }
}
