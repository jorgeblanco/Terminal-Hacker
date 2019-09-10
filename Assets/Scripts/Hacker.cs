using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration
    private const int LevelCount = 3;
    private readonly string[][] _passwords = new string[LevelCount][];

    // Game State
    enum Screen
    {
       MainMenu,
       Password,
       Win
    }
    
    private string _userName = "Jorge";
    private int _level;
    private Screen _currentScreen;
    private string _password;

    private void Start()
    {
        _passwords[0] = new string[] {"tooth", "molar", "tongue"};
        _passwords[1] = new string[] {"ambulance", "paramedic", "critical"};
        _passwords[2] = new string[] {"environmental", "cataclysmic", "seismology"};
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        _currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + _userName); 
        Terminal.WriteLine("Welcome to the WordMaster 2000 Terminal"); 
        Terminal.WriteLine(""); 
        Terminal.WriteLine("What would you like to log into?"); 
        Terminal.WriteLine(""); 
        Terminal.WriteLine("Type 1 for Dr. Pinkman D.D.S. Office"); 
        Terminal.WriteLine("Type 2 for San Francisco EMT services"); 
        Terminal.WriteLine("Type 3 for the EPA Database"); 
        Terminal.WriteLine(""); 
        Terminal.WriteLine("Type exit to leave"); 
        Terminal.WriteLine("Enter your selection:"); 
    }

    private void OnUserInput(string input)
    {
        Debug.Log("User typed: " + input);
        if (input == "exit" || input == "quit" || input == "close" || input == "leave")
        {
            Quit();
        }
        else if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (_currentScreen == Screen.MainMenu)
        {
            HandleMainMenu(input);
        }
        else if (_currentScreen == Screen.Password)
        {
            HandlePassword(input);
        }
        else if (_currentScreen == Screen.Win)
        {
            HandleWin(input);
        }
    }

    private void HandleMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
           _level = int.Parse(input);
           _password = _passwords[_level - 1][Random.Range(0, _passwords[_level - 1].Length)];
           AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please select a valid target");
            DisplayMenuHint();
        }
    }

    private void DisplayMenuHint()
    {
        Terminal.WriteLine("Type menu to go back");
        Terminal.WriteLine("");
    }

    private void AskForPassword()
    {
        _currentScreen = Screen.Password;
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your password."); 
        Terminal.WriteLine("Hint: " + _password.Anagram()); 
        DisplayMenuHint();
    }

    private void HandleWin(string input)
    {
        ShowMainMenu();
    }

    private void HandlePassword(string input)
    {
        if (input == _password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Sorry, that's the wrong password");
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        _currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("You are in! Congratulations!");
        Terminal.WriteLine("Press Enter to return to the main menu");
    }
    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }
}
