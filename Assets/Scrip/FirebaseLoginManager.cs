using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirebaseLoginManager : MonoBehaviour
{
    // Đăng kí
    [Header("Register")]
    public InputField ipRegisterEmail;
    public InputField ipRegisterPassword;

    public Button buttonRegister;

    // Đăng nhập
    [Header("Sign In")]
    public InputField ipLoginEmail;
    public InputField ipLoginPassword;

    public Button buttonLogin;

    // Firebase Authentication  --> đăng kí, đăng nhập
    private FirebaseAuth auth;

    // Chuyển đổi qua lại giữa đăng kí, đăng nhập
    [Header("Switch form")]
    public Button buttonMoveToSignIn;
    public Button buttonMoveToRegister;

    public GameObject loginForm;
    public GameObject registerForm;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        buttonRegister.onClick.AddListener(RegisterAccountWithFirebase);
        buttonLogin.onClick.AddListener(SignInAccountWithFirebase);

        buttonMoveToRegister.onClick.AddListener(SwitchForm);
        buttonMoveToSignIn.onClick.AddListener(SwitchForm);
    }

    public void RegisterAccountWithFirebase()
    {
        string email = ipRegisterEmail.text;
        string password = ipRegisterPassword.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log(message: "Dang ki bi huy");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log(message: "Dang ki bi that bai");
                return;
            }
            if (task.IsCompleted)
            {
                Debug.Log(message: "Dang ki thanh cong");
                FirebaseUser user = task.Result.User;
                SceneManager.LoadScene("Menu");
            }
        });
    }

    public void SignInAccountWithFirebase()
    {
        string email = ipLoginEmail.text;
        string password = ipLoginPassword.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log(message: "Dang nhap bi huy");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log(message: "Dang nhap that bai");
                return;
            }
            if (task.IsCompleted)
            {
                Debug.Log(message: "Dang nhap thanh cong");
                FirebaseUser user = task.Result.User;

                // Chuyển màn chơi sau khi đăng nhập thành công
                SceneManager.LoadScene("Menu");
            }
        });
    }

    public void SwitchForm()
    {
        loginForm.SetActive(!loginForm.activeSelf);
        registerForm.SetActive(!registerForm.activeSelf);
    }
}
