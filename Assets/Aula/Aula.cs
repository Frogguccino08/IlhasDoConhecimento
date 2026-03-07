/*
Variaveis:
    string
    int
    float (coloca um f no final de numeros quebrados como "1.4f")
    bool

Tipos de variaveis e funções:
    public (ver no inspetor e ser usada em outros scripts)
    private (exclusivo para aquele script)

Testes:
    Debug.Log(""); (Para escrever no console).
    // Comentar uma linha */    /* */  /*para comentar uma parte

Funções:
    public void Nome(int i){ }
    primeiro se é publico ou privado, depois o tipo da função normalmente void ou Ienumerator, depois o nome, dentro do () váriaveis da funções se tiver, { } Código
    StartCoroutine(FunçãoIenumerator()); Inicia uma função Ienumerator
    yield return FunçãoIenumerator(); Dentro de outro Ienumerator espera a função chamada para continuar a função maior

    void Start(){ } função que acontece ao iniciar
    void Updae() { } função que acontece todo frame (60fps)

Fields:
    [HideInInspector] Faz variaveis publicas não aparecerem no inspetor
    [SerializeField] Faz variaveis privadas aparecerem no inspetor

    Colocado na linha de cima de váriaveis

Chamar objetos:
    public GameObject nome; variavel do objeto de jogo, pode trocar o "GameObject" por componentes para facilitar, principalmente em scripts
    GetComponent<Nome do componente>() acha um componente dentro de um outro objeto
    .nome encontra variaveis e funções dentro de um componente

Objetos importantes:
    Script: O arquivo de código que você conecta a um objeto
    Scene: O arquivo que salva uma sala do jogo
    Canva: Permite colocar imagens sem estarem ligadas a um objeto, usado para colocar textos. feito para criar UI
    TMP_Text: Texto em tela dos jogos

Partes da tela:
    Scene: Tela do jogo onde você mexe componentes
    Game: O jogo como ele será rodado
    Hierarquia: Mostra todos os objetos em cena e quais objetos são filhos de quais objetos
    Inspetor: Onde mostra todos os componentes do objeto que você selecionou

Miscs:
    ScriptableObject: Um tipo de arquivo criado pelo próprio dev
*/

using UnityEngine;

public class Aula : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
