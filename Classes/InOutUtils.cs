using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

namespace LABORAS3.Classes
{
    public class InOutUtils
    {

        /// <summary>
        /// Method to read services from data file
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns></returns>
        public static LinkList<Service> ReadServices(Stream path)
        {
            LinkList<Service> servicelist = new LinkList<Service>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                    string[] Values = line.Split(';');
                    string ID = Values[0];
                    string Title = Values[1];
                    double Price = double.Parse(Values[2]);
                    Service service = new Service(ID, Title, Price);
                    servicelist.PutDataT(service);
                }
            }
            return servicelist;
        }

        /// <summary>
        /// method to read residents data from file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns></returns>
        public static LinkList<Resident> ReadResidents(Stream path)
        {
            LinkList<Resident> residentlist = new LinkList<Resident>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                    string[] Values = line.Split(';');
                    string name = Values[0];
                    string surname = Values[1];
                    string address = Values[2];
                    string month = Values[3];
                    string serviceid = Values[4];
                    int amount = int.Parse(Values[5]);
                    Resident resident = new Resident(name, surname, address, month, serviceid, amount);
                    residentlist.PutDataT(resident);
                }
            }
            return residentlist;
        }

        /// <summary>
        /// printing initial data to txt
        /// </summary>
        /// <param name="services">services</param>
        public static void PrintToFile<T>(string pathfile, string header, LinkList<T> list) where T: IComparable<T>, IEquatable<T>, StringFormat
        {
            list.Beginning();
            string file = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            List<string> lines = new List<string>();
            lines.Add(header);
            lines.Add(new string('-', list.GetData().Format().Length));
            lines.Add(list.GetData().Format());
            lines.Add(new string('-', list.GetData().Format().Length));
            foreach (T element in list)
            {
                lines.Add(element.ToString());
            }
            list.Beginning();
            lines.Add(new string('-', list.GetData().Format().Length));
            File.AppendAllLines((file + pathfile), lines);
        }

        /// <summary>
        /// printing initial data to txt file
        /// </summary>
        /// <param name="residents">residents</param>
        public static void PrintResidents(LinkList<Resident> residents)
        {
            string file = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            List<string> lines = new List<string>();
            lines.Add("Initial data \nResidents:");
            residents.Beginning();
            lines.Add(new string('-', residents.GetData().StringFormat().Length));
            lines.Add(residents.GetData().StringFormat());
            lines.Add(new string('-', residents.GetData().StringFormat().Length));
            for (residents.Beginning(); residents.Exist(); residents.Next())
            {
                lines.Add(residents.GetData().ToString());
            }
            residents.Beginning();
            lines.Add(new string('-', residents.GetData().StringFormat().Length));
            File.AppendAllLines((file + "/Rezultatai.txt"), lines);

        }

        /// <summary>
        /// preparing table for the services
        /// </summary>
        /// <param name="table"></param>
        public static void ServiceTable(Table table)
        {
            TableCell servid = new TableCell();
            TableCell servname = new TableCell();
            TableCell servprice = new TableCell();

            servid.Text = "Service ID";
            servname.Text = "Service Name";
            servprice.Text = "Service Price";

            TableRow row = new TableRow();
            row.Cells.Add(servid);
            row.Cells.Add(servname);
            row.Cells.Add(servprice);

            table.Rows.Add(row);
        }

        /// <summary>
        /// preparing table for the residents
        /// </summary>
        /// <param name="table"></param>
        public static void ResidentTable(Table table)
        {
            TableCell residentname = new TableCell();
            TableCell residentsurname = new TableCell();
            TableCell residentaddress = new TableCell();
            TableCell residentmonth = new TableCell();
            TableCell residentID = new TableCell();
            TableCell residentamount = new TableCell();

            residentname.Text = "Resident's name";
            residentsurname.Text = "Resident's surname";
            residentaddress.Text = "Resident's address";
            residentmonth.Text = "Month to pay";
            residentID.Text = "Service ID";
            residentamount.Text = "Service amount";

            TableRow row = new TableRow();

            row.Cells.Add(residentname);
            row.Cells.Add(residentsurname);
            row.Cells.Add(residentaddress);
            row.Cells.Add(residentmonth);
            row.Cells.Add(residentID);
            row.Cells.Add(residentamount);

            table.Rows.Add(row);
        }

        /// <summary>
        /// inserting services to table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="services"></param>
        public static void InsertServices(Table table, LinkList<Service> services)
        {
            for (services.Beginning(); services.Exist(); services.Next())
            {
                Service temp = services.GetData();

                TableCell servid = new TableCell();
                TableCell servname = new TableCell();
                TableCell servprice = new TableCell();

                servid.Text = temp.ID;
                servname.Text = temp.Title;
                servprice.Text = temp.Price.ToString();

                TableRow row = new TableRow();

                row.Cells.Add(servid);
                row.Cells.Add(servname);
                row.Cells.Add(servprice);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// inserting residents
        /// </summary>
        /// <param name="table"></param>
        /// <param name="residents"></param>
        public static void InsertResidents(Table table, LinkList<Resident> residents)
        {
            for (residents.Beginning(); residents.Exist(); residents.Next())
            {
                Resident temp = residents.GetData();

                TableCell residentname = new TableCell();
                TableCell residentsurname = new TableCell();
                TableCell residentaddress = new TableCell();
                TableCell residentmonth = new TableCell();
                TableCell residentID = new TableCell();
                TableCell residentamount = new TableCell();

                residentname.Text = temp.Name;
                residentsurname.Text = temp.Surname;
                residentaddress.Text = temp.Address;
                residentmonth.Text = temp.Month;
                residentID.Text = temp.ServiceId;
                residentamount.Text = temp.Amount.ToString();

                TableRow row = new TableRow();

                row.Cells.Add(residentname);
                row.Cells.Add(residentsurname);
                row.Cells.Add(residentaddress);
                row.Cells.Add(residentmonth);
                row.Cells.Add(residentID);
                row.Cells.Add(residentamount);

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// preparing table for the residents who paid less than avg
        /// </summary>
        /// <param name="table"></param>
        public static void TableForLessAvg(Table table)
        {
            TableCell name = new TableCell();
            TableCell surname = new TableCell();
            TableCell address = new TableCell();

            name.Text = "First name";
            surname.Text = "Last name";
            address.Text = "Address";

            TableRow row = new TableRow();

            row.Cells.Add(name);
            row.Cells.Add(surname);
            row.Cells.Add(address);

            table.Rows.Add(row);
        }
        /// <summary>
        /// table for the residents who paid less than avg
        /// </summary>
        /// <param name="table"></param>
        /// <param name="residents">residents</param>
        public static void TableInsertLessAvg(Table table, LinkList<Resident> residents)
        {
            for (residents.Beginning(); residents.Exist(); residents.Next())
            {
                Resident temp = residents.GetData();

                TableCell name = new TableCell();
                TableCell surname = new TableCell();
                TableCell address = new TableCell();

                name.Text = temp.Name;
                surname.Text = temp.Surname;
                address.Text = temp.Address;

                TableRow row = new TableRow();

                row.Cells.Add(name);
                row.Cells.Add(surname);
                row.Cells.Add(address);

                table.Rows.Add(row);
                
                  
            }
        }
    }
}