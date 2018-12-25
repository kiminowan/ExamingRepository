namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.QuestionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChoiceA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChoiceB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChoiceC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChoiceD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KnowledgePointID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Analysis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionHasImg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionImg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuestionID,
            this.QuestionName,
            this.ChoiceA,
            this.ChoiceB,
            this.ChoiceC,
            this.ChoiceD,
            this.Answer,
            this.KnowledgePointID,
            this.Analysis,
            this.QuestionHasImg,
            this.QuestionImg,
            this.ExamID,
            this.TypeID});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1420, 370);
            this.dataGridView1.TabIndex = 9;
            // 
            // QuestionID
            // 
            this.QuestionID.DataPropertyName = "QuestionID";
            this.QuestionID.HeaderText = "QuestionID";
            this.QuestionID.Name = "QuestionID";
            // 
            // QuestionName
            // 
            this.QuestionName.DataPropertyName = "QuestionName";
            this.QuestionName.HeaderText = "题目";
            this.QuestionName.Name = "QuestionName";
            // 
            // ChoiceA
            // 
            this.ChoiceA.DataPropertyName = "ChoiceA";
            this.ChoiceA.HeaderText = "A选项";
            this.ChoiceA.Name = "ChoiceA";
            // 
            // ChoiceB
            // 
            this.ChoiceB.DataPropertyName = "ChoiceB";
            this.ChoiceB.HeaderText = "B选项";
            this.ChoiceB.Name = "ChoiceB";
            // 
            // ChoiceC
            // 
            this.ChoiceC.DataPropertyName = "ChoiceC";
            this.ChoiceC.HeaderText = "C选项";
            this.ChoiceC.Name = "ChoiceC";
            // 
            // ChoiceD
            // 
            this.ChoiceD.DataPropertyName = "ChoiceD";
            this.ChoiceD.HeaderText = "ChoiceD";
            this.ChoiceD.Name = "ChoiceD";
            // 
            // Answer
            // 
            this.Answer.DataPropertyName = "Answer";
            this.Answer.HeaderText = "Answer";
            this.Answer.Name = "Answer";
            // 
            // KnowledgePointID
            // 
            this.KnowledgePointID.DataPropertyName = "KnowledgePointID";
            this.KnowledgePointID.HeaderText = "KnowledgePointID";
            this.KnowledgePointID.Name = "KnowledgePointID";
            // 
            // Analysis
            // 
            this.Analysis.DataPropertyName = "Analysis";
            this.Analysis.HeaderText = "Analysis";
            this.Analysis.Name = "Analysis";
            // 
            // QuestionHasImg
            // 
            this.QuestionHasImg.DataPropertyName = "QuestionHasImg";
            this.QuestionHasImg.HeaderText = "QuestionHasImg";
            this.QuestionHasImg.Name = "QuestionHasImg";
            // 
            // QuestionImg
            // 
            this.QuestionImg.DataPropertyName = "QuestionImg";
            this.QuestionImg.HeaderText = "ChoiceIsImg";
            this.QuestionImg.Name = "QuestionImg";
            // 
            // ExamID
            // 
            this.ExamID.DataPropertyName = "ExamID";
            this.ExamID.HeaderText = "ExamID";
            this.ExamID.Name = "ExamID";
            // 
            // TypeID
            // 
            this.TypeID.DataPropertyName = "TypeID";
            this.TypeID.HeaderText = "TypeID";
            this.TypeID.Name = "TypeID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 580);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChoiceA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChoiceB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChoiceC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChoiceD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn KnowledgePointID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Analysis;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionHasImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeID;
    }
}

