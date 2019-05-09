namespace KeyRepeater
{
    partial class HotKeyUI
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.KeyGlobal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(12, 47);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(192, 23);
            this.Button_OK.TabIndex = 0;
            this.Button_OK.Text = "确定";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // KeyGlobal
            // 
            this.KeyGlobal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyGlobal.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyGlobal.FormattingEnabled = true;
            this.KeyGlobal.Location = new System.Drawing.Point(12, 12);
            this.KeyGlobal.Name = "KeyGlobal";
            this.KeyGlobal.Size = new System.Drawing.Size(192, 29);
            this.KeyGlobal.TabIndex = 3;
            // 
            // HotKeyUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(216, 77);
            this.Controls.Add(this.KeyGlobal);
            this.Controls.Add(this.Button_OK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotKeyUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置全局热键";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.ComboBox KeyGlobal;
    }
}