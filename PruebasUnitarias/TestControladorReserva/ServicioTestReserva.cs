using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControladorReserva
{
    public class ServicioTestReserva
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaReservaContextMock();
        }


        [Test]
        public void testReturnListaReservasCaso01()
        {

            var reservaRepository = new ReservaService(mockContex.Object);
            var reserva = reservaRepository.getLista();

            Assert.IsNotNull(reserva);
        }

        [Test]
        public void testReturnListaBusquedaCriterioCaso02()
        {

            var reservaRepository = new ReservaService(mockContex.Object);

            var reservas = reservaRepository.getLista("Juan");

            Assert.IsNotNull(reservas);
        }

        [Test]
        public void testReturnReservasCaso03()
        {

            var reservaRepository = new ReservaService(mockContex.Object);
            Reserva reserva = (Reserva) reservaRepository.getReserva(2);

            Assert.AreEqual("Jose Perez Soza", reserva.NombreCliente);
        }

    }
}
