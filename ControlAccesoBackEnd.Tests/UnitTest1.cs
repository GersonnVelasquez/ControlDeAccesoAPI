using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlAccesoBackEnd.Controllers;
using ControlAccesoBackEnd;
using System.Web.Http;

namespace ControlAccesoBackEnd.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UsuariosController Controlador = new UsuariosController();
            var valuesController = Controlador;
            // if your action returns: NotFound()
            IHttpActionResult actionResult = valuesController.Get();
            var notFoundRes = actionResult as NotFoundResult;
            Assert.IsNotNull(notFoundRes);

        

            // if your action was returning data in the body like: Ok<string>("data: 12")
            actionResult = valuesController.Get();
            var conNegResult = actionResult as OkNegotiatedContentResult<Usuario>;
            Assert.IsNotNull(conNegResult);
            Assert.AreEqual(usuario, conNegResult.Content);

        }
    }
}
