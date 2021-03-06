using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Newtonsoft.Json;

public class PlayFabManager : MonoBehaviour
{
    //Code to connect database and input and output data
    //Account menu page, register account and login account and aslo reset password 
    // have added code for leader board but couldnt complete because different coding styles was hard to conver into the data type I needed.

    [Header("UI")]

    //Fields that I needed from the UI
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;
    public InputField usernameInput;

    //Resiter button functions 
    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false,
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    //On register success - code for message output
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
    }

    //Changing scences 
    public GameObject usernameWindow;
    public GameObject hideAccountWindow;
    //Loggin button functions 
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    //What happens if login successful
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Logged In!";
        Debug.Log("Successful Login");
        GetData();

        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if (name == null)
        {
            usernameWindow.SetActive(true);
            hideAccountWindow.SetActive(false);
        }
    }
    //Button for username - updates username to database
    public void submitUsernameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = usernameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    //Displays message when username is saved.
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Username Saved!");

    }
    //Reset Password function 
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "8C408"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);

    }
    //Message after email is sent to reset password
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Reset Password Email Sent!";
    }

    /* Extra code that i used to connect database and test.
    //Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
        
    }
    */

    //How to save and send data to database but this code below is not used.
    public AccountData AData;
    public AccountData[] characterBoxes;

    public void SaveData()
    {
        List<AData> AccountData = new List<AData>();
        foreach (var item in characterBoxes)
        {
            AccountData.Add(item.ReturnClass());
        }
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"AData", JsonConvert.SerializeObject(AData) }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful user data send!");
    }

    public void GetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnAccountDataRecieved, OnError);
    }
    void OnAccountDataRecieved(GetUserDataResult result)
    {
        Debug.Log("Data Recieved!");
        if (result.Data != null & result.Data.ContainsKey("AData"))
        {
            List<AData> AccountData = JsonConvert.DeserializeObject<List<AData>>(result.Data["AData"].Value);
            for (int i = 0; i < characterBoxes.Length; i++)
            {
                characterBoxes[i].SetUI(AccountData[i]);
            }
        }
    }

    //Sending leaderboard for display couldnt implement due to codeing differently from another member.
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successful Leaderboard Sent");
    }

    //Displays error messages to the game.
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        //Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
}