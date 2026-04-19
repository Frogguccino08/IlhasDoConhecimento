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
                InfoPlayer.instance.material[0] = quant;
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = new Color32(65, 105, 225, 255);
                InfoPlayer.instance.material[1] = quant;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = new Color32(155, 17, 30, 255);
                InfoPlayer.instance.material[2] = quant;
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = new Color32(0, 100, 0, 255);
                InfoPlayer.instance.material[3] = quant;
                break;
            case 4:
                GetComponent<SpriteRenderer>().color = new Color32(238, 173, 45, 255);
                InfoPlayer.instance.material[4] = quant;
                break;
            case 5:
                GetComponent<SpriteRenderer>().color = new Color32(120, 64, 8, 255);
                InfoPlayer.instance.material[5] = quant;
                break;
        }
    }
}
