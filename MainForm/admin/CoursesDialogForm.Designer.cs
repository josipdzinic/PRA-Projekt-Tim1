namespace MainForm.admin
{
    partial class CoursesDialogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCourse = new System.Windows.Forms.TextBox();
            this.tbLecturer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbECTS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course";
            // 
            // tbCourse
            // 
            this.tbCourse.Location = new System.Drawing.Point(31, 59);
            this.tbCourse.Name = "tbCourse";
            this.tbCourse.Size = new System.Drawing.Size(299, 27);
            this.tbCourse.TabIndex = 1;
            // 
            // tbLecturer
            // 
            this.tbLecturer.Location = new System.Drawing.Point(31, 146);
            this.tbLecturer.Name = "tbLecturer";
            this.tbLecturer.Size = new System.Drawing.Size(299, 27);
            this.tbLecturer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lecturer";
            // 
            // tbECTS
            // 
            this.tbECTS.Location = new System.Drawing.Point(31, 234);
            this.tbECTS.Name = "tbECTS";
            this.tbECTS.Size = new System.Drawing.Size(299, 27);
            this.tbECTS.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "ECTS";
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddCourse.Location = new System.Drawing.Point(31, 293);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(94, 29);
            this.btnAddCourse.TabIndex = 6;
            this.btnAddCourse.Text = "Add";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CoursesDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 358);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddCourse);
            this.Controls.Add(this.tbECTS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLecturer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCourse);
            this.Controls.Add(this.label1);
            this.Name = "CoursesDialogForm";
            this.Text = "CoursesDialogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbCourse;
        private TextBox tbLecturer;
        private Label label2;
        private TextBox tbECTS;
        private Label label3;
        private Button btnAddCourse;
        private Button btnCancel;
    }
}