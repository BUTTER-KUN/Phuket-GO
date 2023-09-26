using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginScript : MonoBehaviour
{
    // Login UI elements
    public InputField usernameInput;
    public InputField passwordInput;
    public Text messageText;
    public GameObject registrationPanel; // Link to the RegistrationPanel

    // Registration UI elements
    public InputField registerUsernameInput;
    public InputField registerPasswordInput;
    public InputField confirmPasswordInput;

    private void Start()
    {
        // Ensure the registration panel is hidden on start
        if (registrationPanel)
        {
            registrationPanel.SetActive(false);
        }
    }

    public void OnLoginButtonClicked()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        // Here, you'd typically send a request to your backend to verify credentials.
        // For this example, we'll just check if the username is "admin" and the password is "password".

        if (usernameInput.text == "admin" && passwordInput.text == "password")
        {
            messageText.text = "Login successful!";
            // Load another scene or perform some action.
        }
        else
        {
            messageText.text = "Login failed!";
        }

        yield return null;
    }

    public void OnRegisterButtonClicked()
    {
        // Show the registration panel
        if (registrationPanel)
        {
            registrationPanel.SetActive(true);
        }
    }

    public void OnRegisterSubmitClicked()
    {
        if (registerPasswordInput.text == confirmPasswordInput.text)
        {
            // Here, you'd typically send a request to your backend to create a new user.
            // For this example, we'll just display a success message.
            messageText.text = "Registration successful!";
            if (registrationPanel)
            {
                registrationPanel.SetActive(false);
            }
        }
        else
        {
            messageText.text = "Passwords do not match!";
        }
    }
}
