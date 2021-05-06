using Rocketcress.UIAutomation;
using Rocketcress.UIAutomation.Controls;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BATClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var notification = new UITestControl(By.CPath("/Window/*[@id='PriorityToastView']").AndName("Brave", ByOptions.UseContains));
                var closeBtn = new UITestControl(By.CPath("/Button[@name='Close']"), notification);
                var dismissBtn = new UITestControl(By.CPath("/Button[@id='DismissButton']"), notification);
                if (notification.Exists)
                {
                    Console.WriteLine("found");
                    var existingBtn = closeBtn.Exists ? closeBtn : dismissBtn;
                    var currentCursorPos = Cursor.Position;
                    existingBtn.MoveMouseToClickablePoint();

                    existingBtn.Click();
                    Cursor.Position = currentCursorPos;
                    Thread.Sleep(500);
                }
                Thread.Sleep(100);
            }
        }


    }
}
