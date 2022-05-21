
namespace WindowsFormsApp1
{
    partial class CartUC
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartUC));
            this.ProductPB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plusPB = new System.Windows.Forms.PictureBox();
            this.minusPB = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusPB)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductPB
            // 
            this.ProductPB.Location = new System.Drawing.Point(0, 0);
            this.ProductPB.Name = "ProductPB";
            this.ProductPB.Size = new System.Drawing.Size(120, 120);
            this.ProductPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProductPB.TabIndex = 3;
            this.ProductPB.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(175, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 58);
            this.label1.TabIndex = 4;
            this.label1.Text = "1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plusPB
            // 
            this.plusPB.BackColor = System.Drawing.Color.Transparent;
            this.plusPB.Image = ((System.Drawing.Image)(resources.GetObject("plusPB.Image")));
            this.plusPB.Location = new System.Drawing.Point(144, 80);
            this.plusPB.Name = "plusPB";
            this.plusPB.Size = new System.Drawing.Size(25, 25);
            this.plusPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plusPB.TabIndex = 5;
            this.plusPB.TabStop = false;
            this.plusPB.Click += new System.EventHandler(this.plusPB_Click);
            // 
            // minusPB
            // 
            this.minusPB.Image = ((System.Drawing.Image)(resources.GetObject("minusPB.Image")));
            this.minusPB.Location = new System.Drawing.Point(206, 80);
            this.minusPB.Name = "minusPB";
            this.minusPB.Size = new System.Drawing.Size(25, 25);
            this.minusPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minusPB.TabIndex = 6;
            this.minusPB.TabStop = false;
            this.minusPB.Click += new System.EventHandler(this.minusPB_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(150, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 75);
            this.label2.TabIndex = 7;
            this.label2.Text = "text";
            // 
            // CartUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minusPB);
            this.Controls.Add(this.plusPB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductPB);
            this.Name = "CartUC";
            this.Size = new System.Drawing.Size(270, 120);
            ((System.ComponentModel.ISupportInitialize)(this.ProductPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minusPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ProductPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox plusPB;
        private System.Windows.Forms.PictureBox minusPB;
        private System.Windows.Forms.Label label2;
    }
}
