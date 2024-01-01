using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalTools.Migrations
{
    /// <inheritdoc />
    public partial class addProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ID", "Cost", "Description", "Name", "Price", "UrlImage", "categoryID", "percentageOfDiscount" },
                values: new object[,]
                {
                    { 1, 100.0, " National Ultrasound is proud to offer a wide range of Mindray products, including the Mindray DP-30 Portable Ultrasound Machine. Designed for ease of use for family practice, orthopedics, and women’s care centers, the DP-30 is a compact, low-cost, black and white ultrasound designed for general imaging studies, OB/GYN, and light MSK work. This powerful system is equipped with advanced imaging technologies to provide you with high-quality images and a convenient workflow, allowing you to scan with confidence and ease. With its lightweight, ergonomic, mobile design, the DP-30 can accompany you wherever required. Designed for high performance and value, this system exceeds every expectation. ", "Digital Ultrasound Machine Mindray DP-30", 120.0, "/Image/d70ccb50-7210-45a8-8fcd-02af2a068c2b7.jpg", 1, 1.0 },
                    { 2, 150.0, "Powerful professional measurement tools allow you to give an accurate and quick diagnosis. The measurement packages of the ultrasound are comprehensively applicable to cardiology OB/GYN, radiology, anesthetics department, etc. The high-level ultrasound diagnosis systems provide excellent solutions for both adults and pediatrics. You can make clinical decisions with greater confidence and expand your practice in new directions.", "MEK-L3", 200.0, "/Image/b339e910-93d6-4634-9985-2cb82940ad198.jpg", 1, 1.0 },
                    { 3, 350.0, "The Medical Equipment Heating Incubator with LCD screen is a sophisticated and essential device designed for laboratory use. This incubator is specifically engineered to provide controlled and optimal conditions for the cultivation and growth of various biological samples, tissues, or cultures that require a controlled environment.", "Medical Equipment Heating Incubator with LCD screen for Laboratory", 400.0, "/Image/136a386c-1425-4fe2-b5f7-635a84deb779WhatsApp Image 2023-12-30 at 23.11.12_c1240c08.jpg", 1, 0.80000000000000004 },
                    { 4, 50.0, "An infusion pump infuses fluids, medication or nutrients into a patient's circulatory system. It is generally used intravenously, although subcutaneous, arterial, and epidural infusions are occasionally used. We supply many kinds of cheap infusion pumps and even with high quality, MSL syringe pumps are people known for outstanding reliability and performance.", "Infrared Vein Finder MSL-265", 70.0, "/Image/97a45c33-eced-4b7f-be17-b013e478f955WhatsApp Image 2023-12-30 at 23.11.12_f4bd87d2.jpg", 1, 1.0 },
                    { 5, 60.0, "The EC100 Electronic Colposcope is the latest product which applies the digital image technique to gynecology check. It adopts the professional hardware equipments of the SONY company in Japan and the system software of our company. Our Electronic Colposcope has some advantages, such as clear and exact imaging, no distortion image color, high magnification, large screen display for identifying hairlike focus easily, also through", "EC100 Electronic Colposcope", 100.0, "/Image/f0d802de-50a1-48a8-8c2d-f1dd0a43fb5eDigital Ultrasound Machine Mindray DP-30.jpg", 1, 0.44 },
                    { 6, 100.0, "The CMS600B3 is a compact and lightweight ultrasound system designed for point-of-care diagnostics. It is commonly used in various medical settings, including clinics, hospitals, and mobile healthcare units. The 'B' in B-Ultrasound stands for 'brightness,' indicating that it primarily uses ultrasound technology to produce real-time, high-resolution images of internal body structures.", "CMS600B3 B-Ultrasound Diagnostic System", 60.0, "/Image/748552bb-80ef-41c0-8381-48a8622857331.jpg", 2, 0.80000000000000004 },
                    { 7, 80.0, "Rechargeable battery that allows operation during power outages. Overload protection. Medically approved, in accordance with IEC 60601-1. Easy plug-and-play system that reduces time-to-market.", "Medical device control unit VCU", 130.0, "/Image/4027fae0-b660-4aed-a61f-183b039c4e032.jpg", 2, 0.69999999999999996 },
                    { 8, 130.0, "General current limiter, protection against individual faults. Extended service life > 100 000 cycles. Protection against isolated faults. A compact controller for up to 5 actuators. The parameters of the motor outputs can be set.", "Infrared Vein Finder MSL-265", 180.0, "/Image/a4c1660d-22c2-4d37-84a9-652f6060adef3.jpg", 2, 0.90000000000000002 },
                    { 9, 24.0, "Medical needles are slender, pointed devices commonly used in healthcare settings for various purposes such as injections, blood draws, and fluid aspiration. They are typically made of stainless steel or other materials and feature a sharp, beveled tip designed to minimize patient discomfort during penetration.", "Safety tester 62353+", 40.0, "/Image/92969552-4876-47f5-aa0f-018b4ad4a7424.jpg", 2, 1.0 },
                    { 10, 50.0, "The Rigel 62353+ is the smallest and most flexible electrical safety analyzer on the market with battery-powered earth/ground bond and insulation testing. It provides an accurate and fast solution for testing in accordance with the IEC 62353 safety standard.", "Monitoring ECG cable", 70.0, "/Image/026d6b89-1a58-4df7-a2d4-a5057e3ea5c15.jpg", 2, 1.0 },
                    { 11, 170.0, "Portable design with optional carry bag. Arrhythmia analysis and ST segment analysis. Protection against defibrillator interference. Data export via USB cable with software 12000 groups NIBP list and 2000 groups arrhythmia event. 60-hour ECG waveform and 1000-hour trend data recall. Pitch tone selection and brightness adjustment.", "Multi-Parameter Patient Monitor 12.1 Inch Color TFT Portable Medical Equipment MSLMP12", 200.0, "/Image/5622e88c-3f93-453d-bd24-a83928b506d01.jpg", 3, 0.69999999999999996 },
                    { 12, 170.0, "Knotless anchors are commonly used in orthopedic surgeries, particularly in procedures involving the repair of soft tissues like tendons or ligaments. They are designed to secure the soft tissue to bone without the need for traditional knots, simplifying the surgical technique and potentially reducing the risk of complications.", "ORTHOPROMED KNOTLESS ANCHOR", 200.0, "/Image/108e8876-bd86-46a8-8f69-a4859a6c957d2.jpg", 3, 0.69999999999999996 },
                    { 13, 260.0, "Being outstanding in cardiology and radiology, Apogee 5300 Pro serves as a professional assistant to facilitate diagnostic accuracy. It possesses remarkable computing capabilities that enable automatic measurement of essential results within seconds.", "4D Doppler Obstetric and Abdominal Ultrasound I3", 300.0, "/Image/63355122-61ad-4b31-846f-63749b2fc0433.jpg", 3, 1.0 },
                    { 14, 220.0, "Fiber tape sutures are commonly used in orthopedic surgeries, especially in procedures involving the repair of soft tissues like tendons or ligaments. They provide a strong and durable option for securing soft tissues to bone.", "ORTHOPROMED FIBER TAPE SUTURE", 250.0, "/Image/abe1bcb5-f73c-417b-ab2c-13f4f7d048cd4.jpg", 3, 0.90000000000000002 },
                    { 15, 220.0, "A collection of medical instruments and supplies used during the process of childbirth, specifically for a vaginal delivery. The contents of a delivery set may vary, but they generally include essential items needed.", "Delivery Set", 250.0, "/Image/c0cc51bf-3eed-48ce-afae-659fa756b5495.jpg", 3, 1.0 },
                    { 16, 50.0, "It is designed for use in the operating and intervention rooms. The cabinet is made of AISI 304 quality 18/8 CrNi stainless steel. The upper part has a glass cover and locks. There are two drawers and one lockable cupboard at the bottom. The drawer can be removed from its place to be completely cleaned by the telescopic rail system used in the drawer system. There are 4 feet that adjust the height and level of the cabinet. Different models are designed and manufactured upon customer request.", "Cabinet with drawer ER series", 70.0, "/Image/9c15891e-e93c-447b-9caa-cb8bbff47dfb1.jpg", 4, 1.0 },
                    { 17, 50.0, "Cart dimensions: 644mm(L) x 638mm(W) x 1650mm(H); Worksurface height: 1125mm; Worksurface dimensions: 527mm(L) x 420mm(W) Arm Standard Load≦10Kg.", "Medical cart G-NB2-00", 120.0, "/Image/6ecc0271-4f8e-4be4-831a-e7edc84d9f2f2.jpg", 4, 1.0 },
                    { 18, 50.0, "Powder-coated trunk. ABS top and bottom slab. 5 pcs telescopic railed, separable drawers. IV Pole and Defibrillator Table on the top side. Detachable waste bin on the side section. Oxygen tube section on the backside. 4 antistatic wheels, 2 with breaks. Design and dimensions are customizable according to users' needs and wishes.", "Emergency cart W.CC.10 series", 120.0, "/Image/ec75d3d8-145b-44f8-9d2b-3c2519861bfd3.jpg", 4, 1.0 },
                    { 19, 150.0, "Cart dimensions: 644mm(L) x 638mm(W) x 1650mm(H); Worksurface height: 1125mm; Worksurface dimensions: 527mm(L) x 420mm(W) Arm Standard Load≦10Kg.", "Medical cart CE-011", 200.0, "/Image/6ee17f4a-5d7f-48d8-ac87-ec55ca8e81304.jpg", 4, 0.80000000000000004 },
                    { 20, 100.0, "Emergency case that is designed to hold and organize medical supplies, equipment, or tools that may be needed in emergency situations. They can vary in size, design, and features depending on the intended use and the preferences of the manufacturer.", "Handle emergency case STH2EC12ABR2", 120.0, "/Image/36ffe217-405d-4355-86b4-c6187571d1345.jpg", 4, 0.59999999999999998 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ID",
                keyValue: 20);
        }
    }
}
