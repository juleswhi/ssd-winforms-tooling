namespace FormSystem;

// Contains a bunch of extension methods
public enum ControlDirection
{
    X,
    Y
}

public static class FormHelper
{
    public static void Center(this Control control, ControlDirection controlDirection)
    {
        switch(controlDirection)
        {
            case X:
                control.Location = new Point((control.Parent!.Width / 2) - (int)0.5*(control.Width), control.Location.Y);
                break;

            case Y:
                control.Location = new Point(control.Location.X, (control.Parent!.Height / 2) - (int)0.5*(control.Width));
                break;
        }
    }

    public static void CenterX(this Control control)
    {
        control.Location = new Point((control.Parent!.Width / 2) - (int)0.5 * (control.Width), control.Location.Y);
    }
    public static void CenterY(this Control control)
    {
        control.Location = new Point(control.Location.X, (control.Parent!.Height / 2) - (int)0.5 * (control.Width));
    }
}
