namespace ImageDownload
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
            this.prg_thread = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_single_thread = new System.Windows.Forms.Label();
            this.tmr_thread = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_dl_single = new System.Windows.Forms.Label();
            this.btn_multi_thread = new System.Windows.Forms.Button();
            this.lbl_dl_multi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.num_threads = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_threads)).BeginInit();
            this.SuspendLayout();
            // 
            // prg_thread
            // 
            this.prg_thread.Location = new System.Drawing.Point(11, 81);
            this.prg_thread.Name = "prg_thread";
            this.prg_thread.Size = new System.Drawing.Size(747, 43);
            this.prg_thread.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "total seconds:";
            // 
            // lbl_single_thread
            // 
            this.lbl_single_thread.AutoSize = true;
            this.lbl_single_thread.Location = new System.Drawing.Point(267, 60);
            this.lbl_single_thread.Name = "lbl_single_thread";
            this.lbl_single_thread.Size = new System.Drawing.Size(14, 16);
            this.lbl_single_thread.TabIndex = 4;
            this.lbl_single_thread.Text = "0";
            // 
            // tmr_thread
            // 
            this.tmr_thread.Interval = 1000;
            this.tmr_thread.Tick += new System.EventHandler(this.tmr_single_thread_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "sec";
            // 
            // lbl_dl_single
            // 
            this.lbl_dl_single.AutoSize = true;
            this.lbl_dl_single.Location = new System.Drawing.Point(13, 137);
            this.lbl_dl_single.Name = "lbl_dl_single";
            this.lbl_dl_single.Size = new System.Drawing.Size(0, 16);
            this.lbl_dl_single.TabIndex = 6;
            // 
            // btn_multi_thread
            // 
            this.btn_multi_thread.Location = new System.Drawing.Point(11, 28);
            this.btn_multi_thread.Name = "btn_multi_thread";
            this.btn_multi_thread.Size = new System.Drawing.Size(140, 43);
            this.btn_multi_thread.TabIndex = 7;
            this.btn_multi_thread.Text = "START";
            this.btn_multi_thread.UseVisualStyleBackColor = true;
            this.btn_multi_thread.Click += new System.EventHandler(this.btn_multi_thread_Click);
            // 
            // lbl_dl_multi
            // 
            this.lbl_dl_multi.AutoSize = true;
            this.lbl_dl_multi.Location = new System.Drawing.Point(43, 232);
            this.lbl_dl_multi.Name = "lbl_dl_multi";
            this.lbl_dl_multi.Size = new System.Drawing.Size(0, 16);
            this.lbl_dl_multi.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "number of threads:";
            // 
            // num_threads
            // 
            this.num_threads.Location = new System.Drawing.Point(302, 26);
            this.num_threads.Name = "num_threads";
            this.num_threads.Size = new System.Drawing.Size(62, 22);
            this.num_threads.TabIndex = 13;
            this.num_threads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 169);
            this.Controls.Add(this.num_threads);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_multi_thread);
            this.Controls.Add(this.lbl_dl_multi);
            this.Controls.Add(this.lbl_dl_single);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_single_thread);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prg_thread);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Image Downloader Using Threads";
            ((System.ComponentModel.ISupportInitialize)(this.num_threads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar prg_thread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_single_thread;
        private System.Windows.Forms.Timer tmr_thread;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_dl_single;
        private System.Windows.Forms.Button btn_multi_thread;
        private System.Windows.Forms.Label lbl_dl_multi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_threads;
    }
}

