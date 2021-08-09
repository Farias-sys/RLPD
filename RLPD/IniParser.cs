using System;
using System.IO;
using System.Collections;

public class IniParser
{
    private Hashtable keyPairs = new Hashtable();
    private string iniFilePath;

    private struct SectionPair
    {
        public string Section;
        public string Key;
    }

    // Open the INI at the given path

    public IniParser(string iniPath)
    {
        string strLine = null;
        string currentRoot = null;
        string[] keyPair = null;
        iniFilePath = iniPath;

        using(FileStream fs = new FileStream(iniPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            StreamReader iniFile = new StreamReader(fs);
            strLine = iniFile.ReadLine();

            while (strLine != null)
            {
                strLine = strLine.Trim().ToUpper();

                if (strLine != "")
                {
                    if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                    {
                        currentRoot = strLine.Substring(1, strLine.Length - 2);
                    }

                    else
                    {
                        keyPair = strLine.Split(new char[] { '=' }, 2);

                        SectionPair sectionPair;
                        string value = null;

                        if (currentRoot == null)
                        {
                            currentRoot = "ROOT";
                        }

                        sectionPair.Section = currentRoot;
                        sectionPair.Key = keyPair[0];

                        if (keyPair.Length > 1)
                        {
                            value = keyPair[1];
                        }
                        keyPairs.Add(sectionPair, value);
                    }
                }
                strLine = iniFile.ReadLine();
            }
            iniFile.Close();
        }

    }
    public String GetSetting(String sectionName, String settingName)
    {
        SectionPair sectionPair;
        sectionPair.Section = sectionName.ToUpper();
        sectionPair.Key = settingName.ToUpper();

        return (String)keyPairs[sectionPair];
    }

    public String[] EnumSection(String sectionName)
    {
        ArrayList tmpArray = new ArrayList();

        foreach (SectionPair pair in keyPairs.Keys)
        {
            if (pair.Section == sectionName.ToUpper())
                tmpArray.Add(pair.Key);
        }

        return (String[])tmpArray.ToArray(typeof(String));
    }
}