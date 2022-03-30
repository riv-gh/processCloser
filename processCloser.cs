using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace processCloser
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string configFile = Process.GetCurrentProcess().ProcessName + ".txt";
                if (args.Length != 0)
                {
                    configFile = args[0];
                }

                string[] processNamesToKill_arr = File.ReadAllLines(configFile);

                foreach (string processNamesToKill in processNamesToKill_arr)
                {
                    try
                    {
                        foreach (Process proc in Process.GetProcessesByName(processNamesToKill))
                        {
                            proc.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(null, ex.Message, "Помилка закриття " + processNamesToKill, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show(null, "Можно продовжити роботу :)", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(null, exc.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
