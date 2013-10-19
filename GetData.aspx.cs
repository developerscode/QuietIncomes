using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class GetData : System.Web.UI.Page
{
    public int memberid;
    // MemberDetails class declaration 
    public class MemberDetails
    {
        public string MemberTitle { get; set; }
        public string FullNmae { get; set; }
        public string AboutMe { get; set; }
        public string GoalText1 { get; set; }
        public string AccountStatusID { get; set; }
        public string InboxCount { get; set; }
        public string SentCount { get; set; }
        public string ArchiveCount { get; set; }

    }
    //Inbox details class declaration 
    public class InboxDetails
    {
        public string FromMemberName { get; set; }
        public string FromMemberTitle { get; set; }
        public string FromImageName { get; set; }
        public string EmailDate { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ToMemberName { get; set; }
        public bool IsArchive { get; set; }
        public bool IsReminder { get; set; }
        public int InboxId { get; set; }
        public int FromMemberId { get; set; }
        public int ToMemberID { get; set; }

    }
    public class SentBoxDetails
    {
        public string ToMemberName1 { get; set; }
        public string FromMemberName1 { get; set; }
        public string FromImageName1 { get; set; }
        public string EmailDate1 { get; set; }
        public string Message1 { get; set; }
        public int InboxId { get; set; }

    }
    public class ArchiveDetails
    {
        public string ToMemberName1 { get; set; }
        public string FromMemberName1 { get; set; }
        public string FromImageName1 { get; set; }
        public string EmailDate1 { get; set; }
        public string Subject1 { get; set; }
        public string Message1 { get; set; }
        public int InboxId { get; set; }
        public int FromMemberId { get; set; }
        public int ToMemberID { get; set; }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // nothing here 
         memberid = 10000000;
        
        

    }

    [WebMethod]
    public static MemberDetails[] GetMemberDetails(string userId)
    {

        DataTable dt = new DataTable();

        List<MemberDetails> details = new List<MemberDetails>();
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboGetMemerDetails]", con))
            {
                command.Parameters.Add("@MemberID", SqlDbType.VarChar).Value = userId;//;10000066;// 10000000;// 10000031;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {
                    MemberDetails st = new MemberDetails();
                    st.MemberTitle = dtrow["MemberTitle"].ToString();
                    st.FullNmae = dtrow["FullNmae"].ToString();
                    st.AboutMe = dtrow["AboutMe"].ToString();
                    st.GoalText1 = dtrow["GoalText"].ToString();
                    st.AccountStatusID = dtrow["AccountStatusID"].ToString();
                    st.InboxCount = dtrow["InboxCount"].ToString();
                    st.SentCount = dtrow["SentCount"].ToString();
                    st.ArchiveCount = dtrow["ArchiveCount"].ToString();
                    details.Add(st);

                }

            }

        }
        return details.ToArray();


    }

    [WebMethod]
    public static InboxDetails[] GetInboxDetails(string userId)
    {

        DataTable dt = new DataTable();

        List<InboxDetails> maildetails = new List<InboxDetails>();
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboGetInboxDetailInfo]", con))
            {

                command.Parameters.Add("@MemberID", SqlDbType.VarChar).Value = userId;// 10000000; //10000000;// 10000031;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {
                    InboxDetails str = new InboxDetails();
                    str.FromMemberName = dtrow["FromMemberName"].ToString();
                    str.FromMemberTitle = dtrow["FromMemberTitle"].ToString();
                    str.FromImageName = dtrow["FromImageName"].ToString();
                    str.EmailDate = dtrow["EmailDate"].ToString();
                    str.Subject = dtrow["Subject"].ToString();
                    str.Message = dtrow["Message"].ToString();
                    str.InboxId = Convert.ToInt32(dtrow["InboxId"].ToString());
                    str.FromMemberId = Convert.ToInt32(dtrow["FromMemberId"].ToString());
                    str.ToMemberID = Convert.ToInt32(dtrow["ToMemberID"].ToString());
                    maildetails.Add(str);

                }

            }

        }
        return maildetails.ToArray();
    }

    [WebMethod]
    public static SentBoxDetails[] GetSentDetails(string userId)
    {

        DataTable dt = new DataTable();

        List<SentBoxDetails> sentMaildetails = new List<SentBoxDetails>();
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboSentItemsDetailInfo]", con))
            {

                command.Parameters.Add("@MemberID", SqlDbType.VarChar).Value = userId;// 10000000;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {

                    SentBoxDetails senttr = new SentBoxDetails();
                    senttr.ToMemberName1 = dtrow["ToMemberName"].ToString();
                    senttr.FromMemberName1 = dtrow["FromMemberName"].ToString();
                    senttr.FromImageName1 = dtrow["FromImageName"].ToString();
                    senttr.EmailDate1 = dtrow["EmailDate"].ToString();
                    senttr.Message1 = dtrow["Message"].ToString();
                    senttr.InboxId = Convert.ToInt32(dtrow["InboxId"].ToString());
                    sentMaildetails.Add(senttr);

                }

            }

        }
        return sentMaildetails.ToArray();


    }
    [WebMethod]
    public static ArchiveDetails[] GetArchiveDetails(string userId)
    {

        DataTable dt = new DataTable();

        List<ArchiveDetails> sentMaildetails = new List<ArchiveDetails>();
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboArchivedItemsDetailInfo]", con))
            {

                command.Parameters.Add("@MemberID", SqlDbType.VarChar).Value = userId;// 10000031;// 10000000;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                foreach (DataRow dtrow in dt.Rows)
                {

                    ArchiveDetails senttr = new ArchiveDetails();
                    senttr.ToMemberName1 = dtrow["ToMemberName"].ToString();
                    senttr.FromMemberName1 = dtrow["FromMemberName"].ToString();
                    senttr.FromImageName1 = dtrow["FromImageName"].ToString();
                    senttr.EmailDate1 = dtrow["EmailDate"].ToString();
                    senttr.Subject1 = dtrow["Subject"].ToString();
                    senttr.Message1 = dtrow["Message"].ToString();
                    senttr.InboxId = Convert.ToInt32(dtrow["InboxId"].ToString());
                    senttr.FromMemberId = Convert.ToInt32(dtrow["FromMemberId"].ToString());
                    senttr.ToMemberID = Convert.ToInt32(dtrow["ToMemberID"].ToString());

                    sentMaildetails.Add(senttr);

                }

            }

        }
        return sentMaildetails.ToArray();


    }
    [WebMethod]
    public static string getmyvalue()
    {
        return "tanisha";
    }
    [WebMethod]
    public static string MoveToArchive(string Id)
    {

        DataSet ds = new DataSet();
        string msg = "";
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboMoveToArchive]", con))
            {

                command.Parameters.Add("@InboxID", SqlDbType.VarChar).Value = Id;// 10000000;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msg = "your messages(S) are successfully moved to Archive";
                }
                else
                {
                    msg = "Error occurred";
                }

            }

        }
        return msg;
    }

    [WebMethod]
    public static string DeleteMEssages(string Id)
    {

        DataSet ds = new DataSet();
        string msg = "";
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboDeleteMessages]", con))
            {

                command.Parameters.Add("@InboxID", SqlDbType.VarChar).Value = Id;// 10000000;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msg = "your messages(S) are successfully Deleted";
                }
                else
                {
                    msg = "Error occurred";
                }

            }

        }
        return msg;
    }
    [WebMethod]
    public static string MoveToRemainder(string Id)
    {

        DataSet ds = new DataSet();
        string msg = "";
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboMoveToIsReminder]", con))
            {

                command.Parameters.Add("@InboxID", SqlDbType.VarChar).Value = Id;// 10000000;// 10000031;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msg = "your messages(S) are successfully moved to Reminder";
                }
                else
                {
                    msg = "Error occurred";
                }

            }

        }
        return msg;
    }
  
    [WebMethod]
    public static string sendmessages(string frmId, string toid, string RepMesg)
    {

        DataSet ds = new DataSet();
        string msg = "";
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboArchiveReplayMessage]", con))
            {

                command.Parameters.Add("@FromMemberID", SqlDbType.VarChar).Value = frmId;// Convert.ToInt32(frmId);
                command.Parameters.Add("@ToMemberID", SqlDbType.VarChar).Value = toid;// Convert.ToInt32(toid);
                command.Parameters.Add("@Subject", SqlDbType.VarChar).Value = "";
                // 10000000;// 10000031;
                command.Parameters.Add("@ReplyText", SqlDbType.VarChar).Value = RepMesg;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msg = "your messages(S) are successfully sent";
                }
                else
                {
                    msg = "Error occurred";
                }

            }

        }
        return msg;
    }
     [WebMethod]
    public static string ReplayfromInbox(string frmId, string toid, string RepMesg)
    {

        DataSet ds = new DataSet();
        string msg = "";
        string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand command = new SqlCommand("[mboArchiveReplayMessage]", con))
            {

                command.Parameters.Add("@FromMemberID", SqlDbType.VarChar).Value = toid;// Convert.ToInt32(frmId);
                command.Parameters.Add("@ToMemberID", SqlDbType.VarChar).Value = frmId;// Convert.ToInt32(toid);
                command.Parameters.Add("@Subject", SqlDbType.VarChar).Value = "";
                // 10000000;// 10000031;
                command.Parameters.Add("@ReplyText", SqlDbType.VarChar).Value = RepMesg;
                command.CommandType = CommandType.StoredProcedure;
                con.Open();
                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    msg = "your messages(S) are successfully sent";
                }
                else
                {
                    msg = "Error occurred";
                }

            }

        }
        return msg;
    }
     [WebMethod]
     public static string GetNormalUserId(string Username, string password)
     {

         DataSet ds = new DataSet();
         string msg = "";
         string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
         using (SqlConnection con = new SqlConnection(strConnString))
         {
             using (SqlCommand command = new SqlCommand("[Get_UserLoginId ]", con))
             {

                 command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;// Convert.ToInt32(frmId);
                 command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;// Convert.ToInt32(toid);
                 command.Parameters.Add("@UserType", SqlDbType.VarChar).Value = "NORMAL";
                 command.Parameters.Add("@otherId", SqlDbType.VarChar).Value = "";
                 command.CommandType = CommandType.StoredProcedure;
                 con.Open();

                 SqlDataAdapter da = new SqlDataAdapter();
                 da.SelectCommand = command;
                 da.Fill(ds);
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     msg = ds.Tables[0].Rows[0]["MemberID"].ToString();
                 }
                 else
                 {
                     msg = "Error occurred";
                 }

             }

         }
         return msg;


     }

     [WebMethod]//Fb_id,twitter_id,google_id,linkedin_id
     public static string GetSocialUserId(string UserType, string otherId)
     {

         DataSet ds = new DataSet();
         string msg = "";
         string strConnString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
         using (SqlConnection con = new SqlConnection(strConnString))
         {
             using (SqlCommand command = new SqlCommand("[Get_UserLoginId ]", con))
             {

                 command.Parameters.Add("@Username", SqlDbType.VarChar).Value = "";// Convert.ToInt32(frmId);
                 command.Parameters.Add("@password", SqlDbType.VarChar).Value = "";// Convert.ToInt32(toid);
                 command.Parameters.Add("@UserType", SqlDbType.VarChar).Value = UserType;
                 command.Parameters.Add("@otherId", SqlDbType.VarChar).Value = otherId;
                 command.CommandType = CommandType.StoredProcedure;
                 con.Open();

                 SqlDataAdapter da = new SqlDataAdapter();
                 da.SelectCommand = command;
                 da.Fill(ds);
                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     msg = ds.Tables[0].Rows[0]["MemberID"].ToString();
                 }
                 else
                 {
                     msg = "Error occurred";
                 }

             }

         }
         return msg;


     }
    



}