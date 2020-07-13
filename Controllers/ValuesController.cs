using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using valueApi.Data;
using valueApi.Models;
//using valueApi.Models;

namespace valueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;
        public ValuesController(DataContext context)
        {
            this.context = context;

        }

        // GET api/values
        [HttpGet("")]
        public ActionResult Get()
        {
            var result = new object();
            try
            {
                List<Value> val = context.Values.Select(
                    v => new Value()
                    {
                        Id = v.Id,
                        Name = v.Name
                    }
                ).ToList();
                if (val != null)
                {
                    result = new
                    {
                        error = false,
                        data = val
                    };
                    return Ok(result);
                }
                else
                {
                    result = new
                    {
                        error = true,
                        message = "Get valuse error"
                    };
                    return Ok(result);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                result = new
                {
                    error = true,
                    message = "Get valuse error"
                };
                return Ok(result);
                // throw;
            }
            // return Ok(val);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            var result = new object();
            try
            {
                Value val = (from u in context.Values
                             where u.Id == id
                             select new Value
                             {
                                 Id = u.Id,
                                 Name = u.Name
                             }).FirstOrDefault();
                if (val != null)
                {
                    result = new
                    {
                        error = false,
                        data = val
                    };
                    return Ok(result);
                }
                else
                {
                    result = new
                    {
                        error = true,
                        message = "No data found!"
                    };
                    return Ok(result);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                result = new
                {
                    error = true,
                    message = "Get valuse error"
                };
                return Ok(result);
                // throw;
            }
        }

        // POST api/values
        [HttpPost("")]
        public ActionResult Post(Value value)
        {
            var result = new object();
            try
            {
                Value val = new Value();
                val.Id = value.Id;
                val.Name = value.Name;
                context.Values.Add(val);
                context.SaveChanges();
                result = new
                {
                    error = false,
                    data = val
                };
                return Ok(result);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                result = new
                {
                    error = true,
                    message = "Get valuse error"
                };
                return Ok(result);
                // throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Value value)
        {
            var result = new object();
            try
            {
                // Value val = (from u in context.Values
                //              where u.Id == id
                //              select new Value
                //              {
                //                  Id = u.Id,
                //                  Name = u.Name
                //              }).FirstOrDefault();
                // Not work!

                Value val = context.Values.Where(x => x.Id == id).FirstOrDefault();

                if (val != null)
                {
                    val.Id = value.Id;
                    val.Name = value.Name;
                    context.SaveChanges();
                    // return value;
                    result = new
                    {
                        error = false,
                        data = val
                    };
                    return Ok(result);
                }
                else
                {
                    result = new
                    {
                        error = true,
                        message = "No data found!"
                    };
                    return Ok(result);
                }

            }
            catch (System.Exception)
            {
                result = new
                {
                    error = true,
                    message = "Put valuse error"
                };
                return Ok(result);
                // throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = new object();
            try
            {
                Value val = (from u in context.Values
                             where u.Id == id
                             select new Value
                             {
                                 Id = u.Id,
                                 Name = u.Name
                             }).FirstOrDefault();
                if (val != null)
                {
                    context.RemoveRange(val);
                    context.SaveChanges();
                    result = new
                    {
                        error = false,
                        data = val
                    };
                    return Ok(result);
                }
                else
                {
                    result = new
                    {
                        error = false,
                        message = "No data found!"
                    };
                    return Ok(result);
                }
            }
            catch (System.Exception)
            {
                result = new
                {
                    error = true,
                    message = "Delete valuse error"
                };
                return Ok(result);
            }
        }
    }
}