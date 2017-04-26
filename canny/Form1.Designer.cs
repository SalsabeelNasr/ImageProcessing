namespace canny
{
    partial class CannyEdgeDetectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CannyEdgeDetectionForm));
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnImageBefore = new System.Windows.Forms.Button();
            this.btnImageAfter = new System.Windows.Forms.Button();
            this.txtMaskSize = new System.Windows.Forms.TextBox();
            this.lblGaussianMaskSize = new System.Windows.Forms.Label();
            this.txtSigmaforGaussianKernel = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.lblTH = new System.Windows.Forms.Label();
            this.txtTH = new System.Windows.Forms.TextBox();
            this.lblTI = new System.Windows.Forms.Label();
            this.txtTI = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Image = ((System.Drawing.Image)(resources.GetObject("imageBox.Image")));
            this.imageBox.Location = new System.Drawing.Point(15, 230);
            this.imageBox.Margin = new System.Windows.Forms.Padding(6);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(640, 480);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 15);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(205, 44);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // btnImageBefore
            // 
            this.btnImageBefore.Enabled = false;
            this.btnImageBefore.Location = new System.Drawing.Point(15, 174);
            this.btnImageBefore.Margin = new System.Windows.Forms.Padding(6);
            this.btnImageBefore.Name = "btnImageBefore";
            this.btnImageBefore.Size = new System.Drawing.Size(205, 44);
            this.btnImageBefore.TabIndex = 4;
            this.btnImageBefore.Text = "Before";
            this.btnImageBefore.UseVisualStyleBackColor = true;
            this.btnImageBefore.Click += new System.EventHandler(this.imageBefore_Click);
            // 
            // btnImageAfter
            // 
            this.btnImageAfter.Enabled = false;
            this.btnImageAfter.Location = new System.Drawing.Point(232, 174);
            this.btnImageAfter.Margin = new System.Windows.Forms.Padding(6);
            this.btnImageAfter.Name = "btnImageAfter";
            this.btnImageAfter.Size = new System.Drawing.Size(205, 44);
            this.btnImageAfter.TabIndex = 5;
            this.btnImageAfter.Text = "After";
            this.btnImageAfter.UseVisualStyleBackColor = true;
            this.btnImageAfter.Click += new System.EventHandler(this.imageAfter_Click);
            // 
            // txtMaskSize
            // 
            this.txtMaskSize.Location = new System.Drawing.Point(222, 85);
            this.txtMaskSize.Name = "txtMaskSize";
            this.txtMaskSize.Size = new System.Drawing.Size(203, 29);
            this.txtMaskSize.TabIndex = 6;
            this.txtMaskSize.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaskSize_Validating);
            this.txtMaskSize.Validated += new System.EventHandler(this.txtMaskSize_Validated);
            // 
            // lblGaussianMaskSize
            // 
            this.lblGaussianMaskSize.AutoSize = true;
            this.lblGaussianMaskSize.Location = new System.Drawing.Point(24, 85);
            this.lblGaussianMaskSize.Name = "lblGaussianMaskSize";
            this.lblGaussianMaskSize.Size = new System.Drawing.Size(192, 25);
            this.lblGaussianMaskSize.TabIndex = 7;
            this.lblGaussianMaskSize.Text = "Gaussian Mask Size";
            // 
            // txtSigmaforGaussianKernel
            // 
            this.txtSigmaforGaussianKernel.Location = new System.Drawing.Point(723, 85);
            this.txtSigmaforGaussianKernel.Name = "txtSigmaforGaussianKernel";
            this.txtSigmaforGaussianKernel.Size = new System.Drawing.Size(203, 29);
            this.txtSigmaforGaussianKernel.TabIndex = 8;
            this.txtSigmaforGaussianKernel.Validating += new System.ComponentModel.CancelEventHandler(this.txtSigmaforGaussianKernel_Validating);
            this.txtSigmaforGaussianKernel.Validated += new System.EventHandler(this.txtSigmaforGaussianKernel_Validated);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(472, 85);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(245, 25);
            this.lbl.TabIndex = 9;
            this.lbl.Text = "Sigma for Gaussian Kernel";
            // 
            // lblTH
            // 
            this.lblTH.AutoSize = true;
            this.lblTH.Location = new System.Drawing.Point(177, 124);
            this.lblTH.Name = "lblTH";
            this.lblTH.Size = new System.Drawing.Size(39, 25);
            this.lblTH.TabIndex = 10;
            this.lblTH.Text = "TH";
            // 
            // txtTH
            // 
            this.txtTH.Location = new System.Drawing.Point(222, 120);
            this.txtTH.Name = "txtTH";
            this.txtTH.Size = new System.Drawing.Size(203, 29);
            this.txtTH.TabIndex = 11;
            this.txtTH.Validating += new System.ComponentModel.CancelEventHandler(this.txtTH_Validating);
            this.txtTH.Validated += new System.EventHandler(this.txtTH_Validated);
            // 
            // lblTI
            // 
            this.lblTI.AutoSize = true;
            this.lblTI.Location = new System.Drawing.Point(687, 124);
            this.lblTI.Name = "lblTI";
            this.lblTI.Size = new System.Drawing.Size(30, 25);
            this.lblTI.TabIndex = 12;
            this.lblTI.Text = "TI";
            // 
            // txtTI
            // 
            this.txtTI.Location = new System.Drawing.Point(723, 120);
            this.txtTI.Name = "txtTI";
            this.txtTI.Size = new System.Drawing.Size(203, 29);
            this.txtTI.TabIndex = 13;
            this.txtTI.Validating += new System.ComponentModel.CancelEventHandler(this.txtTI_Validating);
            this.txtTI.Validated += new System.EventHandler(this.txtTI_Validated);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(989, 85);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(197, 64);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CannyEdgeDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 826);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtTI);
            this.Controls.Add(this.lblTI);
            this.Controls.Add(this.txtTH);
            this.Controls.Add(this.lblTH);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtSigmaforGaussianKernel);
            this.Controls.Add(this.lblGaussianMaskSize);
            this.Controls.Add(this.txtMaskSize);
            this.Controls.Add(this.btnImageAfter);
            this.Controls.Add(this.btnImageBefore);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.imageBox);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CannyEdgeDetectionForm";
            this.Text = "Canny Edge Detection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnImageBefore;
        private System.Windows.Forms.Button btnImageAfter;
        private System.Windows.Forms.TextBox txtMaskSize;
        private System.Windows.Forms.Label lblGaussianMaskSize;
        private System.Windows.Forms.TextBox txtSigmaforGaussianKernel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblTH;
        private System.Windows.Forms.TextBox txtTH;
        private System.Windows.Forms.Label lblTI;
        private System.Windows.Forms.TextBox txtTI;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

