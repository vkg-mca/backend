To reverse Engineer entities from existing database
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=PointsDb;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -force
