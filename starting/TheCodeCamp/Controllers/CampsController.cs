﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repository; // field that holds repository data
        private readonly IMapper _mapper;
        public CampsController(ICampRepository repository, IMapper mapper) // constructor instantiates a field from ICampRepo
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllCampsAsync();

                // Mapping
                var mappedResult = _mapper.Map<IEnumerable<CampModel>>(result);
                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                //TODO add logging
                return InternalServerError(ex);
            }
        }
    }
}
