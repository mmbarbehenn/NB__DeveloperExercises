using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.UI;

public partial class PersonForm : System.Web.UI.Page
{
    public string myString;


    protected void Page_Load(object sender, EventArgs e)
    {
        List<Person> lstAllPeople = new List<Person>();

        PersonSamples.RunSamples(ref lstAllPeople);
        BindPeopleGrid(lstAllPeople);

        SurveySamples.RunSamples();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    public void BindPeopleGrid(List<Person> AllThePeople)
    {
        DataTable dt = ToDataTable(AllThePeople);
        GridView gv = new GridView();


        gv.DataSource = dt;
        gv.DataBind();

        Page.Controls.Add(gv);
    }

    public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }
} 