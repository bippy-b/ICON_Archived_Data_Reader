using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Security.Permissions;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: PermissionSet(SecurityAction.RequestOptional, Name = "Nothing")]

namespace ArchivedDataReader
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
		private System.Windows.Forms.ListBox lstSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtSearch;
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
			try
			{
				
				string MyXMLDirectory = System.Configuration.ConfigurationSettings.AppSettings.Get("XmlDir");
				//(@"\\tx-it-01\IVRS_Archived_Studies"); //For Release versions
				//string MyXMLDirectory = (@"C:\XML"); // For local testing
				


				string[] dirs = Directory.GetDirectories(MyXMLDirectory);
				foreach (string dir in dirs)
				{
					//Debug.WriteLine(dir); // Used for debugging
					this.lstProject.Items.Add(dir); 
				}
			}
			catch (System.ArgumentNullException e)
			{
				MessageBox.Show("An error has occured loading the study list.  You are probably missing the config file.");
				//MessageBox.Show(e.ToString());
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form2));
			this.dgXML = new System.Windows.Forms.DataGrid();
			this.btnLoadXML = new System.Windows.Forms.Button();
			this.lstFiles = new System.Windows.Forms.ListBox();
			this.lstDataType = new System.Windows.Forms.ListBox();
			this.lstProject = new System.Windows.Forms.ListBox();
			this.lstSearch = new System.Windows.Forms.ListBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgXML)).BeginInit();
			this.SuspendLayout();
			// 
			// dgXML
			// 
			this.dgXML.DataMember = "";
			this.dgXML.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgXML.Location = new System.Drawing.Point(8, 312);
			this.dgXML.Name = "dgXML";
			this.dgXML.Size = new System.Drawing.Size(736, 224);
			this.dgXML.TabIndex = 2;
			// 
			// btnLoadXML
			// 
			this.btnLoadXML.Enabled = false;
			this.btnLoadXML.Location = new System.Drawing.Point(344, 224);
			this.btnLoadXML.Name = "btnLoadXML";
			this.btnLoadXML.TabIndex = 5;
			this.btnLoadXML.Text = "Load Data";
			this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
			// 
			// lstFiles
			// 
			this.lstFiles.Location = new System.Drawing.Point(24, 136);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(720, 69);
			this.lstFiles.TabIndex = 6;
			this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
			// 
			// lstDataType
			// 
			this.lstDataType.Enabled = false;
			this.lstDataType.Items.AddRange(new object[] {
															 "Shared_Core_Data",
															 "Study_Specific_Data"});
			this.lstDataType.Location = new System.Drawing.Point(24, 96);
			this.lstDataType.Name = "lstDataType";
			this.lstDataType.Size = new System.Drawing.Size(720, 30);
			this.lstDataType.TabIndex = 7;
			this.lstDataType.SelectedIndexChanged += new System.EventHandler(this.lstDataType_SelectedIndexChanged);
			// 
			// lstProject
			// 
			this.lstProject.Location = new System.Drawing.Point(24, 16);
			this.lstProject.Name = "lstProject";
			this.lstProject.Size = new System.Drawing.Size(720, 69);
			this.lstProject.TabIndex = 8;
			this.lstProject.SelectedIndexChanged += new System.EventHandler(this.lstProject_SelectedIndexChanged);
			// 
			// lstSearch
			// 
			this.lstSearch.Location = new System.Drawing.Point(96, 264);
			this.lstSearch.Name = "lstSearch";
			this.lstSearch.Size = new System.Drawing.Size(192, 30);
			this.lstSearch.TabIndex = 9;
			this.lstSearch.SelectedIndexChanged += new System.EventHandler(this.lstSearch_SelectedIndexChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(496, 264);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.TabIndex = 10;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(344, 264);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.TabIndex = 11;
			this.txtSearch.Text = "";
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 549);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.lstSearch);
			this.Controls.Add(this.lstProject);
			this.Controls.Add(this.lstDataType);
			this.Controls.Add(this.lstFiles);
			this.Controls.Add(this.btnLoadXML);
			this.Controls.Add(this.dgXML);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ICON Archived Data Reader";
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
			btnLoadXML.Enabled = false;
			btnSearch.Enabled = false;
			lstSearch.Items.Clear();
			txtSearch.Text="";
			txtSearch.Enabled = false;
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
				lstSearch.Enabled = true;
				btnSearch.Enabled = false;
				txtSearch.Text = "";
				txtSearch.Enabled = false;
				DataSet MyDataSet = new DataSet("ArchivedData");
				MyDataSet = Form2.ReadXML("ArchivedData",lstFiles.Items[lstFiles.SelectedIndex].ToString());
				dgXML.ReadOnly = true;
				dgXML.DataSource = MyDataSet;
				dgXML.SetDataBinding(MyDataSet,"row");
				lstSearch.Items.Clear();
				for (int i=0 ; i <= MyDataSet.Tables[1].Columns.Count - 1; i++)
				{
					if (MyDataSet.Tables[1].Columns[i].ColumnName != "data_Id" )
						lstSearch.Items.Add(MyDataSet.Tables[1].Columns[i].ColumnName);
				}
				//MessageBox.Show(MyDataSet.Tables[1].Columns[i].ColumnName);
				//MyDataSet.Tables[0].Columns[0].ColumnName;
				//MessageBox.Show(lstFiles.Items[lstFiles.SelectedIndex].ToString());
				//if (lstFiles.Items[lstFiles.SelectedIndex].ToString() = "" )
				//	MessageBox.Show("No file is selected.");
			}
			catch (System.ArgumentOutOfRangeException)
			{
				MessageBox.Show("No file selected to show!");
			}

		}

		private void lstFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnLoadXML.Enabled = true;
			txtSearch.Enabled = false;
			lstSearch.Items.Clear();
			lstSearch.Enabled = false;
			btnSearch.Enabled = false;
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataSet MyDataSet = new DataSet("ArchivedData");
			//Add If statement to be sure user typed something
			if (txtSearch.Text != "")
			{
				MyDataSet = Form2.ReadXML("ArchivedData",lstFiles.Items[lstFiles.SelectedIndex].ToString());
				DataView MyDataView = new DataView(MyDataSet.Tables[1]);
				MyDataView.RowFilter = lstSearch.Items[lstSearch.SelectedIndex].ToString()+ "='" + txtSearch.Text.ToString() + "'";
				dgXML.DataSource = MyDataView;
			}
			else
				MessageBox.Show("Please type something into the search box.");
		}

		private void lstSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnSearch.Enabled = true;
			txtSearch.Enabled = true;
		}



	}
}
