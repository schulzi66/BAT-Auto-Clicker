using Rocketcress.UIAutomation;
using Rocketcress.UIAutomation.Controls;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BATClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Create("./log.txt");
            while (true)
            {
                try
                {
                    var notification = new UITestControl(By.CPath("/Window/*[@id='PriorityToastView']").AndName("Brave", ByOptions.UseContains));
                    if (notification.Exists)
                    {
                        var closeBtn = new UITestControl(By.CPath("/Button[@name='Close']"), notification);
                        var dismissBtn = new UITestControl(By.CPath("/Button[@id='DismissButton']"), notification);

                        var existingBtn = closeBtn.Exists ? closeBtn : dismissBtn;
                        var currentCursorPos = Cursor.Position;
                        existingBtn.MoveMouseToClickablePoint();

                        existingBtn.Click();
                        Cursor.Position = currentCursorPos;
                        Thread.Sleep(500);
                    }
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    File.AppendAllText("./log.txt", ex.StackTrace);
                }

            }
        }


    }
}
