namespace GameUI
{
    using System.Windows.Forms;

    public partial class GameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelPlayers = new System.Windows.Forms.Label();
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.TextBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.TextBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.LabelBoardSize = new System.Windows.Forms.Label();
            this.LabelRows = new System.Windows.Forms.Label();
            this.NumericRows = new System.Windows.Forms.NumericUpDown();
            this.NumericCols = new System.Windows.Forms.NumericUpDown();
            this.LabelCols = new System.Windows.Forms.Label();
            this.ButtonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCols)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelPlayers
            // 
            this.LabelPlayers.AutoSize = true;
            this.LabelPlayers.Location = new System.Drawing.Point(13, 13);
            this.LabelPlayers.Name = "LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.LabelPlayers.TabIndex = 0;
            this.LabelPlayers.Text = "Players:";
            // 
            // LabelPlayer1
            // 
            this.LabelPlayer1.AutoSize = true;
            this.LabelPlayer1.Location = new System.Drawing.Point(26, 50);
            this.LabelPlayer1.Name = "LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.LabelPlayer1.TabIndex = 1;
            this.LabelPlayer1.Text = "Player 1:";
            // 
            // TextBoxPlayer1Name
            // 
            this.TextBoxPlayer1Name.Location = new System.Drawing.Point(177, 47);
            this.TextBoxPlayer1Name.Name = "TextBoxPlayer1Name";
            this.TextBoxPlayer1Name.Size = new System.Drawing.Size(161, 26);
            this.TextBoxPlayer1Name.TabIndex = 0;
            this.TextBoxPlayer1Name.TextChanged += new System.EventHandler(this.m_TextPlayer1_TextChanged);
            // 
            // TextBoxPlayer2Name
            // 
            this.TextBoxPlayer2Name.BackColor = System.Drawing.SystemColors.Control;
            this.TextBoxPlayer2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxPlayer2Name.Enabled = false;
            this.TextBoxPlayer2Name.Location = new System.Drawing.Point(177, 93);
            this.TextBoxPlayer2Name.Name = "TextBoxPlayer2Name";
            this.TextBoxPlayer2Name.Size = new System.Drawing.Size(161, 26);
            this.TextBoxPlayer2Name.TabIndex = 3;
            this.TextBoxPlayer2Name.Text = "[Computer]";
            this.TextBoxPlayer2Name.TextChanged += new System.EventHandler(this.m_TextPlayer2_TextChanged);
            // 
            // CheckBoxPlayer2
            // 
            this.CheckBoxPlayer2.AutoSize = true;
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(30, 94);
            this.CheckBoxPlayer2.Name = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.CheckBoxPlayer2.TabIndex = 4;
            this.CheckBoxPlayer2.Text = "Player 2:";
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_CheckBoxPlayer2_CheckedChanged);
            // 
            // LabelBoardSize
            // 
            this.LabelBoardSize.AutoSize = true;
            this.LabelBoardSize.Location = new System.Drawing.Point(17, 201);
            this.LabelBoardSize.Name = "LabelBoardSize";
            this.LabelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.LabelBoardSize.TabIndex = 5;
            this.LabelBoardSize.Text = "Board Size:";
            // 
            // LabelRows
            // 
            this.LabelRows.AutoSize = true;
            this.LabelRows.Location = new System.Drawing.Point(30, 236);
            this.LabelRows.Name = "LabelRows";
            this.LabelRows.Size = new System.Drawing.Size(53, 20);
            this.LabelRows.TabIndex = 6;
            this.LabelRows.Text = "Rows:";
            // 
            // NumericRows
            // 
            this.NumericRows.Location = new System.Drawing.Point(89, 234);
            this.NumericRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericRows.Name = "NumericRows";
            this.NumericRows.Size = new System.Drawing.Size(53, 26);
            this.NumericRows.TabIndex = 7;
            this.NumericRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericRows.ValueChanged += new System.EventHandler(this.m_NumericRows_ValueChanged);
            // 
            // NumericCols
            // 
            this.NumericCols.Location = new System.Drawing.Point(246, 234);
            this.NumericCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericCols.Name = "NumericCols";
            this.NumericCols.Size = new System.Drawing.Size(53, 26);
            this.NumericCols.TabIndex = 9;
            this.NumericCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericCols.ValueChanged += new System.EventHandler(this.m_NumericCols_ValueChanged);
            // 
            // LabelCols
            // 
            this.LabelCols.AutoSize = true;
            this.LabelCols.Location = new System.Drawing.Point(187, 236);
            this.LabelCols.Name = "LabelCols";
            this.LabelCols.Size = new System.Drawing.Size(44, 20);
            this.LabelCols.TabIndex = 8;
            this.LabelCols.Text = "Cols:";
            // 
            // ButtonStart
            // 
            this.ButtonStart.Enabled = false;
            this.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonStart.Location = new System.Drawing.Point(17, 303);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(321, 36);
            this.ButtonStart.TabIndex = 10;
            this.ButtonStart.Text = "Start!";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(360, 370);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.NumericCols);
            this.Controls.Add(this.LabelCols);
            this.Controls.Add(this.NumericRows);
            this.Controls.Add(this.LabelRows);
            this.Controls.Add(this.LabelBoardSize);
            this.Controls.Add(this.CheckBoxPlayer2);
            this.Controls.Add(this.TextBoxPlayer2Name);
            this.Controls.Add(this.TextBoxPlayer1Name);
            this.Controls.Add(this.LabelPlayer1);
            this.Controls.Add(this.LabelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.NumericRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Controls
        private Label LabelPlayers;
        private Label LabelPlayer1;
        private TextBox TextBoxPlayer1Name;
        private TextBox TextBoxPlayer2Name;
        private CheckBox CheckBoxPlayer2;
        private Label LabelBoardSize;
        private Label LabelRows;
        private NumericUpDown NumericRows;
        private NumericUpDown NumericCols;
        private Label LabelCols;
        private Button ButtonStart;
        #endregion Controls
    }
}
