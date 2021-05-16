using Rocketcress.UIAutomation;
using Rocketcress.UIAutomation.Controls;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace BATClicker
{
    class Program
    {
        static void Main(string[] args)
        {
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
                catch (ElementNotAvailableException ex)
                {
                    EventLog.WriteEntry("BATClicker", ex.StackTrace, EventLogEntryType.Error);
                }
                
            }
        }


    }
}
