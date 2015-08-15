using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FrameWorkExample
{
    public partial class EgPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region Create a record
            Emp rec = new Emp();
            rec.Empno = short.Parse(TxtEmpno.Text);
            rec.Ename = TxtName.Text;
            rec.Job = TxtJob.Text;
            rec.Salary = short.Parse(TxtSalary.Text);
            #endregion

            #region Add employ into db and save changes
            DbCompanyEntities dce = new DbCompanyEntities();
            dce.AddToEmps(rec);
            dce.SaveChanges();
            #endregion
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DbCompanyEntities ce = new DbCompanyEntities();

            short empno = short.Parse( TxtEmpno.Text);
            Emp context = ce.Emps.SingleOrDefault(col => col.Empno == empno);

            TxtName.Text = context.Ename;
            TxtJob.Text = context.Job;
            TxtSalary.Text = context.Salary.ToString();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DbCompanyEntities ce = new DbCompanyEntities();

            short empno = short.Parse(TxtEmpno.Text);
            Emp context = ce.Emps.SingleOrDefault(col => col.Empno == empno);

            context.Ename = TxtName.Text;
            context.Job = TxtJob.Text;
            context.Salary = short.Parse(TxtSalary.Text);
            ce.SaveChanges();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DbCompanyEntities ce = new DbCompanyEntities();

            short empno = short.Parse(TxtEmpno.Text);
            Emp context = ce.Emps.SingleOrDefault(col => col.Empno == empno);
            ce.DeleteObject(context);
            ce.SaveChanges();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DbCompanyEntities ce = new DbCompanyEntities();
            var recs = ce.Emps ;
            GridView1.DataSource = recs;
            GridView1.DataBind();

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            DbCompanyEntities ce = new DbCompanyEntities();
            var recs = from tab in ce.Emps where tab.Job == TxtJob.Text select tab;
            GridView1.DataSource = recs;
            GridView1.DataBind();
        }
    }
}