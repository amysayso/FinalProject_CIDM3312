using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Models
{
    public class DataSeed
    {
        public static void Seed(IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetRequiredService<AppDbContext>();

            db.Database.EnsureCreated();

            if (!db.Project.Any())
            {
                //Create 10 members
                //Create 2 Clients
                //Create 2 Projects
                var projects = new List<Project>
                {
                    new Project
                    {
                        ProjectName = "The Cupcake Co.",
                        ProjectDesc = "Selling cupcakes, cake, and goodies"
                    },

                    new Project 
                    {
                        ProjectName = "Bill's Place",
                        ProjectDesc = "Selling coffee, tea, and hot chocolate"
                    }
                };
                db.Project.AddRange(projects);
                db.SaveChanges();

                //Add Clients
                var clients = new List<Client>
                {
                    new Client
                    {
                        FirstName = "Bill",
                        LastName = "Co",
                        Phone = "806-123-4567",
                        Email = " BillCo@email.com",
                        CompanyName = "Bill Co"
                    },
                    new Client
                    {
                        FirstName = "The Cupcake",
                        LastName = "Co",
                        Phone = "806-859-6789",
                        Email = " TheCupcakeCo@email.com",
                        CompanyName = "The Cupcake"
                    },

                };

                db.Client.AddRange(clients);
                db.SaveChanges();

                //Data- Members
                var members = new List<Member>
                {
                    new Member
                    {
                        FirstName = "Raven",
                        LastName = "Baxter",
                        Phone = "758-484-9593",
                        Email = "Raven@email.com",
                        Major = "CIS"
                        
                    },

                     new Member
                    {
                        FirstName = "Cory",
                        LastName = "Baxter",
                        Phone = "234-987-9838",
                        Email = "Cory@email.com",
                        Major = "CIS"
                    },

                     new Member
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        Phone = "765-444-8584",
                        Email = "John@email.com",
                        Major = "CIS"
                    },

                     new Member
                    {
                        FirstName = "William",
                        LastName = "Jones",
                        Phone = "567-993-2234",
                        Email = "William@email.com",
                        Major = "CIS"
                    },

                     new Member
                    {
                        FirstName = "Aaron",
                        LastName = "Doe",
                        Phone = "783-858-9942",
                        Email = "Aaron@email.com",
                        Major = "CIS"
                    },

                     new Member
                    {
                        FirstName = "Jacky",
                        LastName = "Smith",
                        Phone = "758-222-9993",
                        Email = "Jacky@email.com",
                        Major = "CIS"
                    },

                     new Member
                    {
                        FirstName = "Ann",
                        LastName = "Jones",
                        Phone = "774-838-8388",
                        Email = "Ann@email.com",
                        Major = "CIS"
                    },
                     new Member
                    {
                        FirstName = "Jeff",
                        LastName = "Salmon",
                        Phone = "454-774-9999",
                        Email = "Jeff@email.com",
                        Major = "CIS"
                    },
                     new Member
                    {
                        FirstName = "Bob",
                        LastName = "Burger",
                        Phone = "444-838-9292",
                        Email = "Bob@email.com",
                        Major = "CIS"
                    },
                     new Member
                    {
                        FirstName = "Pablo",
                        LastName = "West",
                        Phone = "832-039-3838",
                        Email = "Pablo@email.com",
                        Major = "CIS"
                    },
                };

                db.Member.AddRange(members);
                db.SaveChanges();

               if (db.ProjectList.Any())
               {
                   return;
               }

               var projectsFromDb = db.Project.ToList();
               var clientsFromDb = db.Client.ToList();
               var membersFromDb = db.Member.ToList();

               var projectLists = new List<ProjectList>
               {
                   //taking the project form above, the first client form above, and the first three students from above.
                   new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = clientsFromDb.ElementAt(0).ID,
                                     Person = clientsFromDb.ElementAt(0)
                                    },

                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(0).ID,
                                     Person = membersFromDb.ElementAt(0)
                                    },
                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(1).ID,
                                     Person = membersFromDb.ElementAt(1)
                                    },
                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(2).ID,
                                     Person = membersFromDb.ElementAt(2)
                                    
                                    },

                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = clientsFromDb.ElementAt(1).ID,
                                     Person = clientsFromDb.ElementAt(1)
                                    },

                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(3).ID,
                                     Person = membersFromDb.ElementAt(3)
                                    },
                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(4).ID,
                                     Person = membersFromDb.ElementAt(4)
                                    },
                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(5).ID,
                                     Person = membersFromDb.ElementAt(5)
                                    },
                    new ProjectList { ProjectID = projectsFromDb.ElementAt(1).ProjectID,
                                     Project = projectsFromDb.ElementAt(1),
                                     PersonID = membersFromDb.ElementAt(6).ID,
                                     Person = membersFromDb.ElementAt(6)
                                    }         
                   };

                   db.ProjectList.AddRange(projectLists);
                   db.SaveChanges();

               }


            }
        }
    }
