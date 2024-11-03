
namespace TLV_Walker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusBar = new System.Windows.Forms.StatusStrip();
            fileLen = new System.Windows.Forms.ToolStripStatusLabel();
            tagLen = new System.Windows.Forms.ToolStripStatusLabel();
            menuBar = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importTagDecodingSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportTagDecodingSchemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tlvTreeView = new System.Windows.Forms.TreeView();
            TagDecode = new System.Windows.Forms.GroupBox();
            limitPreviewBytes = new System.Windows.Forms.CheckBox();
            decodeAsLeaf = new System.Windows.Forms.RadioButton();
            decodeAsNode = new System.Windows.Forms.RadioButton();
            tagLbl = new System.Windows.Forms.Label();
            tagCodeLbl = new System.Windows.Forms.Label();
            contentPreviewGroup = new System.Windows.Forms.GroupBox();
            textPreview = new System.Windows.Forms.RichTextBox();
            hexPreview = new System.Windows.Forms.RichTextBox();
            statusBar.SuspendLayout();
            menuBar.SuspendLayout();
            TagDecode.SuspendLayout();
            contentPreviewGroup.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileLen, tagLen });
            statusBar.Location = new System.Drawing.Point(0, 427);
            statusBar.Name = "statusBar";
            statusBar.Size = new System.Drawing.Size(904, 26);
            statusBar.TabIndex = 0;
            statusBar.Text = "statusBar";
            // 
            // fileLen
            // 
            fileLen.Name = "fileLen";
            fileLen.Size = new System.Drawing.Size(109, 20);
            fileLen.Text = "File size: 0 byte";
            // 
            // tagLen
            // 
            tagLen.Name = "tagLen";
            tagLen.Size = new System.Drawing.Size(109, 20);
            tagLen.Text = "Tag size: 0 byte";
            // 
            // menuBar
            // 
            menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuBar.Location = new System.Drawing.Point(0, 0);
            menuBar.Name = "menuBar";
            menuBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            menuBar.Size = new System.Drawing.Size(904, 28);
            menuBar.TabIndex = 1;
            menuBar.Text = "menuBar";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, importTagDecodingSchemaToolStripMenuItem, exportTagDecodingSchemaToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // importTagDecodingSchemaToolStripMenuItem
            // 
            importTagDecodingSchemaToolStripMenuItem.Name = "importTagDecodingSchemaToolStripMenuItem";
            importTagDecodingSchemaToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            importTagDecodingSchemaToolStripMenuItem.Text = "Import tag decoding schema";
            importTagDecodingSchemaToolStripMenuItem.Click += ImportTagDecodingSchemaToolStripMenuItem_Click;
            // 
            // exportTagDecodingSchemaToolStripMenuItem
            // 
            exportTagDecodingSchemaToolStripMenuItem.Name = "exportTagDecodingSchemaToolStripMenuItem";
            exportTagDecodingSchemaToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            exportTagDecodingSchemaToolStripMenuItem.Text = "Export tag decoding schema";
            exportTagDecodingSchemaToolStripMenuItem.Click += ExportTagDecodingSchemaToolStripMenuItem_Click;
            // 
            // tlvTreeView
            // 
            tlvTreeView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tlvTreeView.Location = new System.Drawing.Point(0, 28);
            tlvTreeView.Margin = new System.Windows.Forms.Padding(0);
            tlvTreeView.Name = "tlvTreeView";
            tlvTreeView.Size = new System.Drawing.Size(350, 403);
            tlvTreeView.TabIndex = 2;
            tlvTreeView.AfterSelect += TlvTreeView_AfterSelect;
            // 
            // TagDecode
            // 
            TagDecode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TagDecode.Controls.Add(limitPreviewBytes);
            TagDecode.Controls.Add(decodeAsLeaf);
            TagDecode.Controls.Add(decodeAsNode);
            TagDecode.Controls.Add(tagLbl);
            TagDecode.Controls.Add(tagCodeLbl);
            TagDecode.Location = new System.Drawing.Point(353, 31);
            TagDecode.Name = "TagDecode";
            TagDecode.Size = new System.Drawing.Size(539, 56);
            TagDecode.TabIndex = 3;
            TagDecode.TabStop = false;
            TagDecode.Text = "Decode as:";
            // 
            // limitPreviewBytes
            // 
            limitPreviewBytes.AutoSize = true;
            limitPreviewBytes.Checked = true;
            limitPreviewBytes.CheckState = System.Windows.Forms.CheckState.Checked;
            limitPreviewBytes.Location = new System.Drawing.Point(328, 27);
            limitPreviewBytes.Name = "limitPreviewBytes";
            limitPreviewBytes.Size = new System.Drawing.Size(205, 24);
            limitPreviewBytes.TabIndex = 4;
            limitPreviewBytes.Text = "Limit preview to 100 bytes";
            limitPreviewBytes.UseVisualStyleBackColor = true;
            // 
            // decodeAsLeaf
            // 
            decodeAsLeaf.AutoSize = true;
            decodeAsLeaf.Location = new System.Drawing.Point(229, 26);
            decodeAsLeaf.Name = "decodeAsLeaf";
            decodeAsLeaf.Size = new System.Drawing.Size(93, 24);
            decodeAsLeaf.TabIndex = 3;
            decodeAsLeaf.TabStop = true;
            decodeAsLeaf.Text = "Leaf (file)";
            decodeAsLeaf.UseVisualStyleBackColor = true;
            decodeAsLeaf.CheckedChanged += DecodeAsLeaf_CheckedChanged;
            // 
            // decodeAsNode
            // 
            decodeAsNode.AutoSize = true;
            decodeAsNode.Location = new System.Drawing.Point(82, 26);
            decodeAsNode.Name = "decodeAsNode";
            decodeAsNode.Size = new System.Drawing.Size(140, 24);
            decodeAsNode.TabIndex = 2;
            decodeAsNode.TabStop = true;
            decodeAsNode.Text = "Node (directory)";
            decodeAsNode.UseVisualStyleBackColor = true;
            decodeAsNode.CheckedChanged += DecodeAsNode_CheckedChanged;
            // 
            // tagLbl
            // 
            tagLbl.AutoSize = true;
            tagLbl.Location = new System.Drawing.Point(6, 28);
            tagLbl.Name = "tagLbl";
            tagLbl.Size = new System.Drawing.Size(35, 20);
            tagLbl.TabIndex = 0;
            tagLbl.Text = "Tag:";
            // 
            // tagCodeLbl
            // 
            tagCodeLbl.AutoSize = true;
            tagCodeLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            tagCodeLbl.Location = new System.Drawing.Point(47, 28);
            tagCodeLbl.Name = "tagCodeLbl";
            tagCodeLbl.Size = new System.Drawing.Size(29, 20);
            tagCodeLbl.TabIndex = 1;
            tagCodeLbl.Text = "XX";
            // 
            // contentPreviewGroup
            // 
            contentPreviewGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            contentPreviewGroup.Controls.Add(textPreview);
            contentPreviewGroup.Controls.Add(hexPreview);
            contentPreviewGroup.Location = new System.Drawing.Point(353, 93);
            contentPreviewGroup.Name = "contentPreviewGroup";
            contentPreviewGroup.Size = new System.Drawing.Size(539, 335);
            contentPreviewGroup.TabIndex = 4;
            contentPreviewGroup.TabStop = false;
            contentPreviewGroup.Text = "Preview";
            // 
            // textPreview
            // 
            textPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textPreview.BackColor = System.Drawing.SystemColors.Window;
            textPreview.Location = new System.Drawing.Point(3, 183);
            textPreview.Margin = new System.Windows.Forms.Padding(0);
            textPreview.Name = "textPreview";
            textPreview.ReadOnly = true;
            textPreview.Size = new System.Drawing.Size(533, 149);
            textPreview.TabIndex = 1;
            textPreview.Text = "";
            // 
            // hexPreview
            // 
            hexPreview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hexPreview.BackColor = System.Drawing.SystemColors.Window;
            hexPreview.Location = new System.Drawing.Point(3, 23);
            hexPreview.Margin = new System.Windows.Forms.Padding(0);
            hexPreview.Name = "hexPreview";
            hexPreview.ReadOnly = true;
            hexPreview.Size = new System.Drawing.Size(533, 160);
            hexPreview.TabIndex = 0;
            hexPreview.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(904, 453);
            Controls.Add(contentPreviewGroup);
            Controls.Add(TagDecode);
            Controls.Add(tlvTreeView);
            Controls.Add(statusBar);
            Controls.Add(menuBar);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuBar;
            MinimumSize = new System.Drawing.Size(922, 500);
            Name = "MainForm";
            Text = "TLV Walker";
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            menuBar.ResumeLayout(false);
            menuBar.PerformLayout();
            TagDecode.ResumeLayout(false);
            TagDecode.PerformLayout();
            contentPreviewGroup.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TreeView tlvTreeView;
        private System.Windows.Forms.GroupBox TagDecode;
        private System.Windows.Forms.RadioButton decodeAsLeaf;
        private System.Windows.Forms.RadioButton decodeAsNode;
        private System.Windows.Forms.Label tagCodeLbl;
        private System.Windows.Forms.Label tagLbl;
        private System.Windows.Forms.GroupBox contentPreviewGroup;
        private System.Windows.Forms.RichTextBox hexPreview;
        private System.Windows.Forms.RichTextBox textPreview;
        private System.Windows.Forms.ToolStripStatusLabel fileLen;
        private System.Windows.Forms.ToolStripStatusLabel tagLen;
        private System.Windows.Forms.ToolStripMenuItem importTagDecodingSchemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTagDecodingSchemaToolStripMenuItem;
        private System.Windows.Forms.CheckBox limitPreviewBytes;
    }
}

