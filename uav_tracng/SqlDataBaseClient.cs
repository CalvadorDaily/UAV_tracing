using System.Data;
using System.Data.SqlClient;

namespace uav_tracng
{
    class SqlDataBaseClient
    {
        public const string SQLDataBaseConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Trac.mdf;Integrated Security=True;Connect Timeout=30";
        static SqlConnection con = new SqlConnection(SQLDataBaseConnString);
        public static DataSet SQLCommandSelectAllFrom(string TableName)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT * FROM " + TableName;
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCommand, con);
            adapter.Fill(dataSet);
            con.Close();
            return dataSet;
        }
        public static DataSet SQLCommandSelectAllFromColumn(string TableName, string ColumnName)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT "+ ColumnName + " FROM " + TableName;
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCommand, con);
            adapter.Fill(dataSet);
            con.Close();
            return dataSet;
        }
        public static DataSet SQLCustomCommandSelectAllFrom(string TableName, string request)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT * FROM " + TableName + " WHERE " + request;
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCommand, con);
            adapter.Fill(dataSet);
            con.Close();
            return dataSet;
        }
        public static int SQLCustomCommandSelectMAXFrom(string TableName, string columnName)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT MAX (" + columnName + ") FROM " + TableName;
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCommand, con);
            adapter.Fill(dataSet);
            con.Close();
            if (int.TryParse(dataSet.Tables[0].Rows[0][0].ToString(), out int result))
                { return int.Parse(dataSet.Tables[0].Rows[0][0].ToString()); }
            return 0;
        }
            public static int SQLCustomCommandSelectOneFromInt(string TableName, string request)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            string SqlCommand = "SELECT count (*) FROM " + TableName + " WHERE " + request;
            SqlDataAdapter adapter = new SqlDataAdapter(SqlCommand, con);
            adapter.Fill(dataSet);
            con.Close();
            return int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
        }
        public static void SQLCommandCreateCon(string request)
        {
            con.Open();
            string SqlCommand = "INSERT INTO DeviceConnectionSettings (connectionid, projectid,FirstDeviceSerialNumber,secondDeviceSerialNumber) " +
                "values (" + request + ")";
            SqlCommand command = new SqlCommand(SqlCommand, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void SQLCommandCreateChan(string request, double length)
        {
            con.Open();
            string SqlCommand = "INSERT INTO ChannelConnectionParameters (channelid, projectid,FirstDeviceSerialNumber,secondDeviceSerialNumber,ChannelLength)"
                + "values (" + request +" @Username)";
            SqlCommand command = new SqlCommand(SqlCommand, con);
            command.Parameters.AddWithValue("@Username", length);
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void SQLCommandCreateEMC(string request)
        {
            con.Open();
            string SqlCommand = "INSERT INTO EMCParameters (projectid,FirstConnectionNumber," +
                "secondConnectionNumber) values (" + request + ")";
            SqlCommand command = new SqlCommand(SqlCommand, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void SQLCommandCreateTrack(string request)
        {
            con.Open();
            string SqlCommand = "INSERT INTO TrackOptions (projectid,connectionid," +
                "channelid) values (" + request + ")";
            SqlCommand command = new SqlCommand(SqlCommand, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void SQLCommandCreateProject(string request1,  double EMC, string request2)
        {
            con.Open();
            string SqlCommand = "INSERT INTO Project (projectid, projectname, countDevices, EMC, chanellsVolume) values (" + request1 + ", @Username,"+request2+")";
            SqlCommand command = new SqlCommand(SqlCommand, con);
            command.Parameters.AddWithValue("@Username",EMC);
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void SQLCommandDeleteProject(string value)
        {
            con.Open();
            string SqlCommand = "delete project where projectid = " + value +
            "; delete ChannelConnectionParameters where projectid = " + value +
            "; delete DeviceConnectionSettings where projectid = " + value +
            "; delete EMCParameters where projectid = " + value +
            "; delete TrackOptions where projectid = " + value;
            SqlCommand command = new SqlCommand(SqlCommand, con);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}