using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryNat.Migrations
{
    public partial class PopularProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                " VALUES(1," +
                "'Pão, hambúrger, ovo, presunto, queijo e batata palha'" +
                ",'Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha'" +
                ",1" +
                ", 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                " VALUES(1,'Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.',1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                " VALUES(1,'Pão, hambúrger, presunto, mussarela e batalha palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha.',1,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Produtos(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsProdutoPreferido,Nome,Preco)" +
                " VALUES(2,'Massa Crocante, queijo branco, peito de peru, Cheddar','Pizza saborosa, super agradavél, vale a pena experimentar',1,'https://pastapizza.com.br/wp-content/uploads/2017/07/Pizza-Pizzaria-Forno-Forza-Express-1536x1007.jpg','https://pastapizza.com.br/wp-content/uploads/2017/07/Pizza-Pizzaria-Forno-Forza-Express-1536x1007.jpg',1,'Pizza Moda Bill', 55.00)");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }

    }


}
