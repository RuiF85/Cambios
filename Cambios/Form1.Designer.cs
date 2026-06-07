namespace Cambios
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            TextBoxValor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ComboBoxOrigem = new ComboBox();
            ComboBoxDestino = new ComboBox();
            ButtonConverter = new Button();
            LabelResultado = new Label();
            LabelStatus = new Label();
            ProgressBar = new ProgressBar();
            BtnTroca = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 47);
            label1.Name = "label1";
            label1.Size = new Size(55, 21);
            label1.TabIndex = 0;
            label1.Text = "Valor:";
            // 
            // TextBoxValor
            // 
            TextBoxValor.Location = new Point(118, 47);
            TextBoxValor.Name = "TextBoxValor";
            TextBoxValor.Size = new Size(100, 25);
            TextBoxValor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(52, 90);
            label2.Name = "label2";
            label2.Size = new Size(149, 21);
            label2.TabIndex = 2;
            label2.Text = "Moeda de origem:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 137);
            label3.Name = "label3";
            label3.Size = new Size(151, 21);
            label3.TabIndex = 3;
            label3.Text = "Moeda de destino:";
            // 
            // ComboBoxOrigem
            // 
            ComboBoxOrigem.FormattingEnabled = true;
            ComboBoxOrigem.Location = new Point(209, 90);
            ComboBoxOrigem.Name = "ComboBoxOrigem";
            ComboBoxOrigem.Size = new Size(236, 25);
            ComboBoxOrigem.TabIndex = 4;
            // 
            // ComboBoxDestino
            // 
            ComboBoxDestino.FormattingEnabled = true;
            ComboBoxDestino.Location = new Point(209, 137);
            ComboBoxDestino.Name = "ComboBoxDestino";
            ComboBoxDestino.Size = new Size(236, 25);
            ComboBoxDestino.TabIndex = 5;
            // 
            // ButtonConverter
            // 
            ButtonConverter.Enabled = false;
            ButtonConverter.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ButtonConverter.Location = new Point(506, 61);
            ButtonConverter.Name = "ButtonConverter";
            ButtonConverter.Size = new Size(111, 41);
            ButtonConverter.TabIndex = 6;
            ButtonConverter.Text = "Converter";
            ButtonConverter.UseVisualStyleBackColor = true;
            ButtonConverter.Click += ButtonConverter_Click;
            // 
            // LabelResultado
            // 
            LabelResultado.AutoSize = true;
            LabelResultado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelResultado.Location = new Point(52, 198);
            LabelResultado.Name = "LabelResultado";
            LabelResultado.Size = new Size(353, 21);
            LabelResultado.TabIndex = 7;
            LabelResultado.Text = "Escolha um valor moeda de origem e destino";
            // 
            // LabelStatus
            // 
            LabelStatus.AutoSize = true;
            LabelStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelStatus.Location = new Point(50, 253);
            LabelStatus.Name = "LabelStatus";
            LabelStatus.Size = new Size(57, 21);
            LabelStatus.TabIndex = 8;
            LabelStatus.Text = "Status";
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(556, 253);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(137, 21);
            ProgressBar.TabIndex = 9;
            // 
            // BtnTroca
            // 
            BtnTroca.BackColor = Color.Aquamarine;
            BtnTroca.BackgroundImage = (Image)resources.GetObject("BtnTroca.BackgroundImage");
            BtnTroca.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTroca.Enabled = false;
            BtnTroca.Location = new Point(534, 108);
            BtnTroca.Name = "BtnTroca";
            BtnTroca.Size = new Size(59, 54);
            BtnTroca.TabIndex = 11;
            BtnTroca.UseVisualStyleBackColor = false;
            BtnTroca.Click += BtnTroca_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 308);
            Controls.Add(BtnTroca);
            Controls.Add(ProgressBar);
            Controls.Add(LabelStatus);
            Controls.Add(LabelResultado);
            Controls.Add(ButtonConverter);
            Controls.Add(ComboBoxDestino);
            Controls.Add(ComboBoxOrigem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxValor);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Câmbios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxValor;
        private Label label2;
        private Label label3;
        private ComboBox ComboBoxOrigem;
        private ComboBox ComboBoxDestino;
        private Button ButtonConverter;
        private Label LabelResultado;
        private Label LabelStatus;
        private ProgressBar ProgressBar;
        private Button BtnTroca;
    }
}
