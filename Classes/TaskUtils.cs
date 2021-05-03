using System;
using System.Collections.Generic;
using System.Linq;


namespace LABORAS3.Classes
{
    public class TaskUtils
    {
        
        // 
        /// <summary>
        /// to find out which resident paid the least amount 
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static Resident LeastPaid(LinkList<Resident> residentlist, LinkList<Service> servicelist)
        {
            residentlist.Beginning();
            Resident temp = residentlist.GetData();
            Resident resident = new Resident();
            Resident residents = new Resident();
            double temp1 = Calcs.HowMuchPaid(temp, servicelist);
            double temp2 = 0;
            if (residentlist.getCount() == 1)
            {
                residents = new Resident(residentlist.GetData().Name, residentlist.GetData().Surname, servicelist.GetData().Title, residentlist.GetData().Month);
                return residents;
            }

            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                 temp2 = Calcs.HowMuchPaid(residentlist.GetData(), servicelist);
                 if(temp2 < temp1)
                 {
                    resident = new Resident(residentlist.GetData().Name, residentlist.GetData().Surname, servicelist.GetData().Title, residentlist.GetData().Month);                 
                    temp1 = temp2;
                 }                                    
            }         
            return resident;
        }


        /// <summary>
        /// to find the list of the residents who paid less than average for the services
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static LinkList<Resident> PaidLessThanAvg(LinkList<Resident> residentlist, LinkList<Service> servicelist)
        {
            LinkList<Resident> residentaverage = new LinkList<Resident>();

            residentlist.Beginning();
            double avg = Calcs.AveragePrice(residentlist, servicelist);
            residentlist.Beginning();
            
            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                
                if (Calcs.HowMuchPaid(residentlist.GetData(), servicelist) < avg)
                {
                    
                    residentaverage.PutDataT(residentlist.GetData());
                }
            }
            return residentaverage;
        }

        
        /// <summary>
        /// to find out which resident didnt pay for the chosen month
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static LinkList<Resident> DidntPay(LinkList<Resident> residentlist, LinkList<Service> servicelist, string month, string serviceid)
        {
            LinkList<Resident> notpaidservices = new LinkList<Resident>();
            for(residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                if(residentlist.GetData().Month != month || residentlist.GetData().ServiceId != serviceid )
                {
                    notpaidservices.PutDataT(residentlist.GetData());
                }
            }
            return notpaidservices;
        }

        /// <summary>
        /// method to remove people, who didnt pay for the month and service
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="notpaidservices"></param>
        /// <returns></returns>
        public static LinkList<Resident> ResidentRemoval(LinkList<Resident> residentlist, LinkList<Resident> notpaidservices)
        {           
            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                for (notpaidservices.Beginning(); notpaidservices.Exist(); notpaidservices.Next())
                {
                    if(residentlist.GetData() == notpaidservices.GetData())
                    {
                        residentlist.Remove(residentlist.GetNode());
                    }                  
                }               
            }
            return residentlist;
        }

    }
}