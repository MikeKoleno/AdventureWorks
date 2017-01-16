using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureWorks
{
    public class NotificationService
    {
        public static void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
