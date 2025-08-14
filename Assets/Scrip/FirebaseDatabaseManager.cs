using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseDatabaseManager : MonoBehaviour
{
    private DatabaseReference reference;

    private void Awake()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void Start()
    {
        WriteDatabase(id: "123", message: "Xin chao the gioi");
        ReadDatabase(id: "123");
    }

    public void WriteDatabase(string id, string message)
    {
        reference.Child(pathString: "Users").Child(id).SetValueAsync(message).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log(message: "Ghi du lieu thanh cong");
            }
            else
            {
                Debug.Log("Ghi du lieu that bai: " + task.Exception);
            }
        });
    }

    public void ReadDatabase(string id)
    {
        reference.Child(pathString: "Users").Child(id).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log("Doc du lieu thanh cong: " + snapshot.Value.ToString());
            }
            else
            {
                Debug.Log("Doc du lieu that bai: " + task.Exception);
            }
        });
    }
}
