using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Dataset_Builder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public struct Feature
        {
            public string FeatureID;
            public string FeatureInfo;
            public List<Point> FeatureRegion;

            public Feature(string id, string info, List<Point> region)
            {
                FeatureID = id;
                FeatureInfo = info;
                FeatureRegion = new List<Point>(region);
            }

            public override string ToString()
            {
                return FeatureID + "\t" + FeatureInfo + "\t" + FeatureRegion.ToString();
            }
        }

        public Dictionary<string, string> DataSetFeatureTypesList = new Dictionary<string, string>();
        public Dictionary<string, List<Feature>> DataSetImageList = new Dictionary<string, List<Feature>>();

        string projectAddress = null;
        string datasetAddress = null;
        string projectName = "Project 1";

        List<string> imageSet = null;
        int currentImageIndex = 0;

        readonly int maxPictureBoxWidth = 640;
        readonly int maxPictureBoxHeight = 360;
        float imageScale = 1.0f;

        List<Point> featureRegion = new List<Point>();
        bool redrawRegion = false;

        public void SaveDataSetProject(string projectAddress, string datasetAddress)
        {
            using (TextWriter tw = new StreamWriter(projectAddress))
            {
                tw.WriteLine("-----START-----");
                tw.WriteLine("DataSet Address\t<" + datasetAddress + ">");
                tw.WriteLine("-----DataSet Features Type-----");
                foreach (var pair in DataSetFeatureTypesList)
                {
                    tw.WriteLine(pair.Key + "\t" + pair.Value);
                }

                tw.WriteLine("-----DataSet Features List-----");
                foreach (var image in DataSetImageList)
                {
                    for (int i = 0; i < DataSetImageList[image.Key].Count(); i++)
                    {
                        string tmp = null;
                        foreach (var p in DataSetImageList[image.Key][i].FeatureRegion)
                        {
                            tmp += p.ToString();
                        }
                        tw.WriteLine("<" + image.Key + ">" + "\t\t" + DataSetImageList[image.Key][i].FeatureID + "\t\t" + DataSetImageList[image.Key][i].FeatureInfo + "\t\t" + tmp);
                    }
                }

                tw.WriteLine("-----END-----");
            }
            projectName = Path.GetFileName(projectAddress);
            this.Text = projectName + " - [" + datasetAddress + "] - DataSet Builder (beta)";
        }

        public void LoadDataSetFeatureTypes(string address)
        {
            DataSetFeatureTypesList.Clear();
            string[] lines = File.ReadAllLines(address);

            if (lines[0] != "-----START-----")
            {
                MessageBox.Show("Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lines[lines.Count() - 1] != "-----END-----")
            {
                MessageBox.Show("Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                datasetAddress = lines[1].Substring(lines[1].IndexOf('<') + 1, lines[1].LastIndexOf('>') - lines[1].IndexOf('<') - 1);
                if (!Directory.Exists(datasetAddress))
                {
                    datasetAddress = null;

                    using (var fbd = new FolderBrowserDialog())
                    {
                        MessageBox.Show("Dataset directory not found, Please select your dataset directory to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            datasetAddress = fbd.SelectedPath;

                            imageSet = Directory.GetFiles(datasetAddress, "*.jpg", SearchOption.AllDirectories).ToList();
                            if (imageSet != null)
                            {
                                currentImageIndex = 0;
                                PreviewImage(imageSet[0]);
                                textBox1.Text = (currentImageIndex + 1).ToString();
                            }

                            label1.Text = "of " + imageSet.Count;
                            hScrollBar1.Minimum = 0;
                            hScrollBar1.Maximum = imageSet.Count - 1;
                            hScrollBar1.Value = currentImageIndex;
                        }
                        else
                        {
                            MessageBox.Show("No dataset is selected.\r\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                imageSet = Directory.GetFiles(datasetAddress, "*.jpg", SearchOption.AllDirectories).ToList();

                if (imageSet != null)
                {
                    currentImageIndex = 0;
                    PreviewImage(imageSet[0]);
                    textBox1.Text = (currentImageIndex + 1).ToString();
                }

                label1.Text = "of " + imageSet.Count;
                hScrollBar1.Minimum = 0;
                hScrollBar1.Maximum = imageSet.Count - 1;
                hScrollBar1.Value = currentImageIndex;

                bool featureTypeStart = false;
                bool featuresStart = false;
                int l = 0;
                while (!featureTypeStart)
                {
                    if (lines[l].Contains("-----DataSet Features Type-----"))
                        featureTypeStart = true;
                    l++;
                }

                while (!featuresStart)
                {
                    if (lines[l].Contains("-----DataSet Features List-----"))
                    {
                        featuresStart = true;
                    }
                    else
                    {
                        DataSetFeatureTypesList.Add(lines[l].Split('\t')[0], lines[l].Split('\t')[1]);
                    }
                    l++;
                }
                FeatureTypesList_to_GridView();

                for (int i = l; i < lines.Count() - 1; i++)
                {
                    var imgName = lines[i].Substring(lines[i].IndexOf('<') + 1, lines[i].LastIndexOf('>') - lines[i].IndexOf('<') - 1);
                    var featureID = lines[i].Split(new string[] { "\t\t" }, StringSplitOptions.None)[1];
                    var featureInfo = lines[i].Split(new string[] { "\t\t" }, StringSplitOptions.None)[2];
                    var Region = lines[i].Split(new string[] { "\t\t" }, StringSplitOptions.None)[3];

                    if (DataSetImageList.ContainsKey(imgName))
                    {
                        DataSetImageList[imgName].Add(new Feature(featureID, featureInfo, String2Point(Region)));
                    }
                    else
                    {
                        DataSetImageList.Add(imgName, new List<Feature>());
                        DataSetImageList[imgName].Add(new Feature(featureID, featureInfo, String2Point(Region)));
                    }

                    featureRegion.Clear();
                    pictureBox1.Refresh();

                    DataSetFeatureList_to_GridView();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid File\r\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            projectName = Path.GetFileName(projectAddress);
            InitialEnvironment();
        }

        public List<Point> String2Point(string str)
        {
            List<Point> r = new List<Point>();
            try
            {
                foreach (var p in str.Substring(1, str.Length - 2).Split(new string[] { "}{" }, StringSplitOptions.None))
                {
                    int x = Convert.ToInt32(p.Split(new string[] { "," }, StringSplitOptions.None)[0].Substring(2));
                    int y = Convert.ToInt32(p.Split(new string[] { "," }, StringSplitOptions.None)[1].Substring(2));

                    r.Add(new Point(x, y));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid File\r\n" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return r;
        }

        private void FeatureTypesList_to_GridView()
        {
            featureGridView.Rows.Clear();
            featureGridView.Columns[0].Name = "featureID";
            featureGridView.Columns[1].Name = "featureInfo";

            featureGridView.Columns[0].HeaderText = "ID";
            featureGridView.Columns[1].HeaderText = "Info";

            foreach (var pair in DataSetFeatureTypesList)
            {
                featureGridView.Rows.Add(pair.Key, pair.Value);
            }
        }

        private void DataSetFeatureList_to_GridView()
        {
            imageFeaturesGridView.Rows.Clear();
            imageFeaturesGridView.Columns[0].Name = "imageFeatureID";
            imageFeaturesGridView.Columns[1].Name = "imageFeatureInfo";
            imageFeaturesGridView.Columns[2].Name = "imageFeatureRegion";

            imageFeaturesGridView.Columns[0].HeaderText = "ID";
            imageFeaturesGridView.Columns[1].HeaderText = "Info";
            imageFeaturesGridView.Columns[2].HeaderText = "Region";

            var imgName = imageSet[currentImageIndex].Substring(imageSet[currentImageIndex].LastIndexOf('\\') + 1);

            if (DataSetImageList.ContainsKey(imgName))
            {
                for (int i = 0; i < DataSetImageList[imgName].Count(); i++)
                {
                    string tmp = null;
                    foreach (var p in DataSetImageList[imgName][i].FeatureRegion)
                    {
                        tmp += p.ToString();
                    }

                    imageFeaturesGridView.Rows.Add(DataSetImageList[imgName][i].FeatureID, DataSetImageList[imgName][i].FeatureInfo, tmp);
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
            pictureBox1.Refresh();
        }

        private void PreviewImage(string address)
        {
            using (Image tmpImg = Image.FromFile(address))
            {
                if (tmpImg.Width <= maxPictureBoxWidth && tmpImg.Height <= maxPictureBoxHeight)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                else
                {
                    if (tmpImg.Width > maxPictureBoxWidth && tmpImg.Height > maxPictureBoxHeight)
                    {
                        imageScale = Math.Max((float)tmpImg.Width / maxPictureBoxWidth, (float)tmpImg.Height / maxPictureBoxHeight);
                    }
                    else if (tmpImg.Width > maxPictureBoxWidth)
                    {
                        imageScale = (float)tmpImg.Width / maxPictureBoxWidth;
                    }
                    else
                    {
                        imageScale = (float)tmpImg.Height / maxPictureBoxHeight;
                    }
                    pictureBox1.Size = new Size((int)(tmpImg.Width / imageScale), (int)(tmpImg.Height / imageScale));
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                pictureBox1.Load(address);
                pictureBox1.Refresh();
            }

            DataSetFeatureList_to_GridView();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (featureGridView.SelectedRows.Count > 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    featureRegion.Add(new Point((int)(imageScale * e.X), (int)(imageScale * e.Y)));
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (featureRegion.Count > 0)
                    {
                        featureRegion.RemoveAt(featureRegion.Count - 1);
                    }
                }
                pictureBox1.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a feature before setting region.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<Point> ScaledPoints(List<Point> p)
        {
            List<Point> r = new List<Point>();
            for (int i = 0; i < p.Count(); i++)
            {
                r.Add(new Point(Convert.ToInt32(p[i].X / imageScale), Convert.ToInt32(p[i].Y / imageScale)));
            }
            return r;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {                     
            using (HatchBrush brush = new HatchBrush(HatchStyle.DiagonalCross, Color.LightCoral, Color.Transparent))
            {
                if (featureRegion.Count > 1)
                {
                    e.Graphics.FillPolygon(brush, (ScaledPoints(featureRegion)).ToArray());
                }
            }
            using (Pen pen = new Pen(Color.Red, 2))
            {
                for (int i = 0; i < featureRegion.Count; i++)
                {
                    e.Graphics.DrawLine(pen, new Point(ScaledPoints(featureRegion)[i].X - 3, ScaledPoints(featureRegion)[i].Y - 3), new Point(ScaledPoints(featureRegion)[i].X + 3, ScaledPoints(featureRegion)[i].Y + 3));
                    e.Graphics.DrawLine(pen, new Point(ScaledPoints(featureRegion)[i].X - 3, ScaledPoints(featureRegion)[i].Y + 3), new Point(ScaledPoints(featureRegion)[i].X + 3, ScaledPoints(featureRegion)[i].Y - 3));
                }
            }

            if (redrawRegion)
            {
                redrawRegion = false;
                if (imageFeaturesGridView.SelectedRows.Count == 0) return;

                string tmpRegionString = imageFeaturesGridView.SelectedRows[0].Cells[2].Value.ToString();
                var tmpRegion = ScaledPoints(String2Point(tmpRegionString));

                using (HatchBrush brush = new HatchBrush(HatchStyle.DiagonalCross, Color.LightCoral, Color.Transparent))
                {
                    if (tmpRegion.Count > 1)
                    {
                        e.Graphics.FillPolygon(brush, tmpRegion.ToArray());
                    }
                }
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    for (int i = 0; i < tmpRegion.Count; i++)
                    {
                        e.Graphics.DrawLine(pen, new Point(tmpRegion[i].X - 3, tmpRegion[i].Y - 3), new Point(tmpRegion[i].X + 3, tmpRegion[i].Y + 3));
                        e.Graphics.DrawLine(pen, new Point(tmpRegion[i].X - 3, tmpRegion[i].Y + 3), new Point(tmpRegion[i].X + 3, tmpRegion[i].Y - 3));
                    }
                }
            }            
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            currentImageIndex = hScrollBar1.Value;
            if (imageSet != null)
            {
                PreviewImage(imageSet[currentImageIndex]);
                textBox1.Text = (currentImageIndex + 1).ToString();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (imageSet != null)
                {
                    try
                    {
                        if (0 < Convert.ToInt32(textBox1.Text) && Convert.ToInt32(textBox1.Text) <= imageSet.Count)
                        {
                            currentImageIndex = Convert.ToInt32(textBox1.Text) - 1;
                            PreviewImage(imageSet[currentImageIndex]);
                            hScrollBar1.Value = currentImageIndex;
                        }
                        else
                        {
                            PreviewImage(imageSet[currentImageIndex]);
                            textBox1.Text = (currentImageIndex + 1).ToString();
                        }
                    }
                    catch
                    {
                        PreviewImage(imageSet[currentImageIndex]);
                        textBox1.Text = (currentImageIndex + 1).ToString();
                    }
                }
                e.SuppressKeyPress = true;
            }
        }

        private void addNewFeatureType_Click(object sender, EventArgs e)
        {
            if (featureIDText.Text == "" || featureInfoText.Text == "" ||
                featureIDText.Text == "Feature ID" || featureInfoText.Text == "Feature Info") return;

            if (DataSetFeatureTypesList.ContainsKey(featureIDText.Text))
            {
                MessageBox.Show("Entered Feature ID Exists in the List.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataSetFeatureTypesList.Add(featureIDText.Text, featureInfoText.Text);

                featureIDText.Text = "Feature ID";
                featureIDText.ForeColor = Color.LightGray;
                featureInfoText.Text = "Feature Info";
                featureInfoText.ForeColor = Color.LightGray;

                FeatureTypesList_to_GridView();
            }
        }

        private void featureIDText_Enter(object sender, EventArgs e)
        {
            if (featureIDText.Text == "Feature ID")
            {
                featureIDText.Text = "";
                featureIDText.ForeColor = Color.Black;
            }
        }

        private void featureInfoText_Enter(object sender, EventArgs e)
        {
            if (featureInfoText.Text == "Feature Info")
            {
                featureInfoText.Text = "";
                featureInfoText.ForeColor = Color.Black;
            }
        }

        private void addFeature_Click(object sender, EventArgs e)
        {
            if (featureGridView.SelectedRows.Count > 0)
            {
                var imgName = imageSet[currentImageIndex].Substring(imageSet[currentImageIndex].LastIndexOf('\\') + 1);
                var featureID = featureGridView.SelectedRows[0].Cells[0].Value.ToString();
                var featureInfo = featureGridView.SelectedRows[0].Cells[1].Value.ToString();

                if (DataSetImageList.ContainsKey(imgName))
                {
                    DataSetImageList[imgName].Add(new Feature(featureID, featureInfo, featureRegion));
                }
                else
                {
                    DataSetImageList.Add(imgName, new List<Feature>());
                    DataSetImageList[imgName].Add(new Feature(featureID, featureInfo, featureRegion));
                }

                featureRegion.Clear();
                pictureBox1.Refresh();

                DataSetFeatureList_to_GridView();
            }
            else
            {
                MessageBox.Show("Please Select a Feature.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Open Feature Type File";
            // set filters - this can be done in properties as well
            openfile.Filter = "DataSet Builder files (*.dsb)|*.dsb|All files (*.*)|*.*";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                projectAddress = openfile.FileName;

                if (projectAddress != null)
                {
                    LoadDataSetFeatureTypes(openfile.FileName);
                }
            }
        }

        private void clearSelectedRegion_Click(object sender, EventArgs e)
        {
            featureRegion.Clear();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Make a bitmap for the selected area's image.
                Bitmap bm = new Bitmap(200, 200);

                // Copy the selected area into the bitmap.
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    Rectangle dest_rect = new Rectangle(0, 0, 200, 200);                    
                    gr.DrawImage(pictureBox1.Image, dest_rect, new RectangleF(e.X * imageScale - 50, e.Y * imageScale - 50, 100, 100), GraphicsUnit.Pixel);
                    gr.DrawLine(new Pen(Color.Red, 2), new Point(100 - 5, 100 - 5), new Point(100 + 5, 100 + 5));
                    gr.DrawLine(new Pen(Color.Red, 2), new Point(100 - 5, 100 + 5), new Point(100 + 5, 100 - 5));
                    pictureBox2.Image = bm;
                    pictureBox2.Refresh();

                }
            }
        }

        private void featureGridView_Click(object sender, EventArgs e)
        {
            imageFeaturesGridView.ClearSelection();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datasetAddress = null;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Dataset's Folder to Continue ...";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    datasetAddress = fbd.SelectedPath;

                    imageSet = Directory.GetFiles(datasetAddress, "*.jpg", SearchOption.AllDirectories).ToList();
                    if (imageSet != null)
                    {
                        currentImageIndex = 0;
                        PreviewImage(imageSet[0]);
                        textBox1.Text = (currentImageIndex + 1).ToString();
                    }

                    label1.Text = "of " + imageSet.Count;
                    hScrollBar1.Minimum = 0;
                    hScrollBar1.Maximum = imageSet.Count - 1;
                    hScrollBar1.Value = currentImageIndex;

                    InitialEnvironment();
                }
            }
        }

        private void InitialEnvironment()
        {
            this.Text = projectName + " - [" + datasetAddress + "] - DataSet Builder (beta)";
            groupBox1.Enabled = true;
            addFeature.Enabled = true;
            clearSelectedRegion.Enabled = true;
            hScrollBar1.Enabled = true;
            imageFeaturesGridView.Enabled = true;
            textBox1.Enabled = true;
            label1.Enabled = true;
            saveProjectToolStripMenuItem.Enabled = true;
            saveProjectAsToolStripMenuItem.Enabled = true;
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectAddress == null)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Title = "Open Feature Type File";
                // set a default file name
                savefile.FileName = "unknown.dsb";
                // set filters - this can be done in properties as well
                savefile.Filter = "DataSet Builder files (*.dsb)|*.dsb|All files (*.*)|*.*";

                savefile.InitialDirectory = datasetAddress;

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    projectAddress = savefile.FileName;
                    SaveDataSetProject(savefile.FileName, datasetAddress);
                }
            }
            else
            {
                SaveDataSetProject(projectAddress, datasetAddress);
            }
        }

        private void SaveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Open Feature Type File";
            // set a default file name
            savefile.FileName = "unknown.dsb";
            // set filters - this can be done in properties as well
            savefile.Filter = "DataSet Builder files (*.dsb)|*.dsb|All files (*.*)|*.*";

            savefile.InitialDirectory = datasetAddress;

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                projectAddress = savefile.FileName;
                SaveDataSetProject(savefile.FileName, datasetAddress);
            }
        }

        private void ImageFeaturesGridView_Click(object sender, EventArgs e)
        {
            redrawRegion = true;
            featureGridView.ClearSelection();
            pictureBox1.Refresh();
        }

        private void ImageFeaturesGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this feature? ", "Delete Feature", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    var imgName = imageSet[currentImageIndex].Substring(imageSet[currentImageIndex].LastIndexOf('\\') + 1);
                    DataSetImageList[imgName].RemoveAt(imageFeaturesGridView.SelectedRows[0].Index);
                    DataSetFeatureList_to_GridView();
                }
            }
        }

        private void FeatureGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to permanently delete this feature type? ", "Delete Feature Type", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (var image in DataSetImageList)
                    {
                        for (int i = 0; i < DataSetImageList[image.Key].Count(); i++)
                        {
                            if (DataSetImageList[image.Key][i].FeatureID.Equals(featureGridView.SelectedRows[0].Cells[0].Value.ToString()))
                            {
                                DataSetImageList[image.Key].RemoveAt(i);
                            }
                        }
                    }
                    DataSetFeatureList_to_GridView();

                    DataSetFeatureTypesList.Remove(featureGridView.SelectedRows[0].Cells[0].Value.ToString());
                    FeatureTypesList_to_GridView();
                }  
            }
        }

        string tmpKey = null;
        private void FeatureGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tmpKey = featureGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void FeatureGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataSetFeatureTypesList.Remove(tmpKey);
                DataSetFeatureTypesList.Add(featureGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), featureGridView.Rows[e.RowIndex].Cells[1].Value.ToString());

                foreach (var image in DataSetImageList)
                {
                    for (int i = 0; i < DataSetImageList[image.Key].Count(); i++)
                    {
                        if (DataSetImageList[image.Key][i].FeatureID.Equals(tmpKey))
                        {
                            var tmp = DataSetImageList[image.Key][i];
                            tmp.FeatureID = featureGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                            DataSetImageList[image.Key][i] = tmp;
                        }
                    }
                }
                DataSetFeatureList_to_GridView();

            }
            else
            {
                DataSetFeatureTypesList[tmpKey] = featureGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                foreach (var image in DataSetImageList)
                {
                    for (int i = 0; i < DataSetImageList[image.Key].Count(); i++)
                    {
                        if (DataSetImageList[image.Key][i].FeatureID.Equals(tmpKey))
                        {
                            var tmp = DataSetImageList[image.Key][i];
                            tmp.FeatureInfo = featureGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                            DataSetImageList[image.Key][i] = tmp;
                        }
                    }
                }
                DataSetFeatureList_to_GridView();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dataset builder \r\n\r\nversion 1.0.0.0\r\n\r\n(contact: amiraslanhaghrah@gmail.com)", "Dataset Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}