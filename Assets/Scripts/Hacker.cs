using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the WordMaster 2000 Terminal"); 
        Terminal.WriteLine(""); 
        Terminal.WriteLine("What would you like to log into?"); 
        Terminal.WriteLine(""); 
        Terminal.WriteLine("Type 1 for Dr. Pinkman D.D.S Office"); 
        Terminal.WriteLine("Type 2 for San Francisco EMT services"); 
        Terminal.WriteLine("Type 3 for the EPA Database"); 
        Terminal.WriteLine(""); 
        Terminal.WriteLine("Enter your selection:"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
