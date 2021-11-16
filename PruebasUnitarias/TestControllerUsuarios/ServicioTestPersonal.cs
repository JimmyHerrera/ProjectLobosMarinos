using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControladorPersonal
{
    public class ServicioTestPersonal
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaPersonalContextMock();
        }

        [Test]
        public void testReturnListaPersonalCaso01()
        {

            var mesaRepository = new PersonaService(mockContex.Object);
            var mesa = mesaRepository.getLista();

            Assert.IsNotNull(mesa);
        }

        [Test]
        public void testReturnPersonalIdCaso02()
        {

            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(2);

            Assert.AreEqual("Personal 2", personal.Nombres);
        }

    }
}