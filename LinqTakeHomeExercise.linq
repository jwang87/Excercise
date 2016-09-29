<Query Kind="Statements">
  <Connection>
    <ID>062984a3-e07e-4fef-a66a-ff9bb3f0ec33</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var results = from x in Skills
			  where x.RequiresTicket == true
			  select new
			  {
			  	Discription = x.Description,
				Employees = (from y in EmployeeSkills
							 select new
				             {
							 	Name = y.Employee.FirstName + " " + y.Employee.LastName,
								Level = y.Level,
								YearsOfExperience = y.YearsOfExperience
							 }
							 )
			   };
results.Dump();
