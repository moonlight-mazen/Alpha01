using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace career
{
	/// <summary>
	/// Summary description for studentreg.
	/// </summary>
	public class studentreg : System.Web.UI.Page
	{	
		protected SqlTransaction trans = null;
		protected bool datecorrect=false;
		protected bool phonecorrect=false;
		protected bool degreecorrect=false;
		

		#region Defintions
		protected System.Data.SqlClient.SqlConnection conn;
		protected System.Data.SqlClient.SqlCommand cmdcountry;
		protected System.Web.UI.WebControls.DropDownList DDL_Day;
		protected System.Web.UI.WebControls.DropDownList DDL_Month;
		protected System.Web.UI.WebControls.DropDownList DDL_Year;
		protected System.Data.SqlClient.SqlConnection conn2;
		protected DataSet ds;
		protected bool flag=false;
		protected System.Data.SqlClient.SqlCommand cmdUniv;
		protected System.Data.SqlClient.SqlCommand cmdcheckusername;
		protected System.Data.SqlClient.SqlCommand cmdRegisterUser;
		protected System.Data.SqlClient.SqlCommand cmdcheckids;
		protected System.Web.UI.WebControls.Label Lbl_Phone;
		protected System.Web.UI.WebControls.Button But_AddPhone;
		protected System.Web.UI.WebControls.TextBox Txt_Phone;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.TextBox txt_CurAddress;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.TextBox txt_P_Address;
		protected System.Web.UI.WebControls.Label lbldate;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.DropDownList ddlDay;
		protected System.Web.UI.WebControls.RegularExpressionValidator Val_Email;
		protected System.Web.UI.WebControls.TextBox Txt_email;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_Cntry;
		protected System.Web.UI.WebControls.DropDownList DDL_Cntry;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.TextBox Txt_Lname;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_MI;
		protected System.Web.UI.WebControls.TextBox Txt_MI;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_FName;
		protected System.Web.UI.WebControls.TextBox Txt_Fname;
		protected System.Web.UI.WebControls.DataGrid dgdegrees1;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist3;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist4;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.DropDownList dllDegree;
		protected System.Web.UI.WebControls.DropDownList ddlDegree;
		protected System.Web.UI.WebControls.Label lbldegr;
		protected System.Web.UI.WebControls.DropDownList ddlUniv;
		protected System.Web.UI.WebControls.DropDownList ddlgradyr;
		protected System.Web.UI.WebControls.Button But_Adddeg;
		protected System.Web.UI.WebControls.Button But_Submit;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox Txt_Secr;
		protected System.Web.UI.WebControls.Label Lb_Img;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.TextBox Txt_ConPass;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_ConPass;
		protected System.Web.UI.WebControls.CompareValidator ValComp_Pas;
		protected System.Web.UI.WebControls.TextBox Txt_Pass;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_Pass;
		protected System.Web.UI.WebControls.TextBox Txt_UserN;
		protected System.Web.UI.WebControls.Label lblusernameexist;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_User;
		protected System.Web.UI.WebControls.RequiredFieldValidator Val_ID;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.TextBox Txt_ID;
		protected System.Web.UI.WebControls.Label lblidexist;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.DataGrid dgdegrees;
		protected System.Web.UI.WebControls.DataGrid dgphone;
		protected System.Web.UI.WebControls.Label lbldeg;
		protected System.Web.UI.WebControls.Label lbluniv;
		protected System.Web.UI.WebControls.Label lblgrad;
		protected System.Web.UI.WebControls.Label lbldegearned;
		protected sstchur.web.SmartNav.SmartScroller SmartScroller1;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.DropDownList ddlmajor;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator10;
		protected System.Web.UI.WebControls.HyperLink hlinternship;
		protected System.Data.SqlClient.SqlCommand cmdDeg;
		protected System.Data.SqlClient.SqlCommand cmdgetmajors;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist5;
		protected System.Web.UI.WebControls.RadioButtonList rblgender;
		protected System.Data.SqlClient.SqlCommand cmdgetgenders;
		protected int studentid;

		#endregion

		#region Pageload
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{//create 6 letters image
				Session.Timeout=50;
				Session["CheckCode"] = this.CreateRandomCode(6);
				FEALib.library bindddls =new FEALib.library();
				bindddls.binddrops(DDL_Cntry,cmdcountry,"Select Country","0","Country","CouID");
				career.Administrator.library obj=new career.Administrator.library();
				obj.bindEdulevelJobStatus(conn,rblgender,cmdgetgenders,Label2,"studenreg");

				bindddls.binddrops(ddlDegree,cmdDeg,"Select Degree","0","DegreeName","DegreeID");
				bindddls.binddrops(ddlmajor,cmdgetmajors,"Select Major","NA","MajorName","MajorID");


				bindddls.binddrops(ddlUniv,cmdUniv,"Select University","0","UnivName","Univid");
				Session["CheckImg"]=CreateRandomCode(6);
				
				
				
				//Fill the day,month and year DDLs
						
				ddlDay.Items.Insert(0,new ListItem("Day","0"));
				for(int i=1;i<32;i++)
					ddlDay.Items.Insert(i,i.ToString());
				ddlDay.DataBind();
				ddlDay.SelectedIndex=-1;
			
				
				ddlMonth.Items.Insert(0,new ListItem("Month","0"));
				for(int i=1;i<=12;i++)
					ddlMonth.Items.Insert(i,i.ToString());
				ddlMonth.DataBind();
				ddlMonth.SelectedIndex=-1;
				
				ddlYear.Items.Insert(0,new ListItem("Year","0"));
				ddlgradyr.Items.Insert(0,new ListItem("Year","0"));
				for(int i=1;i<89;i++)
				{ddlYear.Items.Insert(i,(System.DateTime.Now.Year-i+1).ToString());
					ddlgradyr.Items.Insert(i,(System.DateTime.Now.Year-i+5).ToString());}
				ddlYear.DataBind();	
				ddlgradyr.DataBind();
			
				dgphone.DataSource=null;
				dgphone.DataBind();
				
				dgdegrees.DataSource=null;
				dgdegrees.DataBind();
				
				
				ds = new DataSet();
				//Create Phones table
				DataTable dtPhones = ds.Tables.Add("Phones");		
				DataColumn dcPhone = dtPhones.Columns.Add("Phone Number", typeof(string));
				
				
				//Create Degrees Table
				DataTable dtDegrees = ds.Tables.Add("Degrees");
				DataColumn dcDegID = dtDegrees.Columns.Add("DID", typeof(int));
				DataColumn dcDegName = dtDegrees.Columns.Add("Degree", typeof(string));
				DataColumn dcUnivName = dtDegrees.Columns.Add("University", typeof(string));
				DataColumn dcUnivID = dtDegrees.Columns.Add("UID", typeof(int));
				DataColumn dcGrad_Year = dtDegrees.Columns.Add("Grad_Year", typeof(int));
				dcDegID.ColumnMapping= MappingType.Hidden;
				dcUnivID.ColumnMapping=MappingType.Hidden;
				Session["dset"]=ds;
				
				//added logic for 2nd ,3rd and 4th year students
				if(Session["Division"].ToString()=="Alumni" || Session["Division"].ToString()=="Masters")
				{
				//don't disable controls of degrees
				}
				else
					DisableDegrees();

				//just for the link
				if(Session["Division"].ToString()=="Intern")
					hlinternship.Visible=true;
			
			}	
			
				
				
		}

		#endregion

		#region Web Form Designer Generated Code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.conn = new System.Data.SqlClient.SqlConnection();
			this.cmdcountry = new System.Data.SqlClient.SqlCommand();
			this.conn2 = new System.Data.SqlClient.SqlConnection();
			this.cmdUniv = new System.Data.SqlClient.SqlCommand();
			this.cmdcheckids = new System.Data.SqlClient.SqlCommand();
			this.cmdcheckusername = new System.Data.SqlClient.SqlCommand();
			this.cmdRegisterUser = new System.Data.SqlClient.SqlCommand();
			this.cmdDeg = new System.Data.SqlClient.SqlCommand();
			this.cmdgetmajors = new System.Data.SqlClient.SqlCommand();
			this.cmdgetgenders = new System.Data.SqlClient.SqlCommand();
			this.But_AddPhone.Click += new System.EventHandler(this.But_AddPhone_Click);
			this.But_Adddeg.Click += new System.EventHandler(this.But_Adddeg_Click);
			this.dgdegrees.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdegrees_DeleteCommand);
			this.But_Submit.Click += new System.EventHandler(this.But_Submit_Click);
			// 
			// conn
			// 
			this.conn.ConnectionString = ((string)(configurationAppSettings.GetValue("conn2", typeof(string))));
			// 
			// cmdcountry
			// 
			this.cmdcountry.CommandText = "dbo.[GetCountries]";
			this.cmdcountry.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdcountry.Connection = this.conn;
			this.cmdcountry.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdUniv
			// 
			this.cmdUniv.CommandText = "dbo.[GetUniversitiesA]";
			this.cmdUniv.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdUniv.Connection = this.conn;
			this.cmdUniv.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdcheckids
			// 
			this.cmdcheckids.CommandText = "dbo.[checkids]";
			this.cmdcheckids.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdcheckids.Connection = this.conn;
			this.cmdcheckids.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdcheckids.Parameters.Add(new System.Data.SqlClient.SqlParameter("@idnumber", System.Data.SqlDbType.NVarChar, 15));
			// 
			// cmdcheckusername
			// 
			this.cmdcheckusername.CommandText = "dbo.[checkusername]";
			this.cmdcheckusername.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdcheckusername.Connection = this.conn;
			this.cmdcheckusername.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdcheckusername.Parameters.Add(new System.Data.SqlClient.SqlParameter("@username", System.Data.SqlDbType.NVarChar, 30));
			// 
			// cmdRegisterUser
			// 
			this.cmdRegisterUser.CommandText = "dbo.[RegisterUserA]";
			this.cmdRegisterUser.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdRegisterUser.Connection = this.conn;
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fname", System.Data.SqlDbType.NVarChar, 50));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lname", System.Data.SqlDbType.NVarChar, 50));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mname", System.Data.SqlDbType.NVarChar, 5));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@idnumber", System.Data.SqlDbType.NVarChar, 15));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nationalityid", System.Data.SqlDbType.Int, 4));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dob", System.Data.SqlDbType.NVarChar, 12));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@genderid", System.Data.SqlDbType.Int, 4));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@majorid", System.Data.SqlDbType.Int, 4));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@divisionid", System.Data.SqlDbType.Int, 4));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@exp_years", System.Data.SqlDbType.NVarChar, 20));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dateogradn", System.Data.SqlDbType.DateTime, 8));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@username", System.Data.SqlDbType.NVarChar, 30));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 30));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paddress", System.Data.SqlDbType.NVarChar, 1073741823));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@caddress", System.Data.SqlDbType.NVarChar, 1073741823));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@encpass", System.Data.SqlDbType.VarChar, 50));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cuname", System.Data.SqlDbType.VarChar, 30));
			this.cmdRegisterUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@idgenerated", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdDeg
			// 
			this.cmdDeg.CommandText = "dbo.[GetDegrees]";
			this.cmdDeg.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdDeg.Connection = this.conn;
			this.cmdDeg.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdgetmajors
			// 
			this.cmdgetmajors.CommandText = "dbo.[GetMajors]";
			this.cmdgetmajors.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdgetmajors.Connection = this.conn;
			this.cmdgetmajors.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdgetgenders
			// 
			this.cmdgetgenders.CommandText = "dbo.[Getgenders]";
			this.cmdgetgenders.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdgetgenders.Connection = this.conn;
			this.cmdgetgenders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		#region Image Verification 
		/*------------------Image Verification-----------------------*/
		public string CreateRandomCode(int codeCount)
		{
			string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
			string[] allCharArray = allChar.Split(',');
			string randomCode = "";
			int temp = -1;

			Random rand = new Random();
			for (int i = 0; i < codeCount; i++)
			{
				if (temp != -1)
				{
					rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
				}
				int t = rand.Next(34);
				if (temp != -1 && temp == t)
				{
					return CreateRandomCode(codeCount);
				}
				temp = t;
				randomCode += allCharArray[t];
			}
			return randomCode;
		}

		#endregion

		#region Phone's Logic
		private void But_AddPhone_Click(object sender, System.EventArgs e)
		{
				
			if(Txt_Phone.Text.Trim()!="")
			{
				DataSet ds1;
				ds1=(DataSet) Session["dset"];
				bool phonein=false;

				foreach(DataRow drow in ds1.Tables["Phones"].Rows)
				{
					if(Txt_Phone.Text.ToString()==drow["Phone Number"].ToString())
					{
						phonein=true;
						break;
					}
				}
				/*Phone entered for fist time*/
				if(phonein==false)
				{
					ds1.Tables["Phones"].Rows.Add(new object[]{Txt_Phone.Text});
					Txt_Phone.Text="";
					Lbl_Phone.Text="";
				}
				
				/*Phone previously entered*/
				else 
				{						
					Lbl_Phone.Visible=true; 
					Lbl_Phone.Text="Phone already entered."; 
					Txt_Phone.Text=""; 			
				}
				
				dgphone.DataSource=ds1.Tables["Phones"].DefaultView;
				dgphone.DataBind();
				
			}
			else{Lbl_Phone.Visible=true;Lbl_Phone.Text="Please Enter a Phone Number";}
			
			
		}

		

		private void dgphone_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			DataSet ds1;
			ds1=(DataSet) Session["dset"];
			ds1.Tables["Phones"].Rows[e.Item.ItemIndex].Delete();
			Session["dset"]=ds1;
			if(ds1.Tables["Phones"].Rows.Count>0)
				dgphone.DataSource=ds1.Tables["Phones"];
			else
				dgphone.DataSource=null;
			dgphone.DataBind();
		}

	
		
		//END FUNCTION

		#endregion
	
		#region Degrees' Logic
		private void But_Adddeg_Click(object sender, System.EventArgs e)
		{
				
			if(ddlDegree.SelectedIndex!=0 && ddlUniv.SelectedIndex!=0 && ddlgradyr.SelectedIndex!=0)
			{
				DataSet ds1;
				ds1=(DataSet) Session["dset"];

				bool degin=false;

				foreach(DataRow drow in ds1.Tables["Degrees"].Rows)
				{
					if(drow["Degree"].ToString()==ddlDegree.SelectedItem.Text)
					{
						degin=true;
						break;
					}
				}
				/*New Degree*/
				if(degin==false)
				{
					ds1.Tables["Degrees"].Rows.Add(new object[]{ddlDegree.SelectedValue,ddlDegree.SelectedItem.Text,ddlUniv.SelectedItem.Text,ddlUniv.SelectedValue,ddlgradyr.SelectedValue});
			
					dgdegrees.DataSource=ds1.Tables["Degrees"];
					dgdegrees.DataBind();
									
					ddlDegree.ClearSelection();
					ddlUniv.ClearSelection();
					ddlgradyr.ClearSelection();
					lbldegr.Text="";
				}
				else
				{
					lbldegr.Visible=true; 
					lbldegr.Text="Degree already entered";
				}
				dgdegrees.DataSource=ds1.Tables["Degrees"];
				dgdegrees.DataBind();
				
			}

			else
			{
				lbldegr.Visible=true; lbldegr.Text="Please enter complete degree information";
			}

		}

					
		private void dgdegrees_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataSet ds1;
			ds1=(DataSet) Session["dset"];
			ds1.Tables["Degrees"].Rows[e.Item.ItemIndex].Delete();
			Session["dset"]=ds1;
			if(ds1.Tables["Degrees"].Rows.Count>0)
				dgdegrees.DataSource=ds1.Tables["Degrees"];
			else
				dgdegrees.DataSource=null;	
			
			dgdegrees.DataBind();
			
		}

		#endregion
		
		#region Submit
		private void But_Submit_Click(object sender, System.EventArgs e)
		{
			if(Session["Division"]==null)
				Response.Redirect("~/Main.aspx");

			if(Txt_Secr.Text.ToString()==Session["CheckCode"].ToString())
			{
				#region if
				if(Page.IsValid)
				{
					conn.Open();
					cmdcheckusername.Parameters["@username"].Value=Txt_UserN.Text;
					cmdcheckids.Parameters["@idnumber"].Value=Txt_ID.Text;
					SqlDataReader drc=cmdcheckids.ExecuteReader(CommandBehavior.CloseConnection);

					/*If id exists*/
					if(drc.Read())
					{
						lblidexist.Visible=true;
						drc.Close();
						conn.Open();
						SqlDataReader dru=cmdcheckusername.ExecuteReader(CommandBehavior.CloseConnection);
						/*If id and username exist*/
						if(dru.Read())
						{
							lblusernameexist.Visible=true;
							dru.Close();
						}
					}
			
					else				
					{
						drc.Close();
						conn.Open();
						SqlDataReader dru=cmdcheckusername.ExecuteReader(CommandBehavior.CloseConnection);
						/*If username exists alone*/
						if(dru.Read())
						{
							lblusernameexist.Visible=true;
							dru.Close();
						}
							/*id and username don't exist*/		
						else
						{
							lblusernameexist.Visible=false;
							lblidexist.Visible=false;
							dru.Close();
						
							/*Check Correct Date*/
							if(ddlDay.SelectedIndex==0 || ddlMonth.SelectedIndex==0 || ddlYear.SelectedIndex==0)
							{lbldate.Text="Choose correct date"; lbldate.Visible=true;}
							else
							{
								try
								{
									Convert.ToDateTime(ddlDay.SelectedItem.Value+"/"+ddlMonth.SelectedItem.Value+"/"+ddlYear.SelectedItem.Value);
									datecorrect=true;
								}
								catch{lbldate.Text="Invalid date"; lbldate.Visible=true;}
							}
						
							DataSet ds1;
							ds1=(DataSet) Session["dset"];

										


							/*Check that user entered a phone number*/
							if(ds1.Tables["Phones"].Rows.Count.ToString()=="0")
							{Lbl_Phone.Visible=true; Lbl_Phone.Text="You should insert a phone number";}
							else{phonecorrect=true; Lbl_Phone.Visible=false;}

						
							/*Check that user entered a degree*/
							if(Session["Division"].ToString()=="Alumni" || Session["Division"].ToString()=="Masters")
							{
								if(ds1.Tables["Degrees"].Rows.Count.ToString()=="0")	
								{lbldegr.Visible=true; lbldegr.Text="You should insert a degree";}
								else{degreecorrect=true; lbldegr.Visible=false;}							
							}
							else
								degreecorrect=true;
						
							/*Date, phone, degree entered correctly*/
							if(datecorrect && phonecorrect & degreecorrect)
						
							{
								try
								{
									if (this.conn.State==ConnectionState.Closed)
										this.conn.Open();
									trans= this.conn.BeginTransaction();
									cmdRegisterUser.Transaction=trans;

									cmdRegisterUser.Parameters["@fname"].Value=Txt_Fname.Text;
									cmdRegisterUser.Parameters["@lname"].Value=Txt_Lname.Text;
									cmdRegisterUser.Parameters["@mname"].Value=Txt_MI.Text;
									cmdRegisterUser.Parameters["@idnumber"].Value=Txt_ID.Text;
									cmdRegisterUser.Parameters["@email"].Value=Txt_email.Text;
									cmdRegisterUser.Parameters["@nationalityid"].Value=int.Parse(DDL_Cntry.SelectedItem.Value);
									cmdRegisterUser.Parameters["@dob"].Value=ddlDay.SelectedItem.Value+"/"+ddlMonth.SelectedItem.Value+"/"+ddlYear.SelectedItem.Value;
									cmdRegisterUser.Parameters["@genderid"].Value=Convert.ToInt32(rblgender.SelectedValue);
									
									cmdRegisterUser.Parameters["@majorid"].Value=int.Parse(ddlmajor.SelectedValue);
									cmdRegisterUser.Parameters["@divisionid"].Value=int.Parse(Session["divid"].ToString());
													
									cmdRegisterUser.Parameters["@exp_years"].Value=0;
									cmdRegisterUser.Parameters["@dateogradn"].Value=ddlDay.SelectedItem.Value+"/"+ddlMonth.SelectedItem.Value+"/"+ddlYear.SelectedItem.Value;
									cmdRegisterUser.Parameters["@paddress"].Value=txt_P_Address.Text;
									cmdRegisterUser.Parameters["@caddress"].Value=txt_CurAddress.Text;
									cmdRegisterUser.Parameters["@username"].Value=Txt_UserN.Text;
									cmdRegisterUser.Parameters["@password"].Value=Txt_Pass.Text;								
												
																						
									SHA256Managed sha = new  SHA256Managed();
									string pass = Convert.ToBase64String(sha.ComputeHash(Encoding.Default.GetBytes(Txt_Pass.Text.ToString())));
									cmdRegisterUser.Parameters["@encpass"].Value=pass;
									cmdRegisterUser.Parameters["@cuname"].Value=Txt_UserN.Text.Trim().ToString();
									cmdRegisterUser.ExecuteNonQuery();	
								
									/*Retrieve the auto id generated*/
									studentid=Convert.ToInt32(cmdRegisterUser.Parameters["@idgenerated"].Value.ToString());  
												
									#region Insert_Phones	
									/* @@@@@@@@@@@@@@@@@@@@@@@ To insert Phones @@@@@@@@@@@@@@@@@ */
									SqlCommand[] commands = new SqlCommand[Convert.ToInt32(ds1.Tables["Phones"].Rows.Count.ToString())];

									for (int i = 0; i < Convert.ToInt32(ds1.Tables["Phones"].Rows.Count.ToString()); i++)
									{
										DataRow drow = ds1.Tables["Phones"].Rows[i];
										commands[i] = new SqlCommand();
										commands[i].Transaction = trans;
										commands[i].CommandText = "insertphone";
										commands[i].CommandType = System.Data.CommandType.StoredProcedure;
										commands[i].Connection = this.conn;

										SqlParameter param;
										param = commands[i].Parameters.Add("@id",studentid);
										param.DbType = DbType.Int64;
										param.Direction = ParameterDirection.Input;

						
										param = commands[i].Parameters.Add("@phone", drow["Phone Number"].ToString());
										param.DbType = DbType.String;
										param.Direction = ParameterDirection.Input;

										commands[i].ExecuteNonQuery();

									}
									
									/*@@@@@@@@@@@@@@@@@@@End of command for phones@@@@@@@@@@@@@@@@@@@*/
									#endregion
																						
									#region Insert_Degrees

									if(Session["Division"].ToString()=="Alumni" || Session["Division"].ToString()=="Masters")
									{
										SqlCommand[] deg_commands = new SqlCommand[Convert.ToInt32(ds1.Tables["Degrees"].Rows.Count.ToString())];

										for (int i = 0; i < Convert.ToInt32(ds1.Tables["Degrees"].Rows.Count.ToString()); i++)
										{
											DataRow drow = ds1.Tables["Degrees"].Rows[i];
											deg_commands[i] = new SqlCommand();
											deg_commands[i].Transaction = trans;
											deg_commands[i].CommandText = "insertdegreeinfo";
											deg_commands[i].CommandType = System.Data.CommandType.StoredProcedure;
											deg_commands[i].Connection = this.conn;

											SqlParameter param;
											param = deg_commands[i].Parameters.Add("@id",studentid);
											param.DbType = DbType.Int64;
											param.Direction = ParameterDirection.Input;

					
											param = deg_commands[i].Parameters.Add("@degid", drow["DID"].ToString());
											param.DbType = DbType.String;
											param.Direction = ParameterDirection.Input;

											param = deg_commands[i].Parameters.Add("@yearofgrad", drow["Grad_Year"].ToString());
											param.DbType = DbType.String;
											param.Direction = ParameterDirection.Input;

											param = deg_commands[i].Parameters.Add("@univid", drow["UID"].ToString());
											param.DbType = DbType.String;
											param.Direction = ParameterDirection.Input;

											deg_commands[i].ExecuteNonQuery();

										}
									}
									#endregion
									# region sendregemail
									//send an automated email
									try
									{
									FEALib.library obj=new FEALib.library();
                                    obj.sendemail("FAFSCareerRegistration@aub.edu.lb", "fafs.careers@aub.edu.lb", "", Txt_email.Text.Trim(), "FAFS Career Registration", "Dear " + Txt_Fname.Text + " " + Txt_Lname.Text + ", \n \n" + "Your Account is still inactive." + Txt_email.Text.Trim() + "\n \nPlease allow two working days for activation.\n\nYou will Receive an automated e-mail upon activation. \n\n" + "Regards, \nFAFS Career Website \n\nP.S:This is an automated message, Please Do Not Reply\n\n ");
									}
									catch
									{
										Label2.Text=Server.UrlEncode("An error has occured,please contact Webmaster(specify your username)");
									}

									#endregion
								
									/*Insert Everything to database*/
									trans.Commit();
                                    string redirect = "~/studentreg2.aspx?c=" + Txt_email.Text.Trim();
									Response.Redirect(redirect);
												
								}//END TRY

							
								catch(Exception ex)
								{
									try
									{
										if(trans!=null)
											trans.Rollback();
									}
									catch(SqlException sqlex)
									{
										FEALib.library s=new FEALib.library();
										if(trans!=null)
											s.sendemail("FAFSCareerError@aub.edu.lb","","","fafs.careers@aub.edu.lb","Error in rolling back Alumni","Error:"+sqlex.ToString());
									}
									Label2.Text="Error encountered while inserting data. Administrator was notified.";
									FEALib.library smail=new FEALib.library();
									smail.sendemail("FAFSCareerError@aub.edu.lb","","","fafs.careers@aub.edu.lb","Error in inserting Alumni","Error:"+ex.ToString());
					
								}
								finally
								{
									if(conn!=null)
										conn.Close();
								}

							
							}//end if

						}//END ELSE DRC.READ
			  
					}//END else 
	
				}//END IF PAGE IS VALID
				#endregion
			}
			/*Not same as image*/
			else
			{Lb_Img.Text="Secret Numbers do not match.";
			 Session["CheckCode"]=CreateRandomCode(6);
			
			 Txt_Secr.Text="";
			 
			 }
		
		}

		#endregion

		protected void DisableDegrees(){
		
		lbldeg.Visible=false;
		lbluniv.Visible=false;
		lbldegearned.Visible=false;
		lblgrad.Visible=false;
			ddlDegree.Visible=false;ddlDegree.Enabled=false;
			ddlUniv.Visible=false;ddlUniv.Enabled=false;
			ddlgradyr.Visible=false;ddlgradyr.Enabled=false;
			lbldegr.Visible=false;But_Adddeg.Visible=false;
			But_Adddeg.Enabled=false;
			dgdegrees.Visible=false;
		
		
		}
		

	}
}

