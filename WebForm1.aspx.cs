using System;
using System.IO;
using System.Linq;
using LABORAS3.Classes;
using System.Web.UI.WebControls;

namespace LABORAS3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LinkList<Service> services = new LinkList<Service>();
        LinkList<Resident> residents = new LinkList<Resident>();
        LinkList<Resident> residentsaverage = new LinkList<Resident>();
        LinkList<Resident> notpaidservices = new LinkList<Resident>();
        LinkList<Resident> removedlist = new LinkList<Resident>();


        protected void Page_Load(object sender, EventArgs e) { }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath(@"App_Data/Rezultatai.txt"));
            if (FileUpload1.HasFile && FileUpload2.HasFile && FileUpload1.FileName.EndsWith(".txt") && FileUpload2.FileName.EndsWith(".txt"))
            {
                hidden.Style["visibility"] = "visible";
                Session["Residents"] = InOutUtils.ReadResidents(FileUpload1.FileContent);
                Session["Services"] = InOutUtils.ReadServices(FileUpload2.FileContent);

                residents = (LinkList<Resident>)Session["Residents"];
                services = (LinkList<Service>)Session["Services"];

                InOutUtils.ServiceTable(Table1);
                InOutUtils.ResidentTable(Table2);

                InOutUtils.InsertServices(Table1, services);
                InOutUtils.InsertResidents(Table2, residents);

                InOutUtils.PrintToFile<Service>("/Rezultatai.txt", "Initial Services data:", services);
                InOutUtils.PrintToFile<Resident>("/Rezultatai.txt", "Initial Residents data:", residents);


                Resident cheapestmonth = TaskUtils.LeastPaid(residents, services);
                double amount = Calcs.TotalAmountPaid(residents, services);
                Label2.Text = "Pigiausias mėnesis - " + cheapestmonth.Month;
                Label4.Text = "Pigiausi mokesčiai buvo - " + cheapestmonth.Service;
                Label3.Text = "Visų gyventojų išleisti pinigai - " + amount.ToString();
                Label1.Text = "Gyventojai, kurie sumokėjo mažesnę sumą mokesčių už vidurkį";

                residentsaverage = TaskUtils.PaidLessThanAvg(residents, services);

                InOutUtils.TableForLessAvg(Table3);
                InOutUtils.TableInsertLessAvg(Table3, residentsaverage);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            hidden.Style["visibility"] = "visible";

            residents = (LinkList<Resident>)Session["Residents"];
            services = (LinkList<Service>)Session["Services"];


            InOutUtils.ServiceTable(Table1);
            InOutUtils.ResidentTable(Table2);

            InOutUtils.InsertServices(Table1, services);
            InOutUtils.InsertResidents(Table2, residents);

            Label5.Text = "Pašalintas sąrašas";
            string month = TextBox1.Text;
            string serviceid = TextBox2.Text;
            residentsaverage = TaskUtils.PaidLessThanAvg(residents, services);
            notpaidservices = TaskUtils.DidntPay(residentsaverage, services, month, serviceid);
            InOutUtils.TableForLessAvg(Table3);
            removedlist = TaskUtils.ResidentRemoval(residentsaverage, notpaidservices);
            InOutUtils.TableInsertLessAvg(Table3, removedlist);


        }
    
    }
}