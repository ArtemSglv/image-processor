namespace Image_Processor
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
            this.loadButton = new System.Windows.Forms.Button();
            this.convolutionButton = new System.Windows.Forms.Button();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.inputPictureBox = new System.Windows.Forms.PictureBox();
            this.outputPictureBox = new System.Windows.Forms.PictureBox();
            this.inputPanel.SuspendLayout();
            this.outputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(13, 13);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(109, 33);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // convolutionButton
            // 
            this.convolutionButton.Location = new System.Drawing.Point(149, 13);
            this.convolutionButton.Name = "convolutionButton";
            this.convolutionButton.Size = new System.Drawing.Size(109, 33);
            this.convolutionButton.TabIndex = 1;
            this.convolutionButton.Text = "Convolution";
            this.convolutionButton.UseVisualStyleBackColor = true;
            this.convolutionButton.Click += new System.EventHandler(this.convolutionButton_Click);
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.inputPictureBox);
            this.inputPanel.Location = new System.Drawing.Point(13, 61);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(469, 544);
            this.inputPanel.TabIndex = 2;
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.outputPictureBox);
            this.outputPanel.Location = new System.Drawing.Point(494, 61);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(469, 544);
            this.outputPanel.TabIndex = 3;
            // 
            // inputPictureBox
            // 
            this.inputPictureBox.Location = new System.Drawing.Point(3, 3);
            this.inputPictureBox.Name = "inputPictureBox";
            this.inputPictureBox.Size = new System.Drawing.Size(191, 89);
            this.inputPictureBox.TabIndex = 0;
            this.inputPictureBox.TabStop = false;
            // 
            // outputPictureBox
            // 
            this.outputPictureBox.Location = new System.Drawing.Point(3, 3);
            this.outputPictureBox.Name = "outputPictureBox";
            this.outputPictureBox.Size = new System.Drawing.Size(191, 89);
            this.outputPictureBox.TabIndex = 1;
            this.outputPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 617);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.convolutionButton);
            this.Controls.Add(this.loadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.inputPanel.ResumeLayout(false);
            this.outputPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button convolutionButton;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.PictureBox inputPictureBox;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.PictureBox outputPictureBox;
    }
}

