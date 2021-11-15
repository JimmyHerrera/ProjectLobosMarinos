using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControladorMesa
{
    public class ServicioTestMesa
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaContextMock();
        }

        [Test]
        public void testReturnListaMesasCaso01()
        {

            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getLista();     
            
            Assert.IsNotNull(mesa);
        }

        [Test]
        public void testReturnMesaIdCaso02()
        {

            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(2);

            Assert.AreEqual("4",mesa.NumeroMesa);
        }

        [Test]
        public void testReturnListaMesasCreadaCaso03()
        {

            var mesaRepository = new MesaService(mockContex.Object);
            List<Mesa> mesas = (List<Mesa>) mesaRepository.getMesaById();

            Assert.AreEqual(2, mesas.Count);
        }

        [Test]
        public void testReturnListaMesasReservadasCaso04()
        {

            var mesaRepository = new MesaService(mockContex.Object);
            List<Mesa> mesas = (List<Mesa>)mesaRepository.getMesaByState();

            Assert.AreEqual(1, mesas.Count);
        }
    }
}
