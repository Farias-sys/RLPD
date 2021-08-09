using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;


namespace RealLifePD
{
    class Economy
    {

        public static void playerEntered()
        {
            string time = DateTime.Now.TimeOfDay.ToString();
            int varHour = int.Parse(time.Substring(0, 2));
            int varMinutes = int.Parse(time.Substring(3, 2));


            if (varHour > 12)
            {
                varHour = Utils.convertPMAM(varHour);
            }

            Utils.createVarINI(varHour, varMinutes);
            

        }

        public static void playerRegisterActivity()
        {
            int hoursi = Utils.readVarINI()[0];
            int minutesi = Utils.readVarINI()[1];

            string leaveTime = DateTime.Now.TimeOfDay.ToString();
            int leaveHours = int.Parse(leaveTime.Substring(0, 2));
            int leaveMinutes = int.Parse(leaveTime.Substring(3, 2));

            if (leaveHours > 12)
            {
                leaveHours = Utils.convertPMAM(leaveHours);
            }

            int totalHours = leaveHours - hoursi;
            if (leaveMinutes + minutesi >= 60)
            {
                int totalMinutes = leaveMinutes + minutesi;
                totalHours += (totalMinutes / 60);
            }

            Utils.sumExp(totalHours * 100);

            int exp = int.Parse(Utils.readINIUserData()[1]);

            if(exp >= 3000)
            {
                Utils.editPatent("Incorporated Officer");
            }
            else if(exp >= 5000)
            {
                Utils.editPatent("3st Officer");
            }
            else if(exp >= 6000)
            {
                Utils.editPatent("2st Officer");
            }
            else if(exp >= 10000)
            {
                Utils.editPatent("1st Officer");
            }
            else if(exp >= 12000)
            {
                Utils.editPatent("Senior Officer");
            }
            else if(exp >= 15000)
            {
                Utils.editPatent("Sergeant");
            }

            string patent = Utils.readINIUserData()[0];
            int salary = 0;

            if (patent == "Trainee Officer")
            {
                salary = 1000 * totalHours;
            }
            else if (patent == "Incorporated Officer")
            {
                salary = 1500 * totalHours;
            }
            else if (patent == "3st Officer")
            {
                salary = 2000 * totalHours;
            }
            else if (patent == "2st Officer")
            {
                salary = 2500 * totalHours;
            }
            else if (patent == "1st Officer")
            {
                salary = 3000 * totalHours;
            }
            else if (patent == "Senior Officer")
            {
                salary = 4000 * totalHours;
            }
            else if (patent == "Sergeant")
            {
                salary = 5000 * totalHours;
            }
            Utils.sumBankAccount(salary);

        }
    }
}
