namespace PoCTesterLibrary
{
    partial class FrmTester
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.txtPathDLL = new System.Windows.Forms.TextBox();
            this.btnLoadDLL = new System.Windows.Forms.Button();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lstMethods = new System.Windows.Forms.ListBox();
            this.testerPanel = new System.Windows.Forms.Panel();
            this.splitTester = new System.Windows.Forms.SplitContainer();
            this.inputTabControl = new System.Windows.Forms.TabControl();
            this.tabPageManual = new System.Windows.Forms.TabPage();
            this.tabPageXML = new System.Windows.Forms.TabPage();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.panelXMLTop = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCargarXML = new System.Windows.Forms.Button();
            this.btnGuardarXML = new System.Windows.Forms.Button();
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.testerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTester)).BeginInit();
            this.splitTester.Panel1.SuspendLayout();
            this.splitTester.Panel2.SuspendLayout();
            this.splitTester.SuspendLayout();
            this.inputTabControl.SuspendLayout();
            this.tabPageXML.SuspendLayout();
            this.panelXMLTop.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.txtPathDLL);
            this.topPanel.Controls.Add(this.btnLoadDLL);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1023, 40);
            this.topPanel.TabIndex = 0;
            // 
            // txtPathDLL
            // 
            this.txtPathDLL.Location = new System.Drawing.Point(12, 10);
            this.txtPathDLL.Name = "txtPathDLL";
            this.txtPathDLL.Size = new System.Drawing.Size(400, 20);
            this.txtPathDLL.TabIndex = 0;
            // 
            // btnLoadDLL
            // 
            this.btnLoadDLL.Location = new System.Drawing.Point(420, 8);
            this.btnLoadDLL.Name = "btnLoadDLL";
            this.btnLoadDLL.Size = new System.Drawing.Size(100, 23);
            this.btnLoadDLL.TabIndex = 1;
            this.btnLoadDLL.Text = "Cargar DLL";
            this.btnLoadDLL.UseVisualStyleBackColor = true;
            this.btnLoadDLL.Click += new System.EventHandler(this.btnLoadDLL_Click);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 40);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.lstMethods);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.testerPanel);
            this.mainSplitContainer.Size = new System.Drawing.Size(1023, 500);
            this.mainSplitContainer.SplitterDistance = 306;
            this.mainSplitContainer.TabIndex = 1;
            // 
            // lstMethods
            // 
            this.lstMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMethods.FormattingEnabled = true;
            this.lstMethods.Location = new System.Drawing.Point(0, 0);
            this.lstMethods.Name = "lstMethods";
            this.lstMethods.Size = new System.Drawing.Size(306, 500);
            this.lstMethods.TabIndex = 0;
            this.lstMethods.SelectedIndexChanged += new System.EventHandler(this.lstMethods_SelectedIndexChanged);
            this.lstMethods.DoubleClick += new System.EventHandler(this.lstMethods_DoubleClick);
            // 
            // testerPanel
            // 
            this.testerPanel.Controls.Add(this.splitTester);
            this.testerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testerPanel.Location = new System.Drawing.Point(0, 0);
            this.testerPanel.Name = "testerPanel";
            this.testerPanel.Size = new System.Drawing.Size(713, 500);
            this.testerPanel.TabIndex = 0;
            // 
            // splitTester
            // 
            this.splitTester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTester.Location = new System.Drawing.Point(0, 0);
            this.splitTester.Name = "splitTester";
            this.splitTester.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTester.Panel1
            // 
            this.splitTester.Panel1.Controls.Add(this.inputTabControl);
            // 
            // splitTester.Panel2
            // 
            this.splitTester.Panel2.Controls.Add(this.txtSalida);
            this.splitTester.Size = new System.Drawing.Size(713, 500);
            this.splitTester.SplitterDistance = 300;
            this.splitTester.TabIndex = 0;
            // 
            // inputTabControl
            // 
            this.inputTabControl.Controls.Add(this.tabPageManual);
            this.inputTabControl.Controls.Add(this.tabPageXML);
            this.inputTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTabControl.Location = new System.Drawing.Point(0, 0);
            this.inputTabControl.Name = "inputTabControl";
            this.inputTabControl.SelectedIndex = 0;
            this.inputTabControl.Size = new System.Drawing.Size(713, 300);
            this.inputTabControl.TabIndex = 0;
            // 
            // tabPageManual
            // 
            this.tabPageManual.Location = new System.Drawing.Point(4, 22);
            this.tabPageManual.Name = "tabPageManual";
            this.tabPageManual.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManual.Size = new System.Drawing.Size(777, 274);
            this.tabPageManual.TabIndex = 0;
            this.tabPageManual.Text = "Entrada manual";
            this.tabPageManual.UseVisualStyleBackColor = true;
            // 
            // tabPageXML
            // 
            this.tabPageXML.Controls.Add(this.txtXML);
            this.tabPageXML.Controls.Add(this.panelXMLTop);
            this.tabPageXML.Location = new System.Drawing.Point(4, 22);
            this.tabPageXML.Name = "tabPageXML";
            this.tabPageXML.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXML.Size = new System.Drawing.Size(705, 274);
            this.tabPageXML.TabIndex = 1;
            this.tabPageXML.Text = "Entrada XML";
            this.tabPageXML.UseVisualStyleBackColor = true;
            // 
            // txtXML
            // 
            this.txtXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtXML.Location = new System.Drawing.Point(3, 33);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXML.Size = new System.Drawing.Size(699, 238);
            this.txtXML.TabIndex = 1;
            // 
            // panelXMLTop
            // 
            this.panelXMLTop.Controls.Add(this.flowLayoutPanel1);
            this.panelXMLTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelXMLTop.Location = new System.Drawing.Point(3, 3);
            this.panelXMLTop.Name = "panelXMLTop";
            this.panelXMLTop.Size = new System.Drawing.Size(699, 30);
            this.panelXMLTop.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCargarXML);
            this.flowLayoutPanel1.Controls.Add(this.btnGuardarXML);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(699, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnCargarXML
            // 
            this.btnCargarXML.Location = new System.Drawing.Point(0, 0);
            this.btnCargarXML.Margin = new System.Windows.Forms.Padding(0);
            this.btnCargarXML.Name = "btnCargarXML";
            this.btnCargarXML.Size = new System.Drawing.Size(343, 30);
            this.btnCargarXML.TabIndex = 0;
            this.btnCargarXML.Text = "Cargar XML";
            this.btnCargarXML.UseVisualStyleBackColor = true;
            this.btnCargarXML.Click += new System.EventHandler(this.btnCargarXML_Click);
            // 
            // btnGuardarXML
            // 
            this.btnGuardarXML.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardarXML.Location = new System.Drawing.Point(343, 0);
            this.btnGuardarXML.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardarXML.Name = "btnGuardarXML";
            this.btnGuardarXML.Size = new System.Drawing.Size(343, 30);
            this.btnGuardarXML.TabIndex = 1;
            this.btnGuardarXML.Text = "Guardar XML";
            this.btnGuardarXML.UseVisualStyleBackColor = true;
            // 
            // txtSalida
            // 
            this.txtSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSalida.Location = new System.Drawing.Point(0, 0);
            this.txtSalida.Multiline = true;
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSalida.Size = new System.Drawing.Size(713, 196);
            this.txtSalida.TabIndex = 0;
            // 
            // FrmTester
            // 
            this.ClientSize = new System.Drawing.Size(1023, 540);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1039, 579);
            this.Name = "FrmTester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tester DLLs";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.testerPanel.ResumeLayout(false);
            this.splitTester.Panel1.ResumeLayout(false);
            this.splitTester.Panel2.ResumeLayout(false);
            this.splitTester.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTester)).EndInit();
            this.splitTester.ResumeLayout(false);
            this.inputTabControl.ResumeLayout(false);
            this.tabPageXML.ResumeLayout(false);
            this.tabPageXML.PerformLayout();
            this.panelXMLTop.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.TextBox txtPathDLL;
        private System.Windows.Forms.Button btnLoadDLL;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.ListBox lstMethods;
        private System.Windows.Forms.Panel testerPanel;
        private System.Windows.Forms.SplitContainer splitTester;
        private System.Windows.Forms.TabControl inputTabControl;
        private System.Windows.Forms.TabPage tabPageManual;
        private System.Windows.Forms.TabPage tabPageXML;
        private System.Windows.Forms.Panel panelXMLTop;
        private System.Windows.Forms.Button btnCargarXML;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.Button btnGuardarXML;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
