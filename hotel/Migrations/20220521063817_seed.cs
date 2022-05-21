using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "metodoPago",
                columns: new[] { "idMetodoPago", "nombre" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de débito" },
                    { 3, "Tarjeta de crédito" }
                });

            migrationBuilder.InsertData(
                table: "tipoHabitacion",
                columns: new[] { "idTipoHabitacion", "costo", "costoExPersona", "descripcion", "nombre", "rutaImg" },
                values: new object[,]
                {
                    { 1, 1500.0, 300.0, "Esta habitación cuenta con una cama matrimonial y con excelente vista.", "Sencilla", "/img/sencilla.png" },
                    { 2, 1800.0, 400.0, "Esta habitación cuenta con dos camas matrimoniales.", "Doble", "/img/doble.png" },
                    { 3, 2000.0, 500.0, "Esta habitación cuenta dos camas matrimoniales y con excelente vista.", "Suit", "/img/suit.png" },
                    { 4, 2500.0, 600.0, "Esta habitación cuenta con una cama queen, jacuzzi y con excelente vista.", "Deluxe", "/img/deluxe.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "metodoPago",
                keyColumn: "idMetodoPago",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "metodoPago",
                keyColumn: "idMetodoPago",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "metodoPago",
                keyColumn: "idMetodoPago",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tipoHabitacion",
                keyColumn: "idTipoHabitacion",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tipoHabitacion",
                keyColumn: "idTipoHabitacion",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tipoHabitacion",
                keyColumn: "idTipoHabitacion",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tipoHabitacion",
                keyColumn: "idTipoHabitacion",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "rutaImg",
                table: "tipoHabitacion",
                type: "varchar(max)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idHabitacion",
                table: "habitaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
