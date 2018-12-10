using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            return View(await _context.Project.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       //76 // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,ProjectName,ProjectDesc")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,ProjectName,ProjectDesc")] Project project)
        {
            if (id != project.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectID == id);
        }
    }
}



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using FinalProject.Models;

// namespace FinalProject.Controllers
// {
//     public class ProjectsController : Controller
//     {
//         private readonly AppDbContext _context;

//         public ProjectsController(AppDbContext context)
//         {
//             _context = context;
//         }

//         // GET: Projects
//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.Project.ToListAsync());
//         }

//         // GET: Projects/Details/5
//         public async Task<IActionResult> Details(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var project = await _context.Project
//                 .SingleOrDefaultAsync(m => m.ID == id);

//             if (project == null)
//             {
//                 return NotFound();
//             }

//             var clients = 
//                 from Person in _context.Client
//                 join projectPerson in _context.ProjectList
//                 on Person.ID equals project.ProjectpersonID
//                 where project.ID == projectPerson.ProjectID
//                 select Person;

//             var members = 
//                 from Person in _context.Member
//                 join projectPerson in _context.ProjectList
//                 on Person.ID equals projectPerson.ProjectID
//                 where project.ID == projectPerson.ProjectID                
//                 select Person;

//             ProjectDetailViewModel pdvm = new ProjectDetailViewModel
//             {
//                 Project = project,
//                 Clients = clients.ToList() ?? null,
//                 Members = members.ToList() ?? null
//             };


//             return View(pdvm);
//         }

//         // GET: Projects/Create
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // POST: Projects/Create
//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("ID,ProjectName,ProjectDescription")] Project project)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(project);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(project);
//         }

//         // GET: Projects/Edit/5
//         public async Task<IActionResult> Edit(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == id);
//             if (project == null)
//             {
//                 return NotFound();
//             }
//             return View(project);
//         }

//         // POST: Projects/Edit/5
//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(string id, [Bind("ID,ProjectName,ProjectDescription")] Project project)
//         {
//             if (id != project.ID)
//             {
//                 return NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(project);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!ProjectExists(project.ID))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(project);
//         }

//         // GET: Projects/EditProjectParticipants/5
//         public async Task<IActionResult> EditProjectParticipants(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == id);
//             if (project == null)
//             {
//                 return NotFound();
//             }


//             //var clients = await _context.Clients.ToListAsync();

//             //CLIENTS
//             //pull 'em into lists first
//             var clients = await _context.Client.ToListAsync();
//             var projectroster = await _context.ProjectList.ToListAsync();

//             /*
//             var uniqueclients = 
//                 from participant in clients
//                 join projectparticipant in projectroster
//                 on participant.ID equals projectparticipant.ProjectParticipantID
//                 where participant.ID != projectparticipant.ProjectParticipantID
//                 select participant;
//             */                

//             List<SelectListItem> clientsSelectList = new List<SelectListItem>();

//             foreach(var client in clients)
//             {
//                 clientsSelectList.Add(new SelectListItem { Value=clients.ID, Text = client.FirstName + " " + client.LastName});
//             }

//             //MEMBERS
//             //pull 'em into lists first
//             var members = await _context.Member.ToListAsync();

//             /*
//             var uniquemembers = 
//                 from participant in members
//                 join projectparticipant in projectroster
//                 on participant.ID equals projectparticipant.ProjectParticipantID
//                 where participant.ID != projectparticipant.ProjectParticipantID
//                 select participant;    
//             */                

//             List<SelectListItem> membersSelectList = new List<SelectListItem>();

//             foreach(var member in members)
//             {
//                 membersSelectList.Add(new SelectListItem { Value=members.ID, Text = member.FirstName + " " + member.LastName});
//             }

//             //create and prepare ViewModel
//             ProjectDetailViewModel epdvm = new ProjectDetailViewModel
//             {
//                 Project = project,
//                 Clients = clientsSelectList,
//                 ProjectMembersList = membersSelectList
//             };
            

//             return View(epdvm);
//         }

//         //POST: Projects/AddProjectClientParticpant/x
//         [HttpPost]
//         public async Task<IActionResult> AddProjectClientParticipant(ProjectDetailViewModel model)
//         {

//             if(ModelState.IsValid)
//             {

//                 //ViewData["theid"] = model.ProjectID;

//                 try{
//                     var ProjectId = model.ProjectID;
//                     var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == ProjectId);
//                     var ClientId = model.SelectID;
//                     var client = await _context.Client.SingleOrDefaultAsync(m => m.ID == ClientId);

//                     ProjectList participant = new ProjectList { ProjectID = ProjectId, 
//                                                                     Project = project, 
//                                                                     ProjectID = ClientId,
//                                                                     ProjectPerson = client };

//                     _context.ProjectList.Add(participant);
//                     _context.SaveChanges();                            
//                 }
//                 catch(Exception exp)
//                 {
//                     throw(exp);
//                 }

//                 return RedirectToAction(nameof(Details), new { id = model.ProjectID });

//             }

//              return View();
//         }

//         //AddProjectMemberParticipant
//         //POST: Projects/AddProjectMemberParticipant/
//         [HttpPost]        
//         public async Task<IActionResult> AddProjectMemberParticipant(ProjectDetailViewModel model)
//         {

//             if(ModelState.IsValid)
//             {
//                 try{
//                     var ProjectId = model.ProjectID;
//                     var project = await _context.Project.SingleOrDefaultAsync(m => m.ID == ProjectId);
//                     var MemberId = model.SelectedID;
//                     var member = await _context.Member.SingleOrDefaultAsync(m => m.ID == MemberId);

//                     ProjectList participant = new ProjectList { ProjectID = ProjectId, 
//                                                                    Project = project, 
//                                                                    ProjectParticipantID = MemberId,
//                                                                    ProjectPerson = member };

//                     _context.ProjectList.Add(participant);
//                     _context.SaveChanges();                            
//                 }
//                 catch(Exception exp)
//                 {
//                     throw(exp);
//                 }

//                 return RedirectToAction(nameof(Details), new { id = model.ProjectID });

//             }

//              return View();
//         }

//         public async Task<IActionResult> DeleteProjectParticipant(string pid, string id)
//         {
//             //DeleteProjectParticipant
//            //var project = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);
//            var projectparticipant = await _context.ProjectList.SingleOrDefaultAsync(m => m.ProjectID == pid && m.ProjectPersonID == id );
//             _context.ProjectList.Remove(projectparticipant);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Details), new { id = pid });

//         }

//         // GET: Projects/Delete/5
//         public async Task<IActionResult> Delete(string id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var project = await _context.Project
//                 .SingleOrDefaultAsync(m => m.ID == id);
//             if (project == null)
//             {
//                 return NotFound();
//             }

//             return View(project);
//         }

//         // POST: Projects/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(string id)
//         {
//             var project = await _context.Projects.SingleOrDefaultAsync(m => m.ID == id);
//             _context.Projects.Remove(project);

//             //also cascade the delete to the ProjectRoster entries associated with this project
//             var roster = _context.ProjectRoster.Where(m => m.ProjectID == id);
//             List<ProjectList> rosterlist = roster.ToList<ProjectList>();
//             foreach(var person in rosterlist)
//             {
//                 _context.ProjectRoster.Remove(person);
//             }
            
//             await _context.SaveChangesAsync();
            
//             return RedirectToAction(nameof(Index));
//         }

//         private bool ProjectExists(string id)
//         {
//             return _context.Project.Any(e => e.ID == id);
//         }
//     }
// }