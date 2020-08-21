namespace proget_Reservation_chambre.formulaire
{
    partial class frmClasse
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
            this.txtDesignationClasse = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNvCla = new System.Windows.Forms.Button();
            this.buttonSup = new System.Windows.Forms.Button();
            this.buttonModi = new System.Windows.Forms.Button();
            this.buttonSaveClas = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDesignationClasse
            // 
            this.txtDesignationClasse.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignationClasse.Location = new System.Drawing.Point(233, 232);
            this.txtDesignationClasse.Name = "txtDesignationClasse";
            this.txtDesignationClasse.Size = new System.Drawing.Size(228, 26);
            this.txtDesignationClasse.TabIndex = 10;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(233, 200);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(228, 26);
            this.txtCode.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Desigation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "code";
            // 
            // buttonNvCla
            // 
            this.buttonNvCla.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNvCla.Location = new System.Drawing.Point(490, 178);
            this.buttonNvCla.Name = "buttonNvCla";
            this.buttonNvCla.Size = new System.Drawing.Size(128, 30);
            this.buttonNvCla.TabIndex = 22;
            this.buttonNvCla.Text = "Nauveau";
            this.buttonNvCla.UseVisualStyleBackColor = true;
            this.buttonNvCla.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonSup
            // 
            this.buttonSup.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSup.Location = new System.Drawing.Point(490, 281);
            this.buttonSup.Name = "buttonSup";
            this.buttonSup.Size = new System.Drawing.Size(128, 30);
            this.buttonSup.TabIndex = 21;
            this.buttonSup.Text = "Suprimer";
            this.buttonSup.UseVisualStyleBackColor = true;
            this.buttonSup.Click += new System.EventHandler(this.buttonSup_Click);
            // 
            // buttonModi
            // 
            this.buttonModi.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModi.Location = new System.Drawing.Point(490, 245);
            this.buttonModi.Name = "buttonModi";
            this.buttonModi.Size = new System.Drawing.Size(128, 30);
            this.buttonModi.TabIndex = 20;
            this.buttonModi.Text = "Modifier";
            this.buttonModi.UseVisualStyleBackColor = true;
            this.buttonModi.Click += new System.EventHandler(this.buttonModi_Click);
            // 
            // buttonSaveClas
            // 
            this.buttonSaveClas.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveClas.Location = new System.Drawing.Point(490, 213);
            this.buttonSaveClas.Name = "buttonSaveClas";
            this.buttonSaveClas.Size = new System.Drawing.Size(128, 30);
            this.buttonSaveClas.TabIndex = 19;
            this.buttonSaveClas.Text = "Enregistrer";
            this.buttonSaveClas.UseVisualStyleBackColor = true;
            this.buttonSaveClas.Click += new System.EventHandler(this.buttonSaveClas_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(666, 178);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 23;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // frmClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 551);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.buttonNvCla);
            this.Controls.Add(this.buttonSup);
            this.Controls.Add(this.buttonModi);
            this.Controls.Add(this.buttonSaveClas);
            this.Controls.Add(this.txtDesignationClasse);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmClasse";
            this.Text = "frmClasse";
            this.Load += new System.EventHandler(this.frmClasse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesignationClasse;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNvCla;
        private System.Windows.Forms.Button buttonSup;
        private System.Windows.Forms.Button buttonModi;
        private System.Windows.Forms.Button buttonSaveClas;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}