using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment1KyleJordan
{
public partial class MyForm : Form
    {
        public string AuthorName { get; set; }
        public string MessageText { get; set; }
        public List<Control> controls = new List<Control>();
        public List<Control> bottomPanelControls = new List<Control>();
        public List<Control> fillPanelControls = new List<Control>();
        public ListBox itemNames = new ListBox();


        public MyForm(string titleBarText, string authorName)
        {
            this.Text = titleBarText;
            this.AuthorName = authorName;
            this.Size = new Size(400, 400);

            GenerateFirstPanel();
            GenerateSecondPanel();
            AffixMasterControls();
        }

        private void AffixMasterControls()
        {
            foreach (Control c in controls)
            {
                this.Controls.Add(c);
            }
        }

        private void GenerateFirstPanel()
        {
            Panel bottomPanel = new Panel()
            {
                BackColor = Color.LightBlue,
                Height = 50,
                Width = 500,
                Dock = DockStyle.Bottom,
                Name = "Panel"
            };

            Label nameLabel = new Label()
            {
                Text = AuthorName,
                Name = "Label"
            };

            
            itemNames.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            itemNames.Dock = DockStyle.Right;
            itemNames.Name = "ListBox";

            bottomPanelControls.Add(nameLabel);
            bottomPanelControls.Add(itemNames);

            foreach (Control c in bottomPanelControls)
            {
                bottomPanel.Controls.Add(c);
            }

            controls.Add(bottomPanel);
            
        }

        private void GenerateSecondPanel()
        {
            Panel fillPanel = new Panel()
            {
                BackColor = Color.LightCoral,
                Dock = DockStyle.Fill,
                Name = "Panel"
            };

            Label commentLabel = new Label()
            {
                Text = "Comment:",
                Top = 5,
                Left = 30,
                Name = "Label"
            };

            TextBox displayText = new TextBox()
            {
                Width = 150,
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left,
                Dock = DockStyle.Right,
                Name = "Textbox"
            };

            Button displayMessageButton = new Button()
            {
                BackColor = Color.Gray,
                Width = 150,
                Height = 50,
                Text = "Display Comment",
                Location = new Point(235, 260),
                Name = "Button"
            };


            displayMessageButton.Click += new EventHandler(displayMessage_Click);

            fillPanelControls.Add(commentLabel);
            fillPanelControls.Add(displayText);
            fillPanelControls.Add(displayMessageButton);

            foreach (Control c in fillPanelControls)
            {
                fillPanel.Controls.Add(c);
            }

            controls.Add(fillPanel);
            AddListBoxItems(itemNames);
        }

        private void displayMessage_Click(object sender, System.EventArgs e)
        {
            string MessageText = String.Empty;

            foreach (Control c in fillPanelControls)
            {
                if (c.Name == "Textbox")
                {
                    MessageText = c.Text;
                }
            }

            MessageBox.Show("Hello " + MessageText + ", welcome to my application!");
        }

        private void AddListBoxItems(ListBox l){
            
            l.BeginUpdate();

            foreach(Control c in controls){
                l.Items.Add(c.Name);
            }

            foreach (Control c in bottomPanelControls)
            {
                l.Items.Add(c.Name);
            }

            foreach (Control c in fillPanelControls)
            {
                l.Items.Add(c.Name);
            }

            l.EndUpdate();

        }
    }
}