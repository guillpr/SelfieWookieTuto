using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfieAWookie.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Fields

        private readonly SelfieContext _context;

        #endregion Fields

        #region Contructors

        public SelfiesController(SelfieContext context)
        {
            _context = context;
        }

        #endregion Contructors

        #region Public methods

        //[HttpGet]
        //public IEnumerable<Selfie> GetAll()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            // Sans LINQ
            var model = _context.Selfies.Include(item => item.Wookie).Select(item => new { Id = item.Id }).ToList();

            // Avec LINQ
            //var query = from selfie in _context.Selfies
            //            join wookie in _context.Wookies on selfie.WookieId equals wookie.Id
            //            select selfie;

            // Retour sans LINQ
            return Ok(model);

            // Retour avec LINQ
            //return Ok(query.ToList());
        }

        #endregion Public methods
    }
}