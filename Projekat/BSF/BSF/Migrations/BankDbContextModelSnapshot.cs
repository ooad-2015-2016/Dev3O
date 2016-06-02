using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BSF.DAL;

namespace BSF.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("BSF.DAL.BankAccount", b =>
                {
                    b.Property<int>("BankAccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<int?>("OwnerAccoutnId")
                        .IsRequired();

                    b.HasKey("BankAccountID");
                });

            modelBuilder.Entity("BSF.DAL.MobileVerification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Code");

                    b.Property<DateTime>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("VerifyingAccoutnId")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("BSF.DAL.Person", b =>
                {
                    b.Property<int>("AccoutnId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("JMBG")
                        .IsRequired();

                    b.Property<int>("MyProperty");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NameOfFather");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("PostalNumber");

                    b.Property<string>("SurName")
                        .IsRequired();

                    b.Property<string>("TelephoneNumber")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.Property<bool>("Validated");

                    b.HasKey("AccoutnId");
                });

            modelBuilder.Entity("BSF.DAL.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int?>("FromAccountBankAccountID");

                    b.Property<int?>("ReferentAccoutnId");

                    b.Property<DateTime>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("ToAccountBankAccountID");

                    b.HasKey("TransactionID");
                });

            modelBuilder.Entity("BSF.DAL.BankAccount", b =>
                {
                    b.HasOne("BSF.DAL.Person")
                        .WithMany()
                        .HasForeignKey("OwnerAccoutnId");
                });

            modelBuilder.Entity("BSF.DAL.MobileVerification", b =>
                {
                    b.HasOne("BSF.DAL.Person")
                        .WithMany()
                        .HasForeignKey("VerifyingAccoutnId");
                });

            modelBuilder.Entity("BSF.DAL.Transaction", b =>
                {
                    b.HasOne("BSF.DAL.BankAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountBankAccountID");

                    b.HasOne("BSF.DAL.Person")
                        .WithMany()
                        .HasForeignKey("ReferentAccoutnId");

                    b.HasOne("BSF.DAL.BankAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountBankAccountID");
                });
        }
    }
}
