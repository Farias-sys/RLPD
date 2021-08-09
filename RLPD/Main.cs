using System;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using RAGENativeUI.PauseMenu;
using LSPD_First_Response.Mod.API;
using System.Windows.Forms;

namespace RealLifePD
{
    public class Main : Plugin
    {
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
            Game.LogTrivial("RealLifePD " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been initialised.");
            Game.LogTrivial("Ian is the best");

        }

        public override void Finally()
        {
            StoresBlips.proccessBlips(false);
            Game.LogTrivial("RLPD: cleaned up");
        }

        public static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty)
            {
                string[] ini = Utils.readINI(); // Reading INI with preferences of user

                // Catch the menuKey specified by user
                KeysConverter menuKey = new KeysConverter();
                Keys mk = (Keys)menuKey.ConvertFromString(ini[3]);

                // Catch preferences (Real Time system)
                bool activeRT = bool.Parse(ini[1]);

                Utils.readINIUserData(); // Reading userdata 

                // Catching time that player entered

                Economy.playerEntered();

                // Main Menu pool catch

                UIMenu menu = UIMainMenu.MenuConstructor();
                MenuPool mainMenu = new MenuPool();
                mainMenu.Add(menu);

                // Starting blips if hunger system is on

                if (true)
                {
                    if (bool.Parse(Utils.readINI()[4]) == true)
                    {
                        StoresBlips.proccessBlips(true);
                    }
                    else
                    {
                        // Does nothing
                    }
                }

                // Player

                Ped player = Game.LocalPlayer.Character;

                // GameFiber

                GameFiber.StartNew(() =>
                {
                    while (true)
                    {
                        GameFiber.Yield();
                        mainMenu.ProcessMenus();
                        if (Game.IsKeyDown(mk)) // the open/close trigger
                        {
                            if (menu.Visible)
                            {
                                // close the menu
                                menu.Visible = false;
                            }
                            else if (!UIMenu.IsAnyMenuVisible && !TabView.IsAnyPauseMenuVisible) // check that no menus are visible
                            {
                                // open the menu
                                menu.Visible = true;
                            }
                        }
                        if (activeRT == true)
                        {
                            World.TimeOfDay = DateTime.Now.TimeOfDay;
                        }
                        if (player.Health == 0)
                        {
                            Utils.resetUserData();
                        }
                    }
                }
               );

            }
        }
    }
}
