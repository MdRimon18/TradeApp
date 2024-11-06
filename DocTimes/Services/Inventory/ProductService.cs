﻿using Dapper;
using TradeApp.DbContex;
using TradeApp.Helper;
using System.Data;
using Domain.Entity.Settings;

using System.Data;
using System.Drawing;

namespace TradeApp.Services.Inventory
{
	public class ProductService
	{
		private readonly IDbConnection _db;
													

		public ProductService(DbConnection db)
		{
			_db = db.GetDbConnection();

		}
		public async Task<IEnumerable<Products>> Get(long? ProductId, string? ProductKey, long? BranchId, long? ProdCtgId,
			string? TagWord, string? ProdName, string? ManufacturarName, string? SerialNmbrOrUPC,
			string? Sku, string? BarCode,int? SupplirLinkId, int? ColorId, int? SizeId, int? ShippingById, int? Rating, int? ProdStatusId, int? PageNumber, int? PageSize)
		{
			try
			{
				var parameters = new DynamicParameters();
				parameters.Add("@ProductId", ProductId);
				parameters.Add("@ProductKey", ProductKey);
				parameters.Add("@BranchId", BranchId);
				parameters.Add("@ProdCtgId", ProdCtgId);
				parameters.Add("@TagWord", TagWord);
				parameters.Add("@ProdName", ProdName);
				parameters.Add("@ManufacturarName", ManufacturarName);
				parameters.Add("@SerialNmbrOrUPC", SerialNmbrOrUPC);
				parameters.Add("@Sku", Sku);
				parameters.Add("@BarCode", BarCode);
				parameters.Add("@SupplirLinkId", SupplirLinkId);
				parameters.Add("@ColorId", ColorId);
				parameters.Add("@SizeId", SizeId);
				parameters.Add("@ShippingById", ShippingById);
				parameters.Add("@Rating", Rating);
				parameters.Add("@ProdStatusId", ProdStatusId);
				parameters.Add("@PageNumber", PageNumber);
				parameters.Add("@PageSize", PageSize);

				return await _db.QueryAsync<Products>("Products_GetSp", parameters, commandType: CommandType.StoredProcedure);

			}
			catch (Exception ex)
			{

				return Enumerable.Empty<Products>();
			}
		}

		public async Task<Products> GetById(long ProductId)

		{
			var _products = await (Get(ProductId, null, null, null, null, null,null,null,null,null,null,null,null, null, null, null, 1, 1));
			return _products.FirstOrDefault();
		}

		public async Task<Products> GetByKey(string ProductKey)

		{
			var _products = await (Get(null,
				ProductKey,null, null, null, null, null, null, null, null, null, null, null, null, null, null, 1, 1));
			return _products.FirstOrDefault();
		}


		public async Task<long> SaveOrUpdate(Products _products)
		{
			try
			{
				var parameters = new DynamicParameters();

				parameters.Add("@ProductId", _products.ProductId);
				parameters.Add("@ProductKey", _products.ProductKey);
				parameters.Add("@ProdCtgId", _products.ProdCtgId);
				parameters.Add("@ProdSubCtgId", _products.ProdSubCtgId);
				parameters.Add("@UnitId", _products.UnitId);
				parameters.Add("@FinalPrice", _products.FinalPrice);
				parameters.Add("@PreviousPrice", _products.PreviousPrice);
				parameters.Add("@CurrencyId", _products.CurrencyId);
				parameters.Add("@TagWord", _products.TagWord);
				parameters.Add("@ProdName", _products.ProdName);
				parameters.Add("@ManufacturarName", _products.ManufacturarName);
				parameters.Add("@SerialNmbrOrUPC", _products.SerialNmbrOrUPC);
				parameters.Add("@Sku", _products.Sku);
				parameters.Add("@OpeningQnty", _products.OpeningQnty);
				parameters.Add("@AlertQnty", _products.AlertQnty);
				parameters.Add("@BuyingPrice", _products.BuyingPrice);
				parameters.Add("@SellingPrice", _products.SellingPrice);
				parameters.Add("@VatPercent", _products.VatPercent);
				parameters.Add("@VatAmount", _products.VatAmount);
				parameters.Add("@DiscountPercentg", _products.DiscountPercentg);
				parameters.Add("@DiscountAmount", _products.DiscountAmount);
				parameters.Add("@BarCode", _products.BarCode);
				parameters.Add("@SupplirLinkId", _products.SupplirLinkId);
				parameters.Add("@ImportedForm", _products.ImportedForm);
				parameters.Add("@ImportStatusId", _products.ImportStatusId);
				parameters.Add("@GivenEntryDate", _products.GivenEntryDate);
				parameters.Add("@WarrentYear", _products.WarrentYear);
				parameters.Add("@WarrentyPolicy", _products.WarrentyPolicy);
				parameters.Add("@ColorId", _products.ColorId);
				parameters.Add("@SizeId", _products.SizeId);
				parameters.Add("@ShippingById", _products.ShippingById);
				parameters.Add("@ShippingDays", _products.ShippingDays);
				parameters.Add("@ShippingDetails", _products.ShippingDetails);
				parameters.Add("@OriginCountryId", _products.OriginCountryId);
				parameters.Add("@Rating", _products.Rating);
				parameters.Add("@ProdStatusId", _products.ProdStatusId);
				parameters.Add("@Remarks", _products.Remarks);
				parameters.Add("@ProdDescription", _products.ProdDescription);
				parameters.Add("@ReleaseDate", _products.ReleaseDate);
				parameters.Add("@BranchId", _products.BranchId);
				parameters.Add("@StockQuantity", _products.StockQuantity);
				parameters.Add("@ItemWeight", _products.ItemWeight);
				parameters.Add("@WarehouseId", _products.WarehouseId);
				parameters.Add("@RackNumber", _products.RackNumber);
				parameters.Add("@BatchNumber", _products.BatchNumber);
				parameters.Add("@PolicyId", _products.PolicyId);
                parameters.Add("@ProductCode", _products.ProductCode);
                parameters.Add("@ProductHieght", _products.ProductHieght);
                parameters.Add("@BrandId", _products.BrandId);
                parameters.Add("@EntryDateTime", _products.EntryDateTime);
				parameters.Add("@EntryBy", _products.EntryBy);
				parameters.Add("@LastModifyDate", _products.LastModifyDate);
				parameters.Add("@LastModifyBy", _products.LastModifyBy);
				parameters.Add("@DeletedDate", _products.DeletedDate);
				parameters.Add("@DeletedBy", _products.DeletedBy);
				parameters.Add("@ProdStatus", _products.ProdStatus);
				parameters.Add("@SuccessOrFailId", dbType: DbType.Int32, direction: ParameterDirection.Output);
				await _db.ExecuteAsync("Products_InsertOrUpdate_SP", parameters, commandType: CommandType.StoredProcedure);

				return (long)parameters.Get<int>("@SuccessOrFailId");
			}
			catch (Exception ex)
			{
				// Handle the exception (e.g., log the error)
				Console.WriteLine($"An error occurred while adding order: {ex.Message}");
				return 0;
			}
		}

		public async Task<bool> Delete(long ProductId)
		{
			var _products = await (Get(ProductId, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 1, 1));
			var deleteObj = _products.FirstOrDefault();
			long DeletedSatatus = 0;
			if (deleteObj != null)
			{
				deleteObj.DeletedDate = DateTimeHelper.CurrentDateTime();
				deleteObj.ProdStatus = "Deleted";
				DeletedSatatus = await SaveOrUpdate(deleteObj);
			}

			return DeletedSatatus > 0;
		}
	}
}
