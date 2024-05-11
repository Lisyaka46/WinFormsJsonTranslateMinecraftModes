using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace WinFormsJsonTranslateMinecraftModes
{
    public partial class MainForm : Form
    {
        private enum TypeAnalys
        {
            Manual = 0,
            Auto = 1,
            Not = 2,
        }

        private string[] FileLines = [];

        /// <summary>
        /// Присутствует ли запятая в конце элемента
        /// </summary>
        private bool Multi = false;

        /// <summary>
        /// Сохранённый текст перед переводом
        /// </summary>
        private string UndoText = string.Empty;

        /// <summary>
        /// Тип воспроизводимого анализа
        /// </summary>
        private TypeAnalys Analys = TypeAnalys.Not;

        /// <summary>
        /// Директория открытого файла
        /// </summary>
        private string? DirFileOpen;

        /// <summary>
        /// Индекс анализа
        /// </summary>
        private int i = 0;

        /// <summary>
        /// Массив индексов поиска строк
        /// </summary>
        private int[] LinesIndexSearch = [];

        /// <summary>
        /// Активный индекс в поиске
        /// </summary>
        private int IndexSelectedSearch = -1;

        public MainForm()
        {
            InitializeComponent();
            labelInfo.Text = string.Empty;
            buttonCloseFile.Enabled = false;
            buttonStartAnalysis.Enabled = false;
            buttonUndo.Enabled = false;
            buttonCompleteAnalys.Enabled = false;
            buttonTranslating.Enabled = false;
            buttonComplete.Enabled = false;
            tbInputTranslate.Enabled = false;
            progressBar.Visible = false;
            SearchIndexing.Text = "?/?";
            pSearch.Enabled = false;
            tbSearch.Enabled = false;
            buttonSearch.Enabled = false;
            buttonOpenFile.Click += (sender, e) =>
            {
                FileLines = ReadJsonLines();
                labelInfo.Text = "Прочитано";
                if (FileLines.Length > 0)
                {
                    buttonOpenFile.Enabled = false;
                    buttonCloseFile.Enabled = true;

                    buttonStartAnalysis.Enabled = true;
                    buttonTranslating.Enabled = true;
                    buttonComplete.Enabled = true;
                    tbInputTranslate.Enabled = true;

                    listBoxItemsLines.Items.Clear();
                    for (int i = 0; i < FileLines.Length; i++)
                    {
                        if (FileLines[i].Contains(':'))
                            listBoxItemsLines.Items.Add(FileLines[i]);
                    }

                    tbSearch.Enabled = listBoxItemsLines.Items.Count > 0;
                    buttonSearch.Enabled = listBoxItemsLines.Items.Count > 0;

                    labelInfo.Text = "Обновлено";
                }
                else
                {
                    labelInfo.Text = "Проигнорировано";
                }
            };
            buttonSearch.Click += (sender, e) =>
            {
                List<int> SortIndexLines = [];
                for (int i = 0; i < listBoxItemsLines.Items.Count; i++)
                {
                    if ((listBoxItemsLines.Items[i].ToString() ?? string.Empty).Contains(tbSearch.Text)) SortIndexLines.Add(i);
                }
                LinesIndexSearch = [..SortIndexLines];
                if (LinesIndexSearch.Length > 0)
                {
                    pSearch.Enabled = true;
                    UpdateIndexInfo(0);
                }
                else
                {
                    SearchIndexing.Text = "?/?";
                    pSearch.Enabled = false;
                }
            };
            buttonSearchMinus.Click += (sender, e) =>
            {
                if (LinesIndexSearch.Length > 0 && IndexSelectedSearch > 0) UpdateIndexInfo(IndexSelectedSearch - 1);
            };
            buttonSearchPlus.Click += (sender, e) =>
            {
                if (LinesIndexSearch.Length > 0 && IndexSelectedSearch < LinesIndexSearch.Length - 1) UpdateIndexInfo(IndexSelectedSearch + 1);
            };
            listBoxItemsLines.SelectedIndexChanged += (sender, e) =>
            {
                if (listBoxItemsLines.SelectedIndex == -1) return;
                string? Text = listBoxItemsLines.Items[listBoxItemsLines.SelectedIndex].ToString();
                Multi = (Text ?? "?")[^1].Equals(',');
                labelTagName.Text = Regex.Match(Text ?? "\"???\":", "\"[^\"]+\":").Value;
                tbInputTranslate.Text = Regex.Match(Text ?? "\"???\":", ": \"[^\"]+\"").Value;
                if (tbInputTranslate.Text.Length >= 4) tbInputTranslate.Text = tbInputTranslate.Text[3..^1];
            };
            buttonTranslating.Click += (sender, e) =>
            {
                if (!buttonUndo.Enabled) buttonUndo.Enabled = true;
                labelInfo.Text = "Переводится";
                UndoText = tbInputTranslate.Text;
                if (tbInputTranslate.SelectedText.Length > 0) tbInputTranslate.SelectedText = Translator.Translate(tbInputTranslate.SelectedText, "en", "ru");
                else tbInputTranslate.Text = Translator.Translate(tbInputTranslate.Text, "en", "ru");
                labelInfo.Text = "Переведено";
            };
            buttonComplete.Click += (sender, e) =>
            {
                listBoxItemsLines.Items[listBoxItemsLines.SelectedIndex] = $"  {labelTagName.Text} \"{tbInputTranslate.Text}\"{(Multi ? "," : string.Empty)}";
                labelInfo.Text = "Изменено";
                if (Analys == TypeAnalys.Manual)
                {
                    if (i < listBoxItemsLines.Items.Count)
                    {
                        listBoxItemsLines.SelectedIndex = i++;
                        labelInfo.Text = $"Ручной анализ ({i}/{listBoxItemsLines.Items.Count})";
                        progressBar.Value = i;
                    }
                    else
                    {
                        Analys = TypeAnalys.Not;
                        i = 0;
                        progressBar.Visible = false;
                        labelInfo.Text = $"Ручной анализ закончен";
                        buttonStartAnalysis.Enabled = true;
                        buttonCompleteAnalys.Enabled = false;
                    }
                }
            };
            buttonUndo.Click += (sender, e) =>
            {
                buttonUndo.Enabled = false;
                tbInputTranslate.Text = UndoText;
                tbInputTranslate.SelectionStart = tbInputTranslate.TextLength;
                UndoText = string.Empty;
                labelInfo.Text = "Возвращено";
            };
            buttonStartAnalysis.Click += (sender, e) =>
            {
                progressBar.Maximum = listBoxItemsLines.Items.Count;
                progressBar.Value = i;
                progressBar.Visible = true;
                labelInfo.Text = $"Старт ручного анализа (1/{listBoxItemsLines.Items.Count})";
                buttonStartAnalysis.Enabled = false;
                buttonCompleteAnalys.Enabled = true;
                Analys = TypeAnalys.Manual;
                listBoxItemsLines.SelectedIndex = i++;
            };
            buttonCompleteAnalys.Click += (sender, e) =>
            {
                listBoxItemsLines.Items[listBoxItemsLines.SelectedIndex] = $"  {labelTagName.Text} \"{tbInputTranslate.Text}\"{(Multi ? "," : string.Empty)}";
                Analys = TypeAnalys.Not;
                i = 0;
                progressBar.Visible = false;
                labelInfo.Text = $"Ручной анализ закончен";
                buttonStartAnalysis.Enabled = true;
                buttonCompleteAnalys.Enabled = false;
            };
            buttonCloseFile.Click += (sender, e) =>
            {
                if (DirFileOpen != null)
                {
                    buttonCloseFile.Enabled = false;
                    buttonOpenFile.Enabled = true;
                    buttonStartAnalysis.Enabled = false;
                    buttonCompleteAnalys.Enabled = false;
                    buttonUndo.Enabled = false;
                    buttonTranslating.Enabled = false;
                    buttonComplete.Enabled = false;
                    tbInputTranslate.Text = string.Empty;
                    tbInputTranslate.Enabled = false;
                    labelTagName.Text = "\"Name\":";
                    List<string> Lines = ["{"];
                    Lines.AddRange(listBoxItemsLines.Items.Cast<string>());
                    Lines.Add("}");
                    File.WriteAllLines(DirFileOpen, Lines);
                    listBoxItemsLines.Items.Clear();
                    DirFileOpen = null;
                    labelInfo.Text = "Файл сохранён";
                }
            };
        }

        private void UpdateIndexInfo(int index)
        {
            IndexSelectedSearch = index;
            SearchIndexing.Text = $"{index + 1}/{LinesIndexSearch.Length}";
            listBoxItemsLines.SelectedIndex = LinesIndexSearch[index];
        }

        private string[] ReadJsonLines()
        {
            OpenFileDialog dialog = new()
            {
                FileName = "JSON", // Default file name
                DefaultExt = ".json", // Default file extension
                Filter = "Текстовый обмен данными (.json)|*.json" // Filter files by extension
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes || result == DialogResult.Continue)
            {
                DirFileOpen = dialog.FileName;
                return File.ReadAllLines(dialog.FileName);
            }
            return [];
        }
    }
}
