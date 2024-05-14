using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TypingAssist
{
    public partial class Form1 : Form
    {
        private TextBox textBox;
        private Label resultLabel;
        private Stopwatch stopwatch;
        private ContextMenuStrip suggestionBox;

        public Form1()
        {
            //InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.textBox = new TextBox
            {
                Multiline = true,
                Width = 600,
                Height = 300,
                Location = new Point(10, 10)
            };
            this.textBox.KeyUp += TextBox_KeyUp;
            this.Controls.Add(this.textBox);

            Button startButton = new Button
            {
                Text = "Start Insertion",
                Location = new Point(10, 320)
            };
            startButton.Click += StartButton_Click;
            this.Controls.Add(startButton);

            this.resultLabel = new Label
            {
                Location = new Point(120, 325),
                AutoSize = true
            };
            this.Controls.Add(this.resultLabel);

            this.suggestionBox = new ContextMenuStrip();
            string[] suggestions = { "1. Lenovo", "2. HP", "3. Dell", "4. Apple", "5. Asus" };
            foreach (var suggestion in suggestions)
            {
                this.suggestionBox.Items.Add(suggestion);
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ShowSuggestionBox();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.textBox.Clear();
            this.stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                foreach (char letter in "abcdefghijklmnopqrstuvwxyz")
                {
                    this.textBox.AppendText(letter + " ");
                    Application.DoEvents(); // Allow the UI to update
                    ShowSuggestionBox();
                }
            }

            this.stopwatch.Stop();
            this.resultLabel.Text = $"Total time taken: {this.stopwatch.Elapsed.TotalSeconds:F4} seconds";
        }

        private void ShowSuggestionBox()
        {
            if (this.textBox.Focused)
            {
                Point position = this.textBox.GetPositionFromCharIndex(this.textBox.SelectionStart);
                position.Offset(this.textBox.Location);
                this.suggestionBox.Show(this, new Point(position.X + 20, position.Y + 30));
            }
        }
    }
}
