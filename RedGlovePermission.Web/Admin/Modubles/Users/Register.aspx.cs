using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RedGlove.Core.Languages;

namespace RedGlovePermission.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionBox.CheckUserSession())
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
            {
                //初始化模块权限
                UserHandle.InitModule("Mod_Register");
                if (!UserHandle.ValidationHandle("RGP_BROWSE"))
                {
                    Response.Redirect("~/Admin/Frameset/NoRight.aspx");
                }
            }
            #region 語言加入
            btn_reg.Text = ResourceManager.GetString("Pub_Btn_submit");
            #endregion
        }

        protected void btn_reg_Click(object sender, EventArgs e)
        {
            if (txt_username.Text.Trim() != "")
            {
                RedGlovePermission.BLL.Users bll = new RedGlovePermission.BLL.Users();
                RedGlovePermission.Model.Users model = new RedGlovePermission.Model.Users();
                model.UserName = txt_username.Text.Trim();
                model.Password = RedGlovePermission.Lib.SecurityEncryption.MD5(txt_password2.Text.Trim(), 32);
                model.Question = txt_question.Text.Trim();
                model.Answer = txt_answer.Text.Trim();
                if (RGP_Value.IsVerifyUser)
                {
                    model.UserGroup = RGP_Value.initGroupID;
                    model.RoleID = RGP_Value.InitRoleID;
                }
                model.IsLimit = false;

                switch (bll.CreateUser(model))
                {
                    case 1:
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_add_true") + "')", true);
                        break;
                    case 2:
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_IsUser") + "')", true);
                        break;
                    default:
                        ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_add_false") + "')", true);
                        break;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(CustomPanel1, this.GetType(), "MsgBox", "alert('" + ResourceManager.GetString("Pub_Msg_V_1") + "')", true);
            }
        }
    }
}
