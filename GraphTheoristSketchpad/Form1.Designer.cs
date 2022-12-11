
namespace GraphTheoristSketchpad
{
    partial class SketchPad
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
            this.graphPanel = new System.Windows.Forms.Panel();
            this.select_color_button = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.paint_color_dialog = new System.Windows.Forms.ColorDialog();
            this.paint_button = new System.Windows.Forms.Button();
            this.delete_label = new System.Windows.Forms.Label();
            this.select_color_label = new System.Windows.Forms.Label();
            this.vertex_label = new System.Windows.Forms.Label();
            this.edge_label = new System.Windows.Forms.Label();
            this.deg_label = new System.Windows.Forms.Label();
            this.component_label = new System.Windows.Forms.Label();
            this.clear_all_button = new System.Windows.Forms.Button();
            this.matrix_display = new System.Windows.Forms.RichTextBox();
            this.bipartite_label = new System.Windows.Forms.Label();
            this.bipartite_test_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.AutoSize = true;
            this.graphPanel.BackColor = System.Drawing.Color.PapayaWhip;
            this.graphPanel.Location = new System.Drawing.Point(12, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(1226, 793);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.graphPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick_1);
            this.graphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseDown);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseMove);
            this.graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphPanel_MouseUp);
            // 
            // select_color_button
            // 
            this.select_color_button.AutoSize = true;
            this.select_color_button.BackColor = System.Drawing.Color.Red;
            this.select_color_button.Image = global::GraphTheoristSketchpad.Properties.Resources.paint_icon;
            this.select_color_button.Location = new System.Drawing.Point(1288, 37);
            this.select_color_button.Name = "select_color_button";
            this.select_color_button.Size = new System.Drawing.Size(75, 70);
            this.select_color_button.TabIndex = 2;
            this.select_color_button.UseVisualStyleBackColor = false;
            this.select_color_button.Click += new System.EventHandler(this.Select_color_button_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoSize = true;
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deleteButton.Image = global::GraphTheoristSketchpad.Properties.Resources.delete_icon;
            this.deleteButton.Location = new System.Drawing.Point(1409, 37);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 70);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // paint_color_dialog
            // 
            this.paint_color_dialog.AnyColor = true;
            this.paint_color_dialog.Color = System.Drawing.Color.Red;
            // 
            // paint_button
            // 
            this.paint_button.AutoSize = true;
            this.paint_button.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paint_button.Location = new System.Drawing.Point(1288, 113);
            this.paint_button.Name = "paint_button";
            this.paint_button.Size = new System.Drawing.Size(75, 30);
            this.paint_button.TabIndex = 3;
            this.paint_button.Text = "paint";
            this.paint_button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.paint_button.UseVisualStyleBackColor = true;
            this.paint_button.Click += new System.EventHandler(this.Paint_button_Click_1);
            // 
            // delete_label
            // 
            this.delete_label.AutoSize = true;
            this.delete_label.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.delete_label.Location = new System.Drawing.Point(1418, 14);
            this.delete_label.Name = "delete_label";
            this.delete_label.Size = new System.Drawing.Size(54, 20);
            this.delete_label.TabIndex = 4;
            this.delete_label.Text = "Delete";
            this.delete_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // select_color_label
            // 
            this.select_color_label.AutoSize = true;
            this.select_color_label.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.select_color_label.Location = new System.Drawing.Point(1280, 14);
            this.select_color_label.Name = "select_color_label";
            this.select_color_label.Size = new System.Drawing.Size(91, 20);
            this.select_color_label.TabIndex = 5;
            this.select_color_label.Text = "Select Color";
            this.select_color_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vertex_label
            // 
            this.vertex_label.AutoSize = true;
            this.vertex_label.Font = new System.Drawing.Font("Cambria Math", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vertex_label.Location = new System.Drawing.Point(1270, 146);
            this.vertex_label.Name = "vertex_label";
            this.vertex_label.Size = new System.Drawing.Size(74, 106);
            this.vertex_label.TabIndex = 6;
            this.vertex_label.Text = "n =";
            // 
            // edge_label
            // 
            this.edge_label.AutoSize = true;
            this.edge_label.Font = new System.Drawing.Font("Cambria Math", 10.8F, System.Drawing.FontStyle.Italic);
            this.edge_label.Location = new System.Drawing.Point(1391, 146);
            this.edge_label.Name = "edge_label";
            this.edge_label.Size = new System.Drawing.Size(79, 106);
            this.edge_label.TabIndex = 7;
            this.edge_label.Text = "m =";
            // 
            // deg_label
            // 
            this.deg_label.AutoSize = true;
            this.deg_label.Font = new System.Drawing.Font("Cambria Math", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deg_label.Location = new System.Drawing.Point(1270, 215);
            this.deg_label.Name = "deg_label";
            this.deg_label.Size = new System.Drawing.Size(119, 106);
            this.deg_label.TabIndex = 8;
            this.deg_label.Text = "deg(V) =";
            // 
            // component_label
            // 
            this.component_label.AutoSize = true;
            this.component_label.Font = new System.Drawing.Font("Cambria Math", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.component_label.Location = new System.Drawing.Point(1266, 279);
            this.component_label.Name = "component_label";
            this.component_label.Size = new System.Drawing.Size(163, 106);
            this.component_label.TabIndex = 9;
            this.component_label.Text = "components =";
            // 
            // clear_all_button
            // 
            this.clear_all_button.AutoSize = true;
            this.clear_all_button.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear_all_button.Location = new System.Drawing.Point(1409, 113);
            this.clear_all_button.Name = "clear_all_button";
            this.clear_all_button.Size = new System.Drawing.Size(75, 30);
            this.clear_all_button.TabIndex = 10;
            this.clear_all_button.Text = "clear all";
            this.clear_all_button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.clear_all_button.UseVisualStyleBackColor = true;
            this.clear_all_button.Click += new System.EventHandler(this.Clear_all_button_Click);
            // 
            // matrix_display
            // 
            this.matrix_display.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.matrix_display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrix_display.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matrix_display.Location = new System.Drawing.Point(1288, 464);
            this.matrix_display.Name = "matrix_display";
            this.matrix_display.ReadOnly = true;
            this.matrix_display.Size = new System.Drawing.Size(196, 296);
            this.matrix_display.TabIndex = 12;
            this.matrix_display.Text = "";
            // 
            // bipartite_label
            // 
            this.bipartite_label.AutoSize = true;
            this.bipartite_label.Font = new System.Drawing.Font("Cambria Math", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bipartite_label.Location = new System.Drawing.Point(1270, 342);
            this.bipartite_label.Name = "bipartite_label";
            this.bipartite_label.Size = new System.Drawing.Size(119, 106);
            this.bipartite_label.TabIndex = 13;
            this.bipartite_label.Text = "bipartite:";
            // 
            // bipartite_test_button
            // 
            this.bipartite_test_button.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold);
            this.bipartite_test_button.Location = new System.Drawing.Point(1288, 412);
            this.bipartite_test_button.Name = "bipartite_test_button";
            this.bipartite_test_button.Size = new System.Drawing.Size(75, 30);
            this.bipartite_test_button.TabIndex = 14;
            this.bipartite_test_button.Text = "run test";
            this.bipartite_test_button.UseVisualStyleBackColor = true;
            this.bipartite_test_button.Click += new System.EventHandler(this.Bipartite_test_button_Click);
            // 
            // SketchPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1518, 817);
            this.Controls.Add(this.bipartite_test_button);
            this.Controls.Add(this.bipartite_label);
            this.Controls.Add(this.matrix_display);
            this.Controls.Add(this.clear_all_button);
            this.Controls.Add(this.component_label);
            this.Controls.Add(this.deg_label);
            this.Controls.Add(this.edge_label);
            this.Controls.Add(this.vertex_label);
            this.Controls.Add(this.select_color_label);
            this.Controls.Add(this.delete_label);
            this.Controls.Add(this.paint_button);
            this.Controls.Add(this.select_color_button);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.graphPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SketchPad";
            this.Text = "GraphSketchPad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button select_color_button;
        private System.Windows.Forms.ColorDialog paint_color_dialog;
        private System.Windows.Forms.Button paint_button;
        private System.Windows.Forms.Label delete_label;
        private System.Windows.Forms.Label select_color_label;
        private System.Windows.Forms.Label vertex_label;
        private System.Windows.Forms.Label edge_label;
        private System.Windows.Forms.Label deg_label;
        private System.Windows.Forms.Label component_label;
        private System.Windows.Forms.Button clear_all_button;
        private System.Windows.Forms.RichTextBox matrix_display;
        private System.Windows.Forms.Label bipartite_label;
        private System.Windows.Forms.Button bipartite_test_button;
    }
}

