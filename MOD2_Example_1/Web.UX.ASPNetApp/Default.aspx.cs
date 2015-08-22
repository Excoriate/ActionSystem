using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Business.RRHH.Module.PersonManager;

namespace Web.UX.ASPNetApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gv_GridBasic.DataSource = new PersonManager().GetAllPersons();
            gv_GridBasic.DataBind();
        }
    }
}