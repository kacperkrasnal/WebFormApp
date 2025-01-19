using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        private void LoadStudents()
        {
            GridViewStudents.DataSource = Student.GetAllStudents();
            GridViewStudents.DataBind();
        }

        protected void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text,
                BirthDate = Convert.ToDateTime(TextBoxBirthDate.Text),
                Class = TextBoxClass.Text
            };
            student.Insert();

            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxBirthDate.Text = "";
            TextBoxClass.Text = "";

            LoadStudents();
        }

        protected void ButtonSearchStudent_Click(object sender, EventArgs e)
        {
            string lastName = TextBoxLastName.Text;
            Student student = Student.SearchByLastName(lastName);

            if (student != null)
            {
                LabelStudentID.Text = "ID Studenta: " + student.StudentID;
                TextBoxFirstName.Text = student.FirstName;
                TextBoxLastName.Text = student.LastName;
                TextBoxClass.Text = student.Class;

                ButtonEditStudent.Visible = true;
                ButtonDeleteStudent.Visible = true;
            }
            else
            {
                LabelStudentID.Text = "Nie znaleziono studenta.";
                ButtonEditStudent.Visible = false;
                ButtonDeleteStudent.Visible = false;
            }
        }

        protected void ButtonEditStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                StudentID = Convert.ToInt32(LabelStudentID.Text.Replace("ID Studenta: ", "")),
                FirstName = TextBoxFirstName.Text,
                LastName = TextBoxLastName.Text,
                Class = TextBoxClass.Text
            };

            student.Update();

            LabelStudentID.Text = "ID Studenta: " + student.StudentID;

            LoadStudents();
        }

        protected void ButtonDeleteStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                StudentID = Convert.ToInt32(LabelStudentID.Text.Replace("ID Studenta: ", ""))
            };

            student.Delete();

            LabelStudentID.Text = "ID Studenta: -";
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxClass.Text = "";

            ButtonEditStudent.Visible = false;
            ButtonDeleteStudent.Visible = false;

            LoadStudents();
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxBirthDate.Text = "";
            TextBoxClass.Text = "";
            LabelStudentID.Text = "ID Studenta";
            ButtonEditStudent.Visible = false;
            ButtonDeleteStudent.Visible = false;
        }
    }
}
