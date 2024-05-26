using System;
using System.Windows.Forms;

namespace Assignment7_V2;

static class Program
{
    [STAThread]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TheGame());
    }
}
