namespace WinFormsJsonTranslateMinecraftModes
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbInputTranslate = new TextBox();
            labelTagName = new Label();
            buttonComplete = new Button();
            buttonOpenFile = new Button();
            labelInfo = new Label();
            buttonStartAnalysis = new Button();
            buttonCloseFile = new Button();
            listBoxItemsLines = new ListBox();
            buttonTranslating = new Button();
            buttonUndo = new Button();
            buttonCompleteAnalys = new Button();
            progressBar = new ProgressBar();
            buttonSearch = new Button();
            tbSearch = new TextBox();
            buttonSearchPlus = new Button();
            buttonSearchMinus = new Button();
            SearchIndexing = new Label();
            pSearch = new Panel();
            pSearch.SuspendLayout();
            SuspendLayout();
            // 
            // tbInputTranslate
            // 
            tbInputTranslate.Location = new Point(59, 366);
            tbInputTranslate.Name = "tbInputTranslate";
            tbInputTranslate.Size = new Size(567, 23);
            tbInputTranslate.TabIndex = 0;
            // 
            // labelTagName
            // 
            labelTagName.AutoSize = true;
            labelTagName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTagName.Location = new Point(59, 345);
            labelTagName.Name = "labelTagName";
            labelTagName.Size = new Size(59, 17);
            labelTagName.TabIndex = 1;
            labelTagName.Text = "\"Name\":";
            // 
            // buttonComplete
            // 
            buttonComplete.Location = new Point(637, 366);
            buttonComplete.Name = "buttonComplete";
            buttonComplete.Size = new Size(81, 23);
            buttonComplete.TabIndex = 2;
            buttonComplete.Text = "Изменить";
            buttonComplete.UseVisualStyleBackColor = true;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.Location = new Point(6, 5);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(126, 23);
            buttonOpenFile.TabIndex = 3;
            buttonOpenFile.Text = "Открыть Json файл";
            buttonOpenFile.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            labelInfo.AutoEllipsis = true;
            labelInfo.BackColor = Color.LightGray;
            labelInfo.BorderStyle = BorderStyle.FixedSingle;
            labelInfo.Location = new Point(569, 421);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(231, 23);
            labelInfo.TabIndex = 4;
            labelInfo.Text = "Анализирую";
            labelInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonStartAnalysis
            // 
            buttonStartAnalysis.Location = new Point(6, 34);
            buttonStartAnalysis.Name = "buttonStartAnalysis";
            buttonStartAnalysis.Size = new Size(146, 23);
            buttonStartAnalysis.TabIndex = 5;
            buttonStartAnalysis.Text = "Начать ручной анализ";
            buttonStartAnalysis.UseVisualStyleBackColor = true;
            // 
            // buttonCloseFile
            // 
            buttonCloseFile.Location = new Point(138, 5);
            buttonCloseFile.Name = "buttonCloseFile";
            buttonCloseFile.Size = new Size(126, 23);
            buttonCloseFile.TabIndex = 7;
            buttonCloseFile.Text = "Закрыть Json файл";
            buttonCloseFile.UseVisualStyleBackColor = true;
            // 
            // listBoxItemsLines
            // 
            listBoxItemsLines.FormattingEnabled = true;
            listBoxItemsLines.ItemHeight = 15;
            listBoxItemsLines.Location = new Point(59, 113);
            listBoxItemsLines.Name = "listBoxItemsLines";
            listBoxItemsLines.Size = new Size(672, 229);
            listBoxItemsLines.TabIndex = 8;
            // 
            // buttonTranslating
            // 
            buttonTranslating.Location = new Point(59, 394);
            buttonTranslating.Name = "buttonTranslating";
            buttonTranslating.Size = new Size(75, 23);
            buttonTranslating.TabIndex = 9;
            buttonTranslating.Text = "Перевести";
            buttonTranslating.UseVisualStyleBackColor = true;
            // 
            // buttonUndo
            // 
            buttonUndo.Location = new Point(59, 419);
            buttonUndo.Name = "buttonUndo";
            buttonUndo.Size = new Size(121, 23);
            buttonUndo.TabIndex = 10;
            buttonUndo.Text = "Отменить перевод";
            buttonUndo.UseVisualStyleBackColor = true;
            // 
            // buttonCompleteAnalys
            // 
            buttonCompleteAnalys.Location = new Point(158, 34);
            buttonCompleteAnalys.Name = "buttonCompleteAnalys";
            buttonCompleteAnalys.Size = new Size(117, 23);
            buttonCompleteAnalys.TabIndex = 11;
            buttonCompleteAnalys.Text = "Закончить анализ";
            buttonCompleteAnalys.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(569, 439);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(231, 11);
            progressBar.TabIndex = 12;
            progressBar.Value = 80;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(436, 84);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 13;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(59, 84);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(371, 23);
            tbSearch.TabIndex = 14;
            // 
            // buttonSearchPlus
            // 
            buttonSearchPlus.Location = new Point(134, 1);
            buttonSearchPlus.Name = "buttonSearchPlus";
            buttonSearchPlus.Size = new Size(23, 23);
            buttonSearchPlus.TabIndex = 15;
            buttonSearchPlus.Text = "+";
            buttonSearchPlus.UseVisualStyleBackColor = true;
            // 
            // buttonSearchMinus
            // 
            buttonSearchMinus.Location = new Point(108, 1);
            buttonSearchMinus.Name = "buttonSearchMinus";
            buttonSearchMinus.Size = new Size(23, 23);
            buttonSearchMinus.TabIndex = 16;
            buttonSearchMinus.Text = "-";
            buttonSearchMinus.UseVisualStyleBackColor = true;
            // 
            // SearchIndexing
            // 
            SearchIndexing.Location = new Point(8, 4);
            SearchIndexing.Name = "SearchIndexing";
            SearchIndexing.Size = new Size(100, 19);
            SearchIndexing.TabIndex = 17;
            SearchIndexing.Text = "100/100";
            SearchIndexing.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pSearch
            // 
            pSearch.Controls.Add(SearchIndexing);
            pSearch.Controls.Add(buttonSearchPlus);
            pSearch.Controls.Add(buttonSearchMinus);
            pSearch.Location = new Point(517, 83);
            pSearch.Name = "pSearch";
            pSearch.Size = new Size(159, 26);
            pSearch.TabIndex = 18;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pSearch);
            Controls.Add(tbSearch);
            Controls.Add(buttonSearch);
            Controls.Add(labelInfo);
            Controls.Add(progressBar);
            Controls.Add(buttonCompleteAnalys);
            Controls.Add(buttonUndo);
            Controls.Add(buttonTranslating);
            Controls.Add(buttonComplete);
            Controls.Add(listBoxItemsLines);
            Controls.Add(tbInputTranslate);
            Controls.Add(buttonCloseFile);
            Controls.Add(labelTagName);
            Controls.Add(buttonStartAnalysis);
            Controls.Add(buttonOpenFile);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Редактор JSON";
            pSearch.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbInputTranslate;
        private Label labelTagName;
        private Button buttonComplete;
        private Button buttonOpenFile;
        private Label labelInfo;
        private Button buttonStartAnalysis;
        private Button buttonCloseFile;
        private ListBox listBoxItemsLines;
        private Button buttonTranslating;
        private Button buttonUndo;
        private Button buttonCompleteAnalys;
        private ProgressBar progressBar;
        private Button buttonSearch;
        private TextBox tbSearch;
        private Button buttonSearchPlus;
        private Button buttonSearchMinus;
        private Label SearchIndexing;
        private Panel pSearch;
    }
}
