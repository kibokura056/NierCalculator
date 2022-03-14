﻿namespace NierCalculator
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialTable = new System.Windows.Forms.DataGridView();
            this.materialTable2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_reset = new System.Windows.Forms.Button();
            this.bt_calc = new System.Windows.Forms.Button();
            this.cb_count = new System.Windows.Forms.ComboBox();
            this.cb_cost = new System.Windows.Forms.ComboBox();
            this.cb_rank = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lb_NoEnoughParts = new System.Windows.Forms.Label();
            this.lb_log = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.materialTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialTable2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTable
            // 
            this.materialTable.AllowUserToAddRows = false;
            this.materialTable.AllowUserToDeleteRows = false;
            this.materialTable.AllowUserToResizeColumns = false;
            this.materialTable.AllowUserToResizeRows = false;
            this.materialTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.materialTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTable.ColumnHeadersHeight = 25;
            this.materialTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.materialTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.materialTable.Location = new System.Drawing.Point(6, 18);
            this.materialTable.Name = "materialTable";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.materialTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.materialTable.RowHeadersVisible = false;
            this.materialTable.RowHeadersWidth = 35;
            this.materialTable.RowTemplate.Height = 21;
            this.materialTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.materialTable.Size = new System.Drawing.Size(580, 250);
            this.materialTable.TabIndex = 0;
            this.materialTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialTable_CellEnter);
            this.materialTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.materialTable_KeyDown);
            // 
            // materialTable2
            // 
            this.materialTable2.AllowUserToAddRows = false;
            this.materialTable2.AllowUserToDeleteRows = false;
            this.materialTable2.AllowUserToResizeColumns = false;
            this.materialTable2.AllowUserToResizeRows = false;
            this.materialTable2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.materialTable2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTable2.ColumnHeadersHeight = 25;
            this.materialTable2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.materialTable2.Location = new System.Drawing.Point(6, 18);
            this.materialTable2.Name = "materialTable2";
            this.materialTable2.ReadOnly = true;
            this.materialTable2.RowHeadersVisible = false;
            this.materialTable2.RowHeadersWidth = 35;
            this.materialTable2.RowTemplate.Height = 21;
            this.materialTable2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.materialTable2.Size = new System.Drawing.Size(580, 250);
            this.materialTable2.TabIndex = 1;
            this.materialTable2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialTable2_CellEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialTable);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 276);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合成したいプラグインチップの所持数を入力";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_reset);
            this.groupBox2.Controls.Add(this.bt_calc);
            this.groupBox2.Controls.Add(this.cb_count);
            this.groupBox2.Controls.Add(this.cb_cost);
            this.groupBox2.Controls.Add(this.cb_rank);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(12, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 143);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "欲しいレベル・コスト・枚数を指定する";
            // 
            // bt_reset
            // 
            this.bt_reset.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_reset.Location = new System.Drawing.Point(511, 22);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(75, 23);
            this.bt_reset.TabIndex = 13;
            this.bt_reset.Text = "リセット";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // bt_calc
            // 
            this.bt_calc.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_calc.Location = new System.Drawing.Point(430, 22);
            this.bt_calc.Name = "bt_calc";
            this.bt_calc.Size = new System.Drawing.Size(75, 23);
            this.bt_calc.TabIndex = 12;
            this.bt_calc.Text = "計算";
            this.bt_calc.UseVisualStyleBackColor = true;
            this.bt_calc.Click += new System.EventHandler(this.bt_calc_Click);
            // 
            // cb_count
            // 
            this.cb_count.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_count.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cb_count.FormattingEnabled = true;
            this.cb_count.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cb_count.Location = new System.Drawing.Point(284, 24);
            this.cb_count.Name = "cb_count";
            this.cb_count.Size = new System.Drawing.Size(50, 20);
            this.cb_count.TabIndex = 11;
            // 
            // cb_cost
            // 
            this.cb_cost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cost.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cb_cost.FormattingEnabled = true;
            this.cb_cost.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cb_cost.Location = new System.Drawing.Point(166, 24);
            this.cb_cost.Name = "cb_cost";
            this.cb_cost.Size = new System.Drawing.Size(50, 20);
            this.cb_cost.TabIndex = 10;
            // 
            // cb_rank
            // 
            this.cb_rank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rank.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cb_rank.FormattingEnabled = true;
            this.cb_rank.Items.AddRange(new object[] {
            "+1",
            "+2",
            "+3",
            "+4",
            "+5",
            "+6",
            "+7",
            "+8"});
            this.cb_rank.Location = new System.Drawing.Point(51, 24);
            this.cb_rank.Name = "cb_rank";
            this.cb_rank.Size = new System.Drawing.Size(50, 20);
            this.cb_rank.TabIndex = 9;
            this.cb_rank.SelectedIndexChanged += new System.EventHandler(this.cb_rank_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(249, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "枚数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(130, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "コスト";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "ランク";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 83);
            this.label1.TabIndex = 0;
            this.label1.Text = "警告: 以下のプラグインチップは最大までレベルアップしない方が低コストで効果上限に達する。\r\n推奨: 併記されている組み合わせでの使用。\r\n\r\nチャージアタック " +
    "+4 +4,  連続ダメージ防止 +3 +3 +3 or +3 +6,  再起動 +2 +6\r\n移動速度UP +3 +3,  ドロップ率UP +3 +4,  オ" +
    "ーバークロック +3 +4,  挑発強化 +4 +4";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.materialTable2);
            this.groupBox3.Location = new System.Drawing.Point(12, 458);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(592, 276);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "合成後のプラグインチップの所持数";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lb_NoEnoughParts);
            this.groupBox4.Controls.Add(this.lb_log);
            this.groupBox4.Location = new System.Drawing.Point(610, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(308, 722);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "合成ログ";
            // 
            // lb_NoEnoughParts
            // 
            this.lb_NoEnoughParts.AutoSize = true;
            this.lb_NoEnoughParts.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_NoEnoughParts.ForeColor = System.Drawing.Color.Red;
            this.lb_NoEnoughParts.Location = new System.Drawing.Point(83, 15);
            this.lb_NoEnoughParts.Name = "lb_NoEnoughParts";
            this.lb_NoEnoughParts.Size = new System.Drawing.Size(145, 24);
            this.lb_NoEnoughParts.TabIndex = 14;
            this.lb_NoEnoughParts.Text = "警告: パーツ不足\r\n推奨: パーツ集め及び厳選";
            this.lb_NoEnoughParts.Visible = false;
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Location = new System.Drawing.Point(6, 15);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(181, 24);
            this.lb_log.TabIndex = 7;
            this.lb_log.Text = "合成ログがここに表示される。\r\n推奨: 記載される手順に従った合成。";
            // 
            // Form1
            // 
            this.AcceptButton = this.bt_calc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 741);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NierCalculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materialTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialTable2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView materialTable;
        private System.Windows.Forms.DataGridView materialTable2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_count;
        private System.Windows.Forms.ComboBox cb_cost;
        private System.Windows.Forms.ComboBox cb_rank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lb_log;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.Button bt_calc;
        private System.Windows.Forms.Label lb_NoEnoughParts;
    }
}

