using System;
using System.Threading.Tasks;
using Assignment3.Controllers;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using DbContext = Assignment3.DbContext;

namespace Assignment3UnitTests
{
    public class Tests
    {

        DbContextOptions<DbContext> _contextOptions;
        ILoggerFactory _loggerFactory;

        [SetUp]
        public void Setup()
        {
            // Create a test db
            // added connction string for local database 
            string testDB = "Server=(localdb)\\mssqllocaldb;Database=EFAssignment2;Trusted_Connection=True;";
            this._contextOptions = new DbContextOptionsBuilder<DbContext>()
                .UseSqlServer(testDB)
                .EnableSensitiveDataLogging().Options;
            this._loggerFactory = new LoggerFactory();
        }
        /// <summary>
        /// Test Method to test creation of an Immunization record
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreateImmunization()
        {
            Immunization post = new Immunization()
            {
                Id = Guid.NewGuid(),
                OfficialName = "Covid Vaccine",
                TradeName = "CVPlus",
                LotNumber = "A1B",
                ExpirationDate = new DateTime(2022, 06, 05),
            };

            //Test Create a Immunization
            using (var context = new DbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                ILogger<ImmunizationsController> logger = this._loggerFactory.CreateLogger<ImmunizationsController>();
                var controller = new ImmunizationsController(context, logger);

                //Create Immunization
                await controller.PostImmunization(post);

                //Compare created
                Assert.AreEqual(
                    controller.GetImmunization(post.Id).Result.Value,
                    post
                );
            }
        }

        /// <summary>
        /// Test method to Create a Patient record
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreatePatient()
        {
            Patient post = new Patient()
            {
                Id = Guid.NewGuid(),
                FirstName = "Damanpreet",
                LastName = "Singh Sandhu",
                CreationTime = new DateTime(2022, 03, 09),
            };

            //Test Create a Patient
            using (var context = new DbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                ILogger<PatientController> logger = this._loggerFactory.CreateLogger<PatientController>();
                var controller = new PatientController(context, logger);

                //Create Immunization
                await controller.PostPatient(post);

                //Compare created
                Assert.AreEqual(
                    controller.GetPatient(post.Id).Result.Value,
                    post
                );
            }
        }

        /// <summary>
        /// Test method to Create an Organization record
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreateOrganization()
        {
            Organization post = new Organization()
            {
                Id = Guid.NewGuid(),
                Name = "MyOrganization",
                Type = "Pharmacy",
                Address = "Main St",
                CreationTime = new DateTime(2022, 03, 12),
            };

            //Test Create an Organization
            using (var context = new DbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                ILogger<OrganizationController> logger = this._loggerFactory.CreateLogger<OrganizationController>();
                var controller = new OrganizationController(context, logger);

                //Create Organization
                await controller.PostOrganization(post);

                //Compare created
                Assert.AreEqual(
                    controller.GetOrganization(post.Id).Result.Value,
                    post
                );
            }
        }
        /// <summary>
        /// Test method to Create an Provider record.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task CreateProvider()
        {
            //create Provider
            Provider provider = new Provider()
            {
                Id = Guid.NewGuid(),
                FirstName = "Medicare",
                LastName = "Advantage Plus",
                LicenseNumber = 13,
                Address = "547 Medical Rd",
                CreationTime = DateTimeOffset.Now,
            };

            //Test Create a Provider
            using (var context = new DbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                ILogger<ProvidersController> logger = this._loggerFactory.CreateLogger<ProvidersController>();
                var controller = new ProvidersController(context, logger);

                //Create Organization
                await controller.PostProvider(provider);

                //Compare created
                Assert.AreEqual(
                    controller.GetProvider(provider.Id).Result.Value,
                    provider
                );
            }
        }

    }
}