using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class AData
{
    public string email;
    public string password;

    public AData(string email, string password)
    {
        this.email = email;
        this.password = password;
    }
}

public class AccountData : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;

    public AData ReturnClass()
    {
        return new AData(emailInput.text, passwordInput.text);
    }

    public void SetUI(AData aData)
    {
        emailInput.text = aData.email;
        passwordInput.text = aData.password;
    }
}
