namespace GraphMaker
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonCreate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxVertexes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEdges = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonColorPicker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 93);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(154, 23);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Atualizar";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(172, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 428);
            this.panel1.TabIndex = 1;
            // 
            // textBoxVertexes
            // 
            this.textBoxVertexes.Location = new System.Drawing.Point(66, 12);
            this.textBoxVertexes.Name = "textBoxVertexes";
            this.textBoxVertexes.Size = new System.Drawing.Size(100, 20);
            this.textBoxVertexes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vértices:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Arestas:";
            // 
            // textBoxEdges
            // 
            this.textBoxEdges.Location = new System.Drawing.Point(66, 38);
            this.textBoxEdges.Name = "textBoxEdges";
            this.textBoxEdges.Size = new System.Drawing.Size(100, 20);
            this.textBoxEdges.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cor:";
            // 
            // buttonColorPicker
            // 
            this.buttonColorPicker.BackColor = System.Drawing.Color.Black;
            this.buttonColorPicker.Location = new System.Drawing.Point(66, 64);
            this.buttonColorPicker.Name = "buttonColorPicker";
            this.buttonColorPicker.Size = new System.Drawing.Size(23, 23);
            this.buttonColorPicker.TabIndex = 7;
            this.buttonColorPicker.UseVisualStyleBackColor = false;
            this.buttonColorPicker.Click += new System.EventHandler(this.buttonColorPicker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 452);
            this.Controls.Add(this.buttonColorPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEdges);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxVertexes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCreate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Graph Maker";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxVertexes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEdges;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonColorPicker;
    }
}

