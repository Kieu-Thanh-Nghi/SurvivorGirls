using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayService : MonoBehaviour
{
    public static GooglePlayService Instance;

    /// <summary>
    /// Kiểm tra đã login Google Play chưa
    /// </summary>
    public bool IsAuthenticated =>
        PlayGamesPlatform.Instance.localUser.authenticated;

    private bool isSigningIn;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Auto login khi game start
        SignIn();
    }

    /// <summary>
    /// Đăng nhập Google Play Games
    /// </summary>
    public void SignIn(Action<bool> callback = null)
    {
        // Nếu login rồi
        if (IsAuthenticated)
        {
            callback?.Invoke(true);
            return;
        }

        // Tránh spam login nhiều lần
        if (isSigningIn)
        {
            callback?.Invoke(false);
            return;
        }

        isSigningIn = true;

        PlayGamesPlatform.Instance.Authenticate(result =>
        {
            isSigningIn = false;

            bool success =
                result == SignInStatus.Success;

            Debug.Log(
                $"Google Play Login: {success}"
            );

            callback?.Invoke(success);
        });
    }

    /// <summary>
    /// Chạy action nếu đã login,
    /// nếu chưa thì login trước
    /// </summary>
    public void ExecuteWhenAuthenticated(Action action)
    {
        if (IsAuthenticated)
        {
            action?.Invoke();
            return;
        }

        SignIn(success =>
        {
            if (success)
            {
                action?.Invoke();
            }
        });
    }
}
