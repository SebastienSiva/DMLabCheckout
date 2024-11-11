using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class ButtonActions : MonoBehaviour
{

    public void login()
    {
        //ExecuteProcessTerminal("echo 'Testing' > /Users/ssiva/Desktop/testing.txt");
        ExecuteProcessTerminal("/usr/bin/osascript /Applications/DMCheckOutBtns/StartChrome.scpt");
        //ExecuteProcessTerminal("/usr/bin/open -a \"Google Chrome\"");
        //StartCoroutine(cmdLineProcess("usr/bin/open -a \"Google Chrome\""));
        //StartCoroutine(cmdLineProcess("/bin/pwd"));
        ///usr/bin/open -a "Google Chrome"
    }

    public void logout()
    {
        ExecuteProcessTerminal("/usr/bin/osascript /Applications/DMCheckOutBtns/QuitChrome.scpt");
        //StartCoroutine(cmdLineProcess("/usr/bin/osascript /Applications/DMCheckOutBtns/QuitChrome.scpt"));
    }


    private string ExecuteProcessTerminal(string argument)
    {
        try
        {
            //UnityEngine.Debug.LogError("============== Start Executing [" + argument + "] ===============");
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "/bin/bash",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = " -c \"" + argument + " \""
            };
            Process myProcess = new Process
            {
                StartInfo = startInfo
            };
            myProcess.Start();
            string output = myProcess.StandardOutput.ReadToEnd();
            //UnityEngine.Debug.LogError(output);
            myProcess.WaitForExit();
            //UnityEngine.Debug.LogError("============== End ===============");

            return output;
        }
        catch (Exception e)
        {
            print(e);
            return null;
        }
    }

    /*
    private IEnumerator cmdLineProcess(string cmd)
    {

        ProcessStartInfo startInfo = new ProcessStartInfo(cmd);
        startInfo.WorkingDirectory = "/";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();

        string line = process.StandardOutput.ReadLine();
        UnityEngine.Debug.LogError(line);

        process.WaitForExit();
        yield return null;
    }
    */


    private IEnumerator cmdLineProcess(string cmd)
    {

        ProcessStartInfo startInfo = new ProcessStartInfo("/bin/bash");
        startInfo.WorkingDirectory = "/";
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();

        process.StandardInput.WriteLine(cmd);
        process.StandardInput.WriteLine("exit");  // if no exit then WaitForExit will lockup your program
        process.StandardInput.Flush();

        string line = process.StandardOutput.ReadLine();
        UnityEngine.Debug.LogError(cmd);
        UnityEngine.Debug.LogError(line);

        process.WaitForExit();
        yield return null;
    }
    
}
