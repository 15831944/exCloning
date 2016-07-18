namespace exCloning
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
            this.txt_report = new System.Windows.Forms.TextBox();
            this.btn_getSelected = new System.Windows.Forms.Button();
            this.btn_swap = new System.Windows.Forms.Button();
            this.cb_swapFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_swapTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_select = new System.Windows.Forms.Button();
            this.cb_selectFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_report
            // 
            this.txt_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_report.Location = new System.Drawing.Point(157, 12);
            this.txt_report.Multiline = true;
            this.txt_report.Name = "txt_report";
            this.txt_report.ReadOnly = true;
            this.txt_report.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_report.Size = new System.Drawing.Size(289, 366);
            this.txt_report.TabIndex = 0;
            // 
            // btn_getSelected
            // 
            this.btn_getSelected.Location = new System.Drawing.Point(12, 30);
            this.btn_getSelected.Name = "btn_getSelected";
            this.btn_getSelected.Size = new System.Drawing.Size(139, 56);
            this.btn_getSelected.TabIndex = 1;
            this.btn_getSelected.Text = "Get selected\r\n\r\n*vali kolmanda valikuga";
            this.btn_getSelected.UseVisualStyleBackColor = true;
            this.btn_getSelected.Click += new System.EventHandler(this.btn_getSelected_Click);
            // 
            // btn_swap
            // 
            this.btn_swap.Location = new System.Drawing.Point(12, 224);
            this.btn_swap.Name = "btn_swap";
            this.btn_swap.Size = new System.Drawing.Size(139, 23);
            this.btn_swap.TabIndex = 2;
            this.btn_swap.Text = "SWAP";
            this.btn_swap.UseVisualStyleBackColor = true;
            this.btn_swap.Click += new System.EventHandler(this.btn_swap_Click);
            // 
            // cb_swapFrom
            // 
            this.cb_swapFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_swapFrom.FormattingEnabled = true;
            this.cb_swapFrom.Location = new System.Drawing.Point(57, 171);
            this.cb_swapFrom.Name = "cb_swapFrom";
            this.cb_swapFrom.Size = new System.Drawing.Size(94, 21);
            this.cb_swapFrom.TabIndex = 3;
            this.cb_swapFrom.SelectedIndexChanged += new System.EventHandler(this.cb_swapFrom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FROM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "TO:";
            // 
            // txt_swapTo
            // 
            this.txt_swapTo.Location = new System.Drawing.Point(57, 198);
            this.txt_swapTo.Name = "txt_swapTo";
            this.txt_swapTo.ReadOnly = true;
            this.txt_swapTo.Size = new System.Drawing.Size(94, 20);
            this.txt_swapTo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(54, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "SWAP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(49, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "SELECT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(12, 355);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(139, 23);
            this.btn_select.TabIndex = 9;
            this.btn_select.Text = "SELECT";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // cb_selectFrom
            // 
            this.cb_selectFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_selectFrom.FormattingEnabled = true;
            this.cb_selectFrom.Location = new System.Drawing.Point(12, 328);
            this.cb_selectFrom.Name = "cb_selectFrom";
            this.cb_selectFrom.Size = new System.Drawing.Size(139, 21);
            this.cb_selectFrom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(49, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "START";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 390);
            this.Controls.Add(this.cb_selectFrom);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_swapTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_swapFrom);
            this.Controls.Add(this.btn_swap);
            this.Controls.Add(this.btn_getSelected);
            this.Controls.Add(this.txt_report);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_report;
        private System.Windows.Forms.Button btn_getSelected;
        private System.Windows.Forms.Button btn_swap;
        private System.Windows.Forms.ComboBox cb_swapFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_swapTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.ComboBox cb_selectFrom;
        private System.Windows.Forms.Label label5;
    }
}

