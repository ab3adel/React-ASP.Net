using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React_Asp.Model;
using React_Asp.Data;
using Microsoft.AspNetCore.Cors;
namespace React_Asp.Controllers
{  
      [EnableCors("myPolicy")]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DonatContext _context;
        public HomeController(DonatContext context)
        {
            _context = context;
        }
        [EnableCors("myPolicy")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {

            var quests = await _context.Quest.ToListAsync();
            var users = await _context.User.ToListAsync();
            Object[] lst = {quests, users};
            return Ok(lst);
        }
        [Route("createuser")]
       [HttpPost]
        public async Task<ActionResult<User>> CreateUser ([FromBody] User user)
        {
            
           
            if (user != null)
            {
                var nuser = new User
                {
                    Email = user.Email,
                    Location = user.Location,
                    Userdonation = user.Userdonation,
                    Username = user.Username,
                    Userstatus = user.Userstatus,
                    Phonenumber = user.Phonenumber
                };
                _context.User.Add(nuser);
                await _context.SaveChangesAsync();
                return Created(nameof(nuser), nuser);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("createquest")]
        public async Task<ActionResult<Quest>> CreateQuest([FromForm] Quest quest)
        {
            
            if (quest.Title != null )
            {
                
                
                var nquest = new Quest
                {
                    Title = quest.Title,
                    Content = quest.Content,
                    Limit = quest.Limit,
                    Created = DateTime.Now,
                    Enddate = quest.Enddate,
                    State = quest.State,
                    
                    
                };
               
                _context.Quest.Add(nquest);
                await _context.SaveChangesAsync();
               
                return Created(nameof(nquest), nquest);
            }
            return BadRequest();
        }
        [HttpPut("id")]
        [Route("updateuser")]
        public async Task<ActionResult> UpdateUser (int id ,[FromBody] User user)
        {
                
                if (id  == user.ID)

                {
                if (user != null)
                {
                    Console.WriteLine(user.Location);
                    _context.Entry(user).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok();

                    }
                    catch
                    {
                        return BadRequest();
                    }
                }

              
                }
          
           
            return NotFound();
           
           
        }
      [EnableCors("myPolicy")]
         [HttpGet]
        [Route("updatequest/{id?}")]
        public async Task<ActionResult<Quest>> UpdateQuest (int? id)
        {
      
            if (id != null)
            {
                
                  var quest = await _context.Quest.FindAsync(id);
                   if (quest !=null){ 
                       return Ok(quest);
                   }
                return NotFound();
          
            }
            return BadRequest();
        }
         [EnableCors("myPolicy")]
        [HttpPut]
        [Route("updatequest/{id?}")]
        public async Task<ActionResult> UpdateQuest (int id,[FromForm]Quest quest)
        {
          
          Console.WriteLine(id);
            if (id == quest.QuestID)
            {
                if (quest != null)
                {
                    _context.Entry(quest).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                catch
                    {
                        throw;
                    }
                }
          
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("deleteuser/{id?}")]
        public async Task <ActionResult> DeleteUser (int? id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.Entry(user).State = EntityState.Deleted;
                try
                {
                  await  _context.SaveChangesAsync();
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return NotFound(); 
        }
        [HttpDelete]
        [Route("deletequest/{id?}")]
        public async Task<ActionResult> DeleteQuest(int? id)
        {
            if (id != null){
            var quest = await _context.Quest.FindAsync(id);
            if (quest != null)
            {
                _context.Entry(quest).State = EntityState.Deleted;
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return NotFound();
            }
             return BadRequest();
        }
    }
}
