<Query Kind="Statements">
  <Connection>
    <ID>062984a3-e07e-4fef-a66a-ff9bb3f0ec33</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//Question 1
var results = from x in Skills
			  where x.RequiresTicket == true
			  select new
			  {
			  	Discription = x.Description,
				Employees = (from y in EmployeeSkills
							 where y.Skill.SkillID == x.SkillID
							 orderby y.YearsOfExperience descending
							 select new{
				             
							 	Name = y.Employee.FirstName + " " + y.Employee.LastName,
								Level = y.Level,
								YearsOfExperience = y.YearsOfExperience
							           }
							 )
			   };
results.Dump();

//Question 2
var results = from x in Skills
			  orderby x.Description ascending
			  select new{
			  			 	Description = x.Description
			            };
results.Dump();

//Question 3.
var results = (from x in Skills
			  where x.EmployeeSkills.Count() == 0
			  select new{
			  				Description = x.Description
						});
results.Dump();

//Question 4.
var results = from x in Shifts
			  where x.PlacementContract.Location.Name.Contains("NAIT")
			  group x by x.DayOfWeek into y
			  orderby y.Key
			  select new{
			  				Day = Enum.GetName(typeof(DayOfWeek), y.Key),
							EmployeeNeeded = y.Sum(g => g.NumberOfEmployees)
					    };
results.Dump();

var results = from x in Shifts
			  where x.PlacementContract.Location.Name.Contains("NAIT")
			  group x by x.DayOfWeek into y
			  orderby y.Key
			  select y;
results.Dump();


//Question 5
var maxYears = EmployeeSkills.Select(y => y.YearsOfExperience).Max();
var maxYear = EmployeeSkills.Max(a => a.YearsOfExperience);
var results = from x in EmployeeSkills
			where x.YearsOfExperience == EmployeeSkills.Max(a => a.YearsOfExperience)
			orderby x.Employee.LastName
			select new{
							Name = x.Employee.FirstName + " " + x.Employee.LastName
					   };
results.Dump();