using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TLV_Walker
{
    public partial class MainForm : Form
    {
        Dictionary<int, bool> tags = new(); // true: directory, false: file
        private readonly List<KeyValuePair<int, object>> treeNodeColl = new();
        FileStream fs;
        BinaryReader br;
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open a file dialog to select a file
            OpenFileDialog ofd = new()
            {
                RestoreDirectory = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // clear tags
                tags.Clear();
                // get the file name
                string filename = ofd.FileName;
                if (br != null)
                {
                    // try to close the binary reader and the file stream
                    try
                    {
                        br.Close();
                        fs.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                // open the file in binary read mode
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                // create a binary reader
                br = new BinaryReader(fs);
                RecalcTree();
                fileLen.Text = "File size: " + fs.Length + " bytes";
            }
        }
        void RecalcTree()
        {
            treeNodeColl.Clear();
            if (fs == null) return;
            treeNodeColl.AddRange(ScanTLV(br, 0, fs.Length));
            tlvTreeView.Nodes.Clear();
            foreach (KeyValuePair<int, object> node in treeNodeColl)
            {
                TreeNode tn = new(node.Key.ToString("X2"))
                {
                    Tag = node.Value
                };
                tlvTreeView.Nodes.Add(tn);
                if (tags[node.Key])
                {
                    AddSubNodes(tn, node.Value);
                }
            }
            // expand all nodes
            tlvTreeView.ExpandAll();
        }
        void AddSubNodes(TreeNode th, object children)
        {
            List<KeyValuePair<int, object>> childrenList = (List<KeyValuePair<int, object>>)children;
            foreach (KeyValuePair<int, object> node in childrenList)
            {
                TreeNode tn = new(node.Key.ToString("X2"))
                {
                    Tag = node.Value
                };
                th.Nodes.Add(tn);
                if (tags[node.Key])
                {
                    AddSubNodes(tn, node.Value);
                }
            }
        }
        List<KeyValuePair<int, object>> ScanTLV(BinaryReader br, int startPos, long stopPos)
        {
            List<KeyValuePair<int, object>> subTree = new();
            long LastPos;
            // set the position of the stream to the start position
            br.BaseStream.Position = startPos;
            //iterate over br
            while (br.BaseStream.Position < stopPos)
            {
                // read the tag
                int tag = br.ReadByte();
                // read the length
                int length = br.ReadByte();
                // if length is > 0x80, mask it with 0x7F and read the next N bytes
                if (length > 0x80)
                {
                    length &= 0x7F;
                    byte[] lenbytes = br.ReadBytes(length);
                    length = 0;
                    for (int i = 0; i < lenbytes.Length; i++)
                    {
                        length <<= 8;
                        length |= lenbytes[i];
                    }
                }
                // save last position
                LastPos = br.BaseStream.Position;
                // if the tag is contained in the tags list and it's a directory
                if (tags.ContainsKey(tag) && tags[tag])
                {
                    // tag is a directory, so scan the sub tree recursively
                    subTree.Add(new KeyValuePair<int, object>(tag, ScanTLV(br, (int)LastPos, LastPos + length)));
                }
                else
                {
                    if (!tags.ContainsKey(tag))
                    {
                        // add the tag to the tags list
                        tags.Add(tag, false);
                    }
                    // read the value
                    byte[] valueBytes = br.ReadBytes(length);
                    // add the node to the list subTree
                    subTree.Add(new KeyValuePair<int, object>(tag, valueBytes));
                }
                // set the position of the stream to the last position + length
                br.BaseStream.Position = LastPos + length;
            }
            return subTree;
        }

        bool ignoreClick = false;
        TreeNode lastNodeSelected;
        private void TlvTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ignoreClick) return;
            ignoreClick = true;
            try
            {
                lastNodeSelected = tlvTreeView.SelectedNode;
                // if an element is selected in the view
                if (lastNodeSelected != null)
                {
                    // get the tag
                    int tag = int.Parse(lastNodeSelected.Text, System.Globalization.NumberStyles.HexNumber);
                    tagCodeLbl.Text = lastNodeSelected.Text;
                    // if the tag is a directory
                    if (tags[tag])
                    {
                        // select decodeAsNode combobox
                        tagLen.Text = "Number of subelements: " + lastNodeSelected.Nodes.Count;
                        decodeAsNode.Checked = true;
                        decodeAsLeaf.Checked = false;
                        hexPreview.Text = "";
                        textPreview.Text = "";
                    }
                    else
                    {
                        tagLen.Text = "Tag size: " + ((byte[])lastNodeSelected.Tag).Length + " bytes";
                        // select decodeAsLeaf combobox
                        decodeAsNode.Checked = false;
                        decodeAsLeaf.Checked = true;
                        // get the first 100 bytes of the value
                        byte[] valueBytes = (byte[])lastNodeSelected.Tag;
                        string hex = "";
                        string text = "";
                        int maxByte = (limitPreviewBytes.Checked) ? Math.Min(valueBytes.Length - 1, 99) : valueBytes.Length;
                        for (int i = 0; i < maxByte; i++)
                        {
                            hex += valueBytes[i].ToString("X2") + " ";
                            try
                            {
                                text += (char)valueBytes[i];
                            }
                            catch (Exception)
                            {
                                text += ".";
                            }
                        }
                        // set the hex preview
                        hexPreview.Text = hex;
                        // set the text preview
                        textPreview.Text = text;
                    }
                }
            }
            catch
            {
            }
            ignoreClick = false;
        }
        private void DecodeAsNode_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreClick) return;
            // if an element is selected in the view
            if (lastNodeSelected != null)
            {
                // get the tag
                int tag = int.Parse(lastNodeSelected.Text, System.Globalization.NumberStyles.HexNumber);
                // try to set the tag as a directory
                try
                {
                    tags[tag] = true;
                    RecalcTree();
                }
                catch
                {
                    MessageBox.Show("Unable to set tag " + tag.ToString("X2") + " as a directory because this would make the file undecodable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tags[tag] = false;
                    RecalcTree();
                }
            }
        }
        private void DecodeAsLeaf_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreClick) return;
            // if an element is selected in the view
            if (lastNodeSelected != null)
            {
                // get the tag
                int tag = int.Parse(lastNodeSelected.Text, System.Globalization.NumberStyles.HexNumber);
                tags[tag] = false;
                RecalcTree();
            }
        }
        private void ExportTagDecodingSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tags.Count > 0)
            {
                SaveFileDialog sfd = new()
                {
                    Filter = "JSON file (*.json)|*.json",
                    Title = "Export tag decoding schema",
                    FileName = "schema.json"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string outp = "{" + Environment.NewLine;
                    foreach (KeyValuePair<int, bool> t in tags)
                    {
                        outp += "  \"" + t.Key.ToString("X2") + "\": " + t.Value.ToString().ToLower() + ",\n";
                    }
                    // remove last comma
                    outp = outp[..^2] + Environment.NewLine + "}";
                    System.IO.File.WriteAllText(sfd.FileName, outp);
                }
                else
                {
                    MessageBox.Show("No tags to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ImportTagDecodingSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "JSON file (*.json)|*.json",
                Title = "Import tag decoding schema"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new(ofd.FileName);
                string[] jsonLines = sr.ReadToEnd().Trim().Replace("{", "").Replace("}", "").Replace("\"", "").Replace("\r", "").Replace("\n", "").Split(',');
                sr.Close();
                Dictionary<int, bool> tmpTags = new();
                foreach (string line in jsonLines)
                {
                    string[] parts = line.Split(':');
                    try
                    {
                        if (parts.Length != 2) throw new Exception();
                        int tag = int.Parse(parts[0].Trim(), System.Globalization.NumberStyles.HexNumber);
                        bool isNode = bool.Parse(parts[1].Trim());
                        tmpTags.Add(tag, isNode);
                    }
                    catch
                    {
                        MessageBox.Show("Error while importing the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                tags = tmpTags;
                RecalcTree();
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
