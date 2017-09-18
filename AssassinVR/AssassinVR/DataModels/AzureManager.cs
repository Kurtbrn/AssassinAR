using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssassinVR.DataModels
{
    public class AzureManager
	{

		private static AzureManager instance;
		private MobileServiceClient client;
		private IMobileServiceTable<assassinInformation> scoreTable;

		private AzureManager()
		{
			this.client = new MobileServiceClient("https://assassinvr.azurewebsites.net");
            this.scoreTable = this.client.GetTable<assassinInformation>();
		}

		public MobileServiceClient AzureClient
		{
			get { return client; }
		}

		public static AzureManager AzureManagerInstance
		{
			get
			{
				if (instance == null)
				{
					instance = new AzureManager();
				}

				return instance;
			}
		}

		public async Task<List<assassinInformation>> GetScoreInformation()
		{
			return await this.scoreTable.ToListAsync();
		}
	}
}
