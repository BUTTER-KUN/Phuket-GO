using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using System;

public class Authmanager1 : MonoBehaviour
{
    // Login UI references
    public GameObject loginPanel;
    public InputField loginEmailInput;
    public InputField loginPasswordInput;
    public Text loginFeedbackText;
    public Button openRegistrationButton;

    // Registration UI references
    public GameObject registrationPanel;
    public InputField registerEmailInput;
    public InputField registerPasswordInput;
    public InputField confirmPasswordInput;
    public Text registrationFeedbackText;
    public Button closeRegistrationButton;

    private FirebaseAuth auth;

    // Main thread execution
    private readonly Queue<Action> _executeOnMainThreadQueue = new Queue<Action>();

    private void Update()
    {
        while (_executeOnMainThreadQueue.Count > 0)
        {
            _executeOnMainThreadQueue.Dequeue().Invoke();
        }
    }

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            // Initialize Firebase Auth
            auth = Firebase.Auth.FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance);
        });
    }

    public void Login()
    {
        string email = loginEmailInput.text;
        string password = loginPasswordInput.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            _executeOnMainThreadQueue.Enqueue(() =>
            {
                if (task.IsCanceled)
                {
                    loginFeedbackText.text = "Login was canceled.";
                    return;
                }
                if (task.IsFaulted)
                {
                    loginFeedbackText.text = "Login failed: " + task.Exception;
                    return;
                }

                FirebaseUser user = task.Result.User;
                loginFeedbackText.text = "User logged in successfully: " + user.Email;
            });
        });
    }

    public void OpenRegistrationPanel()
    {
        registrationPanel.SetActive(true);
        loginPanel.SetActive(false);
    }

    public void Register()
    {
        if (registerPasswordInput.text != confirmPasswordInput.text)
        {
            registrationFeedbackText.text = "Passwords do not match!";
            return;
        }

        string email = registerEmailInput.text;
        string password = registerPasswordInput.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            _executeOnMainThreadQueue.Enqueue(() =>
            {
                if (task.IsCanceled)
                {
                    registrationFeedbackText.text = "Registration was canceled.";
                    return;
                }
                if (task.IsFaulted)
                {
                    registrationFeedbackText.text = "Registration failed: " + task.Exception;
                    return;
                }

                FirebaseUser newUser = task.Result.User; // Corrected line

                // Save user data in Firestore after successful registration
                FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
                DocumentReference docRef = db.Collection("users").Document(newUser.UserId);

                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "email", email }
                    // Add other data as needed
                };

                docRef.SetAsync(user).ContinueWith(firestoreTask =>
                {
                    _executeOnMainThreadQueue.Enqueue(() =>
                    {
                        if (firestoreTask.IsCompleted && !firestoreTask.IsFaulted)
                        {
                            registrationFeedbackText.text = "User registered successfully: " + newUser.Email;
                        }
                        else
                        {
                            registrationFeedbackText.text = "User registered but failed to store in Firestore: " + firestoreTask.Exception;
                        }
                    });
                });
            });
        });
    }

    public void CloseRegistrationPanel()
    {
        registrationPanel.SetActive(false);
        loginPanel.SetActive(true);
    }
}
