using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
/* 2 Отбор объектов, удовлетворяющих заданному условию для числового поля 
 * 0 Столбчатая диаграмма отображает величины значений фиксированного поля для каждого объекта 
 */
namespace wf2
{
    public partial class Form1 : Form
    {
        BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bindingSource.DataSource = SKZAlbums.skzAlbums;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = bindingSource;
            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "AlbumName",
                HeaderText = "AlbumName",
                DataPropertyName = "AlbumName"
            };
            dataGridView.Columns.Add(nameColumn);
            var dateColumn = new DataGridViewTextBoxColumn
            {
                Name = "ReleaseDate",
                HeaderText = "ReleaseDate",
                DataPropertyName = "ReleaseDate"
            };
            dataGridView.Columns.Add(dateColumn);
            var numberColumn = new DataGridViewTextBoxColumn
            {
                Name = "SongsNumber",
                HeaderText = "SongsNumber",
                DataPropertyName = "SongsNumber"
            };
            dataGridView.Columns.Add(numberColumn);
            var durationColumn = new DataGridViewTextBoxColumn
            {
                Name = "TotalDuration",
                HeaderText = "TotalDuration",
                DataPropertyName = "TotalDuration",
            };
            dataGridView.Columns.Add(durationColumn);
            var typeColumn = new DataGridViewComboBoxColumn
            {
                Name = "AlbumType",
                HeaderText = "AlbumType",
                DataPropertyName = "AlbumType",
                DataSource = Enum.GetValues(typeof(Album.eAlbumType))
            };
            dataGridView.Columns.Add(typeColumn);
            bindingNavigator.BindingSource = bindingSource;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.DataBindings.Add("ImageLocation", bindingSource, "Cover", true);
            pictureBox.DoubleClick += PicBox_DoubleClick;
            chart.DataSource = bindingSource;
            chart.Series[0].XValueMember = "AlbumName";
            chart.Series[0].YValueMembers = "TotalDuration";
            chart.Titles.Add("duration for each album");
            chart.Legends.Clear();
            propertyGrid.DataBindings.Add("SelectedObject", bindingSource, "");
            DataBindings.Add("Text", bindingSource, "AlbumName");
            bindingSource.CurrentChanged += (o, e) => chart.DataBind();
        }
        private void PicBox_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "jpg picture|*.jpg|jpeg picture|*.jpeg"
            })
            {
                OpenFileDialog openFileDialog1 = openFileDialog;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    (bindingSource.Current as Album).Cover = openFileDialog1.FileName;
                    bindingSource.ResetBindings(false);
                }
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "to bin|*.bin|to xml|*.xml"
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            BinarySerialize(saveFileDialog.FileName);
                            break;
                        case 2:
                            SaveXml(saveFileDialog.FileName);
                            break;
                        default:
                            break;
                    }
            }
        }
        private void SaveXml(string file)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Album>));
            using (Stream stream = new FileStream(file, FileMode.Create))
            {
                xml.Serialize(stream, bindingSource.DataSource);
                stream.Close();
            }
        }
        private void BinarySerialize(string file)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream stream = new FileStream(file, FileMode.Create))
            {
                bin.Serialize(stream, bindingSource.DataSource);
                stream.Close();
            }
        }
        private void Grid_RowValidating_1(object sender, DataGridViewCellCancelEventArgs e) 
        {
            var v = dataGridView["AlbumName", e.RowIndex].Value;
            if (v == null)
            {
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView["AlbumName", e.RowIndex];
                dataGridView.BeginEdit(true);
                MessageBox.Show("required field (AlbumName) is not filled");
            }
        }
        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e) { }
    }
}