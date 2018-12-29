namespace WindowsFormsApp
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Mp3_128k = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Mp3_320k = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Ape = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Flac = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Play = new System.Windows.Forms.DataGridViewButtonColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.singerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(712, 265);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "That Girl";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.albumNameDataGridViewTextBoxColumn,
            this.singerDataGridViewTextBoxColumn,
            this.Mp3_128k,
            this.Mp3_320k,
            this.Ape,
            this.Flac,
            this.Play});
            this.dataGridView1.DataSource = this.tableModelBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(712, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Mp3_128k
            // 
            this.Mp3_128k.DataPropertyName = "Mp3_128k";
            this.Mp3_128k.HeaderText = "Mp3_128k";
            this.Mp3_128k.Name = "Mp3_128k";
            this.Mp3_128k.ReadOnly = true;
            // 
            // Mp3_320k
            // 
            this.Mp3_320k.DataPropertyName = "Mp3_320k";
            this.Mp3_320k.HeaderText = "Mp3_320k";
            this.Mp3_320k.Name = "Mp3_320k";
            this.Mp3_320k.ReadOnly = true;
            // 
            // Ape
            // 
            this.Ape.DataPropertyName = "Ape";
            this.Ape.HeaderText = "Ape";
            this.Ape.Name = "Ape";
            this.Ape.ReadOnly = true;
            // 
            // Flac
            // 
            this.Flac.DataPropertyName = "Flac";
            this.Flac.HeaderText = "Flac";
            this.Flac.Name = "Flac";
            this.Flac.ReadOnly = true;
            // 
            // Play
            // 
            this.Play.DataPropertyName = "Play";
            this.Play.HeaderText = "高品质试听";
            this.Play.Name = "Play";
            this.Play.ReadOnly = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "选择保存的路径和文件名";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.Sfd_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(18, 17);
            this.toolStripStatusLabel2.Text = "--";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "歌名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // albumNameDataGridViewTextBoxColumn
            // 
            this.albumNameDataGridViewTextBoxColumn.DataPropertyName = "AlbumName";
            this.albumNameDataGridViewTextBoxColumn.HeaderText = "专辑";
            this.albumNameDataGridViewTextBoxColumn.Name = "albumNameDataGridViewTextBoxColumn";
            this.albumNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // singerDataGridViewTextBoxColumn
            // 
            this.singerDataGridViewTextBoxColumn.DataPropertyName = "Singer";
            this.singerDataGridViewTextBoxColumn.HeaderText = "歌手";
            this.singerDataGridViewTextBoxColumn.Name = "singerDataGridViewTextBoxColumn";
            this.singerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tableModelBindingSource
            // 
            this.tableModelBindingSource.DataSource = typeof(WindowsFormsApp.TableModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 299);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource tableModelBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn singerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn Mp3_128k;
        private System.Windows.Forms.DataGridViewLinkColumn Mp3_320k;
        private System.Windows.Forms.DataGridViewLinkColumn Ape;
        private System.Windows.Forms.DataGridViewLinkColumn Flac;
        private System.Windows.Forms.DataGridViewButtonColumn Play;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

