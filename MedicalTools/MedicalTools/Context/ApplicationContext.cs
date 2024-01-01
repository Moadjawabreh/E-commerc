using MedicalTools.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MedicalTools.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Category> categories { get; set; }
        public List<Category> GetCategories()
        {
            return categories.ToList();
        }
        public DbSet<Product> products { get; set; }

        public DbSet<FeedbackForProduct> feedbackForProducts { get; set; }

        public DbSet<FeedbackForWeb> feedbackForWebs { get; set; }

        public DbSet<Payment> payments { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Order> orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.FeedbackForProducts)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.userID)
                    .IsRequired();

                entity.HasMany(u => u.FeedbackForWebs)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.userID)
                    .IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {

                entity.HasMany(u => u.FeedbackForProducts)
                    .WithOne(f => f.Product)
                    .HasForeignKey(f => f.productID)
                    .IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(u => u.Products)
                    .WithOne(f => f.Category)
                    .HasForeignKey(f => f.categoryID)
                    .IsRequired();
            });

            modelBuilder.Entity<User>()
                .HasMany(u => u.carts)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Product>()
                .HasMany(c => c.carts)
                .WithOne(p => p.product)
                .HasForeignKey(p => p.productId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(c => c.orders)
                .WithOne(p => p.user)
                .HasForeignKey(p => p.userId);

            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Electronic", Image = "" },
                new Category { ID = 2, Name = "Diagnostic", Image = "" },
                new Category { ID = 3, Name = "Surgical", Image = "" },
                new Category { ID = 4, Name = "Storage && Transport", Image = "" }

                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Digital Ultrasound Machine Mindray DP-30",
                    Price = 120,
                    Cost = 100,
                    Description = " National Ultrasound is proud to offer a wide range of Mindray products, including the Mindray DP-30 Portable Ultrasound Machine. Designed for ease of use for family practice, orthopedics, and women’s care centers, the DP-30 is a compact, low-cost, black and white ultrasound designed for general imaging studies, OB/GYN, and light MSK work. This powerful system is equipped with advanced imaging technologies to provide you with high-quality images and a convenient workflow, allowing you to scan with confidence and ease. With its lightweight, ergonomic, mobile design, the DP-30 can accompany you wherever required. Designed for high performance and value, this system exceeds every expectation. ",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/d70ccb50-7210-45a8-8fcd-02af2a068c2b7.jpg",
                    categoryID = 1
                },
                new Product
                {
                    ID = 2,
                    Name = "MEK-L3",
                    Price = 200,
                    Cost = 150,
                    Description = "Powerful professional measurement tools allow you to give an accurate and quick diagnosis. The measurement packages of the ultrasound are comprehensively applicable to cardiology OB/GYN, radiology, anesthetics department, etc. The high-level ultrasound diagnosis systems provide excellent solutions for both adults and pediatrics. You can make clinical decisions with greater confidence and expand your practice in new directions.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/b339e910-93d6-4634-9985-2cb82940ad198.jpg",
                    categoryID = 1
                },
                new Product
                {
                    ID = 3,
                    Name = "Medical Equipment Heating Incubator with LCD screen for Laboratory",
                    Price = 400,
                    Cost = 350,
                    Description = "The Medical Equipment Heating Incubator with LCD screen is a sophisticated and essential device designed for laboratory use. This incubator is specifically engineered to provide controlled and optimal conditions for the cultivation and growth of various biological samples, tissues, or cultures that require a controlled environment.",
                    percentageOfDiscount = 0.8,
                    UrlImage = "/Image/136a386c-1425-4fe2-b5f7-635a84deb779WhatsApp Image 2023-12-30 at 23.11.12_c1240c08.jpg",
                    categoryID = 1
                },
                new Product
                {
                    ID = 4,
                    Name = "Infrared Vein Finder MSL-265",
                    Price = 70,
                    Cost = 50,
                    Description = "An infusion pump infuses fluids, medication or nutrients into a patient's circulatory system. It is generally used intravenously, although subcutaneous, arterial, and epidural infusions are occasionally used. We supply many kinds of cheap infusion pumps and even with high quality, MSL syringe pumps are people known for outstanding reliability and performance.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/97a45c33-eced-4b7f-be17-b013e478f955WhatsApp Image 2023-12-30 at 23.11.12_f4bd87d2.jpg",
                    categoryID = 1
                },
                new Product
                {
                    ID = 5,
                    Name = "EC100 Electronic Colposcope",
                    Price = 100,
                    Cost = 60,
                    Description = "The EC100 Electronic Colposcope is the latest product which applies the digital image technique to gynecology check. It adopts the professional hardware equipments of the SONY company in Japan and the system software of our company. Our Electronic Colposcope has some advantages, such as clear and exact imaging, no distortion image color, high magnification, large screen display for identifying hairlike focus easily, also through",
                    percentageOfDiscount = 0.44,
                    UrlImage = "/Image/f0d802de-50a1-48a8-8c2d-f1dd0a43fb5eDigital Ultrasound Machine Mindray DP-30.jpg",
                    categoryID = 1
                },
                new Product
                {
                    ID = 6,
                    Name = "CMS600B3 B-Ultrasound Diagnostic System",
                    Price = 60,
                    Cost = 100,
                    Description = "The CMS600B3 is a compact and lightweight ultrasound system designed for point-of-care diagnostics. It is commonly used in various medical settings, including clinics, hospitals, and mobile healthcare units. The 'B' in B-Ultrasound stands for 'brightness,' indicating that it primarily uses ultrasound technology to produce real-time, high-resolution images of internal body structures.",
                    percentageOfDiscount = 0.8,
                    UrlImage = "/Image/748552bb-80ef-41c0-8381-48a8622857331.jpg",
                    categoryID = 2
                },
                new Product
                {
                    ID = 7,
                    Name = "Medical device control unit VCU",
                    Price = 130,
                    Cost = 80,
                    Description = "Rechargeable battery that allows operation during power outages. Overload protection. Medically approved, in accordance with IEC 60601-1. Easy plug-and-play system that reduces time-to-market.",
                    percentageOfDiscount = 0.7,
                    UrlImage = "/Image/4027fae0-b660-4aed-a61f-183b039c4e032.jpg",
                    categoryID = 2
                },
                new Product
                {
                    ID = 8,
                    Name = "Infrared Vein Finder MSL-265",
                    Price = 180,
                    Cost = 130,
                    Description = "General current limiter, protection against individual faults. Extended service life > 100 000 cycles. Protection against isolated faults. A compact controller for up to 5 actuators. The parameters of the motor outputs can be set.",
                    percentageOfDiscount = 0.9,
                    UrlImage = "/Image/a4c1660d-22c2-4d37-84a9-652f6060adef3.jpg",
                    categoryID = 2
                },
                new Product
                {
                    ID = 9,
                    Name = "Safety tester 62353+",
                    Price = 40,
                    Cost = 24,
                    Description = "Medical needles are slender, pointed devices commonly used in healthcare settings for various purposes such as injections, blood draws, and fluid aspiration. They are typically made of stainless steel or other materials and feature a sharp, beveled tip designed to minimize patient discomfort during penetration.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/92969552-4876-47f5-aa0f-018b4ad4a7424.jpg",
                    categoryID = 2
                },
                new Product
                {
                    ID = 10,
                    Name = "Monitoring ECG cable",
                    Price = 70,
                    Cost = 50,
                    Description = "The Rigel 62353+ is the smallest and most flexible electrical safety analyzer on the market with battery-powered earth/ground bond and insulation testing. It provides an accurate and fast solution for testing in accordance with the IEC 62353 safety standard.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/026d6b89-1a58-4df7-a2d4-a5057e3ea5c15.jpg",
                    categoryID = 2
                },
                new Product
                {
                    ID = 11,
                    Name = "Multi-Parameter Patient Monitor 12.1 Inch Color TFT Portable Medical Equipment MSLMP12",
                    Price = 200,
                    Cost = 170,
                    Description = "Portable design with optional carry bag. Arrhythmia analysis and ST segment analysis. Protection against defibrillator interference. Data export via USB cable with software 12000 groups NIBP list and 2000 groups arrhythmia event. 60-hour ECG waveform and 1000-hour trend data recall. Pitch tone selection and brightness adjustment.",
                    percentageOfDiscount = 0.7,
                    UrlImage = "/Image/5622e88c-3f93-453d-bd24-a83928b506d01.jpg",
                    categoryID = 3
                },
                new Product
                {
                    ID = 12,
                    Name = "ORTHOPROMED KNOTLESS ANCHOR",
                    Price = 200,
                    Cost = 170,
                    Description = "Knotless anchors are commonly used in orthopedic surgeries, particularly in procedures involving the repair of soft tissues like tendons or ligaments. They are designed to secure the soft tissue to bone without the need for traditional knots, simplifying the surgical technique and potentially reducing the risk of complications.",
                    percentageOfDiscount = 0.7,
                    UrlImage = "/Image/108e8876-bd86-46a8-8f69-a4859a6c957d2.jpg",
                    categoryID = 3
                },
                new Product
                {
                    ID = 13,
                    Name = "4D Doppler Obstetric and Abdominal Ultrasound I3",
                    Price = 300,
                    Cost = 260,
                    Description = "Being outstanding in cardiology and radiology, Apogee 5300 Pro serves as a professional assistant to facilitate diagnostic accuracy. It possesses remarkable computing capabilities that enable automatic measurement of essential results within seconds.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/63355122-61ad-4b31-846f-63749b2fc0433.jpg",
                    categoryID = 3
                },
                new Product
                {
                    ID = 14,
                    Name = "ORTHOPROMED FIBER TAPE SUTURE",
                    Price = 250,
                    Cost = 220,
                    Description = "Fiber tape sutures are commonly used in orthopedic surgeries, especially in procedures involving the repair of soft tissues like tendons or ligaments. They provide a strong and durable option for securing soft tissues to bone.",
                    percentageOfDiscount = 0.9,
                    UrlImage = "/Image/abe1bcb5-f73c-417b-ab2c-13f4f7d048cd4.jpg",
                    categoryID = 3
                },
                new Product
                {
                    ID = 15,
                    Name = "Delivery Set",
                    Price = 250,
                    Cost = 220,
                    Description = "A collection of medical instruments and supplies used during the process of childbirth, specifically for a vaginal delivery. The contents of a delivery set may vary, but they generally include essential items needed.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/c0cc51bf-3eed-48ce-afae-659fa756b5495.jpg",
                    categoryID = 3
                },
                new Product
                {
                    ID = 16,
                    Name = "Cabinet with drawer ER series",
                    Price = 70,
                    Cost = 50,
                    Description = "It is designed for use in the operating and intervention rooms. The cabinet is made of AISI 304 quality 18/8 CrNi stainless steel. The upper part has a glass cover and locks. There are two drawers and one lockable cupboard at the bottom. The drawer can be removed from its place to be completely cleaned by the telescopic rail system used in the drawer system. There are 4 feet that adjust the height and level of the cabinet. Different models are designed and manufactured upon customer request.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/9c15891e-e93c-447b-9caa-cb8bbff47dfb1.jpg",
                    categoryID = 4
                },
                new Product
                {
                    ID = 17,
                    Name = "Medical cart G-NB2-00",
                    Price = 120,
                    Cost = 50,
                    Description = "Cart dimensions: 644mm(L) x 638mm(W) x 1650mm(H); Worksurface height: 1125mm; Worksurface dimensions: 527mm(L) x 420mm(W) Arm Standard Load≦10Kg.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/6ecc0271-4f8e-4be4-831a-e7edc84d9f2f2.jpg",
                    categoryID = 4
                },
                new Product
                {
                    ID = 18,
                    Name = "Emergency cart W.CC.10 series",
                    Price = 120,
                    Cost = 50,
                    Description = "Powder-coated trunk. ABS top and bottom slab. 5 pcs telescopic railed, separable drawers. IV Pole and Defibrillator Table on the top side. Detachable waste bin on the side section. Oxygen tube section on the backside. 4 antistatic wheels, 2 with breaks. Design and dimensions are customizable according to users' needs and wishes.",
                    percentageOfDiscount = 1,
                    UrlImage = "/Image/ec75d3d8-145b-44f8-9d2b-3c2519861bfd3.jpg",
                    categoryID = 4
                },
                new Product
                {
                    ID = 19,
                    Name = "Medical cart CE-011",
                    Price = 200,
                    Cost = 150,
                    Description = "Cart dimensions: 644mm(L) x 638mm(W) x 1650mm(H); Worksurface height: 1125mm; Worksurface dimensions: 527mm(L) x 420mm(W) Arm Standard Load≦10Kg.",
                    percentageOfDiscount = 0.8,
                    UrlImage = "/Image/6ee17f4a-5d7f-48d8-ac87-ec55ca8e81304.jpg",
                    categoryID = 4
                },
                new Product
                {
                    ID = 20,
                    Name = "Handle emergency case STH2EC12ABR2",
                    Price = 120,
                    Cost = 100,
                    Description = "Emergency case that is designed to hold and organize medical supplies, equipment, or tools that may be needed in emergency situations. They can vary in size, design, and features depending on the intended use and the preferences of the manufacturer.",
                    percentageOfDiscount = 0.6,
                    UrlImage = "/Image/36ffe217-405d-4355-86b4-c6187571d1345.jpg",
                    categoryID = 4
                }

                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Name = "Mo'men Safi",
                    Email = "Safi.moumen90@gmail.com",
                    Password = "P@ass0rd",
                    phoneNumber = "0796959979",
                    City = "Amman",
                    location = "https://maps.app.goo.gl/vQFefb6uNaEBtRKR8",
                    ImageUrl = "/Image/mo'men.jpg",
                    Role = Role.Admin
                },
                new User
                {
                    ID = 2,
                    Name = "Mo'men Safi",
                    Email = "Safi.moumen90@yahoo.com",
                    Password = "P@ass0rd",
                    phoneNumber = "0796959979",
                    City = "Amman",
                    location = "https://maps.app.goo.gl/vQFefb6uNaEBtRKR8",
                    ImageUrl = "/Image/mo'men.jpg",
                    Role = Role.User
                }
                );

            modelBuilder.Entity<FeedbackForProduct>().HasData(
                new FeedbackForProduct { ID = 1, Text = "Very accurate measurements!", userID = 2, productID = 1 },
                new FeedbackForProduct { ID = 2, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 1 },
                new FeedbackForProduct { ID = 3, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 1 },
                new FeedbackForProduct { ID = 4, Text = "High-quality ultrasound images.", userID = 2, productID = 1 },
                new FeedbackForProduct { ID = 5, Text = "Expandable features are beneficial.", userID = 2, productID = 1 },

                new FeedbackForProduct { ID = 6, Text = "Very accurate measurements!", userID = 2, productID = 2 },
                new FeedbackForProduct { ID = 7, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 2 },
                new FeedbackForProduct { ID = 8, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 2 },
                new FeedbackForProduct { ID = 9, Text = "High-quality ultrasound images.", userID = 2, productID = 2 },
                new FeedbackForProduct { ID = 10, Text = "Expandable features are beneficial.", userID = 2, productID = 2 },

                new FeedbackForProduct { ID = 11, Text = "Very accurate measurements!", userID = 2, productID = 3 },
                new FeedbackForProduct { ID = 12, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 3 },
                new FeedbackForProduct { ID = 13, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 3 },
                new FeedbackForProduct { ID = 14, Text = "High-quality ultrasound images.", userID = 2, productID = 3 },
                new FeedbackForProduct { ID = 15, Text = "Expandable features are beneficial.", userID = 2, productID = 3 },

                new FeedbackForProduct { ID = 16, Text = "Very accurate measurements!", userID = 2, productID = 4 },
                new FeedbackForProduct { ID = 17, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 4 },
                new FeedbackForProduct { ID = 18, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 4 },
                new FeedbackForProduct { ID = 19, Text = "High-quality ultrasound images.", userID = 2, productID = 4 },
                new FeedbackForProduct { ID = 20, Text = "Expandable features are beneficial.", userID = 2, productID = 4 },

                new FeedbackForProduct { ID = 21, Text = "Very accurate measurements!", userID = 2, productID = 5 },
                new FeedbackForProduct { ID = 22, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 5 },
                new FeedbackForProduct { ID = 23, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 5 },
                new FeedbackForProduct { ID = 24, Text = "High-quality ultrasound images.", userID = 2, productID = 5 },
                new FeedbackForProduct { ID = 25, Text = "Expandable features are beneficial.", userID = 2, productID = 5 },

                new FeedbackForProduct { ID = 26, Text = "Very accurate measurements!", userID = 2, productID = 6 },
                new FeedbackForProduct { ID = 27, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 6 },
                new FeedbackForProduct { ID = 28, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 6 },
                new FeedbackForProduct { ID = 29, Text = "High-quality ultrasound images.", userID = 2, productID = 6 },
                new FeedbackForProduct { ID = 30, Text = "Expandable features are beneficial.", userID = 2, productID = 6 },

                new FeedbackForProduct { ID = 31, Text = "Very accurate measurements!", userID = 2, productID = 7 },
                new FeedbackForProduct { ID = 32, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 7 },
                new FeedbackForProduct { ID = 33, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 7 },
                new FeedbackForProduct { ID = 34, Text = "High-quality ultrasound images.", userID = 2, productID = 7 },
                new FeedbackForProduct { ID = 35, Text = "Expandable features are beneficial.", userID = 2, productID = 7 },

                new FeedbackForProduct { ID = 36, Text = "Very accurate measurements!", userID = 2, productID = 8 },
                new FeedbackForProduct { ID = 37, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 8 },
                new FeedbackForProduct { ID = 38, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 8 },
                new FeedbackForProduct { ID = 39, Text = "High-quality ultrasound images.", userID = 2, productID = 8 },
                new FeedbackForProduct { ID = 40, Text = "Expandable features are beneficial.", userID = 2, productID = 8 },

                new FeedbackForProduct { ID = 41, Text = "Very accurate measurements!", userID = 2, productID = 9 },
                new FeedbackForProduct { ID = 42, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 9 },
                new FeedbackForProduct { ID = 43, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 9 },
                new FeedbackForProduct { ID = 44, Text = "High-quality ultrasound images.", userID = 2, productID = 9 },
                new FeedbackForProduct { ID = 45, Text = "Expandable features are beneficial.", userID = 2, productID = 9 },

                new FeedbackForProduct { ID = 46, Text = "Very accurate measurements!", userID = 2, productID = 10 },
                new FeedbackForProduct { ID = 47, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 10 },
                new FeedbackForProduct { ID = 48, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 10 },
                new FeedbackForProduct { ID = 49, Text = "High-quality ultrasound images.", userID = 2, productID = 10 },
                new FeedbackForProduct { ID = 50, Text = "Expandable features are beneficial.", userID = 2, productID = 10 },

                new FeedbackForProduct { ID = 51, Text = "Very accurate measurements!", userID = 2, productID = 11 },
                new FeedbackForProduct { ID = 52, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 11 },
                new FeedbackForProduct { ID = 53, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 11 },
                new FeedbackForProduct { ID = 54, Text = "High-quality ultrasound images.", userID = 2, productID = 11 },
                new FeedbackForProduct { ID = 55, Text = "Expandable features are beneficial.", userID = 2, productID = 11 },

                new FeedbackForProduct { ID = 56, Text = "Very accurate measurements!", userID = 2, productID = 12 },
                new FeedbackForProduct { ID = 57, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 12 },
                new FeedbackForProduct { ID = 58, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 12 },
                new FeedbackForProduct { ID = 59, Text = "High-quality ultrasound images.", userID = 2, productID = 12 },
                new FeedbackForProduct { ID = 60, Text = "Expandable features are beneficial.", userID = 2, productID = 12 },

                new FeedbackForProduct { ID = 61, Text = "Very accurate measurements!", userID = 2, productID = 13 },
                new FeedbackForProduct { ID = 62, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 13 },
                new FeedbackForProduct { ID = 63, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 13 },
                new FeedbackForProduct { ID = 64, Text = "High-quality ultrasound images.", userID = 2, productID = 13 },
                new FeedbackForProduct { ID = 65, Text = "Expandable features are beneficial.", userID = 2, productID = 13 },

                new FeedbackForProduct { ID = 66, Text = "Very accurate measurements!", userID = 2, productID = 14 },
                new FeedbackForProduct { ID = 67, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 14 },
                new FeedbackForProduct { ID = 68, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 14 },
                new FeedbackForProduct { ID = 69, Text = "High-quality ultrasound images.", userID = 2, productID = 14 },
                new FeedbackForProduct { ID = 70, Text = "Expandable features are beneficial.", userID = 2, productID = 14 },

                new FeedbackForProduct { ID = 71, Text = "Very accurate measurements!", userID = 2, productID = 15 },
                new FeedbackForProduct { ID = 72, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 15 },
                new FeedbackForProduct { ID = 73, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 15 },
                new FeedbackForProduct { ID = 74, Text = "High-quality ultrasound images.", userID = 2, productID = 15 },
                new FeedbackForProduct { ID = 75, Text = "Expandable features are beneficial.", userID = 2, productID = 15 },

                new FeedbackForProduct { ID = 76, Text = "Very accurate measurements!", userID = 2, productID = 16 },
                new FeedbackForProduct { ID = 77, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 16 },
                new FeedbackForProduct { ID = 78, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 16 },
                new FeedbackForProduct { ID = 79, Text = "High-quality ultrasound images.", userID = 2, productID = 16 },
                new FeedbackForProduct { ID = 80, Text = "Expandable features are beneficial.", userID = 2, productID = 16 },

                new FeedbackForProduct { ID = 81, Text = "Very accurate measurements!", userID = 2, productID = 17 },
                new FeedbackForProduct { ID = 82, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 17 },
                new FeedbackForProduct { ID = 83, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 17 },
                new FeedbackForProduct { ID = 84, Text = "High-quality ultrasound images.", userID = 2, productID = 17 },
                new FeedbackForProduct { ID = 85, Text = "Expandable features are beneficial.", userID = 2, productID = 17 },

                new FeedbackForProduct { ID = 86, Text = "Very accurate measurements!", userID = 2, productID = 18 },
                new FeedbackForProduct { ID = 87, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 18 },
                new FeedbackForProduct { ID = 88, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 18 },
                new FeedbackForProduct { ID = 89, Text = "High-quality ultrasound images.", userID = 2, productID = 18 },
                new FeedbackForProduct { ID = 90, Text = "Expandable features are beneficial.", userID = 2, productID = 18 },

                new FeedbackForProduct { ID = 91, Text = "Very accurate measurements!", userID = 2, productID = 19 },
                new FeedbackForProduct { ID = 92, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 19 },
                new FeedbackForProduct { ID = 93, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 19 },
                new FeedbackForProduct { ID = 94, Text = "High-quality ultrasound images.", userID = 2, productID = 19 },
                new FeedbackForProduct { ID = 95, Text = "Expandable features are beneficial.", userID = 2, productID = 19 },

                new FeedbackForProduct { ID = 96, Text = "Very accurate measurements!", userID = 2, productID = 20 },
                new FeedbackForProduct { ID = 97, Text = "Excellent for cardiology diagnostics.", userID = 2, productID = 20 },
                new FeedbackForProduct { ID = 98, Text = "Easy to use, great for OB/GYN applications.", userID = 2, productID = 20 },
                new FeedbackForProduct { ID = 99, Text = "High-quality ultrasound images.", userID = 2, productID = 20 },
                new FeedbackForProduct { ID = 100, Text = "Expandable features are beneficial.", userID = 2, productID = 20 }

            );

            modelBuilder.Entity<FeedbackForWeb>().HasData(
                new FeedbackForWeb { ID = 1, Text = "Great service!", Status = true, userID = 2 },
                new FeedbackForWeb { ID = 2, Text = "Had an issue, but resolved quickly.", Status = true, userID = 2 },
                new FeedbackForWeb { ID = 3, Text = "Product was damaged.", Status = true, userID = 2 },
                new FeedbackForWeb { ID = 4, Text = "Fast shipping, good quality.", Status = true, userID = 2 },
                new FeedbackForWeb { ID = 5, Text = "Easy returns process.", Status = true, userID = 2 }

                );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { ID = 1, cardNo = "1234567890123456", Password = "secretpassword1" },
                new Payment { ID = 2, cardNo = "9876543210987654", Password = "secretpassword2" }
);


        }
    }
}
