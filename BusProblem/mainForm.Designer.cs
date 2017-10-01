namespace BusProblem
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
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.startStopCombo = new System.Windows.Forms.ComboBox();
            this.startStopLabel = new System.Windows.Forms.Label();
            this.endStopCombo = new System.Windows.Forms.ComboBox();
            this.endStopLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.routeControl = new System.Windows.Forms.TabControl();
            this.fastestRouteTab = new System.Windows.Forms.TabPage();
            this.cheapestRouteTab = new System.Windows.Forms.TabPage();
            this.fastestListBox = new System.Windows.Forms.ListBox();
            this.cheapestListBox = new System.Windows.Forms.ListBox();
            this.routeControl.SuspendLayout();
            this.fastestRouteTab.SuspendLayout();
            this.cheapestRouteTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePathBox
            // 
            this.filePathBox.Enabled = false;
            this.filePathBox.Location = new System.Drawing.Point(12, 22);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(204, 20);
            this.filePathBox.TabIndex = 0;
            this.filePathBox.Text = "Выберите файл...";
            this.filePathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(239, 22);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(75, 20);
            this.loadFileButton.TabIndex = 1;
            this.loadFileButton.Text = "Загрузить";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // startStopCombo
            // 
            this.startStopCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startStopCombo.FormattingEnabled = true;
            this.startStopCombo.Location = new System.Drawing.Point(12, 73);
            this.startStopCombo.Name = "startStopCombo";
            this.startStopCombo.Size = new System.Drawing.Size(68, 21);
            this.startStopCombo.TabIndex = 2;
            this.startStopCombo.Visible = false;
            // 
            // startStopLabel
            // 
            this.startStopLabel.Location = new System.Drawing.Point(12, 56);
            this.startStopLabel.Name = "startStopLabel";
            this.startStopLabel.Size = new System.Drawing.Size(68, 15);
            this.startStopLabel.TabIndex = 5;
            this.startStopLabel.Text = "Начальная:";
            this.startStopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startStopLabel.Visible = false;
            // 
            // endStopCombo
            // 
            this.endStopCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endStopCombo.FormattingEnabled = true;
            this.endStopCombo.Location = new System.Drawing.Point(86, 74);
            this.endStopCombo.Name = "endStopCombo";
            this.endStopCombo.Size = new System.Drawing.Size(68, 21);
            this.endStopCombo.TabIndex = 2;
            this.endStopCombo.Visible = false;
            // 
            // endStopLabel
            // 
            this.endStopLabel.Location = new System.Drawing.Point(86, 57);
            this.endStopLabel.Name = "endStopLabel";
            this.endStopLabel.Size = new System.Drawing.Size(68, 15);
            this.endStopLabel.TabIndex = 5;
            this.endStopLabel.Text = "Конечная:";
            this.endStopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endStopLabel.Visible = false;
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(167, 56);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(49, 15);
            this.timeLabel.TabIndex = 5;
            this.timeLabel.Text = "Время:";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timeLabel.Visible = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(239, 75);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 20);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Visible = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(167, 74);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(49, 20);
            this.timePicker.TabIndex = 7;
            this.timePicker.Visible = false;
            // 
            // routeControl
            // 
            this.routeControl.Controls.Add(this.fastestRouteTab);
            this.routeControl.Controls.Add(this.cheapestRouteTab);
            this.routeControl.Location = new System.Drawing.Point(12, 110);
            this.routeControl.Name = "routeControl";
            this.routeControl.SelectedIndex = 0;
            this.routeControl.Size = new System.Drawing.Size(302, 188);
            this.routeControl.TabIndex = 8;
            this.routeControl.Visible = false;
            // 
            // fastestRouteTab
            // 
            this.fastestRouteTab.Controls.Add(this.fastestListBox);
            this.fastestRouteTab.Location = new System.Drawing.Point(4, 22);
            this.fastestRouteTab.Name = "fastestRouteTab";
            this.fastestRouteTab.Padding = new System.Windows.Forms.Padding(3);
            this.fastestRouteTab.Size = new System.Drawing.Size(294, 162);
            this.fastestRouteTab.TabIndex = 0;
            this.fastestRouteTab.Text = "Самый быстрый";
            this.fastestRouteTab.UseVisualStyleBackColor = true;
            // 
            // cheapestRouteTab
            // 
            this.cheapestRouteTab.Controls.Add(this.cheapestListBox);
            this.cheapestRouteTab.Location = new System.Drawing.Point(4, 22);
            this.cheapestRouteTab.Name = "cheapestRouteTab";
            this.cheapestRouteTab.Padding = new System.Windows.Forms.Padding(3);
            this.cheapestRouteTab.Size = new System.Drawing.Size(294, 162);
            this.cheapestRouteTab.TabIndex = 1;
            this.cheapestRouteTab.Text = "Самый дешевый";
            this.cheapestRouteTab.UseVisualStyleBackColor = true;
            // 
            // fastestListBox
            // 
            this.fastestListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastestListBox.FormattingEnabled = true;
            this.fastestListBox.Location = new System.Drawing.Point(3, 3);
            this.fastestListBox.Name = "fastestListBox";
            this.fastestListBox.Size = new System.Drawing.Size(288, 156);
            this.fastestListBox.TabIndex = 0;
            // 
            // cheapestListBox
            // 
            this.cheapestListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cheapestListBox.FormattingEnabled = true;
            this.cheapestListBox.Location = new System.Drawing.Point(3, 3);
            this.cheapestListBox.Name = "cheapestListBox";
            this.cheapestListBox.Size = new System.Drawing.Size(288, 156);
            this.cheapestListBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 310);
            this.Controls.Add(this.routeControl);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.endStopLabel);
            this.Controls.Add(this.startStopLabel);
            this.Controls.Add(this.endStopCombo);
            this.Controls.Add(this.startStopCombo);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.filePathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Поиск маршрута";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.routeControl.ResumeLayout(false);
            this.fastestRouteTab.ResumeLayout(false);
            this.cheapestRouteTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.ComboBox startStopCombo;
        private System.Windows.Forms.Label startStopLabel;
        private System.Windows.Forms.ComboBox endStopCombo;
        private System.Windows.Forms.Label endStopLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.TabControl routeControl;
        private System.Windows.Forms.TabPage fastestRouteTab;
        private System.Windows.Forms.ListBox fastestListBox;
        private System.Windows.Forms.TabPage cheapestRouteTab;
        private System.Windows.Forms.ListBox cheapestListBox;
    }
}

