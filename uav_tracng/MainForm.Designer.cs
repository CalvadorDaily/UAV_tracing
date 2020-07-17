namespace uav_tracng
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitProjectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossTalkItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countDevicesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chanellsVolumeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countCon = new System.Windows.Forms.ToolStripMenuItem();
            this.решениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSolutionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgrammItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interViewItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Структурная матрица каналов и электрических соединений. Введите значение длины ка" +
    "нала в ячейку. Размерность значения не имеет.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(15, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(702, 415);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectItem,
            this.includeDataItem,
            this.решениеToolStripMenuItem,
            this.aboutItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectItem
            // 
            this.projectItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitProjectItem});
            this.projectItem.Image = ((System.Drawing.Image)(resources.GetObject("projectItem.Image")));
            this.projectItem.Name = "projectItem";
            this.projectItem.Size = new System.Drawing.Size(75, 20);
            this.projectItem.Text = "Проект";
            this.projectItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.проектToolStripMenuItem_DropDownItemClicked);
            // 
            // exitProjectItem
            // 
            this.exitProjectItem.Name = "exitProjectItem";
            this.exitProjectItem.Size = new System.Drawing.Size(180, 22);
            this.exitProjectItem.Text = "Создать/выбрать...";
            // 
            // includeDataItem
            // 
            this.includeDataItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crossTalkItem,
            this.countDevicesItem,
            this.chanellsVolumeItem,
            this.countCon});
            this.includeDataItem.Image = ((System.Drawing.Image)(resources.GetObject("includeDataItem.Image")));
            this.includeDataItem.Name = "includeDataItem";
            this.includeDataItem.Size = new System.Drawing.Size(126, 20);
            this.includeDataItem.Text = "Входные данные";
            this.includeDataItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.входныеДанныеToolStripMenuItem_DropDownItemClicked);
            // 
            // crossTalkItem
            // 
            this.crossTalkItem.Name = "crossTalkItem";
            this.crossTalkItem.Size = new System.Drawing.Size(286, 22);
            this.crossTalkItem.Text = "Информация о перекрёстных помехах";
            // 
            // countDevicesItem
            // 
            this.countDevicesItem.Name = "countDevicesItem";
            this.countDevicesItem.Size = new System.Drawing.Size(286, 22);
            this.countDevicesItem.Text = "Количество устройств";
            // 
            // chanellsVolumeItem
            // 
            this.chanellsVolumeItem.Name = "chanellsVolumeItem";
            this.chanellsVolumeItem.Size = new System.Drawing.Size(286, 22);
            this.chanellsVolumeItem.Text = "Вместимость каналов";
            // 
            // countCon
            // 
            this.countCon.Name = "countCon";
            this.countCon.Size = new System.Drawing.Size(286, 22);
            this.countCon.Text = "Количество соединений";
            // 
            // решениеToolStripMenuItem
            // 
            this.решениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getSolutionItem});
            this.решениеToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("решениеToolStripMenuItem.Image")));
            this.решениеToolStripMenuItem.Name = "решениеToolStripMenuItem";
            this.решениеToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.решениеToolStripMenuItem.Text = "Решение";
            this.решениеToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.решениеToolStripMenuItem_DropDownItemClicked);
            // 
            // getSolutionItem
            // 
            this.getSolutionItem.Name = "getSolutionItem";
            this.getSolutionItem.Size = new System.Drawing.Size(128, 22);
            this.getSolutionItem.Text = "Получить";
            // 
            // aboutItem
            // 
            this.aboutItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgrammItem});
            this.aboutItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutItem.Image")));
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(81, 20);
            this.aboutItem.Text = "Справка";
            this.aboutItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.справкаToolStripMenuItem_DropDownItemClicked);
            // 
            // aboutProgrammItem
            // 
            this.aboutProgrammItem.Name = "aboutProgrammItem";
            this.aboutProgrammItem.Size = new System.Drawing.Size(149, 22);
            this.aboutProgrammItem.Text = "О программе";
            // 
            // matrixViewItem
            // 
            this.matrixViewItem.Checked = true;
            this.matrixViewItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.matrixViewItem.Name = "matrixViewItem";
            this.matrixViewItem.Size = new System.Drawing.Size(161, 22);
            this.matrixViewItem.Text = "Матричный";
            // 
            // interViewItem
            // 
            this.interViewItem.Name = "interViewItem";
            this.interViewItem.Size = new System.Drawing.Size(161, 22);
            this.interViewItem.Text = "Интерактивный";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(730, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Трассировка межсоединений в фюзеляже БПЛА с учётом перекрёстных помех";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectItem;
        private System.Windows.Forms.ToolStripMenuItem exitProjectItem;
        private System.Windows.Forms.ToolStripMenuItem matrixViewItem;
        private System.Windows.Forms.ToolStripMenuItem interViewItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgrammItem;
        private System.Windows.Forms.ToolStripMenuItem includeDataItem;
        private System.Windows.Forms.ToolStripMenuItem crossTalkItem;
        private System.Windows.Forms.ToolStripMenuItem countDevicesItem;
        private System.Windows.Forms.ToolStripMenuItem chanellsVolumeItem;
        private System.Windows.Forms.ToolStripMenuItem решениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSolutionItem;
        private System.Windows.Forms.ToolStripMenuItem countCon;
    }
}

