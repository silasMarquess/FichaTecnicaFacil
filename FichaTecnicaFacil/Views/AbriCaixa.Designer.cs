
namespace FichaTecnicaFacil.Views
{
    partial class AbriCaixa
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHorarioAberturaCaixa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorIncicoCaixa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataAberturaCaixa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAbriCaixa = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HORÁRIO ABERTURA:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtHorarioAberturaCaixa
            // 
            this.txtHorarioAberturaCaixa.BackColor = System.Drawing.SystemColors.Control;
            this.txtHorarioAberturaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHorarioAberturaCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHorarioAberturaCaixa.Location = new System.Drawing.Point(140, 78);
            this.txtHorarioAberturaCaixa.Name = "txtHorarioAberturaCaixa";
            this.txtHorarioAberturaCaixa.Size = new System.Drawing.Size(176, 16);
            this.txtHorarioAberturaCaixa.TabIndex = 1;
            this.txtHorarioAberturaCaixa.Text = "00:00:00";
            this.txtHorarioAberturaCaixa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "(Horário de Brasília)";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "VALOR INÍCIO R$:";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtValorIncicoCaixa
            // 
            this.txtValorIncicoCaixa.BackColor = System.Drawing.Color.Yellow;
            this.txtValorIncicoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorIncicoCaixa.ForeColor = System.Drawing.Color.Blue;
            this.txtValorIncicoCaixa.Location = new System.Drawing.Point(140, 135);
            this.txtValorIncicoCaixa.Name = "txtValorIncicoCaixa";
            this.txtValorIncicoCaixa.Size = new System.Drawing.Size(176, 32);
            this.txtValorIncicoCaixa.TabIndex = 1;
            this.txtValorIncicoCaixa.Text = "0,00";
            this.txtValorIncicoCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorIncicoCaixa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "ABERTURA DE CAIXA";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDataAberturaCaixa
            // 
            this.txtDataAberturaCaixa.BackColor = System.Drawing.SystemColors.Control;
            this.txtDataAberturaCaixa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataAberturaCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataAberturaCaixa.Location = new System.Drawing.Point(140, 51);
            this.txtDataAberturaCaixa.Name = "txtDataAberturaCaixa";
            this.txtDataAberturaCaixa.Size = new System.Drawing.Size(176, 16);
            this.txtDataAberturaCaixa.TabIndex = 1;
            this.txtDataAberturaCaixa.Text = "08/12/2000";
            this.txtDataAberturaCaixa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "DATA:";
            this.label6.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAbriCaixa
            // 
            this.btnAbriCaixa.Location = new System.Drawing.Point(140, 173);
            this.btnAbriCaixa.Name = "btnAbriCaixa";
            this.btnAbriCaixa.Size = new System.Drawing.Size(129, 31);
            this.btnAbriCaixa.TabIndex = 2;
            this.btnAbriCaixa.Text = "Abrir Caixa";
            this.btnAbriCaixa.UseVisualStyleBackColor = true;
            this.btnAbriCaixa.Click += new System.EventHandler(this.btnAbriCaixa_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AbriCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 246);
            this.Controls.Add(this.btnAbriCaixa);
            this.Controls.Add(this.txtValorIncicoCaixa);
            this.Controls.Add(this.txtDataAberturaCaixa);
            this.Controls.Add(this.txtHorarioAberturaCaixa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "AbriCaixa";
            this.Text = "AbriCaixa";
            this.Load += new System.EventHandler(this.AbriCaixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtDataAberturaCaixa;
        public System.Windows.Forms.TextBox txtHorarioAberturaCaixa;
        public System.Windows.Forms.TextBox txtValorIncicoCaixa;
        public System.Windows.Forms.Button btnAbriCaixa;
        private System.Windows.Forms.Timer timer1;
    }
}