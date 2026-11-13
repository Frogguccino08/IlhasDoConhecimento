using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassarInput : MonoBehaviour
{
    [SerializeField]
    TMP_InputField[] inputs = new TMP_InputField[5];

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            GameObject atual = EventSystem.current.currentSelectedGameObject;
            TrocarInput(atual);
        }

        if(Input.GetKeyUp(KeyCode.Return))
        {
            GameObject atual = EventSystem.current.currentSelectedGameObject;
            Enter(atual);
        }
    }

    void TrocarInput(GameObject atual)
    {
        int i = 0;

        if(atual == null)
        {
            inputs[0].Select();
            inputs[0].ActivateInputField();
            Debug.Log("Não tinha nada clicado");
            i = 0;
            return;
        }
        else
        {
            foreach (TMP_InputField input in inputs)
            {
                if(atual == input.gameObject)
                {
                    if(i == 4)
                    {
                        i = 0;
                        atual = inputs[0].gameObject;
                        inputs[0].Select();
                        inputs[0].ActivateInputField();
                        break;
                    }

                    atual = inputs[i + 1].gameObject;
                    inputs[i + 1].Select();
                    inputs[i + 1].ActivateInputField();
                    i++;
                    
                    Debug.Log("Passou pro proximo. Input atual: " + atual);
                    break;
                }
                else
                {
                    i++;
                }
            }
        }
    }

    void Enter(GameObject atual)
    {
        if(atual != null)
        {
            int i = 0;
            foreach(TMP_InputField input in inputs)
            {
                if(atual == input.gameObject)
                {
                    if(i < 2)
                    {
                        gameObject.GetComponent<FirebaseRegister>().Login();
                    }
                    else
                    {
                        gameObject.GetComponent<FirebaseRegister>().RegistrarConta();
                    }
                }
                else{i++;}
            }
        }
        
    }
}
