using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml.Linq;
using System.Activities.Expressions;

public partial class Produits : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ecommerce"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["currentUser"] = "User";
        if (Session["currentUser"] == null)
        {
            Response.Redirect("Connexion.aspx");
        }
        if (!IsPostBack)
        {
            display();
        }
    }
    public void display()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Article", con);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "insert into article values('" + txtnom.Text + "','" + txtdescription.Text + "', '" + txtcategorie.Text + "', '" + txtcouleur.Text + "', '" + txtgenre.Text + "', '" + txttaille.Text + "', '" + txtprix.Text + "')";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
        lblmsg.Text = "Record Inserted Successfully";
        con.Close();
        display();
        cleartxt();
    }

    protected void lnkselect_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        Session["id"] = btn.CommandArgument;
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Article", con);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);

        if (dt.Rows.Count >= 0)
        {
            txtnom.Text = dt.Rows[0]["nom"].ToString();
            txtdescription.Text = dt.Rows[0]["description"].ToString();
            txtcategorie.Text = dt.Rows[0]["categorie"].ToString();
            txtcouleur.Text = dt.Rows[0]["couleur"].ToString();
            txtgenre.Text = dt.Rows[0]["genre"].ToString();
            txttaille.Text = dt.Rows[0]["taille"].ToString();
            txtprix.Text = dt.Rows[0]["prix"].ToString();

        }
        con.Close();
    }

    // fix here
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        con.Open();
        string str = "update Article set nom='" + txtnom.Text + "', description='" + txtdescription.Text + "', categorie='" + txtcategorie.Text + "', couleur='" + txtcouleur.Text + "', genre='" + txtgenre.Text + "', taille='" + txttaille.Text + "', prix='" + txtprix.Text + "' where idart='" + Session["id"] + "'";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
        lblmsg.Text = "Record Updated Successfully";
        con.Close();
        display();
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from tblemp where Article='" + Session["id"] + "'", con);
        cmd.ExecuteNonQuery();
        lblmsg.Text = "Record Deleted";
        con.Close();
        display();
    }

    public void cleartxt()
    {
        txtnom.Text = "";
        txtdescription.Text = "";
        txtcategorie.Text = "";
        txtcouleur.Text = "";
        txtgenre.Text = "";
        txttaille.Text = "";
        txtprix.Text = "";
    }
}