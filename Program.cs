using System;
using System.Diagnostics;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace PythonRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to python file to run
            string pathToFile = @"C:\Users\rvive\source\repos\PythonRunner\PythonRunner\mycode.py";

            //METHOD 1 - USING Process
            runPythonProcess(pathToFile);


            //METHOD 2 - 
            runPythonEngine(pathToFile);

            //METHOD 3 - Setting up python environment [Virtual Environment]
            //https://docs.microsoft.com/en-us/visualstudio/python/managing-python-environments-in-visual-studio?view=vs-2019#creating-an-environment-for-an-existing-interpreter

        }

        
        //Method 1 - Using PROCESS
        private static void runPythonProcess(string pathToFile)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "C:/Python27/python.exe";                          //Path to python exe
            processInfo.Arguments = string.Format("{0} {1}", pathToFile, null);       //Path to file and arguments, null here
            processInfo.UseShellExecute = false;                                      //
            processInfo.RedirectStandardOutput = true;                                //Capture python output
            using (Process process = Process.Start(processInfo))                      //Start python process
            {
                using (System.IO.StreamReader reader = process.StandardOutput)  //Get output
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);                                       //Print output
                }
            }
        }

        //Method 2 - Using IronPython
        private static void runPythonEngine(string pathToFile)
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.ExecuteFile(pathToFile);
        }

 
    }
}
