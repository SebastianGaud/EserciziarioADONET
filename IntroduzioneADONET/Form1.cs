using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IntroduzioneADONET
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand comm;

        //string connstr = "database=ADONETTutorial;server=GPHP\\SQLEXPR2014;user=sa;password=sapwd";

        string connstr = "DESKTOP-URUIL6H\\SQLEXPRESS;Initial Catalog=AdoTutorial;Integrated Security=True";

        private void button4_Click ( object sender , EventArgs e )
        {
            conn = new SqlConnection( connstr );
            comm = new SqlCommand();
            conn.Open();
            // creating instance of SsqlParameter
            SqlParameter rollno = new SqlParameter( "@rn" , SqlDbType.Int );
            SqlParameter name = new SqlParameter( "@n" , SqlDbType.VarChar );
            SqlParameter course = new SqlParameter( "@c" , SqlDbType.VarChar );
            SqlParameter city = new SqlParameter( "@ci" , SqlDbType.VarChar );
            // Adding parameter to SqlCommand
            comm.Parameters.Add( rollno );
            comm.Parameters.Add( name );
            comm.Parameters.Add( course );
            comm.Parameters.Add( city );
            // Setting values 
            rollno.Value = Convert.ToInt32( button4.Text );
            name.Value = button3.Text;
            course.Value = button2.Text;
            city.Value = button1.Text;
            // adding connection to SqlCommand
            comm.Connection = conn;
            // Sql Statement
            comm.CommandText = "insert into studenti values(@rn,@n,@c,@ci)";

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show( "Saved" );
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch ( Exception )
            {
                MessageBox.Show( "Not Saved" );
            }
            finally
            {
                conn.Close();
            }
        }

    }
}

