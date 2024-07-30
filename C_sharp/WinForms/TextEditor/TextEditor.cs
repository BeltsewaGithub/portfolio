using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace Text_Editor
{
    public partial class TextEditor : Form
    {
        List<string> colorList = new List<string>();    // holds the System.Drawing.Color names
        string filename;    // file opened inside of RTB
        const int MIDDLE = 382;    // middle sum of RGB - max is 765
        int sumRGB;    // sum of the selected colors RGB
        int pos, line, column;    // for detecting line and column numbers
        Color currentColor = Color.Black;
        
        int fontSize = 8;
        string font = "Calibri";

        public TextEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            textBox.AllowDrop = true;     // to allow drag and drop to the RichTextBox
            textBox.AcceptsTab = true;    // allow tab
            textBox.WordWrap = false;    // disable word wrap on start
            textBox.ShortcutsEnabled = true;    // allow shortcuts
            textBox.DetectUrls = true;    // allow detect url
            fontDialog.ShowColor = true;
            fontDialog.ShowApply = true;
            fontDialog.ShowHelp = true;
            colorDialog.AllowFullOpen = true;
            colorDialog.AnyColor = true;
            colorDialog.SolidColorOnly = false;
            colorDialog.ShowHelp = true;
            colorDialog.AnyColor = true;
            leftAlignButton.Checked = true;
            centerAlignButton.Checked = false;
            rightAlignButton.Checked = false;
            boldButton.Checked = false;
            italicStripButton.Checked = false;
            rightAlignButton.Checked = false;
            markerListButton.Checked = false;
            wordWrapToolStripMenuItem.Image = null;
            MinimizeBox = false;
            MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // fill zoomDropDownButton item list
            zoomDropDownButton.DropDown.Items.Add("20%");
            zoomDropDownButton.DropDown.Items.Add("50%");
            zoomDropDownButton.DropDown.Items.Add("70%");
            zoomDropDownButton.DropDown.Items.Add("100%");
            zoomDropDownButton.DropDown.Items.Add("150%");
            zoomDropDownButton.DropDown.Items.Add("200%");
            zoomDropDownButton.DropDown.Items.Add("300%");
            zoomDropDownButton.DropDown.Items.Add("400%");
            zoomDropDownButton.DropDown.Items.Add("500%");

            // fill font sizes in combo box
            for (int i = 8; i < 80; i += 2)
            {
                fontSizeComboBox.Items.Add(i);
            }

            fontSizeComboBox.Text = fontSize.ToString();

            // fill colors in color drop down list
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    colorList.Add(prop.Name);
                }
            }

            // fill the drop down items list
            foreach (string color in colorList)
            {
                colorStripDropDownButton.DropDownItems.Add(color);
            }

            // fill BackColor for each color in the DropDownItems list
            for (int i = 0; i < colorStripDropDownButton.DropDownItems.Count; i++)
            {
                // Create KnownColor object
                KnownColor selectedColor;
                selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), colorList[i]);    // parse to a KnownColor
                colorStripDropDownButton.DropDownItems[i].BackColor = Color.FromKnownColor(selectedColor);    // set the BackColor to its appropriate list item

                // Set the text color depending on if the barkground is darker or lighter
                // create Color object
                Color col = Color.FromName(colorList[i]);

                // 255,255,255 = White and 0,0,0 = Black
                // Max sum of RGB values is 765 -> (255 + 255 + 255)
                // Middle sum of RGB values is 382 -> (765/2)
                // Color is considered darker if its <= 382
                // Color is considered lighter if its > 382
                sumRGB = ConvertToRGB(col);    // get the color objects sum of the RGB value
                if (sumRGB <= MIDDLE)    // Darker Background
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.White;    // set to White text
                }
                else if (sumRGB > MIDDLE)    // Lighter Background
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.Black;    // set to Black text
                }
            }



            // fill fonts in font combo box
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                fontComboBox.Items.Add(family.Name);
            }

            // determines the line and column numbers of mouse position on the richTextBox
            int pos = textBox.SelectionStart;
            int line = textBox.GetLineFromCharIndex(pos);
            int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);
            lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);

            fontComboBox.Text = font;
            fontSizeComboBox.Text = fontSize.ToString();
        }

        private int ConvertToRGB(System.Drawing.Color c)
        {
            int r = c.R, // RED component value
                g = c.G, // GREEN component value
                b = c.B; // BLUE component value
            int sum = 0;

            // calculate sum of RGB
            sum = r + g + b;

            return sum;
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();     // select all text
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear
            textBox.Clear();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();     // paste text
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();      // copy text
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();     // cut text
        }

        private void ChangeStyle(FontStyle style)
        {
            int start = textBox.SelectionStart;
            int length = textBox.SelectionLength;
            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    textBox.Select(start + i, 1);
                    Font oldfont = textBox.SelectionFont;
                    textBox.SelectionFont = new Font(oldfont.FontFamily, oldfont.Size, oldfont.Style ^ style);
                }
                textBox.Select(start, length);
            }
            else
            {
                Font oldfont = textBox.SelectionFont;
                textBox.SelectionFont = new Font(oldfont.FontFamily, oldfont.Size, oldfont.Style ^ style);
            }
        }

        private void boldStripButton3_Click(object sender, EventArgs e)
        {
            ChangeStyle(FontStyle.Bold);
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(FontStyle.Underline);
        }

        private void italicStripButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(FontStyle.Italic);
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox.SelectionFont == null)
            {
                return;
            }
            int start = textBox.SelectionStart;
            int length = textBox.SelectionLength;
            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    textBox.Select(start + i, 1);
                    Font oldfont = textBox.SelectionFont;
                    textBox.SelectionFont = new Font(oldfont.FontFamily, Convert.ToInt32(fontSizeComboBox.SelectedItem), oldfont.Style);
                }
                textBox.Select(start, length);
            }
            else
            {
                Font oldfont = textBox.SelectionFont;
                textBox.SelectionFont = new Font(oldfont.FontFamily, Convert.ToInt32(fontSizeComboBox.SelectedItem), oldfont.Style);
            }
        }

        private void fontStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox.SelectionFont == null)
            {
                // sets the Font Family style
                textBox.SelectionFont = new Font(fontComboBox.Text, textBox.Font.Size);
            }
            int start = textBox.SelectionStart;
            int length = textBox.SelectionLength;
            if (length != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    textBox.Select(start + i, 1);
                    Font oldfont = textBox.SelectionFont;
                    textBox.SelectionFont = new Font(fontComboBox.Text, oldfont.Size, oldfont.Style);
                }
                textBox.Select(start, length);
               
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //saveFileDialog.ShowDialog();    // show the dialog
                string file;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    // save the contents of the rich text box
                    textBox.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    file = Path.GetFileName(filename);    // get name of file
                    MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            //openFileDialog.ShowDialog();     // show the dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                // load the file into the richTextBox
                textBox.LoadFile(filename, RichTextBoxStreamType.PlainText);    // loads it in regular text format
                // richTextBox1.LoadFile(filename, RichTextBoxStreamType.RichText);    // loads it in RTB format
            }
        }

        private void colorStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // creates a KnownColor object
            KnownColor selectedColor;
            selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), e.ClickedItem.Text);    // converts it to a Color Structure
            textBox.SelectionColor = Color.FromKnownColor(selectedColor);    // sets the selected color
        }

        private void textBox_SelectionChanged(object sender, EventArgs e)
        {
            // highlight button border when buttons are true
            if (textBox.SelectionFont != null)
            {
                boldButton.Checked = textBox.SelectionFont.Bold;
                italicStripButton.Checked = textBox.SelectionFont.Italic;
                underlineStripButton.Checked = textBox.SelectionFont.Underline;
            }
        }

        private void leftAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            centerAlignButton.Checked = false;
            rightAlignButton.Checked = false;
            if (leftAlignButton.Checked == false)
            {
                leftAlignButton.Checked = true;    // LEFT ALIGN is active
            }
            else if (leftAlignButton.Checked == true)
            {
                leftAlignButton.Checked = false;    // LEFT ALIGN is not active
            }
            textBox.SelectionAlignment = HorizontalAlignment.Left;    // selects left alignment
        }

        private void centerAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            leftAlignButton.Checked = false;
            rightAlignButton.Checked = false;
            if (centerAlignButton.Checked == false)
            {
                centerAlignButton.Checked = true;    // CENTER ALIGN is active
            }
            else if (centerAlignButton.Checked == true)
            {
                centerAlignButton.Checked = false;    // CENTER ALIGN is not active
            }
            textBox.SelectionAlignment = HorizontalAlignment.Center;     // selects center alignment
        }

        private void rightAlignStripButton_Click(object sender, EventArgs e)
        {
            // set properties
            leftAlignButton.Checked = false;
            centerAlignButton.Checked = false;

            if (rightAlignButton.Checked == false)
            {
                rightAlignButton.Checked = true;    // RIGHT ALIGN is active
            }
            else if (rightAlignButton.Checked == true)
            {
                rightAlignButton.Checked = false;    // RIGHT ALIGN is not active
            }
            textBox.SelectionAlignment = HorizontalAlignment.Right;    // selects right alignment
        }

        private void markerListButton_Click(object sender, EventArgs e)
        {
            if (markerListButton.Checked == false)
            {
                markerListButton.Checked = true;
                textBox.SelectionBullet = true;    // BULLET LIST is active
            }
            else if (markerListButton.Checked == true)
            {
                markerListButton.Checked = false;
                textBox.SelectionBullet = false;    // BULLET LIST is not active
            }
        }

        private void increaseStripButton_Click(object sender, EventArgs e)
        {
            //int fontSizeNum = Convert.ToInt32(fontSizeComboBox.Text);    // variable to hold selected size         
            try
            {
                
                if (textBox.SelectionFont == null)
                {
                    return;
                }
                int start = textBox.SelectionStart;
                int length = textBox.SelectionLength;
                if (length != 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        textBox.Select(start + i, 1);
                        Font oldfont = textBox.SelectionFont;
                        textBox.SelectionFont = new Font(oldfont.FontFamily, oldfont.Size+1, oldfont.Style);
                    }
                    textBox.Select(start, length);
                }
                //fontSizeComboBox.Text = size.ToString();    // update font size
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }
        }

        private void decreaseStripButton_Click(object sender, EventArgs e)
        {
            //string fontSizeNum = (fontSizeComboBox.Text != "Font Size") ? fontSizeComboBox.Text : "8";    // variable to hold selected size         
            try
            {
                //int size = Convert.ToInt32(fontSizeNum) - 1;    // convert (fontSizeNum + 1)
                if (textBox.SelectionFont == null)
                {
                    return;
                }
                int start = textBox.SelectionStart;
                int length = textBox.SelectionLength;
                if (length != 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        textBox.Select(start + i, 1);
                        Font oldfont = textBox.SelectionFont;
                        textBox.SelectionFont = new Font(oldfont.FontFamily, oldfont.Size-1, oldfont.Style);
                    }
                    textBox.Select(start, length);
                }
                //fontSizeComboBox.Text = size.ToString();    // update font size
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // show error message
            }
        }

        //*********************************************************************************************
        // richTextBox1_DragEnter - Custom Event. Copies text being dragged into the richTextBox      *
        //*********************************************************************************************
        private void textBox_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;    // copies data to the RTB
            else
                e.Effect = DragDropEffects.None;    // doesn't accept data into RTB
        }
        //***************************************************************************************************
        // richTextBox1_DragEnter - Custom Event. Drops the copied text being dragged onto the richTextBox  *
        //***************************************************************************************************
        private void TextBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // variables
            int i;
            String s;

            // Get start position to drop the text.
            i = textBox.SelectionStart;
            s = textBox.Text.Substring(i);
            textBox.Text = textBox.Text.Substring(0, i);
            
            // Drop the text on to the RichTextBox.
            textBox.Text += e.Data.GetData(DataFormats.Text).ToString();
            textBox.Text += s;
        }

        private void undoStripButton_Click(object sender, EventArgs e)
        {
            textBox.Undo();     // undo move
        }

        private void redoStripButton_Click(object sender, EventArgs e)
        {
            textBox.Redo();    // redo move
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();     // close the form
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();     // undo move
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Redo();     // redo move
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox.Cut();     // cut text
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            textBox.Copy();     // copy text
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox.Paste();    // paste text
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();    // select all text
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear the rich text box
            textBox.Clear();
            textBox.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // delete selected text
            textBox.SelectedText = "";
            textBox.Focus();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                // richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);  // loads the file in RTB format
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {

            if (textBox.Text != string.Empty)    // RTB has contents - prompt user to save changes
            {
                // save changes message
                DialogResult result = MessageBox.Show("Would you like to save your changes? Editor is not empty.", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // save the RTB contents if user selected yes
                    saveFileDialog.ShowDialog();    // show the dialog
                    string file;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filename = saveFileDialog.FileName;
                        // save the contents of the rich text box
                        textBox.SaveFile(filename, RichTextBoxStreamType.PlainText);
                        file = Path.GetFileName(filename); // get name of file
                        MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // finally - clear the contents of the RTB 
                    textBox.ResetText();
                    textBox.Focus();
                }
                else if (result == DialogResult.No)
                {
                    // clear the contents of the RTB 
                    textBox.ResetText();
                    textBox.Focus();
                }
            }
            else // RTB has no contents
            {
                // clear the contents of the RTB 
                textBox.ResetText();
                textBox.Focus();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();    // show the dialog
            string file;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                // save the contents of the rich text box
                textBox.SaveFile(filename, RichTextBoxStreamType.PlainText);
            }
            file = Path.GetFileName(filename);    // get name of file
            MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            float zoomPercent = Convert.ToSingle(e.ClickedItem.Text.Trim('%')); // convert
            textBox.ZoomFactor = zoomPercent / 100;    // set zoom factor

            if (e.ClickedItem.Image == null)
            {
                // sets all the image properties to null - incase one is already selected beforehand
                for (int i = 0; i < zoomDropDownButton.DropDownItems.Count; i++)
                {
                    zoomDropDownButton.DropDownItems[i].Image = null;
                }

                // draw bmp in image property of selected item, while its active
                Bitmap bmp = new Bitmap(5, 5);
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
                }
                e.ClickedItem.Image = bmp;    // draw ellipse in image property
            }
            else
            {
                e.ClickedItem.Image = null;
                textBox.ZoomFactor = 1.0f;    // set back to NO ZOOM
            }
        }

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectedText = textBox.SelectedText.ToUpper();    // text to CAPS
        }

        private void lowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectedText = textBox.SelectedText.ToLower();    // text to lowercase
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // draw bmp in image property of selected item, while its active
            Bitmap bmp = new Bitmap(5, 5);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
            }

            if (textBox.WordWrap == false)
            {
                textBox.WordWrap = true;    // WordWrap is active
                wordWrapToolStripMenuItem.Image = bmp;    // draw ellipse in image property
            }
            else if (textBox.WordWrap == true)
            {
                textBox.WordWrap = false;    // WordWrap is not active
                wordWrapToolStripMenuItem.Image = null;    // clear image property
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //fontDialog.ShowDialog();    // show the Font Dialog
                System.Drawing.Font oldFont = this.Font;    // gets current font

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    fontDialog_Apply(textBox, new System.EventArgs());
                }
                // set back to the recent font
                else if (fontDialog.ShowDialog() == DialogResult.Cancel)
                {
                    // set current font back to the old font
                    this.Font = oldFont;

                    // sets the old font for the controls inside richTextBox1
                    foreach (Control containedControl in textBox.Controls)
                    {
                        containedControl.Font = oldFont;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); // error
            }
        }

        private void fontDialog_HelpRequest(object sender, EventArgs e)
        {
            // display HelpRequest message
            MessageBox.Show("Please choose a font and any other attributes; then hit Apply and OK.", "Font Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fontDialog_Apply(object sender, EventArgs e)
        {
            fontDialog.FontMustExist = true;    // error if font doesn't exist

            textBox.Font = fontDialog.Font;    // set selected font (Includes: FontFamily, Size, and, Effect. No need to set them separately)
            textBox.ForeColor = fontDialog.Color;    // set selected font color

            // sets the font for the controls inside richTextBox1
            foreach (Control containedControl in textBox.Controls)
            {
                containedControl.Font = fontDialog.Font;
            }
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectedText = ""; // delete selected text
        }

        private void clearFormattingStripButton_Click(object sender, EventArgs e)
        {
            fontComboBox.Text = "Font Family";
            fontSizeComboBox.Text = "Font Size";
            string pureText = textBox.Text;    // get the current Plain Text     
            textBox.Clear();    // clear RTB
            textBox.ForeColor = Color.Black;    // ensure the text color is back to Black
            textBox.Font = default(Font);    // set default font
            textBox.Text = pureText;    // Set it back to its orginial text, added as plain text
            rightAlignButton.Checked = false;
            centerAlignButton.Checked = false;
            leftAlignButton.Checked = true;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // draws the string onto the print document
            e.Graphics.DrawString(textBox.Text, textBox.Font, Brushes.Black, 100, 20);
            e.Graphics.PageUnit = GraphicsUnit.Inch;
        }

        private void printStripButton_Click(object sender, EventArgs e)
        {
            // printDialog associates with PrintDocument
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print(); // Print the document
            }
        }

        private void printPreviewStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            // Show PrintPreview Dialog 
            printPreviewDialog.ShowDialog();
        }

        private void printStripMenuItem_Click(object sender, EventArgs e)
        {
            // printDialog associates with PrintDocument
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printPreviewStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            // Show PrintPreview Dialog 
            printPreviewDialog.ShowDialog();
        }

        private void colorDialog_HelpRequest(object sender, EventArgs e)
        {
            // display HelpRequest message
            MessageBox.Show("Please select a color by clicking it. This will change the text color.", "Color Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void colorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //colorDialog.ShowDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // set the selected color to the RTB's forecolor
                textBox.ForeColor = colorDialog.Color;
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
        }

        //****************************************************************************************************************************************
        // richTextBox1_KeyUp - Determines which key was released and gets the line and column numbers of the current cursor position in the RTB *
        //**************************************************************************************************************************************** 
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            // determine key released
            switch (e.KeyCode)
            {
                case Keys.Down:
                    pos = textBox.SelectionStart;    // get starting point
                    line = textBox.GetLineFromCharIndex(pos);    // get line number
                    column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Right:
                    pos = textBox.SelectionStart; // get starting point
                    line = textBox.GetLineFromCharIndex(pos); // get line number
                    column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Up:
                    pos = textBox.SelectionStart; // get starting point
                    line = textBox.GetLineFromCharIndex(pos); // get line number
                    column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Left:
                    pos = textBox.SelectionStart; // get starting point
                    line = textBox.GetLineFromCharIndex(pos); // get line number
                    column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);    // get column number
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
            }
        }
        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            int pos = textBox.SelectionStart;    // get starting point
            int line = textBox.GetLineFromCharIndex(pos);    // get line number
            int column = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(line);    // get column number
            lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
        }
    }
}
