namespace Devolutions.Wayk.WinForms
{
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;

    using WpfWaykControl = Wpf.WaykControl;

    public partial class WaykControl : ElementHost
    {
        private WpfWaykControl waykControl;

        public WaykControl()
        {
            InitializeComponent();

            Child = waykControl = new WpfWaykControl();
            
            waykControl.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            waykControl.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }

        public void Connect(string target, string password)
        {
            waykControl.Connect(target, password);
        }
    }
}
