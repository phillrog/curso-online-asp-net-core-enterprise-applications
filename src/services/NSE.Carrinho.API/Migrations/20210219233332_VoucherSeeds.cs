using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Carrinho.API.Migrations
{
    public partial class VoucherSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                USE [NerdStoreEnterpriseDB]
                GO
                INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado])  VALUES ( NEWID(), N'150-OFF-GERAL', NULL, 150.00, 50, 1, CAST( GETDATE() AS Date ), NULL, DATEADD(Day,30,GETDATE()), 1, 0 )
                INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado])  VALUES ( NEWID(), N'50-OFF-GERAL', NULL, 50.00, 50, 0, CAST( GETDATE() AS Date ), NULL, DATEADD(Day,30,GETDATE()), 1, 0 )
                INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado])  VALUES ( NEWID(), N'25-OFF-GERAL', 25,NULL, 5, 0, CAST( GETDATE() AS Date ), NULL, DATEADD(Day,30,GETDATE()), 1, 0 )
                INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado])  VALUES ( NEWID(), N'100-OFF-GERAL', NULL, 100.00, 4, 1, CAST( GETDATE() AS Date ), NULL, DATEADD(Day,30,GETDATE()), 1, 0 )
                INSERT [dbo].[Vouchers] ([Id], [Codigo], [Percentual], [ValorDesconto], [Quantidade], [TipoDesconto], [DataCriacao], [DataUtilizacao], [DataValidade], [Ativo], [Utilizado])  VALUES ( NEWID(), N'10-OFF-GERAL', 10, NULL, 15, 1, CAST( GETDATE() AS Date ), NULL, DATEADD(Day,30,GETDATE()), 1, 0 )
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
