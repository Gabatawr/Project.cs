using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWinAPI.Homework
{
    public class Task_1
    {
        public static void Run()
        {
            List<(string, string)> list = new List<(string, string)>
            {
                ("Kashyrin Artem", "About"),
                ("Test 2", "2"),
                ("Test 3", "3"),
                ("Test 4", "4"),
                ("Test 5", "5"),
                (@"https://github.com/Gabatawr", "GitHub")
            };

            int i = 0;
            User32.MB_RValue ret;
            User32.MB_Button btns = User32.MB_Button.MB_CANCELTRYCONTINUE;

            do 
            {
                if (i == list.Count - 1) btns = User32.MB_Button.MB_OK;
                ret = User32.MessageBox(new IntPtr(0), list[i].Item1, list[i].Item2, btns);
                i += ret == User32.MB_RValue.IDTRYAGAIN ? 0 : 1;

            } while (ret != User32.MB_RValue.IDCANCEL && ret != User32.MB_RValue.IDOK);
        }
    }
}
