using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Rage;

namespace RealLifePD
{
    class Utils
    {
        public static bool createINI()
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\rlpd.ini";
            StreamWriter archive = new StreamWriter(INIPath);
            string[] INIStandardData = {"[User]","", "// Here you put the name you want to be used in RealLifePD",
            "username=ChangeOnINI",
            "","",
            "// Here you can choose where is the standard (and init) departament location that you want to serve (necessary for RolePlay purposes)",
            "// 1 - Local Patrol (Vinewood, Rockford Hills, SouthLosSantos, East Los Santos)",
            "// 2 - County (Sandy Shores, Paleto Bay)",
            "standardLocation=1", "[Preferences]","realtime=true", "hungersystem=true" , "menuKey=F5", "buyMenuKey=F6"};

            foreach (string data in INIStandardData)
            {
                archive.WriteLine(data);
            }
            archive.Close();

            if (File.Exists(INIPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string[] readINI()
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\rlpd.ini";
            if (File.Exists(INIPath))
            {
                IniParser ini = new IniParser(INIPath);
                string[] values = { ini.GetSetting("User", "username"), ini.GetSetting("Preferences", "realtime"),
                ini.GetSetting("Preferences", "hungersystem"), ini.GetSetting("Preferences", "menuKey"), ini.GetSetting("Preferences", "hungersystem")};
                return values;
            }

            else
            {
                Game.LogTrivial("RealLifePD: INI file is missing, creating a new one...");
                bool generateINI = Utils.createINI();
                Game.LogTrivial("ReaLifePD: INI file create succesfully");
                Game.LogTrivial("RealLifePD: Reading INI File");
                string[] values = readINI();
                return values;
            }
        }

        public static void createUserINI()
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\userdata.ini";
            StreamWriter db = new StreamWriter(INIPath);
            string patent = "Trainee Officer";
            string exp = "0";
            string bankAccount = "2000";
            string[] data = { "[UserData]", "", "", "patent=" + patent, "exp="+exp ,"bankAccount="+bankAccount};
            foreach(string value in data)
            {
                db.WriteLine(value);
            }
            db.Close();
        
        
        }

        public static void sumBankAccount(int amount)
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\userdata.ini";
            IniParser ini = new IniParser(INIPath);
            using (FileStream fs = new FileStream(INIPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamWriter db = new StreamWriter(fs);
                int actualSalary = int.Parse(ini.GetSetting("UserData", "bankAccount"));
                string finalSalary = (actualSalary + amount).ToString();



                string patent = ini.GetSetting("UserData", "patent");
                string exp = ini.GetSetting("UserData", "exp");

                string[] data = { "[UserData]", "", "", "patent=" + patent, "exp=" + exp, "bankAccount=" + finalSalary };

                foreach (string value in data)
                { 
                    db.WriteLine(value);
                }
                db.Close();
            }
            }
        
        public static void sumExp(int exp)
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\userdata.ini";
            IniParser ini = new IniParser(INIPath);
            using (FileStream fs = new FileStream(INIPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamWriter db = new StreamWriter(fs);
                int actualExp = int.Parse(ini.GetSetting("UserData", "exp"));
                string finalExp = (actualExp + exp).ToString();

                string patent = ini.GetSetting("UserData", "patent");
                string bankAccount = ini.GetSetting("UserData", "bankAccount");

                string[] data = { "[UserData]", "", "", "patent=" + patent, "exp=" + finalExp, "bankAccount=" + bankAccount };

                foreach (string value in data)
                {
                    db.WriteLine(value);
                }
                db.Close();
            }
        }

        public static void editPatent(string patent)
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\userdata.ini";
            IniParser ini = new IniParser(INIPath);
            using (FileStream fs = new FileStream(INIPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamWriter db = new StreamWriter(fs);


                string exp = ini.GetSetting("UserData", "exp");
                string bankAccount = ini.GetSetting("UserData", "bankAccount");

                string[] data = { "[UserData]", "", "", "patent=" + patent, "exp=" + exp, "bankAccount=" + bankAccount};

                foreach (string value in data)
                {
                    db.WriteLine(value);
                }
                db.Close();
            }
        }

        public static string[] readINIUserData()
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\userdata.ini";
            if (File.Exists(INIPath))
            {
                IniParser db = new IniParser(INIPath);

                string patent = db.GetSetting("UserData", "patent");
                string exp = db.GetSetting("UserData", "exp");
                string bankAccount = db.GetSetting("UserData", "bankAccount");

                string[] data = { patent, exp, bankAccount };
                Globals.INIUserData = data;
                return data;
            }
            else
            {
                Utils.createUserINI();
                string[] data = Utils.readINIUserData();
                Globals.INIUserData = data;
                return data;
            }
        }

        public static void resetUserData()
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\userdata.ini";
            IniParser ini = new IniParser(INIPath);
            using (FileStream fs = new FileStream(INIPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                StreamWriter db = new StreamWriter(fs);

                string[] data = { "[UserData]", "", "", "patent=" + "Trainee Officer", "exp=" + "0", "bankAccount=" + "2000" };

                foreach (string value in data)
                {
                    db.WriteLine(value);
                }
                db.Close();
            }
        }
        public static void createVarINI(int hoursi, int minutesi)
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\uservardata.ini";
            StreamWriter varini = new StreamWriter(INIPath);
            string hoursz = "hoursi="+hoursi.ToString();
            string minutesz = "minutesi="+minutesi.ToString();

            string[] data = {"[Data]",hoursz, minutesz};

            foreach(string value in data)
            {
                varini.WriteLine(value);
            }
            varini.Close();
        }

        public static int[] readVarINI()
        {
            string INIPath = @"..\Grand Theft Auto V\Plugins\lspdfr\RealLifePD\uservardata.ini";
            IniParser varini = new IniParser(INIPath);
            int hoursi = int.Parse(varini.GetSetting("Data", "hoursi"));
            int minutesi = int.Parse(varini.GetSetting("Data", "minutesi"));

            int[] data = { hoursi, minutesi };

            return data;
        }

        public static int convertPMAM(int hours)
        {
            if (hours == 24)
            {
                hours = 0;
            }
            else if (hours == 23)
            {
                hours = 11;
            }
            else if (hours == 22)
            {
                hours = 10;
            }
            else if (hours == 21)
            {
                hours = 9;
            }
            else if (hours == 20)
            {
                hours = 8;
            }
            else if (hours == 19)
            {
                hours = 7;
            }
            else if (hours == 18)
            {
                hours = 6;
            }
            else if (hours == 17)
            {
                hours = 5;
            }
            else if (hours == 16)
            {
                hours = 4;
            }
            else if (hours == 15)
            {
                hours = 3;
            }
            else if (hours== 14)
            {
                hours = 2;
            }
            else if (hours == 1)
            {
                hours = 1;
            }
            return hours;
        }
    }
}
