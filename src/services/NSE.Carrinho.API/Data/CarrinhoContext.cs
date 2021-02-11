﻿using Microsoft.EntityFrameworkCore;
using NSE.Carrinho.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Data
{
	public class CarrinhoContext : DbContext
	{
		public CarrinhoContext(DbContextOptions<CarrinhoContext> options)
			: base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			ChangeTracker.AutoDetectChangesEnabled = false;
		}

		DbSet<CarrinhoItem> CarrinhoItens { get; set; }
		DbSet<CarrinhoCliente> CarrinhoClientes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
				e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarrinhoContext).Assembly);

			modelBuilder.Entity<CarrinhoCliente>()
				.HasIndex(c => c.ClienteId)
				.HasName("IDX_CLIENTE");

			modelBuilder.Entity<CarrinhoCliente>()
				.HasMany(c => c.Itens)
				.WithOne(i => i.CarrinhoCliente)
				.HasForeignKey(f => f.CarrinhoId);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


		}
	}
}
