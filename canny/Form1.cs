using System;
using System.Drawing.Imaging;
using System.Drawing; 
using System.Windows.Forms;

namespace canny
{
    public partial class CannyEdgeDetectionForm : Form
    {
        private Bitmap origionalImage;
        private Bitmap edgedImage;
        private float TI;
        private float TH;
        private float MaskSize;
        private float Sigma;
        int[,] currentImage;
        public CannyEdgeDetectionForm()
        {
            InitializeComponent();
            DisableControls();
        }
        private void ApplyFilter()
        {
            try
            {
                Canny_Edge_Detection Canny = new Canny_Edge_Detection(currentImage, 5.1f, 1f);
                int[,] processedImage = Canny.DetectCannyEdges();
                edgedImage = DisplayImage(processedImage);
                imageBox.Image = edgedImage;
                EnableControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EnableControls()
        {
            btnImageBefore.Enabled = true;
            btnImageAfter.Enabled = true; 
            txtMaskSize.Enabled = true;
            txtSigmaforGaussianKernel.Enabled = true;
            txtTH.Enabled = true;
            txtTI.Enabled = true;
        }
        private void DisableControls()
        {
            btnFilter.Enabled = false;
            btnImageBefore.Enabled = false;
            btnImageAfter.Enabled = false;
            txtMaskSize.Enabled = false;
            txtSigmaforGaussianKernel.Enabled = false;
            txtTH.Enabled = false;
            txtTI.Enabled = false;
        }
        private int[,] ReadImage(Bitmap image)
        {
            try
            {
                int i, j;
                int[,] GreyImage = new int[image.Width, image.Height];  //[Row,Column]
                BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                         ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                unsafe
                {
                    byte* imagePointer1 = (byte*)bitmapData.Scan0;

                    for (i = 0; i < bitmapData.Height; i++)
                    {
                        for (j = 0; j < bitmapData.Width; j++)
                        {
                            GreyImage[j, i] = (int)((imagePointer1[0] + imagePointer1[1] + imagePointer1[2]) / 3.0);
                            //4 bytes per pixel
                            imagePointer1 += 4;
                        }//end for j
                         //4 bytes per pixel
                        imagePointer1 += bitmapData.Stride - (bitmapData.Width * 4);
                    }//end for i
                }//end unsafe
                image.UnlockBits(bitmapData);
                return GreyImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private Bitmap DisplayImage(int[,] GreyImage)
        {
            try
            {
                int i, j;
                int W, H;
                W = GreyImage.GetLength(0);
                H = GreyImage.GetLength(1);
                Bitmap image = new Bitmap(W, H);
                BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, W, H),
                                         ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                unsafe
                {

                    byte* imagePointer1 = (byte*)bitmapData1.Scan0;

                    for (i = 0; i < bitmapData1.Height; i++)
                    {
                        for (j = 0; j < bitmapData1.Width; j++)
                        {
                            // write the logic implementation here
                            imagePointer1[0] = (byte)GreyImage[j, i];
                            imagePointer1[1] = (byte)GreyImage[j, i];
                            imagePointer1[2] = (byte)GreyImage[j, i];
                            imagePointer1[3] = (byte)255;
                            //4 bytes per pixel
                            imagePointer1 += 4;
                        }   //end for j
                            //4 bytes per pixel
                        imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                    }//End for i
                }//end unsafe
                image.UnlockBits(bitmapData1);
                return image;// col;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private bool ValidateAllInputs()
        {
            if (this.Sigma != 0 && this.MaskSize != 0 && this.TH != 0 && this.TI != 0)
            {
                btnFilter.Enabled = true;
                return true;
            }
            return false;
        }
        private bool IsNumber(string text, out string errorMessage)
        { 
            if (string.IsNullOrEmpty(text))
            {
                errorMessage = "value is required.";
                return false;
            }
            if (text.Length==0 || string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "value is required.";
                return false;
            }

            float number;
            bool isNumeric = float.TryParse(text, out number);
            if (isNumeric)
            {
                errorMessage = "value must be numeric.";
                return true;
            }
            errorMessage = "value is invalid.";
            return false;
        }

        #region events
        private void browse_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ChooseImg = new OpenFileDialog();
                ChooseImg.ShowDialog();
                string filePath = ChooseImg.FileName;
                origionalImage = new Bitmap(filePath);
                if (origionalImage.Width > 600 || origionalImage.Height > 600)
                {
                    MessageBox.Show("the image is too big to be processed by me");
                }
                else
                {
                    imageBox.Image = origionalImage;
                    currentImage = ReadImage(origionalImage);
                    EnableControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (ValidateAllInputs())
                ApplyFilter();
        }
        private void txtSigmaforGaussianKernel_Validated(object sender, EventArgs e)
        {
            this.Sigma = float.Parse(txtSigmaforGaussianKernel.Text);
            errorProvider1.SetError(txtSigmaforGaussianKernel, "");
        }
        private void txtSigmaforGaussianKernel_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Sigma = 0.0f;
            string errorMsg = string.Empty;
            if (!IsNumber(txtSigmaforGaussianKernel.Text, out errorMsg))
            {
                e.Cancel = true;
                txtSigmaforGaussianKernel.Select(0, txtSigmaforGaussianKernel.Text.Length);
                this.errorProvider1.SetError(txtSigmaforGaussianKernel, errorMsg);
            }
        }
        private void txtTH_Validated(object sender, EventArgs e)
        {
            this.TH= float.Parse(txtTH.Text);
            errorProvider1.SetError(txtTH, "");
            ValidateAllInputs();
        }
        private void txtTH_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.TH = 0.0f;
            string errorMsg = string.Empty;
            if (!IsNumber(txtTH.Text, out errorMsg))
            {
                e.Cancel = true;
                txtTH.Select(0, txtTH.Text.Length);
                this.errorProvider1.SetError(txtTH, errorMsg);
            }
        }
        private void txtTI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.TI = 0.0f;
            string errorMsg = string.Empty;
            if (!IsNumber(txtTI.Text, out errorMsg))
            {
                e.Cancel = true;
                txtTH.Select(0, txtTI.Text.Length);
                this.errorProvider1.SetError(txtTI, errorMsg);
            }
        }
        private void txtTI_Validated(object sender, EventArgs e)
        {
            this.TI =float.Parse(txtTI.Text);
            errorProvider1.SetError(txtTI, "");
            ValidateAllInputs();
        }
        private void imageBefore_Click(object sender, EventArgs e)
        {
            imageBox.Image = origionalImage;
        }
        private void imageAfter_Click(object sender, EventArgs e)
        {
            imageBox.Image = edgedImage;

        }
        private void txtMaskSize_Validated(object sender, EventArgs e)
        {
            this.MaskSize = float.Parse(txtMaskSize.Text);
            errorProvider1.SetError(txtMaskSize, "");
            ValidateAllInputs();
        }
        private void txtMaskSize_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MaskSize = 0.0f;
            string errorMsg = string.Empty;
            if (!IsNumber(txtMaskSize.Text, out errorMsg))
            {
                e.Cancel = true;
                txtMaskSize.Select(0, txtMaskSize.Text.Length);
                this.errorProvider1.SetError(txtMaskSize, errorMsg);
            }
        }
        #endregion
    }
}
