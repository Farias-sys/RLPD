using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using RAGENativeUI.PauseMenu;
using System.Windows.Forms;



namespace RealLifePD
{
    class UIMainMenu
    {
        public static UIMenu MenuConstructor()
        {


            UIMenu menu = new UIMenu("ReaLifePD Clipboard", "");

            // Main menu itens

            var showAtualPatent = new UIMenuItem("Atual Patent = "+Utils.readINIUserData()[0]);

            var btnEndDuty = new UIMenuItem("End Duty");

            if (bool.Parse(Utils.readINI()[4]) == true)
            {
                menu.AddItems(showAtualPatent, btnEndDuty);
            }
            else
            {
                menu.AddItems(showAtualPatent, btnEndDuty);
            }

            menu.OnItemSelect += UIMainMenu.ItemSelectHandler;

            return menu;

            }

        public static void ItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "End Duty")
            {
                Game.LogTrivial("RealLifePD: EndDuty functon called");
                Economy.playerRegisterActivity();
                Game.DisplayNotification("RLPD: Duty ended successfully");
                Game.LogTrivial("RealLifePD: Duty ended successfully.");
            }
        }
    }
}
