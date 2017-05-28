﻿using CoinbaseExchange.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseExchange.NET.Endpoints.PersonalOrders
{
	public class PersonalOrdersClient : ExchangeClientBase
	{
		public PersonalOrdersClient(CBAuthenticationContainer authenticationContainer) 
			: base(authenticationContainer)
        {

		}

		Int16 pageNumber = 0;

		public async Task<GetPersonalOrdersResponse> GetPersonalOrders(string[] Status = null, Int16 cursor = 0)
		{
			this.pageNumber = cursor;
			var request = new GetPersonalOrdersRequest(Status: Status, cursor: cursor);
			var response = await this.GetResponse(request);
			return new GetPersonalOrdersResponse(response);
		}

		public async Task<GetPersonalOrdersResponse> GetPersonalOrdersPageBefore(string[] Status = null)
		{
			return await GetPersonalOrders(Status, (Int16)(pageNumber-1));
		}

		public async Task<GetPersonalOrdersResponse> GetPersonalOrdersPageAfter(string[] Status = null)
		{
			return await GetPersonalOrders(Status, (Int16)(pageNumber+1));
		}

		public async Task<SubmitPersonalOrderResponse> SubmitPersonalOrder(PersonalOrderParams orderParams)
		{
			var request = new SubmitPersonalOrderRequest(orderParams);
			var response = await this.GetResponse(request);
			return new SubmitPersonalOrderResponse(response);
		}

		public async Task<CancelPersonalOrderResponse> CancelPersonalOrder(Guid orderID)
		{
			var request = new CancelPersonalOrderRequest(orderID);
			var response = await this.GetResponse(request);
			return new CancelPersonalOrderResponse(response);
		}

		public async Task<CancelAllPersonalOrdersResponse> CancelAllPersonalOrders(string product_id = null)
		{
			var request = new CancelAllPersonalOrdersRequest(product_id);
			var response = await this.GetResponse(request);
			return new CancelAllPersonalOrdersResponse(response);
		}
	}
}
