using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace Archived_Data_Reader
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnLoadXML;
		private System.Windows.Forms.ListBox lstFiles;
		private System.Windows.Forms.ListBox lstDataType;
		private System.Windows.Forms.ListBox lstProject;
		private System.Windows.Forms.DataGrid dgXML;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.lstProject.Items.Clear();
			//string MyXMLDirectory = (@"\\tx-it-01\IVRS_Archived_Studies");
			string MyXMLDirectory = (@"C:\XML");
			//MyXMLDirectory = @"C:\XML" ;
			string[] dirs = Directory.GetDirectories(MyXMLDirectory);
			foreach (string dir in dirs)
			{
				//Debug.WriteLine(dir);
				this.lstProject.Items.Add(dir);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		/// <summary>
		/// Function that reads in an XML file and returns a dataset
		/// </summary
		/// 
		public static DataSet ReadXML(string DataSetName,string XMLFile)
		{
			DataSet ds = new DataSet();
			//System.IO.StringReader sr = new System.IO.StringReader(XMLFile);
			System.Xml.XmlTextReader sr = new System.Xml.XmlTextReader(XMLFile);
			ds.ReadXml(XMLFile);
			sr.Close();
			
			return ds;
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgXML = new System.Windows.Forms.DataGrid();
			this.btnLoadXML = new System.Windows.Forms.Button();
			this.lstFiles = new System.Windows.Forms.ListBox();
			this.lstDataType = new System.Windows.Forms.ListBox();
			this.lstProject = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.dgXML)).BeginInit();
			this.SuspendLayout();
			// 
			// dgXML
			// 
			this.dgXML.DataMember = "";
			this.dgXML.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgXML.Location = new System.Drawing.Point(0, 248);
			this.dgXML.Name = "dgXML";
			this.dgXML.Size = new System.Drawing.Size(776, 192);
			this.dgXML.TabIndex = 2;
			// 
			// btnLoadXML
			// 
			this.btnLoadXML.Location = new System.Drawing.Point(336, 168);
			this.btnLoadXML.Name = "btnLoadXML";
			this.btnLoadXML.TabIndex = 5;
			this.btnLoadXML.Text = "Load Data";
			this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
			// 
			// lstFiles
			// 
			this.lstFiles.Location = new System.Drawing.Point(24, 96);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(720, 30);
			this.lstFiles.TabIndex = 6;
			// 
			// lstDataType
			// 
			this.lstDataType.Enabled = false;
			this.lstDataType.Items.AddRange(new object[] {
															 "Shared_Core_Data",
															 "Study_Specific_Data"});
			this.lstDataType.Location = new System.Drawing.Point(24, 56);
			this.lstDataType.Name = "lstDataType";
			this.lstDataType.Size = new System.Drawing.Size(720, 30);
			this.lstDataType.TabIndex = 7;
			this.lstDataType.SelectedIndexChanged += new System.EventHandler(this.lstDataType_SelectedIndexChanged);
			// 
			// lstProject
			// 
			this.lstProject.Location = new System.Drawing.Point(24, 16);
			this.lstProject.Name = "lstProject";
			this.lstProject.Size = new System.Drawing.Size(720, 30);
			this.lstProject.TabIndex = 8;
			this.lstProject.SelectedIndexChanged += new System.EventHandler(this.lstProject_SelectedIndexChanged);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 437);
			this.Controls.Add(this.lstProject);
			this.Controls.Add(this.lstDataType);
			this.Controls.Add(this.lstFiles);
			this.Controls.Add(this.btnLoadXML);
			this.Controls.Add(this.dgXML);
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.dgXML)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form2());
		}

		private void lstProject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lstDataType.Enabled=true;
			lstFiles.Items.Clear();
			lstFiles.Enabled = false;
			//lstDataType.ClearSelected();
		}

		private void lstDataType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lstFiles.Enabled = true;
			lstFiles.Items.Clear();
			string[] files = Directory.GetFiles(lstProject.Items[lstProject.SelectedIndex].ToString() + "\\" + lstDataType.Items[lstDataType.SelectedIndex].ToString(),"*.xml" );
			foreach (string file in files)
			{
				//Debug.WriteLine(file);
				this.lstFiles.Items.Add(file);
			}
		}

		private void btnLoadXML_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet MyDataSet = new DataSet("ArchivedData");
				MyDataSet = Form2.ReadXML("ArchivedData",lstFiles.Items[lstFiles.SelectedIndex].ToString());
				dgXML.ReadOnly = true;
				dgXML.DataSource = MyDataSet;
				dgXML.SetDataBinding(MyDataSet,"row");
				//MessageBox.Show(lstFiles.Items[lstFiles.SelectedIndex].ToString());
				//if (lstFiles.Items[lstFiles.SelectedIndex].ToString() = "" )
				//	MessageBox.Show("No file is selected.");
			}
			catch (System.ArgumentOutOfRangeException)
			{
				MessageBox.Show("No file selected to show!");
			}

		}



	}
}
