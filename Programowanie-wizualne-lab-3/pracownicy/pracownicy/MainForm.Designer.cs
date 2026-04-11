namespace pracownicy
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonExportJson;
        private System.Windows.Forms.Button buttonExport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            buttonAdd = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonExport = new Button();
            buttonExportJson = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(505, 289);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.Location = new Point(523, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(90, 30);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Dodaj";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.Location = new Point(523, 48);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(90, 30);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Usuń";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSave.Location = new Point(12, 307);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 30);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Zapis do .csv";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            buttonLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLoad.Location = new Point(138, 307);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(120, 30);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Odczyt z .csv";
            buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            buttonExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonExport.Location = new Point(264, 307);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(133, 30);
            buttonExport.TabIndex = 5;
            buttonExport.Text = "Eksport do XML";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click_1;
            // 
            // buttonExportJson
            // 
            buttonExportJson.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonExportJson.Location = new Point(403, 307);
            buttonExportJson.Name = "buttonExportJson";
            buttonExportJson.Size = new Size(130, 30);
            buttonExportJson.TabIndex = 6;
            buttonExportJson.Text = "Eksport do JSON";
            buttonExportJson.UseVisualStyleBackColor = true;
            buttonExportJson.Click += ButtonExportJson_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(625, 349);
            Controls.Add(buttonExport);
            Controls.Add(buttonExportJson);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "Pracownicy";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }
    }
}
