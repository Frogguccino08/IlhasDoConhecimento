/*
Pre-game:
    Visual code se não tiverem
    GitHub desktop como funciona e clonar repositório
    Unity e Editor, configurações do visual code

Basicos:
    váriaveis e os tipos (public, private)
    comentários
    Funções Start Update, função e Ienumerator
    Debug.Log

Objetos:
    Adicionar demoninadores [hide e serialize]
    Criar objeto em jogo
    Adicionar script
    chamar outros objetos em código e GetComponent

Especificos:
    Canva, e TMP_text
    Scene
    Prefab
    Objeto permanente (Personagem Selecionado)
    Scriptable object (PCsSO)
    Criar build

Objetivo final:
    Criar um texto na tela com um numero - feito
    Cada um criar um botão para fazer uma operação nesse número
*/

using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Aula : MonoBehaviour
{
    public int num = 0;
    public TMP_Text texto;
    void Start()
    {
        texto.text = "5";
    }
    void Adicionar()
    {
        num += 1;
    }
    void Update()
    {
        Adicionar();
    }
    
    public void Click()
    {s

    }
}
