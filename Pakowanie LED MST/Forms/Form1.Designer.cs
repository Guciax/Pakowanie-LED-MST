namespace Pakowanie_LED_MST
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAddPcb = new System.Windows.Forms.TextBox();
            this.buttonNewBox = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelCurrentBoxId = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAllQty = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelUnknownCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNgCount = new System.Windows.Forms.Label();
            this.labelGoodQty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvCurrentBox = new System.Windows.Forms.DataGridView();
            this.rowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.timerCheckDgvForTestResults = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timerTestResultsToGrid = new System.Windows.Forms.Timer(this.components);
            this.timerFlashNg = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvCurrentBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1130, 608);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 94);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonNewBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1124, 94);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBoxAddPcb);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(546, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(287, 92);
            this.panel4.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Usuń panel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dodaj panel:";
            // 
            // textBoxAddPcb
            // 
            this.textBoxAddPcb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAddPcb.Location = new System.Drawing.Point(6, 22);
            this.textBoxAddPcb.Name = "textBoxAddPcb";
            this.textBoxAddPcb.Size = new System.Drawing.Size(278, 23);
            this.textBoxAddPcb.TabIndex = 9;
            this.textBoxAddPcb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAddPcb_KeyDown);
            this.textBoxAddPcb.Leave += new System.EventHandler(this.textBoxAddPcb_Leave_1);
            // 
            // buttonNewBox
            // 
            this.buttonNewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewBox.Location = new System.Drawing.Point(1, 1);
            this.buttonNewBox.Margin = new System.Windows.Forms.Padding(1);
            this.buttonNewBox.Name = "buttonNewBox";
            this.buttonNewBox.Size = new System.Drawing.Size(78, 92);
            this.buttonNewBox.TabIndex = 0;
            this.buttonNewBox.Text = "Nowe opakowanie\r\n-----------------\r\nWczytaj opakowanie";
            this.buttonNewBox.UseVisualStyleBackColor = true;
            this.buttonNewBox.Click += new System.EventHandler(this.buttonNewBox_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.labelCurrentBoxId);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(161, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 92);
            this.panel3.TabIndex = 12;
            // 
            // labelCurrentBoxId
            // 
            this.labelCurrentBoxId.AutoSize = true;
            this.labelCurrentBoxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentBoxId.Location = new System.Drawing.Point(3, 3);
            this.labelCurrentBoxId.Name = "labelCurrentBoxId";
            this.labelCurrentBoxId.Size = new System.Drawing.Size(253, 26);
            this.labelCurrentBoxId.TabIndex = 5;
            this.labelCurrentBoxId.Text = "Aktualne opakowanie ID:\r\n";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.labelAllQty);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelUnknownCount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelNgCount);
            this.panel2.Controls.Add(this.labelGoodQty);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(835, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 92);
            this.panel2.TabIndex = 11;
            // 
            // labelAllQty
            // 
            this.labelAllQty.AutoSize = true;
            this.labelAllQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAllQty.Location = new System.Drawing.Point(70, 6);
            this.labelAllQty.Name = "labelAllQty";
            this.labelAllQty.Size = new System.Drawing.Size(124, 29);
            this.labelAllQty.TabIndex = 13;
            this.labelAllQty.Text = "Ilość PCB:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ilość:";
            // 
            // labelUnknownCount
            // 
            this.labelUnknownCount.AutoSize = true;
            this.labelUnknownCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUnknownCount.Location = new System.Drawing.Point(41, 71);
            this.labelUnknownCount.Name = "labelUnknownCount";
            this.labelUnknownCount.Size = new System.Drawing.Size(71, 17);
            this.labelUnknownCount.TabIndex = 11;
            this.labelUnknownCount.Text = "Ilość PCB:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "B/D:";
            // 
            // labelNgCount
            // 
            this.labelNgCount.AutoSize = true;
            this.labelNgCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNgCount.Location = new System.Drawing.Point(41, 54);
            this.labelNgCount.Name = "labelNgCount";
            this.labelNgCount.Size = new System.Drawing.Size(71, 17);
            this.labelNgCount.TabIndex = 9;
            this.labelNgCount.Text = "Ilość PCB:";
            // 
            // labelGoodQty
            // 
            this.labelGoodQty.AutoSize = true;
            this.labelGoodQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGoodQty.Location = new System.Drawing.Point(41, 37);
            this.labelGoodQty.Name = "labelGoodQty";
            this.labelGoodQty.Size = new System.Drawing.Size(71, 17);
            this.labelGoodQty.TabIndex = 8;
            this.labelGoodQty.Text = "Ilość PCB:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(5, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "NG:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "OK:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(81, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 92);
            this.button1.TabIndex = 14;
            this.button1.Text = "Opcje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvCurrentBox
            // 
            this.dgvCurrentBox.AllowUserToAddRows = false;
            this.dgvCurrentBox.AllowUserToDeleteRows = false;
            this.dgvCurrentBox.AllowUserToResizeColumns = false;
            this.dgvCurrentBox.AllowUserToResizeRows = false;
            this.dgvCurrentBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowIndex,
            this.Column1,
            this.PCB,
            this.TestResult,
            this.ViResult,
            this.Column4});
            this.dgvCurrentBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrentBox.Location = new System.Drawing.Point(3, 103);
            this.dgvCurrentBox.Name = "dgvCurrentBox";
            this.dgvCurrentBox.ReadOnly = true;
            this.dgvCurrentBox.RowHeadersVisible = false;
            this.dgvCurrentBox.Size = new System.Drawing.Size(1124, 502);
            this.dgvCurrentBox.TabIndex = 1;
            this.dgvCurrentBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrentBox_CellContentClick);
            this.dgvCurrentBox.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrentBox_CellValueChanged);
            // 
            // rowIndex
            // 
            this.rowIndex.HeaderText = "#";
            this.rowIndex.Name = "rowIndex";
            this.rowIndex.ReadOnly = true;
            this.rowIndex.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Data dodania";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // PCB
            // 
            this.PCB.HeaderText = "PCB";
            this.PCB.Name = "PCB";
            this.PCB.ReadOnly = true;
            this.PCB.Width = 300;
            // 
            // TestResult
            // 
            this.TestResult.HeaderText = "Test";
            this.TestResult.Name = "TestResult";
            this.TestResult.ReadOnly = true;
            // 
            // ViResult
            // 
            this.ViResult.HeaderText = "Kontrola wzrokowa";
            this.ViResult.Name = "ViResult";
            this.ViResult.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Usuń";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 35;
            // 
            // timerCheckDgvForTestResults
            // 
            this.timerCheckDgvForTestResults.Enabled = true;
            this.timerCheckDgvForTestResults.Interval = 10000;
            this.timerCheckDgvForTestResults.Tick += new System.EventHandler(this.timerCheckDgvForTestResults_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timerTestResultsToGrid
            // 
            this.timerTestResultsToGrid.Enabled = true;
            this.timerTestResultsToGrid.Interval = 500;
            this.timerTestResultsToGrid.Tick += new System.EventHandler(this.timerTestResultsToGrid_Tick);
            // 
            // timerFlashNg
            // 
            this.timerFlashNg.Interval = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 608);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Pakowanie LED MST";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCurrentBoxId;
        private System.Windows.Forms.Button buttonNewBox;
        private System.Windows.Forms.DataGridView dgvCurrentBox;
        private System.Windows.Forms.TextBox textBoxAddPcb;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelNgCount;
        private System.Windows.Forms.Label labelGoodQty;
        private System.Windows.Forms.Timer timerCheckDgvForTestResults;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timerTestResultsToGrid;
        private System.Windows.Forms.Label labelUnknownCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAllQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timerFlashNg;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ViResult;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.Button button1;
    }
}

