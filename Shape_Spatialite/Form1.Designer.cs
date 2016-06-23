namespace Shape_Spatialite
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
            this.btnCreateShape = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateShape
            // 
            this.btnCreateShape.Location = new System.Drawing.Point(80, 64);
            this.btnCreateShape.Name = "btnCreateShape";
            this.btnCreateShape.Size = new System.Drawing.Size(97, 23);
            this.btnCreateShape.TabIndex = 0;
            this.btnCreateShape.Text = "Create Shape";
            this.btnCreateShape.UseVisualStyleBackColor = true;
            this.btnCreateShape.Click += new System.EventHandler(this.btnCreateShape_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 212);
            this.Controls.Add(this.btnCreateShape);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateShape;

    }
}

