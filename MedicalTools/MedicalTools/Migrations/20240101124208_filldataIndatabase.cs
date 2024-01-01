using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalTools.Migrations
{
    /// <inheritdoc />
    public partial class filldataIndatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "ID", "Password", "cardNo" },
                values: new object[,]
                {
                    { 1, "secretpassword1", "1234567890123456" },
                    { 2, "secretpassword2", "9876543210987654" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "ID", "City", "Email", "ImageUrl", "Name", "Password", "Role", "location", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "Amman", "Safi.moumen90@gmail.com", "/Image/mo'men.png", "Mo'men Safi", "P@ass0rd", 0, "https://maps.app.goo.gl/vQFefb6uNaEBtRKR8", null },
                    { 2, "Amman", "Safi.moumen90@yahoo.com", "/Image/mo'men.png", "Mo'men Safi", "P@ass0rd", 1, "https://maps.app.goo.gl/vQFefb6uNaEBtRKR8", null }
                });

            migrationBuilder.InsertData(
                table: "feedbackForProducts",
                columns: new[] { "ID", "Rating", "Status", "Text", "productID", "userID" },
                values: new object[,]
                {
                    { 1, 0, false, "Very accurate measurements!", 1, 2 },
                    { 2, 0, false, "Excellent for cardiology diagnostics.", 1, 2 },
                    { 3, 0, false, "Easy to use, great for OB/GYN applications.", 1, 2 },
                    { 4, 0, false, "High-quality ultrasound images.", 1, 2 },
                    { 5, 0, false, "Expandable features are beneficial.", 1, 2 },
                    { 6, 0, false, "Very accurate measurements!", 2, 2 },
                    { 7, 0, false, "Excellent for cardiology diagnostics.", 2, 2 },
                    { 8, 0, false, "Easy to use, great for OB/GYN applications.", 2, 2 },
                    { 9, 0, false, "High-quality ultrasound images.", 2, 2 },
                    { 10, 0, false, "Expandable features are beneficial.", 2, 2 },
                    { 11, 0, false, "Very accurate measurements!", 3, 2 },
                    { 12, 0, false, "Excellent for cardiology diagnostics.", 3, 2 },
                    { 13, 0, false, "Easy to use, great for OB/GYN applications.", 3, 2 },
                    { 14, 0, false, "High-quality ultrasound images.", 3, 2 },
                    { 15, 0, false, "Expandable features are beneficial.", 3, 2 },
                    { 16, 0, false, "Very accurate measurements!", 4, 2 },
                    { 17, 0, false, "Excellent for cardiology diagnostics.", 4, 2 },
                    { 18, 0, false, "Easy to use, great for OB/GYN applications.", 4, 2 },
                    { 19, 0, false, "High-quality ultrasound images.", 4, 2 },
                    { 20, 0, false, "Expandable features are beneficial.", 4, 2 },
                    { 21, 0, false, "Very accurate measurements!", 5, 2 },
                    { 22, 0, false, "Excellent for cardiology diagnostics.", 5, 2 },
                    { 23, 0, false, "Easy to use, great for OB/GYN applications.", 5, 2 },
                    { 24, 0, false, "High-quality ultrasound images.", 5, 2 },
                    { 25, 0, false, "Expandable features are beneficial.", 5, 2 },
                    { 26, 0, false, "Very accurate measurements!", 6, 2 },
                    { 27, 0, false, "Excellent for cardiology diagnostics.", 6, 2 },
                    { 28, 0, false, "Easy to use, great for OB/GYN applications.", 6, 2 },
                    { 29, 0, false, "High-quality ultrasound images.", 6, 2 },
                    { 30, 0, false, "Expandable features are beneficial.", 6, 2 },
                    { 31, 0, false, "Very accurate measurements!", 7, 2 },
                    { 32, 0, false, "Excellent for cardiology diagnostics.", 7, 2 },
                    { 33, 0, false, "Easy to use, great for OB/GYN applications.", 7, 2 },
                    { 34, 0, false, "High-quality ultrasound images.", 7, 2 },
                    { 35, 0, false, "Expandable features are beneficial.", 7, 2 },
                    { 36, 0, false, "Very accurate measurements!", 8, 2 },
                    { 37, 0, false, "Excellent for cardiology diagnostics.", 8, 2 },
                    { 38, 0, false, "Easy to use, great for OB/GYN applications.", 8, 2 },
                    { 39, 0, false, "High-quality ultrasound images.", 8, 2 },
                    { 40, 0, false, "Expandable features are beneficial.", 8, 2 },
                    { 41, 0, false, "Very accurate measurements!", 9, 2 },
                    { 42, 0, false, "Excellent for cardiology diagnostics.", 9, 2 },
                    { 43, 0, false, "Easy to use, great for OB/GYN applications.", 9, 2 },
                    { 44, 0, false, "High-quality ultrasound images.", 9, 2 },
                    { 45, 0, false, "Expandable features are beneficial.", 9, 2 },
                    { 46, 0, false, "Very accurate measurements!", 10, 2 },
                    { 47, 0, false, "Excellent for cardiology diagnostics.", 10, 2 },
                    { 48, 0, false, "Easy to use, great for OB/GYN applications.", 10, 2 },
                    { 49, 0, false, "High-quality ultrasound images.", 10, 2 },
                    { 50, 0, false, "Expandable features are beneficial.", 10, 2 },
                    { 51, 0, false, "Very accurate measurements!", 11, 2 },
                    { 52, 0, false, "Excellent for cardiology diagnostics.", 11, 2 },
                    { 53, 0, false, "Easy to use, great for OB/GYN applications.", 11, 2 },
                    { 54, 0, false, "High-quality ultrasound images.", 11, 2 },
                    { 55, 0, false, "Expandable features are beneficial.", 11, 2 },
                    { 56, 0, false, "Very accurate measurements!", 12, 2 },
                    { 57, 0, false, "Excellent for cardiology diagnostics.", 12, 2 },
                    { 58, 0, false, "Easy to use, great for OB/GYN applications.", 12, 2 },
                    { 59, 0, false, "High-quality ultrasound images.", 12, 2 },
                    { 60, 0, false, "Expandable features are beneficial.", 12, 2 },
                    { 61, 0, false, "Very accurate measurements!", 13, 2 },
                    { 62, 0, false, "Excellent for cardiology diagnostics.", 13, 2 },
                    { 63, 0, false, "Easy to use, great for OB/GYN applications.", 13, 2 },
                    { 64, 0, false, "High-quality ultrasound images.", 13, 2 },
                    { 65, 0, false, "Expandable features are beneficial.", 13, 2 },
                    { 66, 0, false, "Very accurate measurements!", 14, 2 },
                    { 67, 0, false, "Excellent for cardiology diagnostics.", 14, 2 },
                    { 68, 0, false, "Easy to use, great for OB/GYN applications.", 14, 2 },
                    { 69, 0, false, "High-quality ultrasound images.", 14, 2 },
                    { 70, 0, false, "Expandable features are beneficial.", 14, 2 },
                    { 71, 0, false, "Very accurate measurements!", 15, 2 },
                    { 72, 0, false, "Excellent for cardiology diagnostics.", 15, 2 },
                    { 73, 0, false, "Easy to use, great for OB/GYN applications.", 15, 2 },
                    { 74, 0, false, "High-quality ultrasound images.", 15, 2 },
                    { 75, 0, false, "Expandable features are beneficial.", 15, 2 },
                    { 76, 0, false, "Very accurate measurements!", 16, 2 },
                    { 77, 0, false, "Excellent for cardiology diagnostics.", 16, 2 },
                    { 78, 0, false, "Easy to use, great for OB/GYN applications.", 16, 2 },
                    { 79, 0, false, "High-quality ultrasound images.", 16, 2 },
                    { 80, 0, false, "Expandable features are beneficial.", 16, 2 },
                    { 81, 0, false, "Very accurate measurements!", 17, 2 },
                    { 82, 0, false, "Excellent for cardiology diagnostics.", 17, 2 },
                    { 83, 0, false, "Easy to use, great for OB/GYN applications.", 17, 2 },
                    { 84, 0, false, "High-quality ultrasound images.", 17, 2 },
                    { 85, 0, false, "Expandable features are beneficial.", 17, 2 },
                    { 86, 0, false, "Very accurate measurements!", 18, 2 },
                    { 87, 0, false, "Excellent for cardiology diagnostics.", 18, 2 },
                    { 88, 0, false, "Easy to use, great for OB/GYN applications.", 18, 2 },
                    { 89, 0, false, "High-quality ultrasound images.", 18, 2 },
                    { 90, 0, false, "Expandable features are beneficial.", 18, 2 },
                    { 91, 0, false, "Very accurate measurements!", 19, 2 },
                    { 92, 0, false, "Excellent for cardiology diagnostics.", 19, 2 },
                    { 93, 0, false, "Easy to use, great for OB/GYN applications.", 19, 2 },
                    { 94, 0, false, "High-quality ultrasound images.", 19, 2 },
                    { 95, 0, false, "Expandable features are beneficial.", 19, 2 },
                    { 96, 0, false, "Very accurate measurements!", 20, 2 },
                    { 97, 0, false, "Excellent for cardiology diagnostics.", 20, 2 },
                    { 98, 0, false, "Easy to use, great for OB/GYN applications.", 20, 2 },
                    { 99, 0, false, "High-quality ultrasound images.", 20, 2 },
                    { 100, 0, false, "Expandable features are beneficial.", 20, 2 }
                });

            migrationBuilder.InsertData(
                table: "feedbackForWebs",
                columns: new[] { "ID", "Status", "Text", "userID" },
                values: new object[,]
                {
                    { 1, true, "Great service!", 2 },
                    { 2, true, "Had an issue, but resolved quickly.", 2 },
                    { 3, true, "Product was damaged.", 2 },
                    { 4, true, "Fast shipping, good quality.", 2 },
                    { 5, true, "Easy returns process.", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "feedbackForProducts",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "payments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "payments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
