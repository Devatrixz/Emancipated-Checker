
namespace Emancipated_Checker
{
    partial class Keygen_API
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keygen_API));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rastgeleBirAlgoritmaOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.numericUpDownNumberOfKeys = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKeyLength = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxKeys = new System.Windows.Forms.ListBox();
            this.keyUretimTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeyLength)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(523, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmaToolStripMenuItem
            // 
            this.algoritmaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rastgeleBirAlgoritmaOluşturToolStripMenuItem});
            this.algoritmaToolStripMenuItem.Name = "algoritmaToolStripMenuItem";
            this.algoritmaToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.algoritmaToolStripMenuItem.Text = "Algoritma";
            // 
            // rastgeleBirAlgoritmaOluşturToolStripMenuItem
            // 
            this.rastgeleBirAlgoritmaOluşturToolStripMenuItem.Name = "rastgeleBirAlgoritmaOluşturToolStripMenuItem";
            this.rastgeleBirAlgoritmaOluşturToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rastgeleBirAlgoritmaOluşturToolStripMenuItem.Text = "Sıfırla";
            this.rastgeleBirAlgoritmaOluşturToolStripMenuItem.Click += new System.EventHandler(this.rastgeleBirAlgoritmaOluşturToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algoritma";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(3, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(236, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Rastgele Oluştur";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key referansınızı buraya yazın";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(260, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 85);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Referans";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 66);
            this.label2.TabIndex = 0;
            this.label2.Text = "Algoritma Burada Gözükür";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGenerateKeys);
            this.groupBox3.Controls.Add(this.numericUpDownNumberOfKeys);
            this.groupBox3.Controls.Add(this.numericUpDownKeyLength);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 129);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Keygen Main";
            // 
            // btnGenerateKeys
            // 
            this.btnGenerateKeys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateKeys.Location = new System.Drawing.Point(3, 103);
            this.btnGenerateKeys.Name = "btnGenerateKeys";
            this.btnGenerateKeys.Size = new System.Drawing.Size(484, 23);
            this.btnGenerateKeys.TabIndex = 9;
            this.btnGenerateKeys.Text = "Başlat";
            this.btnGenerateKeys.UseVisualStyleBackColor = true;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);
            // 
            // numericUpDownNumberOfKeys
            // 
            this.numericUpDownNumberOfKeys.Location = new System.Drawing.Point(122, 50);
            this.numericUpDownNumberOfKeys.Name = "numericUpDownNumberOfKeys";
            this.numericUpDownNumberOfKeys.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumberOfKeys.TabIndex = 8;
            // 
            // numericUpDownKeyLength
            // 
            this.numericUpDownKeyLength.Location = new System.Drawing.Point(122, 21);
            this.numericUpDownKeyLength.Name = "numericUpDownKeyLength";
            this.numericUpDownKeyLength.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownKeyLength.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kaç kere oluşturulsun: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Key uzunluğu";
            // 
            // listBoxKeys
            // 
            this.listBoxKeys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxKeys.Enabled = false;
            this.listBoxKeys.FormattingEnabled = true;
            this.listBoxKeys.Items.AddRange(new object[] {
            "Keyler burada gösterilir"});
            this.listBoxKeys.Location = new System.Drawing.Point(0, 256);
            this.listBoxKeys.Name = "listBoxKeys";
            this.listBoxKeys.Size = new System.Drawing.Size(523, 147);
            this.listBoxKeys.TabIndex = 5;
            // 
            // Keygen_API
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 403);
            this.Controls.Add(this.listBoxKeys);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Keygen_API";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keygen API";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKeyLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rastgeleBirAlgoritmaOluşturToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfKeys;
        private System.Windows.Forms.NumericUpDown numericUpDownKeyLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxKeys;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.Timer keyUretimTimer;
    }
}