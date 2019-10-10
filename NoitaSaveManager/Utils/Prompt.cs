using System.Drawing;
using System.Windows.Forms;

namespace NoitaSaveManager.Utils
{
    public static class Prompt
    {
        public static string ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 425,
                Height = 75,
                Text = caption,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White
            };

            TextBox txtInput = new TextBox() { Left = 5, Top = 5, Width = 400, Font = new Font("Segoe UI", 10, FontStyle.Regular) };
            prompt.Controls.Add(txtInput);

            Button btnClose = new Button() { Text = "Close", Left = 305, Width = 100, Top = 50, DialogResult = DialogResult.OK };
            btnClose.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(btnClose);

            prompt.AcceptButton = btnClose;

            return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
        }
    }
}
