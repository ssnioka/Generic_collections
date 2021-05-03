using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABORAS3.Classes
{
    public class Calcs
    {
        /// <summary>
        /// method to find out how much did the resident pay
        /// </summary>
        /// <param name="resident"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static double HowMuchPaid(Resident resident, LinkList<Service> servicelist)
        {

            for (servicelist.Beginning(); servicelist.Exist(); servicelist.Next())
            {
                if (resident.ServiceId == servicelist.GetData().ID)
                {
                    return resident.Amount * servicelist.GetData().Price;

                }
            }
            
            return 0;
        }
        /// <summary>
        /// method to find the total sum of paid cash by the residents
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static double TotalAmountPaid(LinkList<Resident> residentlist, LinkList<Service> servicelist)
        {
            double amount = 0;
            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                amount += HowMuchPaid(residentlist.GetData(), servicelist);
            }
            return amount;

        }

        /// <summary>
        /// method to find the average price of the service paid by the residents
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static double AveragePrice(LinkList<Resident> residentlist, LinkList<Service> servicelist)
        {
            double average = 0;
            double sum = Calcs.TotalAmountPaid(residentlist, servicelist);
            average = sum / residentlist.getCount();
            
            return average;
            
        }
    }
}