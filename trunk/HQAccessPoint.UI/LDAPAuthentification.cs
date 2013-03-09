using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.Text;

namespace HQAccessPoint.UI
{
    public class LDAPAuthentication
    {
        string _path;

	string _filterAttribute;

    public LDAPAuthentication(string path)
	{
		_path = path;
	}

	public bool IsAuthenticated(string domain, string username, string pwd)
	{

		string domainAndUsername = domain + "\\" + username;
		DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);

		try {
			//Bind to the native AdsObject to force authentication.			
			object obj = entry.NativeObject;
			DirectorySearcher search = new DirectorySearcher(entry);

			search.Filter = "(SAMAccountName=" + username + ")";
			search.PropertiesToLoad.Add("cn");
			SearchResult result = search.FindOne();

			if ((result == null)) {
				return false;
			}

			//Update the new path to the user in the directory.
			_path = result.Path;
			_filterAttribute = Convert.ToString(result.Properties["cn"][0]);

		} catch (Exception ex) {
			throw new Exception("Error authenticating user. " + ex.Message);
		}

		return true;
	}

	public string GetGroups()
	{
		DirectorySearcher search = new DirectorySearcher(_path);
		search.Filter = "(cn=" + _filterAttribute + ")";
		search.PropertiesToLoad.Add("memberOf");
		StringBuilder groupNames = new StringBuilder();

		try {
			SearchResult result = search.FindOne();
			int propertyCount = result.Properties["memberOf"].Count;

			string dn = null;
			dynamic equalsIndex = null;
			dynamic commaIndex = null;

			int propertyCounter = 0;

			for (propertyCounter = 0; propertyCounter <= propertyCount - 1; propertyCounter++) {
				dn = Convert.ToString(result.Properties["memberOf"][propertyCounter]);

				equalsIndex = dn.IndexOf("=", 1);
				commaIndex = dn.IndexOf(",", 1);
				if ((equalsIndex == -1)) {
					return null;
				}

				groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
				groupNames.Append("|");
			}

		} catch (Exception ex) {
			throw new Exception("Error obtaining group names. " + ex.Message);
		}

		return groupNames.ToString();
	}
    }
}