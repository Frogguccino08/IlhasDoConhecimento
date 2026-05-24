using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;

public class FirebaseRegister : MonoBehaviour
{
    public TMP_InputField inputNome;
    public TMP_InputField inputEmail;
    public TMP_InputField inputSenha;

    public TMP_InputField inputEmailLogin;
    public TMP_InputField inputSenhaLogin;

    private FirebaseAuth auth;
    private DatabaseReference DBreference;

    public TelaLogin loginScreen;
    public TMP_Text textoCadastro;
    public TMP_Text textoLogin;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.GetInstance(
            "https://ilhas-do-conhecimento-default-rtdb.firebaseio.com/"
        ).RootReference;
    }

    public void RegistrarConta()
    {
        string nome = inputNome.text;
        string email = inputEmail.text;
        string senha = inputSenha.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, senha).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Cadastro cancelado.");
                return;
            }

            if (task.IsFaulted)
            {
                FirebaseException firebaseEx =
                    task.Exception.GetBaseException() as FirebaseException;

                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                switch (errorCode)
                {
                    case AuthError.InvalidEmail:
                        textoCadastro.text = "Email inválido";
                        break;

                    case AuthError.WeakPassword:
                        textoCadastro.text = "Senha muito curta";
                        break;

                    case AuthError.EmailAlreadyInUse:
                        textoCadastro.text = "Email já cadastrado";
                        break;

                    default:
                        textoCadastro.text = "Erro ao cadastrar";
                        break;
                }

                return;
            }

            FirebaseUser newUser = task.Result.User;

            // Define o nome do usuário no Firebase Auth
            UserProfile profile = new UserProfile
            {
                DisplayName = nome
            };

            newUser.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(profileTask =>
            {
                if(profileTask.IsCompleted)
                {
                    Debug.Log("Perfil atualizado!");

                    // Cria save padrão
                    Info data = new Info(nome);

                    string json = JsonUtility.ToJson(data);

                    DBreference.Child("saves")
                            .Child(newUser.UserId)
                            .SetRawJsonValueAsync(json);

                    Debug.Log("Save inicial criado!");

                    Debug.Log("Usuário criado com sucesso!");
                    textoCadastro.text = "Cadastro feito com sucesso";
                    inputNome.text = "";
                    inputEmail.text = "";
                    inputSenha.text = "";
                }
                else
                {
                    Debug.LogError("Erro ao salvar nome do usuário.");
                }
            });
        });
    }

    public void Login()
    {
        string email = inputEmailLogin.text;
        string senha = inputSenhaLogin.text;

        auth.SignInWithEmailAndPasswordAsync(email, senha)
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Login cancelado.");
                return;
            }

            if (task.IsFaulted)
            {
                Debug.LogError("Erro no login: " + task.Exception);
                textoLogin.text = "Email ou senha incorreto";
                return;
            }

            FirebaseUser user = task.Result.User;

            Debug.Log("Login realizado com sucesso!");
            inputEmailLogin.text = "";
            inputSenhaLogin.text = "";
            inputEmail.text = "";
            inputSenha.text = "";
            inputNome.text = "";
            textoLogin.text = "";
            textoCadastro.text = "";
            Debug.Log("Usuário: " + user.Email);

            InfoPlayer.instance.CarregarInfo();

            loginScreen.FecharTela();
        });
    }

    public void LogOut()
    {
        auth.SignOut();
    }
}
