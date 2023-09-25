
namespace FichaTecnicaFacil.Views.subviews
{
    partial class FrmIngrediente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_ListaProdutos = new System.Windows.Forms.DataGridView();
            this.Ingrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preco_embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conteudo_embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.un = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_ConteudoEmbalagem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_SalvarProduto = new System.Windows.Forms.Button();
            this.Cb_UN = new System.Windows.Forms.ComboBox();
            this.txt_PrecoEmbalagem = new System.Windows.Forms.TextBox();
            this.txt_decricao = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_NumProdutosCadastrados = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaProdutos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.21239F));
            this.tableLayoutPanel1.Controls.Add(this.dgv_ListaProdutos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 557F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1160, 704);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // dgv_ListaProdutos
            // 
            this.dgv_ListaProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ListaProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ListaProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListaProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ListaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListaProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ingrediente,
            this.preco_embalagem,
            this.conteudo_embalagem,
            this.un,
            this.delete,
            this.editar});
            this.dgv_ListaProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ListaProdutos.Location = new System.Drawing.Point(0, 97);
            this.dgv_ListaProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_ListaProdutos.Name = "dgv_ListaProdutos";
            this.dgv_ListaProdutos.RowHeadersVisible = false;
            this.dgv_ListaProdutos.Size = new System.Drawing.Size(1160, 557);
            this.dgv_ListaProdutos.TabIndex = 2;
            // 
            // Ingrediente
            // 
            this.Ingrediente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ingrediente.HeaderText = "Ingredientes";
            this.Ingrediente.Name = "Ingrediente";
            // 
            // preco_embalagem
            // 
            this.preco_embalagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.preco_embalagem.HeaderText = "Preço de Embalagem(Fechada)";
            this.preco_embalagem.Name = "preco_embalagem";
            this.preco_embalagem.Width = 204;
            // 
            // conteudo_embalagem
            // 
            this.conteudo_embalagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.conteudo_embalagem.HeaderText = "Conteudo/Embalagem";
            this.conteudo_embalagem.Name = "conteudo_embalagem";
            this.conteudo_embalagem.Width = 173;
            // 
            // un
            // 
            this.un.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.un.HeaderText = "Unidade/Medida";
            this.un.Name = "un";
            this.un.Width = 139;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.delete.HeaderText = "delete";
            this.delete.Name = "delete";
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 60;
            // 
            // editar
            // 
            this.editar.HeaderText = "EDIT";
            this.editar.Name = "editar";
            this.editar.Text = "Editar";
            this.editar.UseColumnTextForButtonValue = true;
            this.editar.Width = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ConteudoEmbalagem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_SalvarProduto);
            this.groupBox1.Controls.Add(this.Cb_UN);
            this.groupBox1.Controls.Add(this.txt_PrecoEmbalagem);
            this.groupBox1.Controls.Add(this.txt_decricao);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1154, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PRODUTOS DE USO (INGREDIENTES)";
            // 
            // txt_ConteudoEmbalagem
            // 
            this.txt_ConteudoEmbalagem.BackColor = System.Drawing.Color.Yellow;
            this.txt_ConteudoEmbalagem.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConteudoEmbalagem.ForeColor = System.Drawing.Color.Red;
            this.txt_ConteudoEmbalagem.Location = new System.Drawing.Point(766, 49);
            this.txt_ConteudoEmbalagem.Name = "txt_ConteudoEmbalagem";
            this.txt_ConteudoEmbalagem.Size = new System.Drawing.Size(162, 29);
            this.txt_ConteudoEmbalagem.TabIndex = 10;
            this.txt_ConteudoEmbalagem.Text = "-";
            this.txt_ConteudoEmbalagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(763, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Conteúdo/Embalagem:";
            // 
            // btn_SalvarProduto
            // 
            this.btn_SalvarProduto.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_SalvarProduto.FlatAppearance.BorderSize = 0;
            this.btn_SalvarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SalvarProduto.Image = global::FichaTecnicaFacil.Properties.Resources.salvar2;
            this.btn_SalvarProduto.Location = new System.Drawing.Point(969, 23);
            this.btn_SalvarProduto.Name = "btn_SalvarProduto";
            this.btn_SalvarProduto.Size = new System.Drawing.Size(135, 56);
            this.btn_SalvarProduto.TabIndex = 8;
            this.btn_SalvarProduto.Text = "SALVAR";
            this.btn_SalvarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SalvarProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SalvarProduto.UseVisualStyleBackColor = false;
            // 
            // Cb_UN
            // 
            this.Cb_UN.BackColor = System.Drawing.Color.Yellow;
            this.Cb_UN.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cb_UN.FormattingEnabled = true;
            this.Cb_UN.Items.AddRange(new object[] {
            "UN",
            "CT",
            "CX",
            "G(Gramas)",
            "Kg",
            "mL",
            "Lts",
            "PT",
            "RL",
            "DZ",
            "m",
            "cm",
            "",
            ""});
            this.Cb_UN.Location = new System.Drawing.Point(659, 49);
            this.Cb_UN.Name = "Cb_UN";
            this.Cb_UN.Size = new System.Drawing.Size(101, 30);
            this.Cb_UN.TabIndex = 7;
            // 
            // txt_PrecoEmbalagem
            // 
            this.txt_PrecoEmbalagem.BackColor = System.Drawing.Color.Yellow;
            this.txt_PrecoEmbalagem.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecoEmbalagem.ForeColor = System.Drawing.Color.Red;
            this.txt_PrecoEmbalagem.Location = new System.Drawing.Point(500, 50);
            this.txt_PrecoEmbalagem.Name = "txt_PrecoEmbalagem";
            this.txt_PrecoEmbalagem.Size = new System.Drawing.Size(153, 29);
            this.txt_PrecoEmbalagem.TabIndex = 6;
            this.txt_PrecoEmbalagem.Text = "R$ 0,00";
            this.txt_PrecoEmbalagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_decricao
            // 
            this.txt_decricao.BackColor = System.Drawing.Color.Yellow;
            this.txt_decricao.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_decricao.Location = new System.Drawing.Point(91, 50);
            this.txt_decricao.Name = "txt_decricao";
            this.txt_decricao.Size = new System.Drawing.Size(403, 29);
            this.txt_decricao.TabIndex = 5;
            this.txt_decricao.Text = "-";
            this.txt_decricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txt_id.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Location = new System.Drawing.Point(12, 50);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(73, 29);
            this.txt_id.TabIndex = 4;
            this.txt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "UN (medida):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Preço da Embalagem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descricao (Ex. \"Leite Condensado\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.txt_NumProdutosCadastrados);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 657);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 44);
            this.panel1.TabIndex = 1;
            // 
            // txt_NumProdutosCadastrados
            // 
            this.txt_NumProdutosCadastrados.BackColor = System.Drawing.Color.Yellow;
            this.txt_NumProdutosCadastrados.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NumProdutosCadastrados.Location = new System.Drawing.Point(262, 8);
            this.txt_NumProdutosCadastrados.Name = "txt_NumProdutosCadastrados";
            this.txt_NumProdutosCadastrados.Size = new System.Drawing.Size(120, 29);
            this.txt_NumProdutosCadastrados.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Cornsilk;
            this.label6.Location = new System.Drawing.Point(5, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "QUANTIDADE CADASTRADA:";
            // 
            // FrmIngrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 704);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmIngrediente";
            this.Text = "PRODUTOS";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaProdutos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn preco_embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn conteudo_embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn un;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_decricao;
        public System.Windows.Forms.TextBox txt_id;
        public System.Windows.Forms.TextBox txt_PrecoEmbalagem;
        public System.Windows.Forms.ComboBox Cb_UN;
        public System.Windows.Forms.TextBox txt_ConteudoEmbalagem;
        public System.Windows.Forms.Button btn_SalvarProduto;
        public System.Windows.Forms.DataGridView dgv_ListaProdutos;
        public System.Windows.Forms.TextBox txt_NumProdutosCadastrados;
    }
}