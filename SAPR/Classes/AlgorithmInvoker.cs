using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;

namespace SAPR.Classes
{
    public class AlgorithmInvoker
    {
        public List<Algorithm> Algorithms { get { return m_algorithms; } }

        public AlgorithmInvoker(string path)
        {
            m_path = path;
            m_algorithms = new List<Algorithm>();

            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFiles(m_path);
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }

            List<Assembly> testAssemblies = new List<Assembly>();                     

            foreach (string fileName in files)
            { 
                try
                {
                    string fullPath = fileName[1] != ':' ?
                        Environment.CurrentDirectory + "\\" + fileName :
                        fileName;
                    Assembly testAssembly = Assembly.LoadFile(fullPath);
                    testAssemblies.Add(testAssembly);
                }
                catch (BadImageFormatException)
                {
                }
            }

            foreach (Assembly assembly in testAssemblies)
            {
                string name = null;
                MethodInfo calculateMethod = null;

                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
                    bool isCalcMethod = false, isGetNameMethod = false;
                    foreach (MethodInfo method in methods)
                    {
                        if (method.ToString() == m_methodCalculateName)
                        {
                            calculateMethod = method;
                            if (isGetNameMethod)
                                break;
                            isCalcMethod = true;
                            continue;
                        }
                        if (method.ToString() == m_methodGetName)
                        {
                            name = (string)method.Invoke(null, null);
                            if (isCalcMethod)
                                break;
                            isGetNameMethod = true;
                        }
                    }

                    if (name != null && calculateMethod != null)
                        break;
                }

                if (name != null && calculateMethod != null)
                    m_algorithms.Add(new Algorithm(name, calculateMethod));
            }
        }

        private string m_path;
        private List<Algorithm> m_algorithms;

        private static string m_methodCalculateName = "Int32[][] Calculate(Int32[,], Int32, Int32[])";
        private static string m_methodGetName = "System.String GetName()";

        public class Algorithm
        {
            public string Name { get { return m_name; } }

            public Algorithm(string name, MethodInfo calculateMethod)
            {
                m_name = name;
                m_calculateMethod = calculateMethod;
            }

            public int[][] Calculate(int[,] adjMatrix, int countPart, 
                int[] countVertexInParts)
            {
                return (int[][])m_calculateMethod.Invoke(null, new object[] {
                    adjMatrix, countPart, countVertexInParts });
            }

            private string m_name;
            private MethodInfo m_calculateMethod;
        }
    }
}
