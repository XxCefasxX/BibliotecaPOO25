namespace BibliotecaForms
{
    partial class Menu
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
            this.bt_libros = new System.Windows.Forms.Button();
            this.bt_autores = new System.Windows.Forms.Button();
            this.bt_categorias = new System.Windows.Forms.Button();
            this.bt_editorlaes = new System.Windows.Forms.Button();
            this.t_prestamos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_libros
            // 
            this.bt_libros.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_libros.Location = new System.Drawing.Point(12, 12);
            this.bt_libros.Name = "bt_libros";
            this.bt_libros.Size = new System.Drawing.Size(92, 55);
            this.bt_libros.TabIndex = 0;
            this.bt_libros.Text = "Libros";
            this.bt_libros.UseVisualStyleBackColor = true;
            this.bt_libros.Click += new System.EventHandler(this.bt_libros_Click);
            // 
            // bt_autores
            // 
            this.bt_autores.Location = new System.Drawing.Point(143, 12);
            this.bt_autores.Name = "bt_autores";
            this.bt_autores.Size = new System.Drawing.Size(75, 23);
            this.bt_autores.TabIndex = 1;
            this.bt_autores.Text = "Autores";
            this.bt_autores.UseVisualStyleBackColor = true;
            this.bt_autores.Click += new System.EventHandler(this.bt_autores_Click);
            // 
            // bt_categorias
            // 
            this.bt_categorias.Location = new System.Drawing.Point(241, 12);
            this.bt_categorias.Name = "bt_categorias";
            this.bt_categorias.Size = new System.Drawing.Size(75, 23);
            this.bt_categorias.TabIndex = 2;
            this.bt_categorias.Text = "Categorias";
            this.bt_categorias.UseVisualStyleBackColor = true;
            this.bt_categorias.Click += new System.EventHandler(this.bt_categorias_Click);
            // 
            // bt_editorlaes
            // 
            this.bt_editorlaes.Location = new System.Drawing.Point(336, 12);
            this.bt_editorlaes.Name = "bt_editorlaes";
            this.bt_editorlaes.Size = new System.Drawing.Size(96, 23);
            this.bt_editorlaes.TabIndex = 3;
            this.bt_editorlaes.Text = "Editoriales";
            this.bt_editorlaes.UseVisualStyleBackColor = true;
            this.bt_editorlaes.Click += new System.EventHandler(this.bt_editorlaes_Click);
            // 
            // t_prestamos
            // 
            this.t_prestamos.Location = new System.Drawing.Point(143, 62);
            this.t_prestamos.Name = "t_prestamos";
            this.t_prestamos.Size = new System.Drawing.Size(75, 23);
            this.t_prestamos.TabIndex = 4;
            this.t_prestamos.Text = "Prestamos";
            this.t_prestamos.UseVisualStyleBackColor = true;
            this.t_prestamos.Click += new System.EventHandler(this.t_prestamos_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 125);
            this.Controls.Add(this.t_prestamos);
            this.Controls.Add(this.bt_editorlaes);
            this.Controls.Add(this.bt_categorias);
            this.Controls.Add(this.bt_autores);
            this.Controls.Add(this.bt_libros);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_libros;
        private System.Windows.Forms.Button bt_autores;
        private System.Windows.Forms.Button bt_categorias;
        private System.Windows.Forms.Button bt_editorlaes;
        private System.Windows.Forms.Button t_prestamos;
    }
}