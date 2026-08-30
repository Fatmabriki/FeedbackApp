
CREATE TABLE Regions (Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(MAX));
INSERT INTO Regions (Name) VALUES ('Muscat'), ('Dhofar');
CREATE TABLE Wilayas (Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(MAX), RegionId INT);
CREATE TABLE Areas (Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(MAX), WilayaId INT);
CREATE TABLE Villages (Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(MAX), AreaId INT);

INSERT INTO Wilayas (Name, RegionId) VALUES ('Muttrah', 1), ('Salalah', 2);
INSERT INTO Areas (Name, WilayaId) VALUES ('Al Hamriya', 1);
INSERT INTO Villages (Name, AreaId) VALUES ('Test Village', 1);