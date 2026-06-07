using System;
using System.Collections.Generic;
using System.Text;

namespace Cambios.Servicos
{
    public class DialogService
    {
        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
