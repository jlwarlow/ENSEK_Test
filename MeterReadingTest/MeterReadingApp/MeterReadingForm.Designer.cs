namespace MeterReadingApp
{
    partial class MeterReadingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadCSVButton = new Button();
            ProcessButton = new Button();
            label1 = new Label();
            richTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // LoadCSVButton
            // 
            LoadCSVButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoadCSVButton.Location = new Point(713, 9);
            LoadCSVButton.Name = "LoadCSVButton";
            LoadCSVButton.Size = new Size(75, 23);
            LoadCSVButton.TabIndex = 0;
            LoadCSVButton.Text = "LoadCSV";
            LoadCSVButton.UseVisualStyleBackColor = true;
            LoadCSVButton.Click += LoadCSVButton_Click;
            // 
            // ProcessButton
            // 
            ProcessButton.Anchor = AnchorStyles.Bottom;
            ProcessButton.Enabled = false;
            ProcessButton.Location = new Point(355, 415);
            ProcessButton.Name = "ProcessButton";
            ProcessButton.Size = new Size(75, 23);
            ProcessButton.TabIndex = 1;
            ProcessButton.Text = "Process";
            ProcessButton.UseVisualStyleBackColor = true;
            ProcessButton.Click += ProcessButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 2;
            label1.Text = "Meter Readings";
            // 
            // richTextBox
            // 
            richTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox.Location = new Point(12, 49);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.Size = new Size(776, 333);
            richTextBox.TabIndex = 3;
            richTextBox.Text = "";
            // 
            // MeterReadingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox);
            Controls.Add(label1);
            Controls.Add(ProcessButton);
            Controls.Add(LoadCSVButton);
            Name = "MeterReadingForm";
            Text = "Meter Reading Processor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadCSVButton;
        private Button ProcessButton;
        private Label label1;
        private RichTextBox richTextBox;
    }
}
