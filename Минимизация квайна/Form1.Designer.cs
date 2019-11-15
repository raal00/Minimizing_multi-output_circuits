namespace КупсачАвтоматы
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.minBtn = new System.Windows.Forms.Button();
            this.functionText = new System.Windows.Forms.RichTextBox();
            this.inputFunctionBox = new System.Windows.Forms.TextBox();
            this.deleteFunctionBtn = new System.Windows.Forms.Button();
            this.resTB = new System.Windows.Forms.RichTextBox();
            this.functionLabel = new System.Windows.Forms.Label();
            this.resClearbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // minBtn
            // 
            this.minBtn.Location = new System.Drawing.Point(691, 403);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(286, 59);
            this.minBtn.TabIndex = 1;
            this.minBtn.Text = "Минимизировать систему";
            this.minBtn.UseVisualStyleBackColor = true;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // functionText
            // 
            this.functionText.Location = new System.Drawing.Point(507, 12);
            this.functionText.Name = "functionText";
            this.functionText.Size = new System.Drawing.Size(470, 135);
            this.functionText.TabIndex = 2;
            this.functionText.Text = "";
            // 
            // inputFunctionBox
            // 
            this.inputFunctionBox.Location = new System.Drawing.Point(165, 12);
            this.inputFunctionBox.Name = "inputFunctionBox";
            this.inputFunctionBox.Size = new System.Drawing.Size(336, 26);
            this.inputFunctionBox.TabIndex = 4;
            // 
            // deleteFunctionBtn
            // 
            this.deleteFunctionBtn.Location = new System.Drawing.Point(334, 99);
            this.deleteFunctionBtn.Name = "deleteFunctionBtn";
            this.deleteFunctionBtn.Size = new System.Drawing.Size(167, 48);
            this.deleteFunctionBtn.TabIndex = 5;
            this.deleteFunctionBtn.Text = "Удалить функцию";
            this.deleteFunctionBtn.UseVisualStyleBackColor = true;
            this.deleteFunctionBtn.Click += new System.EventHandler(this.deleteFunctionBtn_Click);
            // 
            // resTB
            // 
            this.resTB.Font = new System.Drawing.Font("Sitka Small", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resTB.Location = new System.Drawing.Point(507, 153);
            this.resTB.Name = "resTB";
            this.resTB.Size = new System.Drawing.Size(470, 222);
            this.resTB.TabIndex = 6;
            this.resTB.Text = "";
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.BackColor = System.Drawing.SystemColors.GrayText;
            this.functionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.functionLabel.Location = new System.Drawing.Point(12, 12);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(0, 20);
            this.functionLabel.TabIndex = 7;
            // 
            // resClearbtn
            // 
            this.resClearbtn.Location = new System.Drawing.Point(290, 327);
            this.resClearbtn.Name = "resClearbtn";
            this.resClearbtn.Size = new System.Drawing.Size(211, 48);
            this.resClearbtn.TabIndex = 8;
            this.resClearbtn.Text = "Очистить результат";
            this.resClearbtn.UseVisualStyleBackColor = true;
            this.resClearbtn.Click += new System.EventHandler(this.resClearbtn_Click);
            // 
            // Form1
            // 
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(989, 474);
            this.Controls.Add(this.resClearbtn);
            this.Controls.Add(this.functionLabel);
            this.Controls.Add(this.resTB);
            this.Controls.Add(this.deleteFunctionBtn);
            this.Controls.Add(this.inputFunctionBox);
            this.Controls.Add(this.functionText);
            this.Controls.Add(this.minBtn);
            this.Name = "Form1";
            this.Text = "Минимизация системы булевых функций";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.RichTextBox functionText;
        private System.Windows.Forms.TextBox inputFunctionBox;
        private System.Windows.Forms.Button deleteFunctionBtn;
        private System.Windows.Forms.RichTextBox resTB;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Button resClearbtn;
    }
}

