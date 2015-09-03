using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Business.RRHH.Module.PersonManager;
using Transversal.Entities.DTO.DTO;
using Transversal.Entities.DTO.Utils;
using Transversal.Entities.DTO.UXMessages;
using Transversal.Entities.DTO.ValueObjects.Enums;

namespace Web.UX.ASPNetApp
{
    public partial class _Default : Page
    {     
         
        protected void Page_Load(object sender, EventArgs e)
        {
            //AT: Bind only the fisrt time when we load this page, not in every action that page performs
            //a postback
            if (!Page.IsPostBack)
            {
                BindDropDownList(); 
            }
        }


        internal void BindDropDownList()
        {
            BindControls objBinder = new BindControls(); 
            
            //AT: Bind only if control don't have any value currently binded on it.
            var listOfEnums = objBinder.BindBasicOperationsToControl();

            if (listOfEnums.Any())
            {
                //At: add some custom message to the first item. 
                ddl_ListFunctions.Items.Insert(0, new ListItem("Selecciona la operacion", "index", true));

                //AT: We use loop ineasted datasource for this example. 
                for (var counter = 0; counter < listOfEnums.Count; counter++)
                {
                    ddl_ListFunctions.Items.Insert((counter+1), new ListItem(listOfEnums[counter].ToString(), "enum",  true)); 
                }  
            }   
        }


        //AT: Call backend method that returns all Persons (on memory).
        internal void GetAllPersons(List<PersonDto> updatedDataSource)
        {
            if (object.ReferenceEquals(updatedDataSource, null))
            {
                Session["dataSource"] = new PersonManager().GetAllPersons();
            }
            else
            {
                if (updatedDataSource.Any())
                {
                    Session["dataSource"] = updatedDataSource;
                }
            }
            

            //AT: Bind gridview in UX. / View. 
            gv_Persons.DataSource = (List <PersonDto>) Session["dataSource"];
            gv_Persons.DataBind();
            //gv_Persons.UseAccessibleHeader = true;
            gv_Persons.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        //AT: Custom method, use an Update Panel to shows Boostrap Modal popup.
        //public static void ShowCustomJsMessage(string message)
        //{
        //    var cleanMessage = message.Replace("'", "\'");
        //    Page page        = HttpContext.Current.CurrentHandler as Page;
        //    string script    = string.Format("alert('{0}');", cleanMessage);


        //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //    {
        //        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
        //    }
        //}

        internal void DoFunctionFromSelection()
        {
            if (string.Equals(ddl_ListFunctions.SelectedItem.Text, "Selecciona la operacion", StringComparison.InvariantCulture))
            {
                //AT: There is some "better" ways to do that, avoid use this
                //in production, use ajax control toolkit or another way.(label message or native JS 
                //on clientside). 
                new CustomModalBoostrapManager().ShowCustomJsMessage("You must select a function, try agan. ");
            }
            else
            {
                switch (ddl_ListFunctions.SelectedItem.Text)
                {
                    case "ReadAll":
                        GetAllPersons((List<PersonDto>)Session["dataSource"]);
                        break;

                    case "Insert":
                        ShowModalForma(EnumStruct.ModalShowsOption.Modal_Insert); 
                        InsertPerson();
                        
                        break;

                    case "Remove":
                        break;

                    case "Update":
                        break;

                }
            }


        }


        /// <summary>
        /// AT: Insert a new Person in List<PersonDto>
        /// </summary>
        void InsertPerson()
        {
            PersonManager personBusinessObj = default(PersonManager);

            if (CheckIfInputInsertDataIsFine())
            {
                var personToAdd = new PersonDto()
                {
                    Name        = txt_Name.Text,
                    LastName    = txt_LastName.Text,
                    RutNumeric  = int.Parse(txt_RutN.Text),
                    RutDiv      = txt_RutDV.Text
                }; 

                 personBusinessObj = new PersonManager();

                var lstResult = personBusinessObj.InsertNewPerson(personToAdd, (List<PersonDto>)Session["dataSource"]);

                if (!object.ReferenceEquals(lstResult, null) && (lstResult.Any()))
                {   
                    GetAllPersons(lstResult);
                }

            }
        }

        bool CheckIfInputInsertDataIsFine()
        {
            var isAllOk = true;

            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                lbl_Name_Validation.Text = "No se admiten valores vacios.";
                isAllOk = false;
            }
            else
            {
                lbl_Name_Validation.Text = default(string);
                if (string.IsNullOrEmpty(txt_LastName.Text))
                {
                    lbl_LastName_Validation.Text = "El apellido es obligatorio.";
                    isAllOk = false;
                }
                else
                {
                    lbl_LastName_Validation.Text = string.Empty;

                    if (string.IsNullOrEmpty(txt_RutN.Text))
                    {  
                        lbl_RutNum_Validation.Text = "el valor Rut Numérico es obligatorio";
                        isAllOk = default(bool);
                    }
                    else
                    {
                        lbl_RutNum_Validation.Text = default(string);
                        var auxIntValue = default(int);

                        if (!int.TryParse(txt_RutN.Text, out auxIntValue))
                        {
                            lbl_RutNum_Validation.Text = "Se requiere un valor numérico";
                            isAllOk = default(bool);
                        }
                        else
                        {
                            lbl_RutDv_Validation.Text = default(string);
                            if (string.IsNullOrEmpty(txt_RutDV.Text))
                            {
                                lbl_RutDv_Validation.Text = "el valor Rut DV es obligatorio";
                                isAllOk = default(bool);
                            }
                            else
                            {
                                lbl_RutDv_Validation.Text = default(string);
                            }

                        }
                    }
                }

            }

            return isAllOk;
        }



        void ShowModalForma(EnumStruct.ModalShowsOption option)
        {
            switch (option)
            {
                    case EnumStruct.ModalShowsOption.Modal_Insert:
                    lblModalTitle.Text = "Insertar nuevo usuario";   
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalAddNewUser", "$('#modalAddNewUser').modal();", true);
                   //upModal.Update();

                    break;

                    case EnumStruct.ModalShowsOption.Modal_Update:
                    break;
            }
            
        }

        protected void btn_ListarTodos_Click(object sender, EventArgs e)
        {
            GetAllPersons((List<PersonDto>)Session["dataSource"]);
        }

        protected void btn_Apply_Click(object sender, EventArgs e)
        {
            DoFunctionFromSelection(); 

        }
           
        protected void btn_SaveChanges_Click1(object sender, EventArgs e)
        {
            InsertPerson(); 
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalAddNewUser", "$('#modalAddNewUser').modal('hide');", true);
            UpdatePanel1.Update();

        }
    }
}