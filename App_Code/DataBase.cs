using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace MeeboDb
{
    /// <summary>
    /// DataBase 的摘要说明
    /// </summary>
    public class DataBase
    {
        public DataBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private SqlConnection con;  //创建连接对象

        private void Open()   // 打开数据库连接
        {
            if (con == null)
            {
                con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            }
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        public void Close()    // 关闭数据库连接
        {
            if (con != null)
                con.Close();
        }

        public void Dispose()  //释放数据库连接资源
        {
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }

        //传入参数并且转换为SqlParameter类型
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }

        // 创建一个SqlDataAdapter对象以此来执行命令文本
        private SqlDataAdapter CreateDataAdaper(string procName, SqlParameter[] prams)
        {
            this.Open();
            SqlDataAdapter dap = new SqlDataAdapter(procName, con);
            dap.SelectCommand.CommandType = CommandType.Text;  //执行类型：命令文本
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }
            //加入返回参数
            dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }


        //获取数据库数据
        public DataSet GetData(string procName, SqlParameter[] prams, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //得到执行成功返回值
            return ds;
        }

        public DataSet GetData(string procName, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //得到执行成功返回值
            return ds;
        }

        public void UpdateData(string procName,DataSet ds, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, null);
            SqlCommandBuilder builder = new SqlCommandBuilder(dap);
            dap.Update(ds, tbName);
        }

        public void UpdateData(string procName, SqlParameter[] prams,DataSet ds, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdaper(procName, prams);
            SqlCommandBuilder builder = new SqlCommandBuilder(dap);
            dap.Update(ds, tbName);
        }
    }
}