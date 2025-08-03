using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersoDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject telaDesc;
    public TMP_Text texto;
    public Player player;

    public void OnPointerEnter(PointerEventData eventData)
    {
        telaDesc.SetActive(true);
        telaDesc.transform.SetSiblingIndex(20);
        texto.text = "Dano físico: " + player.phiDamage + "\nDano a dist: " + player.speDamage + "\nDefesa física: " + player.phiDefense + "\nDefesa a dist: " + player.speDefense;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        telaDesc.SetActive(false);
    }
}
