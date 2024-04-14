using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EhrlichPOS_BE.Migrations
{
    /// <inheritdoc />
    public partial class Add_migrations_create_SP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE InsertPizzaOrderDetails
	                -- Add the parameters for the stored procedure here
	                @JsonData NVARCHAR(MAX)
                AS
                BEGIN
	                -- SET NOCOUNT ON added to prevent extra result sets from
	                -- interfering with SELECT statements.
	                SET NOCOUNT ON;

                    -- Insert statements for procedure here
	                INSERT INTO ORDER_DETAILS (order_id, pizza_id, quantity)
	                SELECT order_id, pizzaId, quantity
                    FROM OPENJSON(@JsonData)
                    WITH (
                        order_id INT '$.Order_Id',
                        pizzaId NVARCHAR(50) '$.PizzaId',
                        quantity INT '$.Quantity'
                    );
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS InsertPizzaOrderDetails;");
        }
    }
}
