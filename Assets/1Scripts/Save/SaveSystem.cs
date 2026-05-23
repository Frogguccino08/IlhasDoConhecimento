using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;

public static class SaveSystem
{
    private static DatabaseReference DBreference =
        FirebaseDatabase.GetInstance(
            "https://ilhas-do-conhecimento-default-rtdb.firebaseio.com/"
        ).RootReference;

    // SALVAR
    public static void Save(InfoPlayer perso)
    {
        string uid = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        Info data = new Info(perso);

        string json = JsonUtility.ToJson(data);

        DBreference.Child("saves")
                   .Child(uid)
                   .SetRawJsonValueAsync(json);

        Debug.Log("Save enviado para Firebase!");
    }

    // CARREGAR
    public static void Load(System.Action<Info> callback)
    {
        string uid = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        DBreference.Child("saves")
                   .Child(uid)
                   .GetValueAsync()
                   .ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                if(snapshot.Exists)
                {
                    string json = snapshot.GetRawJsonValue();

                    Info data = JsonUtility.FromJson<Info>(json);

                    Debug.Log("Save carregado!");

                    callback?.Invoke(data);
                }
                else
                {
                    Debug.Log("Nenhum save encontrado.");
                    callback?.Invoke(null);
                }
            }
        });
    }

    public static void CriarSaveInicial()
{
    FirebaseUser user = FirebaseAuth.DefaultInstance.CurrentUser;

    if(user == null)
    {
        Debug.LogError("Usuário não logado.");
        return;
    }

    string uid = user.UserId;

    Info data = new Info(user.DisplayName);

    string json = JsonUtility.ToJson(data);

    DBreference.Child("saves")
               .Child(uid)
               .SetRawJsonValueAsync(json);

    Debug.Log("Save inicial criado!");
}
}
