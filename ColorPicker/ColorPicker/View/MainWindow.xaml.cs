using ColorPicker.Tools;
using System.Windows;

namespace ColorPicker
{
    public partial class MainWindow : Window
    {
        private MouseHook clickEvent = new MouseHook();
        private PixelColor pixelColor = new PixelColor();

        public MainWindow()
        {
            InitializeComponent();
            clickEvent.LeftButtonDown += new MouseHook.MouseHookCallback(ColorChanged);
        }

        private void PickColorButton(object sender, RoutedEventArgs e)
        {
            clickEvent.Install();
        }

        private void ColorChanged(MouseHook.MSLLHOOKSTRUCT str)
        {
            var color = pixelColor.GetColor(System.Windows.Forms.Cursor.Position);

            ColorPickerControl.SelectedColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            Clipboard.SetText(HexConverter(color));
            clickEvent.Uninstall();
        }

        private string HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

    }
}
