using System;
using System.DirectoryServices;

namespace KpProjects.Connector
{
    public class AdConnector
    {
        public static void GetUserData(string domainName, string userName)
        {
            string strrootdse = "LDAP://karjalapulp.local";
            string DomainName = "efremovpv@karjalapulp.local";

            DirectoryEntry objdirentry = new DirectoryEntry(strrootdse);
            DirectorySearcher objsearch = new DirectorySearcher(objdirentry);

            objsearch.Filter = $"(&(objectCategory=person)(|(userAccountControl=512)(userAccountControl=66048))(physicalDeliveryOfficeName=*)(userPrincipalName={DomainName}*))";
            objsearch.PropertiesToLoad.Add("cn"); // Общее имя (ADName ?)
            objsearch.PropertiesToLoad.Add("displayName"); // Отображаемое имя
            objsearch.PropertiesToLoad.Add("givenName"); // Имя
            objsearch.PropertiesToLoad.Add("sn"); // Фамилия
            objsearch.PropertiesToLoad.Add("mail"); // Емаил
            objsearch.PropertiesToLoad.Add("mobile"); // Мобильный
            objsearch.PropertiesToLoad.Add("telephoneNumber"); // Номер телефона       

            objsearch.PropertyNamesOnly = true;

            System.DirectoryServices.SearchResult objresult;

            try
            {
                objresult = objsearch.FindOne();
            }
            catch (Exception e)
            {
            }
        }
    }
}
