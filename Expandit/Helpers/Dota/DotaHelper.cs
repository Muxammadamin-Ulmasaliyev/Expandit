using System.Reflection.Emit;
using System.Runtime.InteropServices;
using WindowsInput;
namespace Expandit.Helpers.Dota;

public class DotaHelper
{
    #region Mouse Click Simulation
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, nuint dwExtraInfo);
    private const uint MOUSEEVENTF_LEFTDOWN = 0x0002; // Mouse left button down
    private const uint MOUSEEVENTF_LEFTUP = 0x0004;   // Mouse left button up
    private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008; // Mouse right button down
    private const uint MOUSEEVENTF_RIGHTUP = 0x0010;   // Mouse right button up


    private void SimulateMouseClick(object? sender = null, EventArgs? e = null)
    {
        int x = Cursor.Position.X;
        int y = Cursor.Position.Y;
        Cursor.Position = new Point(x, y);
        mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, nuint.Zero);
        mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, nuint.Zero);
    }

    #endregion


    private readonly InputSimulator inputSimulator;
    public DotaHelper()
    {
        inputSimulator = new();
    }
    public void DoSpell(object sender, KeyEventArgs e)
    {
       
        switch (e.KeyCode)
        {
            case Keys.NumPad0:
                {
                    ColdSnap();
                    SimulateMouseClick();

                    break;
                }
            case Keys.NumPad1:
                {
                    GhostWalk();

                    break;
                }
            case Keys.NumPad2:
                {
                    IceWall();
                    SimulateMouseClick();
                    break;
                }
            case Keys.NumPad3:
                {
                    EMP();
                    SimulateMouseClick();
                    break;
                }
            case Keys.NumPad4:
                {
                    Tornado();
                    SimulateMouseClick();
                    break;
                }
            case Keys.NumPad5:
                {
                    Alarcrity();
                    SimulateMouseClick();

                    break;
                }
            case Keys.NumPad6:
                {
                    SunStrike();

                    break;
                }
            case Keys.NumPad7:
                {
                    ForgeSpirit();
                    SimulateMouseClick();

                    break;
                }
            case Keys.NumPad8:
                {
                    Meteor();
                    SimulateMouseClick();

                    break;
                }
            case Keys.NumPad9:
                {
                    DefeaningBlast();
                    SimulateMouseClick();

                    break;
                }
            case Keys.Add:
                {
                    break;
                }
            case Keys.Subtract:
                {
                    break;
                }
            case Keys.Multiply:
                {
                    break;
                }
            case Keys.Divide:
                {
                    break;
                }
            case Keys.Decimal:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }


    }

    #region INVOKER

    public void AllWex()
    {
        Thread.Sleep(50);
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
    }

    public void TornadoAndEMP()
    {
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(q)");
        SendKeys.Send("(r)");
        Thread.Sleep(50);
        SendKeys.Send("(d)");
        Thread.Sleep(50);
        SimulateMouseClick();
        Thread.Sleep(50);
        SendKeys.Send("(f)");
        Thread.Sleep(50);
        SimulateMouseClick();
    }
    public void ColdSnap()
    {
        SendKeys.Send("(q)");
        SendKeys.Send("(q)");
        SendKeys.Send("(q)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");
    }
    public void GhostWalk()
    {
        SendKeys.Send("(q)");
        SendKeys.Send("(q)");
        SendKeys.Send("(w)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    public void IceWall()
    {
        SendKeys.Send("(q)");
        SendKeys.Send("(q)");
        SendKeys.Send("(e)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");
    }
    public void EMP()
    {
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    public void Tornado()
    {
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(q)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");
        SimulateMouseClick();

    }
    public void Alarcrity()
    {
        SendKeys.Send("(w)");
        SendKeys.Send("(w)");
        SendKeys.Send("(e)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    public void SunStrike()
    {
        SendKeys.Send("(e)");
        SendKeys.Send("(e)");
        SendKeys.Send("(e)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    public void ForgeSpirit()
    {
        SendKeys.Send("(e)");
        SendKeys.Send("(e)");
        SendKeys.Send("(q)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    public void Meteor()
    {
        SendKeys.Send("(e)");
        SendKeys.Send("(e)");
        SendKeys.Send("(w)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    public void DefeaningBlast()
    {
        SendKeys.Send("(q)");
        SendKeys.Send("(w)");
        SendKeys.Send("(e)");
        SendKeys.Send("(r)");
        SendKeys.Send("(d)");

    }
    #endregion


    #region MEEPO

    // for (int i = 0; i< 4; i++)
    //        {
    //            Thread.Sleep(50);
    //            SendKeys.Send("(q)");
    //            Thread.Sleep(50);
    //            btnSimulateClick_Click(sender, e);
    //Thread.Sleep(50);
    //            SendKeys.Send("{TAB}");
    //            Thread.Sleep(1700);
    //        }

    #endregion




}
